namespace Linear_Programming_Solver
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnPrimalSimplex = new System.Windows.Forms.Button();
            this.btnBranchBound = new System.Windows.Forms.Button();
            this.btnBranchBoundKnapsack = new System.Windows.Forms.Button();
            this.btnCuttingPlane = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(149, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(303, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Linear Programming Solver";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(164, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(272, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Choose an option to solve a problem or perform analysis.";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPrimalSimplex
            // 
            this.btnPrimalSimplex.Location = new System.Drawing.Point(168, 100);
            this.btnPrimalSimplex.Name = "btnPrimalSimplex";
            this.btnPrimalSimplex.Size = new System.Drawing.Size(265, 30);
            this.btnPrimalSimplex.TabIndex = 2;
            this.btnPrimalSimplex.Text = "Solve Using Primal Simplex Algorithm";
            this.btnPrimalSimplex.UseVisualStyleBackColor = true;
            this.btnPrimalSimplex.Click += new System.EventHandler(this.btnPrimalSimplex_Click);
            // 
            // btnBranchBound
            // 
            this.btnBranchBound.Location = new System.Drawing.Point(168, 136);
            this.btnBranchBound.Name = "btnBranchBound";
            this.btnBranchBound.Size = new System.Drawing.Size(265, 30);
            this.btnBranchBound.TabIndex = 3;
            this.btnBranchBound.Text = "Solve Using Branch and Bound Algorithm";
            this.btnBranchBound.UseVisualStyleBackColor = true;
            this.btnBranchBound.Click += new System.EventHandler(this.btnBranchBound_Click);
            // 
            // btnBranchBoundKnapsack
            // 
            this.btnBranchBoundKnapsack.Location = new System.Drawing.Point(168, 208);
            this.btnBranchBoundKnapsack.Name = "btnBranchBoundKnapsack";
            this.btnBranchBoundKnapsack.Size = new System.Drawing.Size(265, 30);
            this.btnBranchBoundKnapsack.TabIndex = 4;
            this.btnBranchBoundKnapsack.Text = "Solve Using Branch and Bound Knapsack Algorithm";
            this.btnBranchBoundKnapsack.UseVisualStyleBackColor = true;
            this.btnBranchBoundKnapsack.Click += new System.EventHandler(this.btnBranchBoundKnapsack_Click);
            // 
            // btnCuttingPlane
            // 
            this.btnCuttingPlane.Location = new System.Drawing.Point(168, 172);
            this.btnCuttingPlane.Name = "btnCuttingPlane";
            this.btnCuttingPlane.Size = new System.Drawing.Size(265, 30);
            this.btnCuttingPlane.TabIndex = 5;
            this.btnCuttingPlane.Text = "Solve Using Cutting Plane Algorithm";
            this.btnCuttingPlane.UseVisualStyleBackColor = true;
            this.btnCuttingPlane.Click += new System.EventHandler(this.btnCuttingPlane_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(250, 257);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCuttingPlane);
            this.Controls.Add(this.btnBranchBoundKnapsack);
            this.Controls.Add(this.btnBranchBound);
            this.Controls.Add(this.btnPrimalSimplex);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Linear Programming Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnPrimalSimplex;
        private System.Windows.Forms.Button btnBranchBound;
        private System.Windows.Forms.Button btnBranchBoundKnapsack;
        private System.Windows.Forms.Button btnCuttingPlane;
        private System.Windows.Forms.Button btnExit;
    }
}