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
        private string GamePath;
        private Image GameImage;
        private int Dimension;
        private int Balls;
        private int Holes;
        private int Walls;
        private const int WidthHeightDiff = 317;
        private int PrevWidth;
        private int PrevHeight;

        public Game()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenOFD();
            LoadGameData();
        }

        private void OpenOFD()
        {
            using (CustomOFDForm Ofd = new CustomOFDForm())
            {
                if (Ofd.ShowDialog() == DialogResult.OK)
                {
                    GamePath = Ofd.GamePath;
                }
                else
                {
                    return;
                }
            }
        }

        private void LoadGameData()
        {
            string ImagePath = $"{GamePath}\\puzzle.jpg";
            string DataPath = $"{GamePath}\\puzzle.txt";
            //TODO: Clear gameboard
            GameImage = Image.FromFile(ImagePath);
            string[] Lines = System.IO.File.ReadAllLines(DataPath);
            string[] Counts = Lines[0].Split(' ');
            Dimension = Convert.ToInt32(Counts[0]);
            Balls = Convert.ToInt32(Counts[1]);
            Holes = Balls;
            Walls = Convert.ToInt32(Counts[2]);
        }

        private void Game_ResizeEnd(object sender, EventArgs e)
        {
            // Find difference between current width and height
            int dw = Math.Abs(PrevWidth - this.Width);
            int dh = Math.Abs(PrevHeight - this.Height);

            // Account for difference
            if (dw > dh)
            {
                this.Height = this.Width - WidthHeightDiff;
            }
            else
            {
                this.Width = this.Height + WidthHeightDiff;
            }

            // Update Measurements
            UpdateMeasurements();
        }

        private void EnableControls()
        {
            this.UpButton.Enabled = true;
            this.RightButton.Enabled = true;
            this.DownButton.Enabled = true;
            this.LeftButton.Enabled = true;
        }

        private void UpdateMeasurements()
        {
            PrevWidth = this.Width;
            PrevHeight = this.Height;
        }
    }
}
