using Linear_Programming_Solver.Core_Classes;
using Linear_Programming_Solver.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Algorithm_Classes
{
    public class BranchAndBoundKnapsackSolver
    {
        private ResultsForm _resultsForm;
        private IPModel _model;
        private int _capacity;
        private double _bestValue;
        private List<double> _bestSolution;

        public BranchAndBoundKnapsackSolver(ResultsForm resultsForm, IPModel model, int capacity)
        {
            _resultsForm = resultsForm;
            _model = model;
            _capacity = capacity;
            _bestValue = 0;
            _bestSolution = new List<double>();
        }

        public void Solve()
        {
            List<double> currentSolution = new List<double>(new double[_model.Objective.Coefficients.Count]);
            SolveRecursive(0, 0, 0, currentSolution);
        }

        private void SolveRecursive(int index, double currentValue, double currentWeight, List<double> currentSolution)
        {
            if (index >= _model.Objective.Coefficients.Count)
            {
                if (currentValue > _bestValue)
                {
                    _bestValue = currentValue;
                    _bestSolution = new List<double>(currentSolution);
                }
                return;
            }

            // Exclude the current item
            SolveRecursive(index + 1, currentValue, currentWeight, currentSolution);

            // Include the current item
            double itemWeight = _model.Constraints[0].Coefficients[index];
            double itemValue = _model.Objective.Coefficients[index];

            if (currentWeight + itemWeight <= _capacity)
            {
                currentSolution[index] = 1; // Include the item
                SolveRecursive(index + 1, currentValue + itemValue, currentWeight + itemWeight, currentSolution);
                currentSolution[index] = 0; // Backtrack
            }
        }
    }
}
