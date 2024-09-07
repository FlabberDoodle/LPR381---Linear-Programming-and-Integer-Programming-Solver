using System;
using System.IO;
using System.Linq;
using Linear_Programming_Solver.Core_Classes;
using System.Windows.Forms;
using Linear_Programming_Solver.Algorithm_Classes;

namespace Linear_Programming_Solver.Forms
{
    public partial class CuttingPlaneForm : Form
    {
        private MainForm.AlgorithmType selectedAlgorithm;
        private IPModel model;

        public CuttingPlaneForm(MainForm.AlgorithmType selectedAlgorithm)
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
                case MainForm.AlgorithmType.CuttingPlane:
                    this.Text = "Cutting Plane Algorithm";
                    break;
                case MainForm.AlgorithmType.RevisedCuttingPlane:
                    this.Text = "Revised Cutting Plane Algorithm";
                    break;
                default:
                    this.Text = "Cutting Plane Algorithm";
                    break;
            }
        }

        private void btnBrowseAndLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            // Clear the text boxes
            txtFilePath.Clear();
            txtObjectiveFunction.Clear();
            txtConstraints.Clear();
            txtSignRestrictions.Clear();

            try
            { 
            
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Display only the file name, not the full path
                    txtFilePath.Text = Path.GetFileName(openFileDialog.FileName);

                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                    // Filter out empty lines
                    lines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

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

                    // Create an instance of IPModel and parse the input
                    model.Parse(txtObjectiveFunction.Text, txtConstraints.Text, txtSignRestrictions.Text);
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void btnSolve_Click(object sender, EventArgs e)
        {
            switch (selectedAlgorithm)
            {
                case MainForm.AlgorithmType.CuttingPlane:
                    // Solve using the Cutting Plane algorithm
                    break;
                case MainForm.AlgorithmType.RevisedCuttingPlane:
                    // Solve using the Revised Cutting Plane algorithm
                    break;
            }

            try
            {
                // Pass the IPModel instance to the ResultsForm
                ResultsForm resultsForm = new ResultsForm(model, selectedAlgorithm);
                resultsForm.ShowDialog(); // Make sure you're calling ShowDialog, not Show
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
    }
}