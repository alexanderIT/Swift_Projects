namespace VersionControlSystem
{
    partial class Form2
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
            this.labelCurrentversionOfFile = new System.Windows.Forms.Label();
            this.labelLastFileversion = new System.Windows.Forms.Label();
            this.richTextBoxLastVersion = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCurrentVersion = new System.Windows.Forms.RichTextBox();
            this.buttonDiff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCurrentversionOfFile
            // 
            this.labelCurrentversionOfFile.AutoSize = true;
            this.labelCurrentversionOfFile.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentversionOfFile.Name = "labelCurrentversionOfFile";
            this.labelCurrentversionOfFile.Size = new System.Drawing.Size(106, 13);
            this.labelCurrentversionOfFile.TabIndex = 1;
            this.labelCurrentversionOfFile.Text = "Current version of file";
            // 
            // labelLastFileversion
            // 
            this.labelLastFileversion.AutoSize = true;
            this.labelLastFileversion.Location = new System.Drawing.Point(366, 9);
            this.labelLastFileversion.Name = "labelLastFileversion";
            this.labelLastFileversion.Size = new System.Drawing.Size(92, 13);
            this.labelLastFileversion.TabIndex = 1;
            this.labelLastFileversion.Text = "Last version of file";
            // 
            // richTextBoxLastVersion
            // 
            this.richTextBoxLastVersion.Location = new System.Drawing.Point(369, 25);
            this.richTextBoxLastVersion.Name = "richTextBoxLastVersion";
            this.richTextBoxLastVersion.Size = new System.Drawing.Size(298, 472);
            this.richTextBoxLastVersion.TabIndex = 3;
            this.richTextBoxLastVersion.Text = "";
            // 
            // richTextBoxCurrentVersion
            // 
            this.richTextBoxCurrentVersion.Location = new System.Drawing.Point(12, 25);
            this.richTextBoxCurrentVersion.Name = "richTextBoxCurrentVersion";
            this.richTextBoxCurrentVersion.Size = new System.Drawing.Size(298, 472);
            this.richTextBoxCurrentVersion.TabIndex = 3;
            this.richTextBoxCurrentVersion.Text = "";
            // 
            // buttonDiff
            // 
            this.buttonDiff.Location = new System.Drawing.Point(303, 519);
            this.buttonDiff.Name = "buttonDiff";
            this.buttonDiff.Size = new System.Drawing.Size(75, 23);
            this.buttonDiff.TabIndex = 4;
            this.buttonDiff.Text = "Show Diff";
            this.buttonDiff.UseVisualStyleBackColor = true;
            this.buttonDiff.Click += new System.EventHandler(this.buttonDiff_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 554);
            this.Controls.Add(this.buttonDiff);
            this.Controls.Add(this.richTextBoxCurrentVersion);
            this.Controls.Add(this.richTextBoxLastVersion);
            this.Controls.Add(this.labelLastFileversion);
            this.Controls.Add(this.labelCurrentversionOfFile);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCurrentversionOfFile;
        private System.Windows.Forms.Label labelLastFileversion;
        private System.Windows.Forms.RichTextBox richTextBoxLastVersion;
        private System.Windows.Forms.RichTextBox richTextBoxCurrentVersion;
        private System.Windows.Forms.Button buttonDiff;
    }
}