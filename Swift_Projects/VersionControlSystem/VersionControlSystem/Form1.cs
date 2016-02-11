using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionControlSystem.VCSEngine;
using System.Security.AccessControl;

namespace VersionControlSystem
{
    public partial class Form1 : Form
    {
        private Engine engine;
        public Form1()
        {
            InitializeComponent();
            engine = new Engine();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            engine.GetFileFromDirectory();
        }

        private void buttonRegisterUser_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            engine.ListRegisterUser();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.buttonCheck_In.Enabled = false;
            engine.ListRegisterUser();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void buttonLatesVersion_Click(object sender, EventArgs e)
        {
            engine.currentFileName = engine.GetFileNameFromDirectory();
            string file = engine.GetLatestVersion();

            this.textFile.Text = file;
            string fileContent = engine.GetFileContentOfDirectory(engine.savePath + @"\" + engine.currentFileName).Trim();
            if (Equals(file, fileContent))
            {
                MessageBox.Show("The file is up to date");
            }
            else
            {
                engine.DeleteFile();

                string path = engine.savePath + @"\" + engine.currentFileName;

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(file);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string file = "";
            engine.AddFileToVCS();
            this.InvokeOrExecute(textFile, () => { file = textFile.Text; });
            this.InvokeOrExecute(textFile, () => engine.SaveFileInDirectory(file));

        }

        private void buttonCheck_Out_Click(object sender, EventArgs e)
        {
            engine.CheckOut();
        }

        private void textBoxComments_TextChanged(object sender, EventArgs e)
        {
            this.buttonCheck_In.Enabled = true;
        }

        private void buttonCheck_In_Click(object sender, EventArgs e)
        {
            engine.CheckIn();
            //var task = Task.Run(() => engine.CheckIn());
            //task.Wait();

        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            engine.LockTextBox();
        }

        private void InvokeOrExecute(Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}

