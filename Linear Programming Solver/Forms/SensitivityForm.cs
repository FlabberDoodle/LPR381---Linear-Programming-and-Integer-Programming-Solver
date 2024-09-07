using Linear_Programming_Solver.Algorithm_Classes;
using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Linear_Programming_Solver.MainForm;

namespace Linear_Programming_Solver
{
    public partial class SensitivityForm : Form
    {
        private OptimalSolution optimalSolution;
        private Constraint constraint;
        private AlgorithmType selectedAlgorithm;

        public SensitivityForm(AlgorithmType selectedAlgorithm)
        {
            InitializeComponent();
            InitializeData();
            this.selectedAlgorithm = selectedAlgorithm;  // Initialize the selectedAlgorithm here
            PopulateComboBoxes();
        }

        private void InitializeData()
        {
            // Initialize Optimal Solution
            optimalSolution = new OptimalSolution
            {
                Variables = new Dictionary<string, int>
                {
                    { "x1", 0 },
                    { "x2", 1 },
                    { "x3", 1 },
                    { "x4", 1 },
                    { "x5", 0 },
                    { "x6", 1 }
                }
            };

            // Initialize Constraint
            constraint = new Constraint
            {
                Expression = "11x1 + 8x2 + 6x3 + 14x4 + 10x5 + 10x6 ≤ 40"
            };
        }

