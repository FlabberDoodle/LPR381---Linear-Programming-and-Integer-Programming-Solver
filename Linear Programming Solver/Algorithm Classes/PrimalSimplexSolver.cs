using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    public class PrimalSimplexSolver
    {
        private IPModel _model;
        private ResultsForm _resultsForm;
        private double[,] _tableau;
        private int[] _basicVariables;
        private int _numVariables;
        private int _numConstraints;

        public PrimalSimplexSolver(IPModel model, ResultsForm resultsForm)
        {
            _model = model;
            _resultsForm = resultsForm;
            _numVariables = model.Objective.Coefficients.Count;
            _numConstraints = model.Constraints.Count;
            _tableau = new double[_numConstraints + 1, _numVariables + _numConstraints + 1];
            _basicVariables = new int[_numConstraints];
        }

        public void SolvePrimalSimplex()
        {
            InitializeTableau();
            _resultsForm.AppendToResults("Canonical Form:\n");
            PrintTableau(0);  // Print initial tableau with iteration 0

            int iteration = 1;
            int maxIterations = 1000;

            while (iteration <= maxIterations)
            {
                int entering = -1;
                double minValue = 0;

                // Find entering variable (most negative coefficient in the last row)
                for (int j = 0; j < _numVariables + _numConstraints; j++)
                {
                    if (_tableau[_numConstraints, j] < minValue)
                    {
                        minValue = _tableau[_numConstraints, j];
                        entering = j;
                    }
                }

                if (entering == -1)
                    break; // Optimal solution found

                // Find leaving variable
                int leaving = FindLeavingVariable(entering);

                if (leaving == -1)
                {
                    _resultsForm.AppendToResults("The solution is unbounded.\n");
                    return;
                }

                PerformPivot(entering, leaving);
                PrintTableau(iteration);
                iteration++;
            }

            if (iteration > maxIterations)
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
            _resultsForm.AppendToResults($"Solution: {string.Join(", ", solution.Select(v => v.ToString("F3")))}\n");
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

                // Slack or surplus variables
                _tableau[i, _numVariables + i] = 1; // Slack variable
                _tableau[i, _numVariables + _numConstraints] = _model.Constraints[i].RHS;
            }
        }

        private void PerformPivot(int entering, int leaving)
        {
            int columns = _tableau.GetLength(1); // Number of columns in the tableau

            // Normalize the pivot row (leaving row)
            double pivotValue = _tableau[leaving, entering];
            for (int j = 0; j < columns; j++)
            {
                _tableau[leaving, j] /= pivotValue;
            }

            // Update other rows
            for (int i = 0; i < _tableau.GetLength(0); i++)
            {
                if (i != leaving)
                {
                    double multiplier = _tableau[i, entering];
                    for (int j = 0; j < columns; j++)
                    {
                        _tableau[i, j] -= multiplier * _tableau[leaving, j];
                    }
                }
            }

            _basicVariables[leaving] = entering;
        }

        private int FindLeavingVariable(int entering)
        {
            int leaving = -1;
            double minRatio = double.MaxValue;

            for (int i = 0; i < _numConstraints; i++)
            {
                // Check if the denominator is greater than 0 to avoid division by zero
                if (_tableau[i, entering] > 0)
                {
                    double ratio = _tableau[i, _numVariables + _numConstraints] / _tableau[i, entering];

                    // Update the leaving variable if the ratio is smaller
                    if (ratio < minRatio)
                    {
                        minRatio = ratio;
                        leaving = i;
                    }
                }
            }

            return leaving;
        }

        private void PrintTableau(int iteration)
        {
            _resultsForm.AppendToResults($"Tableau {iteration}:\n");
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