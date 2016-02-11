namespace VersionControlSystem
{
    partial class Form1
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
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelFile = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCheck_In = new System.Windows.Forms.Button();
            this.buttonCheck_Out = new System.Windows.Forms.Button();
            this.buttonLatesVersion = new System.Windows.Forms.Button();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonRegisterUser = new System.Windows.Forms.Button();
            this.textFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(111, 5);
            this.comboBoxUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(196, 24);
            this.comboBoxUsers.TabIndex = 0;
            this.comboBoxUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsers_SelectedIndexChanged);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(57, 8);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(46, 17);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "User :";
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(38, 73);
            this.labelFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(65, 17);
            this.labelFile.TabIndex = 3;
            this.labelFile.Text = "NewFile :";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(663, 31);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(145, 28);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add_To_VCS";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCheck_In
            // 
            this.buttonCheck_In.Location = new System.Drawing.Point(315, 33);
            this.buttonCheck_In.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCheck_In.Name = "buttonCheck_In";
            this.buttonCheck_In.Size = new System.Drawing.Size(156, 28);
            this.buttonCheck_In.TabIndex = 4;
            this.buttonCheck_In.Text = "Check_In";
            this.buttonCheck_In.UseVisualStyleBackColor = true;
            this.buttonCheck_In.Click += new System.EventHandler(this.buttonCheck_In_Click);
            // 
            // buttonCheck_Out
            // 
            this.buttonCheck_Out.Location = new System.Drawing.Point(520, 31);
            this.buttonCheck_Out.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCheck_Out.Name = "buttonCheck_Out";
            this.buttonCheck_Out.Size = new System.Drawing.Size(145, 28);
            this.buttonCheck_Out.TabIndex = 4;
            this.buttonCheck_Out.Text = "Check_Out";
            this.buttonCheck_Out.UseVisualStyleBackColor = true;
            this.buttonCheck_Out.Click += new System.EventHandler(this.buttonCheck_Out_Click);
            // 
            // buttonLatesVersion
            // 
            this.buttonLatesVersion.Location = new System.Drawing.Point(806, 31);
            this.buttonLatesVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLatesVersion.Name = "buttonLatesVersion";
            this.buttonLatesVersion.Size = new System.Drawing.Size(145, 28);
            this.buttonLatesVersion.TabIndex = 4;
            this.buttonLatesVersion.Text = "Get_Latest_Version";
            this.buttonLatesVersion.UseVisualStyleBackColor = true;
            this.buttonLatesVersion.Click += new System.EventHandler(this.buttonLatesVersion_Click);
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(111, 37);
            this.textBoxComments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(196, 22);
            this.textBoxComments.TabIndex = 5;
            this.textBoxComments.TextChanged += new System.EventHandler(this.textBoxComments_TextChanged);
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(21, 39);
            this.labelComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(82, 17);
            this.labelComment.TabIndex = 6;
            this.labelComment.Text = "Comments :";
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(949, 31);
            this.buttonCompare.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(215, 28);
            this.buttonCompare.TabIndex = 7;
            this.buttonCompare.Text = "Compare_With_Latest_Version";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(1160, 31);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(145, 28);
            this.buttonBrowse.TabIndex = 8;
            this.buttonBrowse.Text = "Browse_File";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonRegisterUser
            // 
            this.buttonRegisterUser.Location = new System.Drawing.Point(315, 0);
            this.buttonRegisterUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRegisterUser.Name = "buttonRegisterUser";
            this.buttonRegisterUser.Size = new System.Drawing.Size(156, 28);
            this.buttonRegisterUser.TabIndex = 10;
            this.buttonRegisterUser.Text = "Register New User";
            this.buttonRegisterUser.UseVisualStyleBackColor = true;
            this.buttonRegisterUser.Click += new System.EventHandler(this.buttonRegisterUser_Click);
            // 
            // textFile
            // 
            this.textFile.Location = new System.Drawing.Point(111, 70);
            this.textFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textFile.Multiline = true;
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(1198, 473);
            this.textFile.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 561);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.buttonRegisterUser);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.buttonLatesVersion);
            this.Controls.Add(this.buttonCheck_Out);
            this.Controls.Add(this.buttonCheck_In);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Version Control System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCheck_In;
        private System.Windows.Forms.Button buttonCheck_Out;
        private System.Windows.Forms.Button buttonLatesVersion;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonRegisterUser;
        private System.Windows.Forms.TextBox textFile;
    }
}

