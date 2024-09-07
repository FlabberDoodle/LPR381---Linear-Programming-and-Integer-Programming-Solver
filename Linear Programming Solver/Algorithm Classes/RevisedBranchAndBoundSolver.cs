using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    public class RevisedBranchAndBoundSolver
    {
        private IPModel _model;
        private ResultsForm _resultsForm;
        private List<Node> _nodes;
        private double _bestObjectiveValue;
        private double[] _bestSolution;

        public RevisedBranchAndBoundSolver(IPModel model, ResultsForm resultsForm)
        {
            _model = model;
            _resultsForm = resultsForm;
            _nodes = new List<Node>();
            _bestObjectiveValue = double.NegativeInfinity;
            _bestSolution = null;
        }

        public void SolveRevisedBranchAndBound()
        {
            Node rootNode = CreateRootNode();
            _nodes.Add(rootNode);

            while (_nodes.Count > 0)
            {
                Node currentNode = _nodes.Last();
                _nodes.RemoveAt(_nodes.Count - 1);

                SolveNode(currentNode);

                if (IsFeasible(currentNode))
                {
                    if (IsIntegerSolution(currentNode.Solution))
                    {
                        UpdateBestSolution(currentNode);
                    }
                    else
                    {
                        CreateBranches(currentNode);
                    }
                }
            }

            if (_bestSolution != null)
            {
                _resultsForm.AppendToResults("Optimal integer solution found:\n");
                _resultsForm.AppendToResults($"Solution: {string.Join(", ", _bestSolution.Select(v => v.ToString("F3")))}\n");
                _resultsForm.AppendToResults($"Optimal Objective Value: {_bestObjectiveValue:F3}\n");
            }
            else
            {
                _resultsForm.AppendToResults("No feasible integer solution found.\n");
            }
        }

        private Node CreateRootNode()
        {
            // Create a root node with no bounds and solve it
            return new Node { LowerBounds = new double[_model.Objective.Coefficients.Count], UpperBounds = new double[_model.Objective.Coefficients.Count] };
        }

        private void SolveNode(Node node)
        {
            node.Solution = new double[_model.Objective.Coefficients.Count];
            node.ObjectiveValue = 0; // Update with actual objective value after solving
        }

        private bool IsFeasible(Node node)
        {
            return true;
        }

        private bool IsIntegerSolution(double[] solution)
        {
            return solution.All(x => Math.Abs(x - Math.Round(x)) < 1e-5);
        }

        private void CreateBranches(Node parentNode)
        {
            // Branch on the first non-integer variable
            int branchingVariable = Array.FindIndex(parentNode.Solution, x => Math.Abs(x - Math.Round(x)) > 1e-5);

            if (branchingVariable >= 0)
            {
                double fractionalValue = parentNode.Solution[branchingVariable];

                Node leftChild = new Node
                {
                    LowerBounds = (double[])parentNode.LowerBounds.Clone(),
                    UpperBounds = (double[])parentNode.UpperBounds.Clone(),
                };
                leftChild.UpperBounds[branchingVariable] = Math.Floor(fractionalValue);

                Node rightChild = new Node
                {
                    LowerBounds = (double[])parentNode.LowerBounds.Clone(),
                    UpperBounds = (double[])parentNode.UpperBounds.Clone(),
                };
                rightChild.LowerBounds[branchingVariable] = Math.Ceiling(fractionalValue);

                _nodes.Add(leftChild);
                _nodes.Add(rightChild);
            }
        }

        private void UpdateBestSolution(Node node)
        {
            if (node.ObjectiveValue > _bestObjectiveValue)
            {
                _bestObjectiveValue = node.ObjectiveValue;
                _bestSolution = (double[])node.Solution.Clone();
            }
        }

        private class Node
        {
            public double[] Solution { get; set; }
            public double ObjectiveValue { get; set; }
            public double[] LowerBounds { get; set; }
            public double[] UpperBounds { get; set; }
        }
    }
}