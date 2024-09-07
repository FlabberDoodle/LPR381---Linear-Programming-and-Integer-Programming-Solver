namespace Linear_Programming_Solver
{
    partial class SensitivityForm
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
            this.groupBoxNonBasic = new System.Windows.Forms.GroupBox();
            this.btnApplyChangeNonBasic = new System.Windows.Forms.Button();
            this.txtChangeNonBasic = new System.Windows.Forms.TextBox();
            this.cmbNonBasicVariables = new System.Windows.Forms.ComboBox();
            this.lblNonBasicVariable = new System.Windows.Forms.Label();
            this.groupBoxBasic = new System.Windows.Forms.GroupBox();
            this.btnApplyChangeBasic = new System.Windows.Forms.Button();
            this.txtChangeBasic = new System.Windows.Forms.TextBox();
            this.cmbBasicVariables = new System.Windows.Forms.ComboBox();
            this.lblBasicVariable = new System.Windows.Forms.Label();
            this.groupBoxConstraint = new System.Windows.Forms.GroupBox();
            this.btnApplyChangeConstraint = new System.Windows.Forms.Button();
            this.txtChangeConstraint = new System.Windows.Forms.TextBox();
            this.cmbConstraints = new System.Windows.Forms.ComboBox();
            this.lblConstraint = new System.Windows.Forms.Label();
            this.groupBoxVariableColumn = new System.Windows.Forms.GroupBox();
            this.btnApplyChangeVariableColumn = new System.Windows.Forms.Button();
            this.txtChangeVariableColumn = new System.Windows.Forms.TextBox();
            this.cmbVariableColumns = new System.Windows.Forms.ComboBox();
            this.lblVariableColumn = new System.Windows.Forms.Label();
            this.groupBoxAdditional = new System.Windows.Forms.GroupBox();
            this.txtAdditionalOptions = new System.Windows.Forms.TextBox();
            this.btnAddNewActivity = new System.Windows.Forms.Button();
            this.btnAddNewConstraint = new System.Windows.Forms.Button();
            this.btnDisplayShadowPrices = new System.Windows.Forms.Button();
            this.btnApplyDuality = new System.Windows.Forms.Button();
            this.lblResults = new System.Windows.Forms.Label();
            this.btnApplyAnalysis = new System.Windows.Forms.Button();
            this.btnBackToResults = new System.Windows.Forms.Button();
            this.groupBoxNonBasic.SuspendLayout();
            this.groupBoxBasic.SuspendLayout();
            this.groupBoxConstraint.SuspendLayout();
            this.groupBoxVariableColumn.SuspendLayout();
            this.groupBoxAdditional.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxNonBasic
            // 
            this.groupBoxNonBasic.Controls.Add(this.btnApplyChangeNonBasic);
            this.groupBoxNonBasic.Controls.Add(this.txtChangeNonBasic);
            this.groupBoxNonBasic.Controls.Add(this.cmbNonBasicVariables);
            this.groupBoxNonBasic.Controls.Add(this.lblNonBasicVariable);
            this.groupBoxNonBasic.Location = new System.Drawing.Point(12, 12);
            this.groupBoxNonBasic.Name = "groupBoxNonBasic";
            this.groupBoxNonBasic.Size = new System.Drawing.Size(300, 150);
            this.groupBoxNonBasic.TabIndex = 0;
            this.groupBoxNonBasic.TabStop = false;
            this.groupBoxNonBasic.Text = "Non-Basic Variable Analysis";
            // 
            // btnApplyChangeNonBasic
            // 
            this.btnApplyChangeNonBasic.Location = new System.Drawing.Point(10, 100);
            this.btnApplyChangeNonBasic.Name = "btnApplyChangeNonBasic";
            this.btnApplyChangeNonBasic.Size = new System.Drawing.Size(130, 23);
            this.btnApplyChangeNonBasic.TabIndex = 3;
            this.btnApplyChangeNonBasic.Text = "Apply Change";
            this.btnApplyChangeNonBasic.UseVisualStyleBackColor = true;
            this.btnApplyChangeNonBasic.Click += new System.EventHandler(this.btnApplyChangeNonBasic_Click);
            // 
            // txtChangeNonBasic
            // 
            this.txtChangeNonBasic.Location = new System.Drawing.Point(10, 70);
            this.txtChangeNonBasic.Name = "txtChangeNonBasic";
            this.txtChangeNonBasic.Size = new System.Drawing.Size(270, 20);
            this.txtChangeNonBasic.TabIndex = 2;
            // 
            // cmbNonBasicVariables
            // 
            this.cmbNonBasicVariables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNonBasicVariables.FormattingEnabled = true;
            this.cmbNonBasicVariables.Location = new System.Drawing.Point(10, 40);
            this.cmbNonBasicVariables.Name = "cmbNonBasicVariables";
            this.cmbNonBasicVariables.Size = new System.Drawing.Size(270, 21);
            this.cmbNonBasicVariables.TabIndex = 1;
            // 
            // lblNonBasicVariable
            // 
            this.lblNonBasicVariable.AutoSize = true;
            this.lblNonBasicVariable.Location = new System.Drawing.Point(10, 20);
            this.lblNonBasicVariable.Name = "lblNonBasicVariable";
            this.lblNonBasicVariable.Size = new System.Drawing.Size(130, 13);
            this.lblNonBasicVariable.TabIndex = 0;
            this.lblNonBasicVariable.Text = "Select Non-Basic Variable";
            // 
            // groupBoxBasic
            // 
            this.groupBoxBasic.Controls.Add(this.btnApplyChangeBasic);
            this.groupBoxBasic.Controls.Add(this.txtChangeBasic);
            this.groupBoxBasic.Controls.Add(this.cmbBasicVariables);
            this.groupBoxBasic.Controls.Add(this.lblBasicVariable);
            this.groupBoxBasic.Location = new System.Drawing.Point(12, 168);
            this.groupBoxBasic.Name = "groupBoxBasic";
            this.groupBoxBasic.Size = new System.Drawing.Size(300, 150);
            this.groupBoxBasic.TabIndex = 1;
            this.groupBoxBasic.TabStop = false;
            this.groupBoxBasic.Text = "Basic Variable Analysis";
            // 
            // btnApplyChangeBasic
            // 
            this.btnApplyChangeBasic.Location = new System.Drawing.Point(10, 100);
            this.btnApplyChangeBasic.Name = "btnApplyChangeBasic";
            this.btnApplyChangeBasic.Size = new System.Drawing.Size(130, 23);
            this.btnApplyChangeBasic.TabIndex = 3;
            this.btnApplyChangeBasic.Text = "Apply Change";
            this.btnApplyChangeBasic.UseVisualStyleBackColor = true;
            // 
            // txtChangeBasic
            // 
            this.txtChangeBasic.Location = new System.Drawing.Point(10, 70);
            this.txtChangeBasic.Name = "txtChangeBasic";
            this.txtChangeBasic.Size = new System.Drawing.Size(270, 20);
            this.txtChangeBasic.TabIndex = 2;
            // 
            // cmbBasicVariables
            // 
            this.cmbBasicVariables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBasicVariables.FormattingEnabled = true;
            this.cmbBasicVariables.Location = new System.Drawing.Point(10, 40);
            this.cmbBasicVariables.Name = "cmbBasicVariables";
            this.cmbBasicVariables.Size = new System.Drawing.Size(270, 21);
            this.cmbBasicVariables.TabIndex = 1;
            // 
            // lblBasicVariable
            // 
            this.lblBasicVariable.AutoSize = true;
            this.lblBasicVariable.Location = new System.Drawing.Point(10, 20);
            this.lblBasicVariable.Name = "lblBasicVariable";
            this.lblBasicVariable.Size = new System.Drawing.Size(107, 13);
            this.lblBasicVariable.TabIndex = 0;
            this.lblBasicVariable.Text = "Select Basic Variable";
            // 
            // groupBoxConstraint
            // 
            this.groupBoxConstraint.Controls.Add(this.btnApplyChangeConstraint);
            this.groupBoxConstraint.Controls.Add(this.txtChangeConstraint);
            this.groupBoxConstraint.Controls.Add(this.cmbConstraints);
            this.groupBoxConstraint.Controls.Add(this.lblConstraint);
            this.groupBoxConstraint.Location = new System.Drawing.Point(318, 12);
            this.groupBoxConstraint.Name = "groupBoxConstraint";
            this.groupBoxConstraint.Size = new System.Drawing.Size(300, 150);
            this.groupBoxConstraint.TabIndex = 2;
            this.groupBoxConstraint.TabStop = false;
            this.groupBoxConstraint.Text = "Constraint Analysis";
            // 
            // btnApplyChangeConstraint
            // 
            this.btnApplyChangeConstraint.Location = new System.Drawing.Point(12, 100);
            this.btnApplyChangeConstraint.Name = "btnApplyChangeConstraint";
            this.btnApplyChangeConstraint.Size = new System.Drawing.Size(130, 23);
            this.btnApplyChangeConstraint.TabIndex = 3;
            this.btnApplyChangeConstraint.Text = "Apply Change";
            this.btnApplyChangeConstraint.UseVisualStyleBackColor = true;
            this.btnApplyChangeConstraint.Click += new System.EventHandler(this.btnApplyChangeConstraint_Click);
            // 
            // txtChangeConstraint
            // 
            this.txtChangeConstraint.Location = new System.Drawing.Point(10, 70);
            this.txtChangeConstraint.Name = "txtChangeConstraint";
            this.txtChangeConstraint.Size = new System.Drawing.Size(270, 20);
            this.txtChangeConstraint.TabIndex = 2;
            // 
            // cmbConstraints
            // 
            this.cmbConstraints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConstraints.FormattingEnabled = true;
            this.cmbConstraints.Location = new System.Drawing.Point(10, 40);
            this.cmbConstraints.Name = "cmbConstraints";
            this.cmbConstraints.Size = new System.Drawing.Size(270, 21);
            this.cmbConstraints.TabIndex = 1;
            // 
            // lblConstraint
            // 
            this.lblConstraint.AutoSize = true;
            this.lblConstraint.Location = new System.Drawing.Point(10, 20);
            this.lblConstraint.Name = "lblConstraint";
            this.lblConstraint.Size = new System.Drawing.Size(87, 13);
            this.lblConstraint.TabIndex = 0;
            this.lblConstraint.Text = "Select Constraint";
            // 
            // groupBoxVariableColumn
            // 
            this.groupBoxVariableColumn.Controls.Add(this.btnApplyChangeVariableColumn);
            this.groupBoxVariableColumn.Controls.Add(this.txtChangeVariableColumn);
            this.groupBoxVariableColumn.Controls.Add(this.cmbVariableColumns);
            this.groupBoxVariableColumn.Controls.Add(this.lblVariableColumn);
            this.groupBoxVariableColumn.Location = new System.Drawing.Point(318, 168);
            this.groupBoxVariableColumn.Name = "groupBoxVariableColumn";
            this.groupBoxVariableColumn.Size = new System.Drawing.Size(300, 150);
            this.groupBoxVariableColumn.TabIndex = 3;
            this.groupBoxVariableColumn.TabStop = false;
            this.groupBoxVariableColumn.Text = "Non-Basic Variable Column Analysis";
            // 
            // btnApplyChangeVariableColumn
            // 
            this.btnApplyChangeVariableColumn.Location = new System.Drawing.Point(12, 100);
            this.btnApplyChangeVariableColumn.Name = "btnApplyChangeVariableColumn";
            this.btnApplyChangeVariableColumn.Size = new System.Drawing.Size(130, 23);
            this.btnApplyChangeVariableColumn.TabIndex = 3;
            this.btnApplyChangeVariableColumn.Text = "Apply Change";
            this.btnApplyChangeVariableColumn.UseVisualStyleBackColor = true;
            // 
            // txtChangeVariableColumn
            // 
            this.txtChangeVariableColumn.Location = new System.Drawing.Point(10, 70);
            this.txtChangeVariableColumn.Name = "txtChangeVariableColumn";
            this.txtChangeVariableColumn.Size = new System.Drawing.Size(270, 20);
            this.txtChangeVariableColumn.TabIndex = 2;
            // 
            // cmbVariableColumns
            // 
            this.cmbVariableColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVariableColumns.FormattingEnabled = true;
            this.cmbVariableColumns.Location = new System.Drawing.Point(10, 40);
            this.cmbVariableColumns.Name = "cmbVariableColumns";
            this.cmbVariableColumns.Size = new System.Drawing.Size(270, 21);
            this.cmbVariableColumns.TabIndex = 1;
            // 
            // lblVariableColumn
            // 
            this.lblVariableColumn.AutoSize = true;
            this.lblVariableColumn.Location = new System.Drawing.Point(10, 20);
            this.lblVariableColumn.Name = "lblVariableColumn";
            this.lblVariableColumn.Size = new System.Drawing.Size(168, 13);
            this.lblVariableColumn.TabIndex = 0;
            this.lblVariableColumn.Text = "Select Non-Basic Variable Column";
            // 
            // groupBoxAdditional
            // 
            this.groupBoxAdditional.Controls.Add(this.txtAdditionalOptions);
            this.groupBoxAdditional.Controls.Add(this.btnAddNewActivity);
            this.groupBoxAdditional.Controls.Add(this.btnAddNewConstraint);
            this.groupBoxAdditional.Controls.Add(this.btnDisplayShadowPrices);
            this.groupBoxAdditional.Controls.Add(this.btnApplyDuality);
            this.groupBoxAdditional.Location = new System.Drawing.Point(12, 324);
            this.groupBoxAdditional.Name = "groupBoxAdditional";
            this.groupBoxAdditional.Size = new System.Drawing.Size(606, 80);
            this.groupBoxAdditional.TabIndex = 4;
            this.groupBoxAdditional.TabStop = false;
            this.groupBoxAdditional.Text = "Additional Options";
            // 
            // txtAdditionalOptions
            // 
            this.txtAdditionalOptions.Location = new System.Drawing.Point(10, 49);
            this.txtAdditionalOptions.Name = "txtAdditionalOptions";
            this.txtAdditionalOptions.Size = new System.Drawing.Size(270, 20);
            this.txtAdditionalOptions.TabIndex = 5;
            // 
            // btnAddNewActivity
            // 
            this.btnAddNewActivity.Location = new System.Drawing.Point(10, 20);
            this.btnAddNewActivity.Name = "btnAddNewActivity";
            this.btnAddNewActivity.Size = new System.Drawing.Size(130, 23);
            this.btnAddNewActivity.TabIndex = 0;
            this.btnAddNewActivity.Text = "Add New Activity";
            this.btnAddNewActivity.UseVisualStyleBackColor = true;
            // 
            // btnAddNewConstraint
            // 
            this.btnAddNewConstraint.Location = new System.Drawing.Point(150, 20);
            this.btnAddNewConstraint.Name = "btnAddNewConstraint";
            this.btnAddNewConstraint.Size = new System.Drawing.Size(130, 23);
            this.btnAddNewConstraint.TabIndex = 1;
            this.btnAddNewConstraint.Text = "Add New Constraint";
            this.btnAddNewConstraint.UseVisualStyleBackColor = true;
            // 
            // btnDisplayShadowPrices
            // 
            this.btnDisplayShadowPrices.Location = new System.Drawing.Point(330, 20);
            this.btnDisplayShadowPrices.Name = "btnDisplayShadowPrices";
            this.btnDisplayShadowPrices.Size = new System.Drawing.Size(130, 23);
            this.btnDisplayShadowPrices.TabIndex = 2;
            this.btnDisplayShadowPrices.Text = "Display Shadow Prices";
            this.btnDisplayShadowPrices.UseVisualStyleBackColor = true;
            this.btnDisplayShadowPrices.Click += new System.EventHandler(this.btnDisplayShadowPrices_Click);
            // 
            // btnApplyDuality
            // 
            this.btnApplyDuality.Location = new System.Drawing.Point(470, 20);
            this.btnApplyDuality.Name = "btnApplyDuality";
            this.btnApplyDuality.Size = new System.Drawing.Size(130, 23);
            this.btnApplyDuality.TabIndex = 3;
            this.btnApplyDuality.Text = "Apply Duality";
            this.btnApplyDuality.UseVisualStyleBackColor = true;
            this.btnApplyDuality.Click += new System.EventHandler(this.btnApplyDuality_Click);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(12, 420);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(42, 13);
            this.lblResults.TabIndex = 5;
            this.lblResults.Text = "Results";
            // 
            // btnApplyAnalysis
            // 
            this.btnApplyAnalysis.Location = new System.Drawing.Point(478, 410);
            this.btnApplyAnalysis.Name = "btnApplyAnalysis";
            this.btnApplyAnalysis.Size = new System.Drawing.Size(140, 23);
            this.btnApplyAnalysis.TabIndex = 6;
            this.btnApplyAnalysis.Text = "Apply Analysis";
            this.btnApplyAnalysis.UseVisualStyleBackColor = true;
            this.btnApplyAnalysis.Click += new System.EventHandler(this.btnApplyAnalysis_Click);
            // 
            // btnBackToResults
            // 
            this.btnBackToResults.Location = new System.Drawing.Point(12, 410);
            this.btnBackToResults.Name = "btnBackToResults";
            this.btnBackToResults.Size = new System.Drawing.Size(140, 23);
            this.btnBackToResults.TabIndex = 7;
            this.btnBackToResults.Text = "Back to Results";
            this.btnBackToResults.UseVisualStyleBackColor = true;
            this.btnBackToResults.Click += new System.EventHandler(this.btnBackToResults_Click);
            // 
            // SensitivityForm
            // 
            this.ClientSize = new System.Drawing.Size(628, 441);
            this.Controls.Add(this.btnApplyAnalysis);
            this.Controls.Add(this.btnBackToResults);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.groupBoxAdditional);
            this.Controls.Add(this.groupBoxVariableColumn);
            this.Controls.Add(this.groupBoxConstraint);
            this.Controls.Add(this.groupBoxBasic);
            this.Controls.Add(this.groupBoxNonBasic);
            this.Name = "SensitivityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sensitivity Analysis";
            this.groupBoxNonBasic.ResumeLayout(false);
            this.groupBoxNonBasic.PerformLayout();
            this.groupBoxBasic.ResumeLayout(false);
            this.groupBoxBasic.PerformLayout();
            this.groupBoxConstraint.ResumeLayout(false);
            this.groupBoxConstraint.PerformLayout();
            this.groupBoxVariableColumn.ResumeLayout(false);
            this.groupBoxVariableColumn.PerformLayout();
            this.groupBoxAdditional.ResumeLayout(false);
            this.groupBoxAdditional.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBoxNonBasic;
        private System.Windows.Forms.Button btnApplyChangeNonBasic;
        private System.Windows.Forms.TextBox txtChangeNonBasic;
        private System.Windows.Forms.ComboBox cmbNonBasicVariables;
        private System.Windows.Forms.Label lblNonBasicVariable;

        private System.Windows.Forms.GroupBox groupBoxBasic;
        private System.Windows.Forms.Button btnApplyChangeBasic;
        private System.Windows.Forms.TextBox txtChangeBasic;
        private System.Windows.Forms.ComboBox cmbBasicVariables;
        private System.Windows.Forms.Label lblBasicVariable;

        private System.Windows.Forms.GroupBox groupBoxConstraint;
        private System.Windows.Forms.Button btnApplyChangeConstraint;
        private System.Windows.Forms.TextBox txtChangeConstraint;
        private System.Windows.Forms.ComboBox cmbConstraints;
        private System.Windows.Forms.Label lblConstraint;

        private System.Windows.Forms.GroupBox groupBoxVariableColumn;
        private System.Windows.Forms.Button btnApplyChangeVariableColumn;
        private System.Windows.Forms.TextBox txtChangeVariableColumn;
        private System.Windows.Forms.ComboBox cmbVariableColumns;
        private System.Windows.Forms.Label lblVariableColumn;

        private System.Windows.Forms.GroupBox groupBoxAdditional;
        private System.Windows.Forms.Button btnAddNewActivity;
        private System.Windows.Forms.Button btnAddNewConstraint;
        private System.Windows.Forms.Button btnDisplayShadowPrices;
        private System.Windows.Forms.Button btnApplyDuality;

        private System.Windows.Forms.Label lblResults;

        private System.Windows.Forms.Button btnApplyAnalysis;
        private System.Windows.Forms.Button btnBackToResults;
        private System.Windows.Forms.TextBox txtAdditionalOptions;
    }
}