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
    public partial class Form3 : Form
    {
        private Engine engine;
        public Form3()
        {
            InitializeComponent();
            engine = new Engine();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            engine.RegisterNewUser();
            this.Close();
        }

    }
}
