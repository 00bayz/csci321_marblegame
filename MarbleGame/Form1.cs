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
        private float AspectRatio;
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
            EnableControls();
            ClearMainLayout();
            CreateGameBoardLayout();
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
            GameImage = Image.FromFile(ImagePath);
            string[] Lines = System.IO.File.ReadAllLines(DataPath);
            string[] Counts = Lines[0].Split(' ');
            Dimension = Convert.ToInt32(Counts[0]);
            Balls = Convert.ToInt32(Counts[1]);
            Holes = Balls;
            Walls = Convert.ToInt32(Counts[2]);
        }

        private void CreateGameBoardLayout()
        {
            TableLayoutPanel GameBoardLayout = new TableLayoutPanel();
            CalculateAspectRatio();
            if (GameImage.Width > GameImage.Height) // 2 rows
            {
                Console.WriteLine("Wide Aspect Ratio - Create 2 Rows");
                Console.WriteLine(AspectRatio);
                float GameBoardRowPercent = AspectRatio * 100F;
                float UnusedRowPercent = 100F - GameBoardRowPercent;
                GameBoardLayout.ColumnCount = 1;
                GameBoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
                GameBoardLayout.RowCount = 2;
                GameBoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, GameBoardRowPercent));
                GameBoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, UnusedRowPercent));
            }
            else // 2 columns (Left Column will contain game board)
            {
                Console.WriteLine("Tall Aspect Ratio - Create 2 Columns");
                Console.WriteLine(AspectRatio);
                float GameBoardColumnPercent = AspectRatio * 100F;
                float UnusedColumnPercent = 100F - GameBoardColumnPercent;
                GameBoardLayout.ColumnCount = 2;
                GameBoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, GameBoardColumnPercent));
                GameBoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, UnusedColumnPercent));
                GameBoardLayout.RowCount = 1;
                GameBoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
                
            }
            MainLayout.Controls.Add(GameBoardLayout, 0, 0);
            GameBoardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void ClearMainLayout()
        {
            MainLayout.Controls.Remove(MainLayout.GetControlFromPosition(0, 0));
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

        private void CalculateAspectRatio()
        {
            if (GameImage.Width > GameImage.Height) // Wide Aspect
            {
                AspectRatio = (float)GameImage.Height / (float)GameImage.Width;
            }
            else // Square or Tall Aspects
            {
                AspectRatio = (float)GameImage.Width / (float)GameImage.Height;
            }
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
