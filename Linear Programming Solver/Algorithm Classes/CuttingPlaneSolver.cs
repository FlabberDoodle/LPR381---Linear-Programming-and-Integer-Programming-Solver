using Linear_Programming_Solver.Core_Classes;
using Linear_Programming_Solver.Supporting_Classes;
using Google.OrTools.LinearSolver;
using GSolver = Google.OrTools.LinearSolver.Solver;
using GConstraint = Google.OrTools.LinearSolver.Constraint;
using GVariable = Google.OrTools.LinearSolver.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    public class CuttingPlaneSolver
    {
        private IPModel _model;
        private ResultsForm _resultsForm;
        private GSolver _solver;
        private List<GConstraint> _cutConstraints;

        public CuttingPlaneSolver(IPModel model, ResultsForm resultsForm)
        {
            _model = model;
            _resultsForm = resultsForm;
            _solver = GSolver.CreateSolver("GLOP"); // Google Linear Optimization Solver
            _cutConstraints = new List<GConstraint>();
        }

        public void SolveCuttingPlane()
        {
            GVariable[] variables = CreateVariables();
            AddObjectiveFunction(variables);
            AddConstraints(variables);

            int iteration = 0;
            while (true)
            {
                GSolver.ResultStatus resultStatus = _solver.Solve();

                if (resultStatus != GSolver.ResultStatus.OPTIMAL)
                {
                    _resultsForm.AppendToResults("The problem does not have an optimal solution.\n");
                    return;
                }

                double[] solution = GetSolution(variables);
                if (IsIntegerSolution(solution))
                {
                    double objectiveValue = _solver.Objective().Value();
                    _resultsForm.AppendToResults("Optimal integer solution found:\n");
                    _resultsForm.AppendToResults($"Solution: {string.Join(", ", solution.Select(v => v.ToString("F3")))}\n");
                    _resultsForm.AppendToResults($"Optimal Objective Value: {objectiveValue:F3}\n");
                    return;
                }

                // Add cutting plane constraints based on the current solution
                AddCuttingPlaneConstraints(solution, variables);

                _resultsForm.AppendToResults($"Iteration {++iteration} - Added new cutting planes.\n");
            }
        }

        private GVariable[] CreateVariables()
        {
            var variables = new GVariable[_model.Objective.Coefficients.Count];
            for (int i = 0; i < variables.Length; i++)
            {
                variables[i] = _solver.MakeNumVar(0.0, double.PositiveInfinity, $"x{i}");
            }
            return variables;
        }

        private void AddObjectiveFunction(GVariable[] variables)
        {
            var objective = _solver.Objective();
            for (int i = 0; i < variables.Length; i++)
            {
                objective.SetCoefficient(variables[i], _model.Objective.Coefficients[i]);
            }
            objective.SetMaximization();
        }

        private void AddConstraints(GVariable[] variables)
        {
            foreach (var constraint in _model.Constraints)
            {
                var gConstraint = _solver.MakeConstraint(constraint.RHS, constraint.RHS);
                for (int i = 0; i < constraint.Coefficients.Count; i++)
                {
                    gConstraint.SetCoefficient(variables[i], constraint.Coefficients[i]);
                }
                _cutConstraints.Add(gConstraint);
            }
        }

        private double[] GetSolution(GVariable[] variables)
        {
            var solution = new double[variables.Length];
            for (int i = 0; i < variables.Length; i++)
            {
                solution[i] = variables[i].SolutionValue();
            }
            return solution;
        }

        private bool IsIntegerSolution(double[] solution)
        {
            return solution.All(x => Math.Abs(x - Math.Round(x)) < 1e-5);
        }

        private void AddCuttingPlaneConstraints(double[] solution, GVariable[] variables)
        {
            for (int i = 0; i < solution.Length; i++)
            {
                if (Math.Abs(solution[i] - Math.Round(solution[i])) > 1e-5)
                {
                    double fractionalPart = solution[i] - Math.Floor(solution[i]);
                    var cut = _solver.MakeConstraint(0, 0);
                    cut.SetCoefficient(variables[i], fractionalPart);
                    _cutConstraints.Add(cut);
                }
            }
        }
    }
}