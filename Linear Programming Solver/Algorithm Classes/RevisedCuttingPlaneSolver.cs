using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    public class RevisedCuttingPlaneSolver
    {
        private IPModel _model;
        private ResultsForm _resultsForm;
        private double[] _solution;
        private double _objectiveValue;
        private List<double[]> _cuts;

        public RevisedCuttingPlaneSolver(IPModel model, ResultsForm resultsForm)
        {
            _model = model;
            _resultsForm = resultsForm;
            _cuts = new List<double[]>();
        }

        public void SolveRevisedCuttingPlane()
        {
            Initialize();

            while (true)
            {
                SolveRelaxedProblem();

                if (IsIntegerSolution(_solution))
                {
                    _resultsForm.AppendToResults("Optimal integer solution found:\n");
                    _resultsForm.AppendToResults($"Solution: {string.Join(", ", _solution.Select(v => v.ToString("F3")))}\n");
                    _resultsForm.AppendToResults($"Optimal Objective Value: {_objectiveValue:F3}\n");
                    break;
                }

                double[] violatedCut = FindViolatedCut();
                if (violatedCut == null)
                {
                    _resultsForm.AppendToResults("No more violated cuts found. Current solution is the best found:\n");
                    _resultsForm.AppendToResults($"Solution: {string.Join(", ", _solution.Select(v => v.ToString("F3")))}\n");
                    _resultsForm.AppendToResults($"Objective Value: {_objectiveValue:F3}\n");
                    break;
                }

                _cuts.Add(violatedCut);
                AddCutToModel(violatedCut);
            }
        }

        private void Initialize()
        {
            _solution = new double[_model.Objective.Coefficients.Count];
            _objectiveValue = double.NegativeInfinity;
            _cuts.Clear();
        }

        private void SolveRelaxedProblem()
        {
            _solution = new double[_model.Objective.Coefficients.Count];
            _objectiveValue = 0; // Update with actual objective value after solving
        }

        private bool IsIntegerSolution(double[] solution)
        {
            return solution.All(x => Math.Abs(x - Math.Round(x)) < 1e-5);
        }

        private double[] FindViolatedCut()
        {
            foreach (var constraint in _model.Constraints)
            {
                double lhsValue = 0;
                for (int i = 0; i < _solution.Length; i++)
                {
                    lhsValue += constraint.Coefficients[i] * _solution[i];
                }

                if (lhsValue > constraint.RHS)
                {
                    // Create and return the violated cut
                    double[] cut = new double[_solution.Length + 1];
                    Array.Copy(constraint.Coefficients.ToArray(), cut, _solution.Length); // Fixed conversion issue
                    cut[_solution.Length] = constraint.RHS;
                    return cut;
                }
            }

            return null;
        }

        private void AddCutToModel(double[] cut)
        {
            // Add the cut to the model as a new constraint
            var newConstraint = new ConstraintValue
            {
                Coefficients = cut.Take(cut.Length - 1).ToArray(),
                RHS = cut.Last(),
                Relation = RelationType.LessThanOrEqual // Assuming all cuts are <= type
            };
        }
    }

    public enum RelationType
    {
        LessThanOrEqual,
        Equal,
        GreaterThanOrEqual
    }

    public class ConstraintValue
    {
        public double[] Coefficients { get; set; }
        public double RHS { get; set; }
        public RelationType Relation { get; set; }
    }
}