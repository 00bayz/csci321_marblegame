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
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenOFD();
        }

        private void OpenOFD()
        {
            using (CustomOFDForm Ofd = new CustomOFDForm())
            {
                if (Ofd.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("OK");
                    Console.WriteLine(Ofd.GamePath);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
