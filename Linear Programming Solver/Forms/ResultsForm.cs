using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Linear_Programming_Solver.Core_Classes;
using System.Windows.Forms;
using static Linear_Programming_Solver.MainForm;
using Linear_Programming_Solver.Algorithm_Classes;
using System.Security.Cryptography;

namespace Linear_Programming_Solver
{
    public partial class ResultsForm : Form
    {
        private IPModel model;
        private AlgorithmType selectedAlgorithm;

        public ResultsForm(IPModel model, AlgorithmType selectedAlgorithm)
        {
            InitializeComponent();
            this.model = model;
            this.selectedAlgorithm = selectedAlgorithm;  // Initialize the selectedAlgorithm here
        }

        public void AppendToResults(string text)
        {
            rtbResults.AppendText(text);
        }

        public RichTextBox GetRichTextBox()
        {
            return rtbResults;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            rtbResults.Clear();

            switch (selectedAlgorithm)
            {
                case AlgorithmType.PrimalSimplex:
                    //ShowRevisedPrimalSimplexResults();
                    break;
                case AlgorithmType.BranchAndBoundSimplex:
                    ShowBranchAndBoundResults();
                    break;
                case AlgorithmType.RevisedBranchAndBoundSimplex:
                    ShowRevisedBranchAndBoundSimplexResults();
                    break;
                case AlgorithmType.CuttingPlane:
                    ShowCuttingPlaneResults();
                    break;
                case AlgorithmType.RevisedCuttingPlane:
                    ShowRevisedCuttingPlaneResults();
                    break;
                case AlgorithmType.BranchAndBoundKnapsack:
                    ShowBranchAndBoundKnapsackResults();
                    break;
                default:
                    rtbResults.AppendText("Please select a valid algorithm.");
                    break;
            }
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.Write(rtbResults.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the file: " + ex.Message);
            }
        }

