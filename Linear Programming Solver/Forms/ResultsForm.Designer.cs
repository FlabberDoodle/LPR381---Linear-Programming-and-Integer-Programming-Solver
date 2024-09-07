namespace Linear_Programming_Solver
{
    partial class ResultsForm
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
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.btnPerformSensitivity = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.rtbResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.Location = new System.Drawing.Point(465, 341);
            this.btnSaveResults.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(112, 24);
            this.btnSaveResults.TabIndex = 1;
            this.btnSaveResults.Text = "Save Results";
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // btnPerformSensitivity
            // 
            this.btnPerformSensitivity.Location = new System.Drawing.Point(232, 341);
            this.btnPerformSensitivity.Margin = new System.Windows.Forms.Padding(2);
            this.btnPerformSensitivity.Name = "btnPerformSensitivity";
            this.btnPerformSensitivity.Size = new System.Drawing.Size(112, 24);
            this.btnPerformSensitivity.TabIndex = 2;
            this.btnPerformSensitivity.Text = "Perform Sensitivity Analysis";
            this.btnPerformSensitivity.UseVisualStyleBackColor = true;
            this.btnPerformSensitivity.Click += new System.EventHandler(this.btnPerformSensitivity_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(9, 341);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 24);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // rtbResults
            // 
            this.rtbResults.Location = new System.Drawing.Point(9, 12);
            this.rtbResults.Name = "rtbResults";
            this.rtbResults.Size = new System.Drawing.Size(567, 324);
            this.rtbResults.TabIndex = 4;
            this.rtbResults.Text = "";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 375);
            this.Controls.Add(this.rtbResults);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPerformSensitivity);
            this.Controls.Add(this.btnSaveResults);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.Button btnPerformSensitivity;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RichTextBox rtbResults;
    }
}