using Google.OrTools.LinearSolver;
using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    internal class PrimalSimplexSolverORTools
    {
        private IPModel _model;
        private ResultsForm _resultsForm;

        public PrimalSimplexSolverORTools(IPModel model, ResultsForm resultsForm)
        {
            _model = model;
            _resultsForm = resultsForm;
        }

        public void SolvePrimalSimplex()
        {
            // Create the solver using Google's OR-Tools
            Solver solver = Solver.CreateSolver("GLOP");

            if (solver == null)
            {
                _resultsForm.AppendToResults("Solver not created.\n");
                return;
            }

            // Variables
            Variable[] variables = new Variable[_model.Objective.Coefficients.Count];
            for (int i = 0; i < variables.Length; i++)
            {
                variables[i] = solver.MakeNumVar(0.0, double.PositiveInfinity, $"x{i + 1}");
            }

            // Objective Function
            Objective objective = solver.Objective();
            for (int i = 0; i < variables.Length; i++)
            {
                objective.SetCoefficient(variables[i], _model.Objective.Coefficients[i]);
            }
            objective.SetMaximization();

            // Constraints
            foreach (var constraintModel in _model.Constraints)
            {
                // Fully qualify the Constraint type to avoid conflicts
                Google.OrTools.LinearSolver.Constraint constraint = solver.MakeConstraint(-double.PositiveInfinity, constraintModel.RHS);

                // Add coefficients directly
                for (int j = 0; j < variables.Length; j++)
                {
                    constraint.SetCoefficient(variables[j], constraintModel.Coefficients[j]);
                }
            }

            // Solve the problem
            Solver.ResultStatus resultStatus = solver.Solve();

            // Display results
            if (resultStatus == Solver.ResultStatus.OPTIMAL)
            {
                _resultsForm.AppendToResults("Optimal solution found:\n");
                _resultsForm.AppendToResults($"Solution: {string.Join(", ", variables.Select(v => v.SolutionValue().ToString("F3")))}\n");
                _resultsForm.AppendToResults($"Optimal Objective Value: {solver.Objective().Value().ToString("F3")}\n");
            }
            else
            {
                _resultsForm.AppendToResults("No optimal solution found.\n");
            }
        }
    }
}
