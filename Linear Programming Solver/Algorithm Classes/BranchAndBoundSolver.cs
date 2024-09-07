using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    public class BranchAndBoundSolver
    {
        private IPModel _model;
        private ResultsForm _resultsForm;
        private double _bestObjectiveValue;
        private double[] _bestSolution;
        private List<Node> _nodes;

        public BranchAndBoundSolver(IPModel model, ResultsForm resultsForm)
        {
            _model = model;
            _resultsForm = resultsForm;
            _bestObjectiveValue = double.MinValue; // Assuming maximization
            _bestSolution = new double[model.Objective.Coefficients.Count];
            _nodes = new List<Node>();
        }

        public void SolveBranchAndBound()
        {
            // Initial LP relaxation
            var rootNode = new Node { Solution = SolveLPRelaxation(), IsInteger = CheckIfInteger(SolveLPRelaxation()) };
            _nodes.Add(rootNode);

            while (_nodes.Count > 0)
            {
                var currentNode = _nodes[0];
                _nodes.RemoveAt(0);

                if (currentNode.IsInteger)
                {
                    if (currentNode.ObjectiveValue > _bestObjectiveValue)
                    {
                        _bestObjectiveValue = currentNode.ObjectiveValue;
                        _bestSolution = currentNode.Solution;
                    }
                }
                else
                {
                    var branchingVariableIndex = SelectBranchingVariable(currentNode.Solution);
                    var leftChild = CreateChildNode(currentNode, branchingVariableIndex, Math.Floor(currentNode.Solution[branchingVariableIndex]));
                    var rightChild = CreateChildNode(currentNode, branchingVariableIndex, Math.Ceiling(currentNode.Solution[branchingVariableIndex]));

                    _nodes.Add(leftChild);
                    _nodes.Add(rightChild);
                }
            }

            _resultsForm.AppendToResults("Optimal solution found:\n");
            _resultsForm.AppendToResults($"Solution: {string.Join(", ", _bestSolution.Select(v => v.ToString("F3")))}\n");
            _resultsForm.AppendToResults($"Optimal Objective Value: {_bestObjectiveValue:F3}\n");
        }

        private Node CreateChildNode(Node parent, int variableIndex, double value)
        {
            var childNode = new Node
            {
                Solution = SolveLPRelaxation(parent, variableIndex, value),
                IsInteger = CheckIfInteger(SolveLPRelaxation(parent, variableIndex, value)),
                ObjectiveValue = CalculateObjectiveValue(SolveLPRelaxation(parent, variableIndex, value))
            };

            return childNode;
        }

        private double[] SolveLPRelaxation(Node parent = null, int variableIndex = -1, double value = 0)
        {
            double[] solution = new double[_model.Objective.Coefficients.Count];
            // Implement the LP solving logic here.
            return solution;
        }

        private bool CheckIfInteger(double[] solution)
        {
            return solution.All(x => Math.Abs(x - Math.Round(x)) < 1e-5);
        }

        private double CalculateObjectiveValue(double[] solution)
        {
            double objectiveValue = 0;
            for (int i = 0; i < _model.Objective.Coefficients.Count; i++)
            {
                objectiveValue += _model.Objective.Coefficients[i] * solution[i];
            }
            return objectiveValue;
        }

        private int SelectBranchingVariable(double[] solution)
        {
            for (int i = 0; i < solution.Length; i++)
            {
                if (Math.Abs(solution[i] - Math.Round(solution[i])) >= 1e-5)
                {
                    return i;
                }
            }
            return -1; // Ideally, this case should never occur if the solution is not integer
        }

        private class Node
        {
            public double[] Solution { get; set; }
            public bool IsInteger { get; set; }
            public double ObjectiveValue { get; set; }
        }
    }
}