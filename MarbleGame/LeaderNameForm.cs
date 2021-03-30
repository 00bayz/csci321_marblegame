using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarbleGame
{
    public partial class LeaderNameForm : Form
    {
        public string LeaderName = null;
        public LeaderNameForm()
        {
            InitializeComponent();
        }

        private void LeaderNameBtn_Click(object sender, EventArgs e)
        {
            if (LeaderNameTextBox.Text.Length > 0)
            {
                LeaderName = LeaderNameTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void LeaderNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LeaderName = "Anonymous";
            this.DialogResult = DialogResult.OK;
        }
    }
}
