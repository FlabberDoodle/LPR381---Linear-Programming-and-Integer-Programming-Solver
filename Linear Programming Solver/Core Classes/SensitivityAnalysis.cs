using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear_Programming_Solver.Supporting_Classes
{
    public class SensitivityAnalysis
    {
        public void DisplayRangeNonBasicVariable(string variableName)
        {
            // Logic to display the range of a selected non-basic variable
        }

        public void ApplyChangeNonBasicVariable(string variableName, double newValue)
        {
            // Logic to apply and display a change of a selected non-basic variable
        }

        public void DisplayRangeBasicVariable(string variableName)
        {
            // Logic to display the range of a selected basic variable
        }

        public void ApplyChangeBasicVariable(string variableName, double newValue)
        {
            // Logic to apply and display a change of a selected basic variable
        }

        public void DisplayRangeConstraint(string constraintName)
        {
            // Logic to display the range of a selected constraint right-hand side value
        }

        public void ApplyChangeConstraint(string constraintName, double newValue)
        {
            // Logic to apply and display a change of a selected constraint right-hand side value
        }

        public void DisplayRangeVariableColumn(string variableName)
        {
            // Logic to display the range of a selected variable in a non-basic variable column
        }

        public void ApplyChangeVariableColumn(string variableName, double newValue)
        {
            // Logic to apply and display a change of a selected variable in a non-basic variable column
        }

        public void AddNewActivity(string activity)
        {
            // Logic to add a new activity to the optimal solution
        }

        public void AddNewConstraint(string constraint)
        {
            // Logic to add a new constraint to the optimal solution
        }

        public void DisplayShadowPrices()
        {
            // Logic to display shadow prices
        }

        public void ApplyDuality()
        {
            // Logic to apply duality to the programming model
        }
    }
}
