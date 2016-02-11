using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionControlSystem.VCSEngine;

namespace VersionControlSystem
{
    public partial class Form2 : Form
    {
        private Engine engine;

        public Form2()
        {
            InitializeComponent();
            engine = new Engine();
        }

        private void buttonDiff_Click(object sender, EventArgs e)
        {
            engine.ShowDifferenceBetweenTwoFile();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            engine.FillDataInRichTextBox();
        }
    }
}

