using System;
using System.Linq;
using System.Windows.Forms;
using Linear_Programming_Solver.Algorithm_Classes;
using Linear_Programming_Solver.Forms;

// Tiaan Theron - 577856
// Tadiwanashe Nyoka - 577633
// Lucky Kgalifi Manamela - 577675
// Gianni Snyders - 577932

namespace Linear_Programming_Solver
{
    public partial class MainForm : Form
    {
        public enum AlgorithmType
        {
            PrimalSimplex,
            BranchAndBoundSimplex,
            RevisedBranchAndBoundSimplex,
            CuttingPlane,
            RevisedCuttingPlane,
            BranchAndBoundKnapsack
        }

        private AlgorithmType selectedAlgorithm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnPrimalSimplex_Click(object sender, EventArgs e)
        {
            selectedAlgorithm = AlgorithmType.PrimalSimplex;
            NavigateToForm(new PrimalSimplexForm(selectedAlgorithm));
        }

        private void btnBranchBound_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Select Algorithm Version:\n\nYes for Branch and Bound Simplex\nNo for Revised Branch and Bound Simplex",
                                         "Algorithm Selection",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            selectedAlgorithm = result == DialogResult.Yes ? AlgorithmType.BranchAndBoundSimplex : AlgorithmType.RevisedBranchAndBoundSimplex;
            NavigateToForm(new BranchBoundForm(selectedAlgorithm));
        }

        private void btnCuttingPlane_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Select Algorithm Version:\n\nYes for Cutting Plane Algorithm\nNo for Revised Cutting Plane Algorithm",
                                         "Algorithm Selection",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            selectedAlgorithm = result == DialogResult.Yes ? AlgorithmType.CuttingPlane : AlgorithmType.RevisedCuttingPlane;
            NavigateToForm(new CuttingPlaneForm(selectedAlgorithm));
        }

        private void btnBranchBoundKnapsack_Click(object sender, EventArgs e)
        {
            selectedAlgorithm = AlgorithmType.BranchAndBoundKnapsack;
            NavigateToForm(new BranchBoundKnapsackForm(selectedAlgorithm));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NavigateToForm(Form form)
        {
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}