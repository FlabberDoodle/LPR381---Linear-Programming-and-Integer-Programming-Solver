namespace Linear_Programming_Solver.Forms
{
    partial class PrimalSimplexForm
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

        private void InitializeComponent()
        {
            this.txtSignRestrictions = new System.Windows.Forms.TextBox();
            this.lblSignRestrictions = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseAndLoad = new System.Windows.Forms.Button();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.txtConstraints = new System.Windows.Forms.TextBox();
            this.lblConstraints = new System.Windows.Forms.Label();
            this.txtObjectiveFunction = new System.Windows.Forms.TextBox();
            this.lblObjectiveFunction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSignRestrictions
            // 
            this.txtSignRestrictions.Location = new System.Drawing.Point(32, 280);
            this.txtSignRestrictions.Multiline = true;
            this.txtSignRestrictions.Name = "txtSignRestrictions";
            this.txtSignRestrictions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSignRestrictions.Size = new System.Drawing.Size(300, 75);
            this.txtSignRestrictions.TabIndex = 23;
            // 
            // lblSignRestrictions
            // 
            this.lblSignRestrictions.AutoSize = true;
            this.lblSignRestrictions.Location = new System.Drawing.Point(32, 264);
            this.lblSignRestrictions.Name = "lblSignRestrictions";
            this.lblSignRestrictions.Size = new System.Drawing.Size(92, 13);
            this.lblSignRestrictions.TabIndex = 22;
            this.lblSignRestrictions.Text = "Sign Restrictions :";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(32, 369);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(219, 20);
            this.txtFilePath.TabIndex = 21;
            // 
            // btnBrowseAndLoad
            // 
            this.btnBrowseAndLoad.Location = new System.Drawing.Point(257, 368);
            this.btnBrowseAndLoad.Name = "btnBrowseAndLoad";
            this.btnBrowseAndLoad.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAndLoad.TabIndex = 20;
            this.btnBrowseAndLoad.Text = "Browse...";
            this.btnBrowseAndLoad.UseVisualStyleBackColor = true;
            this.btnBrowseAndLoad.Click += new System.EventHandler(this.btnBrowseAndLoad_Click);
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.Location = new System.Drawing.Point(35, 410);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(100, 30);
            this.btnBackToMenu.TabIndex = 19;
            this.btnBackToMenu.Text = "Back to Menu";
            this.btnBackToMenu.UseVisualStyleBackColor = true;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(232, 410);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(100, 30);
            this.btnSolve.TabIndex = 18;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // txtConstraints
            // 
            this.txtConstraints.Location = new System.Drawing.Point(32, 101);
            this.txtConstraints.Multiline = true;
            this.txtConstraints.Name = "txtConstraints";
            this.txtConstraints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConstraints.Size = new System.Drawing.Size(300, 150);
            this.txtConstraints.TabIndex = 17;
            // 
            // lblConstraints
            // 
            this.lblConstraints.AutoSize = true;
            this.lblConstraints.Location = new System.Drawing.Point(32, 81);
            this.lblConstraints.Name = "lblConstraints";
            this.lblConstraints.Size = new System.Drawing.Size(62, 13);
            this.lblConstraints.TabIndex = 16;
            this.lblConstraints.Text = "Constraints:";
            // 
            // txtObjectiveFunction
            // 
            this.txtObjectiveFunction.Location = new System.Drawing.Point(32, 41);
            this.txtObjectiveFunction.Name = "txtObjectiveFunction";
            this.txtObjectiveFunction.Size = new System.Drawing.Size(300, 20);
            this.txtObjectiveFunction.TabIndex = 15;
            // 
            // lblObjectiveFunction
            // 
            this.lblObjectiveFunction.AutoSize = true;
            this.lblObjectiveFunction.Location = new System.Drawing.Point(32, 21);
            this.lblObjectiveFunction.Name = "lblObjectiveFunction";
            this.lblObjectiveFunction.Size = new System.Drawing.Size(99, 13);
            this.lblObjectiveFunction.TabIndex = 14;
            this.lblObjectiveFunction.Text = "Objective Function:";
            // 
            // SimplexForm
            // 
            this.ClientSize = new System.Drawing.Size(364, 461);
            this.Controls.Add(this.txtSignRestrictions);
            this.Controls.Add(this.lblSignRestrictions);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnBrowseAndLoad);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.txtConstraints);
            this.Controls.Add(this.lblConstraints);
            this.Controls.Add(this.txtObjectiveFunction);
            this.Controls.Add(this.lblObjectiveFunction);
            this.Name = "SimplexForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Primal Simplex Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtSignRestrictions;
        private System.Windows.Forms.Label lblSignRestrictions;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowseAndLoad;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TextBox txtConstraints;
        private System.Windows.Forms.Label lblConstraints;
        private System.Windows.Forms.TextBox txtObjectiveFunction;
        private System.Windows.Forms.Label lblObjectiveFunction;
    }
}