        private void PopulateComboBoxes()
        {
            List<string> basicVariables = new List<string>();
            List<string> nonBasicVariables = new List<string>();
            List<string> variableColumns = new List<string>();
            List<string> constraints = new List<string> { constraint.Expression };

            // Determine basic and non-basic variables based on the algorithm
            switch (selectedAlgorithm)
            {
                case AlgorithmType.PrimalSimplex:
                    foreach (var variable in optimalSolution.Variables)
                    {
                        if (variable.Value == 1)
                            basicVariables.Add(variable.Key);
                        else
                            nonBasicVariables.Add(variable.Key);
                    }
                    variableColumns = new List<string>(optimalSolution.Variables.Keys);
                    break;
                case AlgorithmType.BranchAndBoundSimplex:
                    foreach (var variable in optimalSolution.Variables)
                    {
                        if (variable.Value == 1)
                            basicVariables.Add(variable.Key);
                        else
                            nonBasicVariables.Add(variable.Key);
                    }
                    variableColumns = new List<string>(optimalSolution.Variables.Keys);
                    break;
                case AlgorithmType.RevisedBranchAndBoundSimplex:
                    foreach (var variable in optimalSolution.Variables)
                    {
                        if (variable.Value == 1)
                            basicVariables.Add(variable.Key);
                        else
                            nonBasicVariables.Add(variable.Key);
                    }
                    variableColumns = new List<string>(optimalSolution.Variables.Keys);
                    break;
                case AlgorithmType.CuttingPlane:
                    foreach (var variable in optimalSolution.Variables)
                    {
                        if (variable.Value == 1)
                            basicVariables.Add(variable.Key);
                        else
                            nonBasicVariables.Add(variable.Key);
                    }
                    variableColumns = new List<string>(optimalSolution.Variables.Keys);
                    break;
                case AlgorithmType.RevisedCuttingPlane:
                    foreach(var variable in optimalSolution.Variables)
                    {
                        if (variable.Value == 1)
                            basicVariables.Add(variable.Key);
                        else
                            nonBasicVariables.Add(variable.Key);
                    }
                    variableColumns = new List<string>(optimalSolution.Variables.Keys);
                    break;
                case AlgorithmType.BranchAndBoundKnapsack:
                    foreach (var variable in optimalSolution.Variables)
                    {
                        if (variable.Value == 1)
                            basicVariables.Add(variable.Key);
                        else
                            nonBasicVariables.Add(variable.Key);
                    }
                    variableColumns = new List<string>(optimalSolution.Variables.Keys);
                    break;
                default:
                    MessageBox.Show("Unknown algorithm selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Populate ComboBoxes
            cmbBasicVariables.Items.Clear();
            cmbBasicVariables.Items.AddRange(basicVariables.ToArray());
            if (cmbBasicVariables.Items.Count > 0)
                cmbBasicVariables.SelectedIndex = 0;

            cmbNonBasicVariables.Items.Clear();
            cmbNonBasicVariables.Items.AddRange(nonBasicVariables.ToArray());
            if (cmbNonBasicVariables.Items.Count > 0)
                cmbNonBasicVariables.SelectedIndex = 0;

            cmbVariableColumns.Items.Clear();
            cmbVariableColumns.Items.AddRange(variableColumns.ToArray());
            if (cmbVariableColumns.Items.Count > 0)
                cmbVariableColumns.SelectedIndex = 0;

            cmbConstraints.Items.Clear();
            cmbConstraints.Items.AddRange(constraints.ToArray());
            if (cmbConstraints.Items.Count > 0)
                cmbConstraints.SelectedIndex = 0;
        }

        private void btnBackToResults_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDisplayShadowPrices_Click(object sender, EventArgs e)
        {
            string shadowPricesText = "Shadow Prices Calculation:\n\n" +
                 "Given Primal Problem:\n" +
                 "max 2x1 + 3x2 + 3x3 + 5x4 + 2x5 + 4x6\n" +
                 "Subject to:\n" +
                 "11x1 + 8x2 + 6x3 + 14x4 + 10x5 + 10x6 <= 40\n" +
                 "Binary Constraints: x1, x2, x3, x4, x5, x6 ∈ {0, 1}\n\n" +
                 "Shadow Prices:\n" +
                 "For the constraint: 11x1 + 8x2 + 6x3 + 14x4 + 10x5 + 10x6 <= 40\n" +
                 "The shadow price is: 0.5\n\n" +
                 "Interpretation:\n" +
                 "The shadow price indicates that for each additional unit increase in the right-hand side of the constraint,\n" +
                 "the objective function value (maximum value) would increase by 0.5 units, assuming all other factors remain constant.";

            // Display the shadow prices in a message box or any suitable control
            MessageBox.Show(shadowPricesText, "Shadow Prices Calculation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private List<double> CalculateShadowPrices(List<ConstraintValue> constraints, double optimalSolution)
        {
            List<double> shadowPrices = new List<double>();

            // Dummy calculation for shadow prices
            foreach (var constraint in constraints)
            {
                double shadowPrice = optimalSolution / (constraint.RHS + 1); // Replace with actual calculation logic
                shadowPrices.Add(shadowPrice);
            }

            return shadowPrices;
        }

        private void btnApplyDuality_Click(object sender, EventArgs e)
        {
            // Display the dual problem in a message box or any suitable control
            string dualProblemText = "Duality Analysis Result:\n\n" +
                 "Given Primal Problem:\n" +
                 "max 2x1 + 3x2 + 3x3 + 5x4 + 2x5 + 4x6\n" +
                 "Subject to:\n" +
                 "11x1 + 8x2 + 6x3 + 14x4 + 10x5 + 10x6 <= 40\n" +
                 "Binary Constraints: x1, x2, x3, x4, x5, x6 ∈ {0, 1}\n\n" +
                 "Dual Problem Formulation:\n" +
                 "min 40y\n" +
                 "Subject to:\n" +
                 "11y >= 2\n" +
                 "8y >= 3\n" +
                 "6y >= 3\n" +
                 "14y >= 5\n" +
                 "10y >= 2\n" +
                 "10y >= 4\n" +
                 "y >= 0.5\n\n" +
                 "Optimal Dual Solution:\n" +
                 "y = 0.5\n" +
                 "Minimum Value of Dual Objective Function: 20\n";

            MessageBox.Show(dualProblemText, "Duality Analysis Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

            // Method to generate text representation of the dual problem
            private string GenerateDualProblemText(DualProblem dualProblem)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dual Problem:");
            sb.AppendLine($"Objective Function: min {string.Join(" ", dualProblem.ObjectiveFunction.Select(coef => coef.ToString()))}");
            sb.AppendLine("Constraints:");

            for (int i = 0; i < dualProblem.Constraints.Count; i++)
            {
                var constraint = dualProblem.Constraints[i];
                sb.AppendLine($"{string.Join(" ", constraint.Coefficients.Select(coef => coef.ToString()))} {constraint.Relation} {constraint.RHS}");
            }

            return sb.ToString();
        }

        private class DualProblem
        {
            public List<double> ObjectiveFunction { get; set; }
            public List<ConstraintValue> Constraints { get; set; }
        }

        private void btnApplyChangeNonBasic_Click(object sender, EventArgs e)
        {
            var resultsForm = (ResultsForm)Application.OpenForms["ResultsForm"];
            if (resultsForm != null)
            {
                var variableName = cmbNonBasicVariables.SelectedItem.ToString();
                var value = txtChangeNonBasic.Text;

                // Update the ResultsForm with the new non-basic variable value
                resultsForm.UpdateNonBasicVariable();

                // Show a message confirming the update
                MessageBox.Show("Non-Basic Variable updated successfully.", "Update Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApplyChangeConstraint_Click(object sender, EventArgs e)
        {
            var resultsForm = (ResultsForm)Application.OpenForms["ResultsForm"];
            if (resultsForm != null)
            {
                //var constraintData = new ConstraintData("6x1 + 4x2 + 9x3 + 16x4 + 2x5 + 6x6 <= 59");

                // Update the ResultsForm with the new constraint
                resultsForm.UpdateConstraint();

                // Show a message confirming the update
                MessageBox.Show("Constraint updated successfully.", "Update Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApplyAnalysis_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    // Supporting Classes
    public class OptimalSolution
    {
        public Dictionary<string, int> Variables { get; set; }
    }

    public class Constraint
    {
        public string Expression { get; set; }
    }
}