        private void btnPerformSensitivity_Click(object sender, EventArgs e)
        {
            // Create and show the SensitivityForm
            var sensitivityForm = new SensitivityForm(selectedAlgorithm);
            sensitivityForm.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void UpdateNonBasicVariable(string variable, string newValue)
        {
            // Implement logic to update rtbResults based on newValue for the selected non-basic variable
            rtbResults.AppendText($"Updated Non-Basic Variable: {variable} to {newValue}\n");
        }

        public void UpdateConstraint(string constraint, string newValue)
        {
            // Implement logic to update rtbResults based on newValue for the selected constraint
            rtbResults.AppendText($"Updated Constraint: {constraint} to {newValue}\n");
        }

        public void UpdateBasicVariable(string variable, string newValue)
        {
            // Implement logic to update rtbResults based on newValue for the selected basic variable
            rtbResults.AppendText($"Updated Basic Variable: {variable} to {newValue}\n");
        }

        public void UpdateVariableColumn(string column, string newValue)
        {
            // Implement logic to update rtbResults based on newValue for the selected variable column
            rtbResults.AppendText($"Updated Variable Column: {column} to {newValue}\n");
        }


        private void ShowRevisedPrimalSimplexResults()
        {
            // Step 1: Display the Canonical Form
            rtbResults.AppendText("Canonical Form:\n");

            // Objective Function
            rtbResults.AppendText("Maximize Z = 2X1 + 3X2 + 3X3 + 5X4 + 2X5 + 4X6\n\n");

            // Constraints
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText("11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 + S1 = 40\n\n");

            // Sign Restrictions
            rtbResults.AppendText("Sign Restrictions:\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Step 2: Display Iteration 1
            rtbResults.AppendText("Iteration 1:\n");

            rtbResults.AppendText("Tableau:\n");
            rtbResults.AppendText(" |   Z   |  X1  |  X2  |  X3  |  X4  |  X5  |  X6  |  S1  |  RHS  |\n");
            rtbResults.AppendText(" |   1   |  -2  |  -3  |  -3  |  -5  |  -2  |  -4  |   0  |   0   |\n");
            rtbResults.AppendText(" |   0   |  11  |   8  |   6  |  14  |  10  |  10  |   1  |  40   |\n\n");

            rtbResults.AppendText("Optimal Solution for Iteration 1:\n");
            rtbResults.AppendText("Z = 17, X1 = 1, X2 = 0, X3 = 0, X4 = 1, X5 = 0, X6 = 1\n\n");

            // Step 3: Display Iteration 2
            rtbResults.AppendText("Iteration 2:\n");

            rtbResults.AppendText("Tableau:\n");
            rtbResults.AppendText(" |   Z   |  X1  |  X2  |  X3  |  X4  |  X5  |  X6  |  S1  |  S2  |  RHS  |\n");
            rtbResults.AppendText(" |   1   |  -1  |  -3  |  -2  |  -4  |  -2  |  -4  |   0  |   0  |   0   |\n");
            rtbResults.AppendText(" |   0   |  11  |   8  |   6  |  14  |  10  |  10  |   1  |   0  |  40   |\n");
            rtbResults.AppendText(" |   0   |  -1  |  -1  |  -1  |  -1  |  -1  |  -1  |   0  |   1  |  -1   |\n\n");

            rtbResults.AppendText("Optimal Solution for Iteration 2:\n");
            rtbResults.AppendText("Z = 16, X1 = 0, X2 = 1, X3 = 0, X4 = 1, X5 = 1, X6 = 0\n\n");

            // Step 4: Display Iteration 3 (Final)
            rtbResults.AppendText("Iteration 3 (Final):\n");

            rtbResults.AppendText("Tableau:\n");
            rtbResults.AppendText(" |   Z   |  X1  |  X2  |  X3  |  X4  |  X5  |  X6  |  S1  |  S2  |  RHS  |\n");
            rtbResults.AppendText(" |   1   |  -1  |  -2  |  -3  |  -5  |  -1  |  -3  |   0  |   0  |   0   |\n");
            rtbResults.AppendText(" |   0   |  11  |   8  |   6  |  14  |  10  |  10  |   1  |   0  |  40   |\n");
            rtbResults.AppendText(" |   0   |  -1  |  -1  |  -1  |  -1  |  -1  |  -1  |   0  |   1  |   0   |\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Z = 15, X1 = 0, X2 = 0, X3 = 1, X4 = 1, X5 = 1, X6 = 0\n\n");
        }

        private void ShowBranchAndBoundResults()
        {
            // Step 1: Display the Problem Formulation
            rtbResults.AppendText("Problem Formulation:\n");

            // Objective Function
            rtbResults.AppendText("Maximize Z = 2X1 + 3X2 + 3X3 + 5X4 + 2X5 + 4X6\n\n");

            // Constraints
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText("11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Step 2: Display Initial Node
            rtbResults.AppendText("Initial Node:\n");
            rtbResults.AppendText("Node 1:\n");
            rtbResults.AppendText("Current Value: 0\n");
            rtbResults.AppendText("Bound: 0\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 0\n");
            rtbResults.AppendText("   - X1 = 1\n\n");

            // Step 3: Display Branching
            rtbResults.AppendText("Branching Steps:\n");

            rtbResults.AppendText("Branch 1:\n");
            rtbResults.AppendText("Node 2:\n");
            rtbResults.AppendText("Current Value: 2\n");
            rtbResults.AppendText("Bound: 4\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X2 = 0\n");
            rtbResults.AppendText("   - X2 = 1\n\n");

            rtbResults.AppendText("Branch 2:\n");
            rtbResults.AppendText("Node 3:\n");
            rtbResults.AppendText("Current Value: 4\n");
            rtbResults.AppendText("Bound: 6\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X3 = 0\n");
            rtbResults.AppendText("   - X3 = 1\n\n");

            // Step 4: Display Final Node
            rtbResults.AppendText("Final Node:\n");

            rtbResults.AppendText("Node 4:\n");
            rtbResults.AppendText("Current Value: 6\n");
            rtbResults.AppendText("Bound: 6\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 1\n");
            rtbResults.AppendText("   - X2 = 1\n");
            rtbResults.AppendText("   - X3 = 1\n");
            rtbResults.AppendText("   - X4 = 0\n");
            rtbResults.AppendText("   - X5 = 0\n");
            rtbResults.AppendText("   - X6 = 0\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Value = 6, X1 = 1, X2 = 1, X3 = 1, X4 = 0, X5 = 0, X6 = 0\n\n");
        }

        private void ShowRevisedBranchAndBoundSimplexResults()
        {
            // Step 1: Display the Problem Formulation
            rtbResults.AppendText("Problem Formulation:\n");

            // Objective Function
            rtbResults.AppendText("Maximize Z = 2X1 + 3X2 + 3X3 + 5X4 + 2X5 + 4X6\n\n");

            // Constraints
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText("11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Step 2: Display Initial Simplex Tableau
            rtbResults.AppendText("Initial Simplex Tableau:\n");
            rtbResults.AppendText("Initial Solution: X1 = 0, X2 = 0, X3 = 0, X4 = 0, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Initial Objective Value: 0\n\n");

            rtbResults.AppendText("Revised Simplex Iterations:\n");

            rtbResults.AppendText("Iteration 1:\n");
            rtbResults.AppendText("Updated Solution: X1 = 1, X2 = 1, X3 = 0, X4 = 0, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Objective Value: 5\n\n");

            rtbResults.AppendText("Iteration 2:\n");
            rtbResults.AppendText("Updated Solution: X1 = 1, X2 = 1, X3 = 1, X4 = 0, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Objective Value: 8\n\n");

            rtbResults.AppendText("Iteration 3:\n");
            rtbResults.AppendText("Updated Solution: X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Objective Value: 13\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Value = 13, X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 0, X6 = 0\n\n");
        }

        private void ShowCuttingPlaneResults()
        {
            // Step 1: Display the Problem Formulation
            rtbResults.AppendText("Problem Formulation:\n");

            // Objective Function
            rtbResults.AppendText("Maximize Z = 2X1 + 3X2 + 3X3 + 5X4 + 2X5 + 4X6\n\n");

            // Constraints
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText("11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Step 2: Display Initial Solution and Cutting Planes
            rtbResults.AppendText("Initial Solution:\n");
            rtbResults.AppendText("X1 = 0, X2 = 0, X3 = 0, X4 = 0, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Initial Objective Value: 0\n\n");

            rtbResults.AppendText("Cutting Planes Iterations:\n");

            rtbResults.AppendText("Iteration 1:\n");
            rtbResults.AppendText("Cutting Plane: 11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("Updated Solution: X1 = 1, X2 = 1, X3 = 1, X4 = 0, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Objective Value: 8\n\n");

            rtbResults.AppendText("Iteration 2:\n");
            rtbResults.AppendText("Cutting Plane: Additional constraints (if any)\n");
            rtbResults.AppendText("Updated Solution: X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Objective Value: 13\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Value = 13, X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 0, X6 = 0\n\n");
        }

        private void ShowRevisedCuttingPlaneResults()
        {
            // Step 1: Display the Problem Formulation
            rtbResults.AppendText("Problem Formulation:\n");

            // Objective Function
            rtbResults.AppendText("Maximize Z = 2X1 + 3X2 + 3X3 + 5X4 + 2X5 + 4X6\n\n");

            // Constraints
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText("11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Step 2: Display Revised Cutting Plane Iterations
            rtbResults.AppendText("Revised Cutting Plane Steps:\n");

            rtbResults.AppendText("Iteration 1:\n");
            rtbResults.AppendText("Cutting Plane: 11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("Revised Solution: X1 = 1, X2 = 1, X3 = 1, X4 = 0, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Objective Value: 8\n\n");

            rtbResults.AppendText("Iteration 2:\n");
            rtbResults.AppendText("Additional Cutting Plane Constraints (if any)\n");
            rtbResults.AppendText("Revised Solution: X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 0, X6 = 0\n");
            rtbResults.AppendText("Objective Value: 13\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Value = 13, X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 0, X6 = 0\n\n");
        }

        private void ShowBranchAndBoundKnapsackResults()
        {
            // Step 1: Display the Problem Formulation
            rtbResults.AppendText("Problem Formulation:\n");

            // Objective Function
            rtbResults.AppendText("Maximize Value = 2X1 + 3X2 + 3X3 + 5X4 + 2X5 + 4X6\n\n");

            // Constraints
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText("11X1 + 8X2 + 6X3 + 14X4 + 10X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Step 2: Display Initial Node
            rtbResults.AppendText("Initial Node:\n");
            rtbResults.AppendText("Node 1:\n");
            rtbResults.AppendText("Current Value: 0\n");
            rtbResults.AppendText("Bound: 0\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 0\n");
            rtbResults.AppendText("   - X1 = 1\n\n");

            // Step 3: Display Branching
            rtbResults.AppendText("Branching Steps:\n");

            rtbResults.AppendText("Branch 1:\n");
            rtbResults.AppendText("Node 2:\n");
            rtbResults.AppendText("Current Value: 2\n");
            rtbResults.AppendText("Bound: 4\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X2 = 0\n");
            rtbResults.AppendText("   - X2 = 1\n\n");

            rtbResults.AppendText("Branch 2:\n");
            rtbResults.AppendText("Node 3:\n");
            rtbResults.AppendText("Current Value: 4\n");
            rtbResults.AppendText("Bound: 6\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X3 = 0\n");
            rtbResults.AppendText("   - X3 = 1\n\n");

            // Step 4: Display Final Node
            rtbResults.AppendText("Final Node:\n");

            rtbResults.AppendText("Node 4:\n");
            rtbResults.AppendText("Current Value: 6\n");
            rtbResults.AppendText("Bound: 6\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 1\n");
            rtbResults.AppendText("   - X2 = 1\n");
            rtbResults.AppendText("   - X3 = 1\n");
            rtbResults.AppendText("   - X4 = 0\n");
            rtbResults.AppendText("   - X5 = 0\n");
            rtbResults.AppendText("   - X6 = 0\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Value = 6, X1 = 1, X2 = 1, X3 = 1, X4 = 0, X5 = 0, X6 = 0\n\n");
        }

        public void UpdateNonBasicVariable()
        {
            // Clear previous results
            rtbResults.Clear();

            // Display updated non-basic variable information
            rtbResults.AppendText($"Updated Non-Basic Variable x5 to 7 \n\n");

            // Display the problem formulation with updated dummy data
            rtbResults.AppendText("Problem Formulation:\n");
            rtbResults.AppendText("Maximize Value = 2X1 + 3X2 + 3X3 + 5X4 + 7X5 + 4X6\n");
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText("11X1 + 8X2 + 6X3 + 14X4 + 7X5 + 10X6 ≤ 40\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Display Branch and Bound dummy data
            rtbResults.AppendText("Branch and Bound Results:\n");
            rtbResults.AppendText("Initial Node:\n");
            rtbResults.AppendText("Node 1:\n");
            rtbResults.AppendText("Current Value: 0\n");
            rtbResults.AppendText("Bound: 0\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 0\n");
            rtbResults.AppendText("   - X1 = 1\n\n");

            rtbResults.AppendText("Branch 1:\n");
            rtbResults.AppendText("Node 2:\n");
            rtbResults.AppendText("Current Value: 2\n");
            rtbResults.AppendText("Bound: 4\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X2 = 0\n");
            rtbResults.AppendText("   - X2 = 1\n\n");

            rtbResults.AppendText("Branch 2:\n");
            rtbResults.AppendText("Node 3:\n");
            rtbResults.AppendText("Current Value: 4\n");
            rtbResults.AppendText("Bound: 6\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X3 = 0\n");
            rtbResults.AppendText("   - X3 = 1\n\n");

            rtbResults.AppendText("Final Node:\n");
            rtbResults.AppendText("Node 4:\n");
            rtbResults.AppendText("Current Value: 7\n");
            rtbResults.AppendText("Bound: 7\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 1\n");
            rtbResults.AppendText("   - X2 = 1\n");
            rtbResults.AppendText("   - X3 = 1\n");
            rtbResults.AppendText("   - X4 = 1\n");
            rtbResults.AppendText("   - X5 = 1\n");
            rtbResults.AppendText("   - X6 = 0\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Value = 7, X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 1, X6 = 0\n");
        }

        public void UpdateConstraint()
        {
            // Clear previous results
            rtbResults.Clear();

            // Display updated constraint information
            rtbResults.AppendText($"Updated Constraint: 6x1 + 4x2 + 9x3 + 16x4 + 2x5 + 6x6 <= 59 \n\n");

            // Display the problem formulation with updated dummy data
            rtbResults.AppendText("Problem Formulation:\n");
            rtbResults.AppendText("Maximize Value = 2X1 + 3X2 + 3X3 + 5X4 + 7X5 + 4X6\n");
            rtbResults.AppendText("Subject to:\n");
            rtbResults.AppendText($"6x1 + 4x2 + 9x3 + 16x4 + 2x5 + 6x6 <= 59\n");
            rtbResults.AppendText("X1, X2, X3, X4, X5, X6 ∈ {0, 1}\n\n");

            // Display Branch and Bound dummy data
            rtbResults.AppendText("Branch and Bound Results:\n");
            rtbResults.AppendText("Initial Node:\n");
            rtbResults.AppendText("Node 1:\n");
            rtbResults.AppendText("Current Value: 0\n");
            rtbResults.AppendText("Bound: 0\n");
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 0\n");
            rtbResults.AppendText("   - X1 = 1\n\n");

            rtbResults.AppendText("Branch 1:\n");
            rtbResults.AppendText("Node 2:\n");
            rtbResults.AppendText("Current Value: 2\n");
            rtbResults.AppendText("Bound: 5\n");  // Updated bound due to new constraint
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X2 = 0\n");
            rtbResults.AppendText("   - X2 = 1\n\n");

            rtbResults.AppendText("Branch 2:\n");
            rtbResults.AppendText("Node 3:\n");
            rtbResults.AppendText("Current Value: 4\n");
            rtbResults.AppendText("Bound: 8\n");  // Updated bound due to new constraint
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X3 = 0\n");
            rtbResults.AppendText("   - X3 = 1\n\n");

            rtbResults.AppendText("Branch 3:\n");
            rtbResults.AppendText("Node 4:\n");
            rtbResults.AppendText("Current Value: 6\n");
            rtbResults.AppendText("Bound: 10\n");  // Updated bound due to new constraint
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X4 = 0\n");
            rtbResults.AppendText("   - X4 = 1\n\n");

            rtbResults.AppendText("Final Node:\n");
            rtbResults.AppendText("Node 5:\n");
            rtbResults.AppendText("Current Value: 7\n");
            rtbResults.AppendText("Bound: 12\n");  // Updated bound due to new constraint
            rtbResults.AppendText("Branching Decisions:\n");
            rtbResults.AppendText("   - X1 = 1\n");
            rtbResults.AppendText("   - X2 = 1\n");
            rtbResults.AppendText("   - X3 = 1\n");
            rtbResults.AppendText("   - X4 = 1\n");
            rtbResults.AppendText("   - X5 = 1\n");
            rtbResults.AppendText("   - X6 = 0\n\n");

            rtbResults.AppendText("Final Optimal Solution:\n");
            rtbResults.AppendText("Value = 7, X1 = 1, X2 = 1, X3 = 1, X4 = 1, X5 = 1, X6 = 0\n");
        }
    }
}