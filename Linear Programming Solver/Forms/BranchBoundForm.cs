using Linear_Programming_Solver.Algorithm_Classes;
using Linear_Programming_Solver.Core_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linear_Programming_Solver.Forms
{
    public partial class BranchBoundForm : Form
    {
        private MainForm.AlgorithmType selectedAlgorithm;
        private IPModel model;

        public BranchBoundForm(MainForm.AlgorithmType selectedAlgorithm)
        {
            InitializeComponent();
            this.selectedAlgorithm = selectedAlgorithm;
            SetFormTitle();
            model = new IPModel(); // Initialize the model here
        }

        private void SetFormTitle()
        {
            switch (selectedAlgorithm)
            {
                case MainForm.AlgorithmType.BranchAndBoundSimplex:
                    this.Text = "Branch and Bound Algorithm";
                    break;
                case MainForm.AlgorithmType.RevisedBranchAndBoundSimplex:
                    this.Text = "Revised Branch and Bound Algorithm";
                    break;
                default:
                    this.Text = "Branch and Bound Algorithm";
                    break;
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                // Debugging output
                Console.WriteLine("Objective Function Text: " + txtObjectiveFunction.Text);
                Console.WriteLine("Constraints Text: " + txtConstraints.Text);
                Console.WriteLine("Sign Restrictions Text: " + txtSignRestrictions.Text);

                // Ensure the model is populated with data from text boxes
                IPModel model = new IPModel();
                model.Parse(txtObjectiveFunction.Text, txtConstraints.Text, txtSignRestrictions.Text);

                // Pass the IPModel instance to the ResultsForm
                ResultsForm resultsForm = new ResultsForm(model, selectedAlgorithm);
                resultsForm.Show(); // Make sure you're calling ShowDialog, not Show
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            // Close the current form
            this.Close();

            // Show the main form again
            var mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.Show();
            }
        }

        private void btnBrowseAndLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            txtFilePath.Clear();
            txtObjectiveFunction.Clear();
            txtConstraints.Clear();
            txtSignRestrictions.Clear();

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = Path.GetFileName(openFileDialog.FileName);

                    string[] lines = File.ReadAllLines(openFileDialog.FileName)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .ToArray();

                    if (lines.Length > 0)
                    {
                        txtObjectiveFunction.Text = lines[0];

                        if (lines.Length > 1)
                        {
                            for (int i = 1; i < lines.Length - 1; i++) // Exclude the last line for sign restrictions
                            {
                                txtConstraints.AppendText(lines[i] + Environment.NewLine);
                            }

                            txtSignRestrictions.Text = lines[lines.Length - 1]; // The last line is for sign restrictions
                        }
                    }

                    // Populate the model
                    model = new IPModel();
                    model.Parse(txtObjectiveFunction.Text, txtConstraints.Text, txtSignRestrictions.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
