using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    public class RevisedPrimalSimplexSolver
    {
        private IPModel _model;
        private ResultsForm _resultsForm;
        private double[,] _tableau;
        private int[] _basicVariables;
        private int _numVariables;
        private int _numConstraints;
        private double[,] B_inv;

        public RevisedPrimalSimplexSolver(IPModel model, ResultsForm resultsForm)
        {
            _model = model;
            _resultsForm = resultsForm;
            _numVariables = model.Objective.Coefficients.Count;
            _numConstraints = model.Constraints.Count;
            _tableau = new double[_numConstraints + 1, _numVariables + _numConstraints + 1];
            _basicVariables = new int[_numConstraints];
            B_inv = new double[_numConstraints, _numConstraints];
        }

        public void SolveRevisedPrimalSimplex()
        {
            InitializeTableau();
            InitializeBasisInverse();

            _resultsForm.AppendToResults("\nRevised Primal Simplex\n\nCanonical Form:\n");
            PrintTableau();

            int maxIterations = 1000;
            int iteration = 0;

            while (iteration < maxIterations)
            {
                // Compute the reduced costs
                double[] cB = new double[_numConstraints];
                for (int i = 0; i < _numConstraints; i++)
                {
                    cB[i] = _model.Objective.Coefficients[_basicVariables[i]]; // Corrected to use the objective coefficients
                }
                var y = MatrixVectorMultiply(B_inv, cB);
                double[] reducedCosts = new double[_numVariables];
                for (int j = 0; j < _numVariables; j++)
                {
                    reducedCosts[j] = _model.Objective.Coefficients[j] - DotProduct(y, GetColumn(_tableau, j));
                }

                // Updated Condition: Check if the solution is optimal
                bool isOptimal = true;
                int entering = -1;
                for (int j = 0; j < _numVariables; j++)
                {
                    if (reducedCosts[j] < -1e-8)
                    {
                        isOptimal = false;
                        entering = j;
                        break;
                    }
                }

                if (isOptimal)
                {
                    break; // Optimal solution found
                }

                // Calculate the direction vector for the entering variable
                var direction = MatrixVectorMultiply(B_inv, GetColumn(_tableau, entering));

                // Determine the leaving variable based on the minimum ratio test
                int leaving = -1;
                double minRatio = double.MaxValue;
                for (int i = 0; i < _numConstraints; i++)
                {
                    if (direction[i] > 1e-10) // Avoid division by near-zero
                    {
                        double ratio = _tableau[i, _numVariables + _numConstraints] / direction[i];
                        if (ratio < minRatio)
                        {
                            minRatio = ratio;
                            leaving = i;
                        }
                    }
                }

                // Check if a valid leaving variable was found
                if (leaving == -1)
                {
                    _resultsForm.AppendToResults("The solution is unbounded.\n");
                    return;
                }

                // Perform the pivot, updating the basis inverse and basic variables
                B_inv = UpdateBasisInverse(B_inv, direction, leaving);
                _basicVariables[leaving] = entering;

                // Recompute the right-hand side (b) using the updated basis inverse
                var b = new double[_numConstraints];
                for (int i = 0; i < _numConstraints; i++)
                {
                    b[i] = _tableau[i, _numVariables + _numConstraints];
                }
                var xB = MatrixVectorMultiply(B_inv, b);
                for (int i = 0; i < _numConstraints; i++)
                {
                    _tableau[i, _numVariables + _numConstraints] = xB[i];
                }

                // Print the current iteration and tableau
                _resultsForm.AppendToResults($"Iteration {iteration + 1}:\n");
                PrintRevisedSolution();
                PrintTableau();

                iteration++;
            }

            if (iteration == maxIterations)
            {
                _resultsForm.AppendToResults("Maximum iterations reached. The problem may be cycling or unbounded.\n");
                return;
            }

            // Extract the solution and objective value
            double[] solution = new double[_numVariables];
            for (int i = 0; i < _numConstraints; i++)
            {
                if (_basicVariables[i] < _numVariables)
                {
                    solution[_basicVariables[i]] = _tableau[i, _numVariables + _numConstraints];
                }
            }

            double objectiveValue = _tableau[_numConstraints, _numVariables + _numConstraints];
            _resultsForm.AppendToResults("Optimal solution found:\n");
            _resultsForm.AppendToResults($"Solution: {string.Join(", ", solution.Select(x => x.ToString("F3")))}\n");
            _resultsForm.AppendToResults($"Optimal Objective Value: {objectiveValue:F3}\n");
        }

        private void InitializeTableau()
        {
            // Objective function coefficients (last row)
            for (int j = 0; j < _numVariables; j++)
            {
                _tableau[_numConstraints, j] = -_model.Objective.Coefficients[j];
            }

            // Constraints coefficients and RHS
            for (int i = 0; i < _numConstraints; i++)
            {
                for (int j = 0; j < _numVariables; j++)
                {
                    _tableau[i, j] = _model.Constraints[i].Coefficients[j];
                }

                _tableau[i, _numVariables + i] = 1; // Slack variable
                _tableau[i, _numVariables + _numConstraints] = _model.Constraints[i].RHS;
            }
        }

        private void InitializeBasisInverse()
        {
            for (int i = 0; i < _numConstraints; i++)
            {
                B_inv[i, i] = 1.0; // Identity matrix
            }
        }

        private void PrintRevisedSolution()
        {
            _resultsForm.AppendToResults("Current basis inverse:\n");
            for (int i = 0; i < B_inv.GetLength(0); i++)
            {
                for (int j = 0; j < B_inv.GetLength(1); j++)
                {
                    _resultsForm.AppendToResults(B_inv[i, j].ToString("F3") + "\t");
                }
                _resultsForm.AppendToResults("\n");
            }
            _resultsForm.AppendToResults("\n");
        }

        private double[,] UpdateBasisInverse(double[,] B_inv, double[] direction, int leaving)
        {
            int n = B_inv.GetLength(0);
            double[,] newB_inv = new double[n, n];
            double alpha = 1.0 / direction[leaving];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == leaving)
                    {
                        newB_inv[i, j] = alpha * B_inv[i, j];
                    }
                    else
                    {
                        newB_inv[i, j] = B_inv[i, j] - alpha * B_inv[i, leaving] * B_inv[leaving, j];
                    }
                }
            }

            return newB_inv;
        }

        private double[] MatrixVectorMultiply(double[,] matrix, double[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[] result = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                result[i] = 0;
                for (int j = 0; j < cols; j++)
                {
                    result[i] += matrix[i, j] * vector[j];
                }
            }

            return result;
        }

        private double DotProduct(double[] vec1, double[] vec2)
        {
            return vec1.Zip(vec2, (x, y) => x * y).Sum();
        }

        private double[] GetColumn(double[,] matrix, int colIndex)
        {
            int rows = matrix.GetLength(0);
            double[] column = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                column[i] = matrix[i, colIndex];
            }
            return column;
        }

        private void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    _resultsForm.AppendToResults(matrix[i, j].ToString("F3") + "\t");
                }
                _resultsForm.AppendToResults("\n");
            }
            _resultsForm.AppendToResults("\n");
        }


        private void PrintTableau()
        {
            _resultsForm.AppendToResults("Tableau:\n");
            for (int i = 0; i < _tableau.GetLength(0); i++)
            {
                for (int j = 0; j < _tableau.GetLength(1); j++)
                {
                    _resultsForm.AppendToResults(_tableau[i, j].ToString("F3") + "\t");
                }
                _resultsForm.AppendToResults("\n");
            }
            _resultsForm.AppendToResults("\n");
        }
    }
}
