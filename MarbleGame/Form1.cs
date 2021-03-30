using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MarbleGame
{
    public partial class Game : Form
    {
        private string GamePath = null;
        private Image GameImage;
        private string[] DataLines;
        private int Dimension;
        private int Balls;
        private int Holes;
        private int Walls;
        private GridItem[,] GameBoardItems;
        private TableLayoutPanel GameBoardLayout;
        private TableLayoutPanel GameBoardGridLayout;
        private float AspectRatio;
        private const int WidthHeightDiff = 317;
        private int PrevWidth;
        private int PrevHeight;
        private const int EmptyXY = 0;
        private const int HoleXY = 2;
        private const int BallXY = 4;
        private const int ErrXY = 6;
        private List<LeaderBoardItem> ExistingLeaderList;
        private string CurrLeaderName = null;

        public Game()
        {
            InitializeComponent();
            ExistingLeaderList = new List<LeaderBoardItem>();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenOFD();
            if (GamePath != null)
            {
                LoadGameData();
                EnableControls();
                ClearMainLayout();
                CalculateAspectRatio();
                CreateGameBoardLayout();
                CreateGameBoardGrid();
                CreateGridItemsList();
                AssignGameItems();
                RenderGridItems();
                RenderWalls();
            }
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
            DataLines = System.IO.File.ReadAllLines(DataPath);
            string[] Counts = DataLines[0].Split(' ');
            Dimension = Convert.ToInt32(Counts[0]);
            Balls = Convert.ToInt32(Counts[1]);
            Holes = Balls;
            Walls = Convert.ToInt32(Counts[2]);
        }

        private void RenderGridItems()
        {
            float GridItemWidth = GameBoardLayout.Width / Dimension;
            float GridItemHeight = GameBoardLayout.Height / Dimension;
            float ImageItemWidth = GameImage.Width / 7;
            float ImageItemHeight = GameImage.Height / 7;

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    GridItem Item = GameBoardItems[i, j];

                    Bitmap BMap = new Bitmap((int)GridItemWidth, (int)GridItemHeight);
                    Rectangle Rect = new Rectangle(0, 0, (int)GridItemWidth, (int)GridItemHeight);

                    if (Item.Item == 0)
                    {
                        using (Graphics G = Graphics.FromImage(BMap))
                        {
                            G.DrawImage(GameImage, Rect, ImageItemWidth * EmptyXY, ImageItemHeight * EmptyXY, ImageItemWidth, ImageItemHeight, GraphicsUnit.Pixel);
                        }
                    }
                    else if (Item.Item == 1)
                    {
                        Font FontArial = new Font("Arial", 24.0f);
                        Brush BrushYellow = new SolidBrush(Color.Yellow);
                        StringFormat SF = new StringFormat();
                        SF.LineAlignment = StringAlignment.Center;
                        SF.Alignment = StringAlignment.Center;
                        string Text = Item.BallNum.ToString();
                        using (Graphics G = Graphics.FromImage(BMap))
                        {
                            G.DrawImage(GameImage, Rect, ImageItemWidth * BallXY, ImageItemHeight * BallXY, ImageItemWidth, ImageItemHeight, GraphicsUnit.Pixel);
                            G.DrawString(Text, FontArial, BrushYellow, Rect, SF);
                        }
                    }
                    else if (Item.Item == 2)
                    {
                        Font FontArial = new Font("Arial", 24.0f);
                        Brush BrushYellow = new SolidBrush(Color.Yellow);
                        StringFormat SF = new StringFormat();
                        SF.LineAlignment = StringAlignment.Center;
                        SF.Alignment = StringAlignment.Center;
                        string Text = Item.HoleNum.ToString();
                        using (Graphics G = Graphics.FromImage(BMap))
                        {
                            G.DrawImage(GameImage, Rect, ImageItemWidth * HoleXY, ImageItemHeight * HoleXY, ImageItemWidth, ImageItemHeight, GraphicsUnit.Pixel);
                            G.DrawString(Text, FontArial, BrushYellow, Rect, SF);
                        }
                    }

                    Item.Image = BMap;
                    Item.Dock = System.Windows.Forms.DockStyle.Fill;
                    GameBoardGridLayout.Controls.Add(Item, j, i);
                }
            }
        }

        private void RenderWalls()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    GridItem Item = GameBoardItems[i, j];
                    PointF TopLeft = new PointF(0, 0);
                    PointF TopRight = new PointF(Item.Image.Width, 0);
                    PointF BottomLeft = new PointF(0, Item.Image.Height);
                    PointF BottomRight = new PointF(Item.Image.Width, Item.Image.Height);
                    Pen PenRed = new Pen(Color.Red, 10);

                    if (Item.LeftWall == 1)
                    {
                        using (Graphics G = Graphics.FromImage(Item.Image))
                        {
                            G.DrawLine(PenRed, TopLeft, BottomLeft);
                        }
                    }

                    if (Item.RightWall == 1)
                    {
                        using (Graphics G = Graphics.FromImage(Item.Image))
                        {
                            G.DrawLine(PenRed, TopRight, BottomRight);
                        }
                    }

                    if (Item.TopWall == 1)
                    {
                        using (Graphics G = Graphics.FromImage(Item.Image))
                        {
                            G.DrawLine(PenRed, TopLeft, TopRight);
                        }
                    }

                    if (Item.BottomWall == 1)
                    {
                        using (Graphics G = Graphics.FromImage(Item.Image))
                        {
                            G.DrawLine(PenRed, BottomRight, BottomLeft);
                        }
                    }
                }
            }
        }

        private void AssignGameItems() // balls, holes, and walls (three loops)
        {
            AssignBalls();
            AssignHoles();
            AssignWalls();
        }

        private void CreateGridItemsList()
        {
            GameBoardItems = new GridItem[Dimension, Dimension];
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    GameBoardItems[i, j] = new GridItem();
                    GameBoardItems[i, j].Row = i;
                    GameBoardItems[i, j].Col = j;
                    GameBoardItems[i, j].Item = 0;
                    GameBoardItems[i, j].WallCount = 0;
                    GameBoardItems[i, j].LeftWall = 0;
                    GameBoardItems[i, j].TopWall = 0;
                    GameBoardItems[i, j].RightWall = 0;
                    GameBoardItems[i, j].BottomWall = 0;
                    GameBoardItems[i, j].BallNum = 0;
                    GameBoardItems[i, j].HoleNum = 0;
                    GameBoardItems[i, j].Name = $"Grid{i}{j}";
                    GameBoardItems[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    GameBoardItems[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    GameBoardItems[i, j].Margin = new System.Windows.Forms.Padding(0);
                }
            }
        }

        private void CreateGameBoardGrid()
        {
            GameBoardGridLayout = new TableLayoutPanel();
            float ColumnWidthPercent = 100F / Dimension;
            float RowHeightPercent = 100F / Dimension;
            GameBoardGridLayout.ColumnCount = Dimension;
            GameBoardGridLayout.RowCount = Dimension;
            for (int i = 0; i < Dimension; i++)
            {
                GameBoardGridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, ColumnWidthPercent));
                GameBoardGridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, RowHeightPercent));
            }
            GameBoardLayout.Controls.Add(GameBoardGridLayout, 0, 0);
            GameBoardGridLayout.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void CreateGameBoardLayout()
        {
            GameBoardLayout = new TableLayoutPanel();
            if (GameImage.Width > GameImage.Height) // 2 rows (Top Row will contain game board)
            {
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
                float GameBoardColumnPercent = AspectRatio * 100F;
                float UnusedColumnPercent = 100F - GameBoardColumnPercent;
                GameBoardLayout.ColumnCount = 2;
                GameBoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, GameBoardColumnPercent));
                GameBoardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, UnusedColumnPercent));
                GameBoardLayout.RowCount = 1;
                GameBoardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                
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

        private void AssignBalls()
        {
            for (int i = 1; i <= Balls; i++)
            {
                string[] Coords = DataLines[i].Split(' ');
                int Row = Convert.ToInt32(Coords[0]);
                int Col = Convert.ToInt32(Coords[1]);
                GameBoardItems[Row, Col].BallNum = i;
                GameBoardItems[Row, Col].Item = 1;
            }
        }

        private void AssignHoles()
        {
            for (int i = Balls + 1; i <= (Balls * 2); i++)
            {
                string[] Coords = DataLines[i].Split(' ');
                int Row = Convert.ToInt32(Coords[0]);
                int Col = Convert.ToInt32(Coords[1]);
                GameBoardItems[Row, Col].HoleNum = i - Balls;
                GameBoardItems[Row, Col].Item = 2;
            }
        }

        private void AssignWalls()
        {
            for (int i = (Balls * 2) + 1; i <= (Balls * 2) + Walls; i++)
            {
                string[] Coords = DataLines[i].Split(' ');
                int Row1 = Convert.ToInt32(Coords[0]);
                int Col1 = Convert.ToInt32(Coords[1]);
                int Row2 = Convert.ToInt32(Coords[2]);
                int Col2 = Convert.ToInt32(Coords[3]);
                GridItem GridItemA = GameBoardItems[Row1, Col1];
                GridItem GridItemB = GameBoardItems[Row2, Col2];
                GridItemA.WallCount++;
                GridItemB.WallCount++;
                
                if (Row1 == Row2) // same row
                {
                    if (Col1 > Col2)
                    {
                        GridItemA.LeftWall = 1;
                        GridItemB.RightWall = 1;
                    }
                    else
                    {
                        GridItemA.RightWall = 1;
                        GridItemB.LeftWall = 1;
                    }
                }
                else // same column
                {
                    if (Row1 > Row2)
                    {
                        GridItemA.TopWall = 1;
                        GridItemB.BottomWall = 1;
                    }
                    else
                    {
                        GridItemA.BottomWall = 1;
                        GridItemB.TopWall = 1;
                    }
                }
            }
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

        private void DisableControls()
        {
            this.UpButton.Enabled = false;
            this.RightButton.Enabled = false;
            this.DownButton.Enabled = false;
            this.LeftButton.Enabled = false;
        }

        private void UpdateMeasurements()
        {
            PrevWidth = this.Width;
            PrevHeight = this.Height;
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            bool HasIncorrectHole = false;
            List<GridItem> Updates = new List<GridItem>();
            for (int row = 0; row < Dimension; row++)
            {
                for (int col = 0; col < Dimension; col++)
                {
                    GridItem Item = GameBoardItems[row, col];
                    if (Item.HasBall())
                    {
                        Updates.Add(Item);
                        int CurrRow = row;
                        GridItem CurrBox;
                        while (true)
                        {
                            CurrBox = GameBoardItems[CurrRow, col];
                            if (CurrRow <= 0)
                            {
                                break;
                            }
                            if (!CurrBox.HasTopWall()) //no wall; move
                            {
                                GridItem nextBox = GameBoardItems[CurrRow - 1, col];
                                if (HasHoleNext(nextBox)) // has hole
                                {
                                    if (nextBox.HoleNum == CurrBox.BallNum) // correct hole
                                    {
                                        CurrBox.Item = 0;
                                        CurrBox.BallNum = 0;
                                        nextBox.Item = 0;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        break;
                                    }
                                    else // incorrect hole
                                    {
                                        CurrBox.Item = -1;
                                        CurrBox.BallNum = 0;
                                        nextBox.Item = -1;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        HasIncorrectHole = true;
                                        break;
                                    }
                                }
                                else if (nextBox.Item == 0) //empty
                                {
                                    nextBox.Item = 1;
                                    nextBox.BallNum = CurrBox.BallNum;
                                    CurrBox.Item = 0;
                                    CurrBox.BallNum = 0;
                                    CurrRow--;
                                }
                                else if (nextBox.Item == 1) // has ball
                                {
                                    break;
                                }
                            }
                            else // wall on bottom
                            {
                                break;
                            }
                        }
                        Updates.Add(CurrBox);
                    }
                }
            }
            RenderUpdates(Updates);
            if (HasIncorrectHole)
            {
                GameOver();
            }
            else
            {
                ValidateWin();
            }            
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            bool HasIncorrectHole = false;
            List<GridItem> Updates = new List<GridItem>();
            for (int col = Dimension - 2; col >= 0; col--)
            {
                for (int row = 0; row < Dimension; row++)
                {
                    GridItem box = GameBoardItems[row, col];
                    if (box.HasBall())
                    {
                        Updates.Add(box);
                        int currCol = col;
                        GridItem currBox;
                        while (true)
                        {
                            currBox = GameBoardItems[row, currCol];
                            if (currCol >= Dimension - 1)
                            {
                                break;
                            }
                            if (!currBox.HasRightWall()) //no wall; move
                            {
                                GridItem nextBox = GameBoardItems[row, currCol + 1];
                                if (HasHoleNext(nextBox)) // has hole
                                {
                                    if (nextBox.HoleNum == currBox.BallNum) // correct hole
                                    {
                                        currBox.Item = 0;
                                        currBox.BallNum = 0;
                                        nextBox.Item = 0;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        break;
                                    }
                                    else // incorrect hole
                                    {
                                        currBox.Item = -1;
                                        currBox.BallNum = 0;
                                        nextBox.Item = -1;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        HasIncorrectHole = true;
                                        break;
                                    }
                                }
                                else if (nextBox.Item == 0) //empty
                                {
                                    nextBox.Item = 1;
                                    nextBox.BallNum = currBox.BallNum;
                                    currBox.Item = 0;
                                    currBox.BallNum = 0;
                                    currCol++;
                                }
                                else if (nextBox.Item == 1) // has ball
                                {
                                    break;
                                }
                            }
                            else // wall on bottom
                            {
                                break;
                            }
                        }
                        Updates.Add(currBox);
                    }
                }
            }
            RenderUpdates(Updates);
            if (HasIncorrectHole)
            {
                GameOver();
            }
            else
            {
                ValidateWin();
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            bool HasIncorrectHole = false;
            List<GridItem> Updates = new List<GridItem>();
            for (int row = Dimension - 2; row >= 0; row--)
            {
                for (int col = 0; col < Dimension; col++)
                {
                    GridItem box = GameBoardItems[row, col];
                    if (box.HasBall())
                    {
                        Updates.Add(box);
                        int currRow = row;
                        GridItem currBox;
                        while (true)
                        {
                            currBox = GameBoardItems[currRow, col];
                            if (currRow >= Dimension - 1)
                            {
                                break;
                            }
                            if (!currBox.HasBottomWall()) //no wall; move
                            {
                                GridItem nextBox = GameBoardItems[currRow + 1, col];
                                if (HasHoleNext(nextBox)) // has hole
                                {
                                    if (nextBox.HoleNum == currBox.BallNum) // correct hole
                                    {
                                        currBox.Item = 0;
                                        currBox.BallNum = 0;
                                        nextBox.Item = 0;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        break;
                                    }
                                    else // incorrect hole
                                    {
                                        currBox.Item = -1;
                                        currBox.BallNum = 0;
                                        nextBox.Item = -1;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        HasIncorrectHole = true;
                                        break;
                                    }
                                }
                                else if (nextBox.Item == 0) //empty
                                {
                                    nextBox.Item = 1;
                                    nextBox.BallNum = currBox.BallNum;
                                    currBox.Item = 0;
                                    currBox.BallNum = 0;
                                    currRow++;
                                }
                                else if (nextBox.Item == 1) // has ball
                                {
                                    break;
                                }
                            }
                            else // wall on bottom
                            {
                                break;
                            }
                        }
                        Updates.Add(currBox);
                    }
                }
            }
            RenderUpdates(Updates);
            if (HasIncorrectHole)
            {
                GameOver();
            }
            else
            {
                ValidateWin();
            }
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            bool HasIncorrectHole = false;
            List<GridItem> Updates = new List<GridItem>();
            for (int col = 1; col < Dimension; col++)
            {
                for (int row = 0; row < Dimension; row++)
                {
                    GridItem box = GameBoardItems[row, col];
                    if (box.HasBall())
                    {
                        Updates.Add(box);
                        int currCol = col;
                        GridItem currBox;
                        while (true)
                        {
                            currBox = GameBoardItems[row, currCol];
                            if (currCol <= 0)
                            {
                                break;
                            }
                            if (!currBox.HasLeftWall()) //no wall; move
                            {
                                GridItem nextBox = GameBoardItems[row, currCol - 1];
                                if (HasHoleNext(nextBox)) // has hole
                                {
                                    if (nextBox.HoleNum == currBox.BallNum) // correct hole
                                    {
                                        currBox.Item = 0;
                                        currBox.BallNum = 0;
                                        nextBox.Item = 0;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        break;
                                    }
                                    else // incorrect hole
                                    {
                                        currBox.Item = -1;
                                        currBox.BallNum = 0;
                                        nextBox.Item = -1;
                                        nextBox.HoleNum = 0;
                                        Updates.Add(nextBox);
                                        HasIncorrectHole = true;
                                        break;
                                    }
                                }
                                else if (nextBox.Item == 0) //empty
                                {
                                    nextBox.Item = 1;
                                    nextBox.BallNum = currBox.BallNum;
                                    currBox.Item = 0;
                                    currBox.BallNum = 0;
                                    currCol--;
                                }
                                else if (nextBox.Item == 1) // has ball
                                {
                                    break;
                                }
                            }
                            else // wall on bottom
                            {
                                break;
                            }
                        }
                        Updates.Add(currBox);
                    }
                }
            }
            RenderUpdates(Updates);
            if (HasIncorrectHole)
            {
                GameOver();
            }
            else
            {
                ValidateWin();
            }
        }

        private void RenderUpdates(List<GridItem> UpdatesList)
        {
            for (int i = 0; i < UpdatesList.Count; i++)
            {
                GridItem Item = UpdatesList[i];
                float ImageItemWidth = GameImage.Width / 7;
                float ImageItemHeight = GameImage.Height / 7;

                Bitmap BMap = new Bitmap(Item.Width, Item.Height);
                Rectangle Rect = new Rectangle(0, 0, Item.Width, Item.Height);

                if (Item.Item == 0)
                {
                    using (Graphics G = Graphics.FromImage(BMap))
                    {
                        G.DrawImage(GameImage, Rect, ImageItemWidth * EmptyXY, ImageItemHeight * EmptyXY, ImageItemWidth, ImageItemHeight, GraphicsUnit.Pixel);
                    }
                }
                else if (Item.Item == 1)
                {
                    Font FontArial = new Font("Arial", 24.0f);
                    Brush BrushYellow = new SolidBrush(Color.Yellow);
                    StringFormat SF = new StringFormat();
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    string Text = Item.BallNum.ToString();
                    using (Graphics G = Graphics.FromImage(BMap))
                    {
                        G.DrawImage(GameImage, Rect, ImageItemWidth * BallXY, ImageItemHeight * BallXY, ImageItemWidth, ImageItemHeight, GraphicsUnit.Pixel);
                        G.DrawString(Text, FontArial, BrushYellow, Rect, SF);
                    }
                }
                else if (Item.Item == 2)
                {
                    Font FontArial = new Font("Arial", 24.0f);
                    Brush BrushYellow = new SolidBrush(Color.Yellow);
                    StringFormat SF = new StringFormat();
                    SF.LineAlignment = StringAlignment.Center;
                    SF.Alignment = StringAlignment.Center;
                    string Text = Item.HoleNum.ToString();
                    using (Graphics G = Graphics.FromImage(BMap))
                    {
                        G.DrawImage(GameImage, Rect, ImageItemWidth * HoleXY, ImageItemHeight * HoleXY, ImageItemWidth, ImageItemHeight, GraphicsUnit.Pixel);
                        G.DrawString(Text, FontArial, BrushYellow, Rect, SF);
                    }
                }
                else if (Item.Item == -1)
                {
                    using (Graphics G = Graphics.FromImage(BMap))
                    {
                        G.DrawImage(GameImage, Rect, ImageItemWidth * ErrXY, ImageItemHeight * ErrXY, ImageItemWidth, ImageItemHeight, GraphicsUnit.Pixel);
                    }
                }
                Item.Image = BMap;
            }
            RenderWalls();
        }

        private bool HasHoleNext(GridItem Item)
        {
            return Item.HoleNum > 0;
        }

        private void GameOver()
        {
            DisableControls();
            MessageBox.Show("Game Over");
        }

        private void ValidateWin()
        {      
            // Check win condition
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    if (GameBoardItems[i, j].Item != 0)
                    {
                        return;
                    }
                }
            }

            LoadButton.Enabled = true;
            DisableControls();
            MessageBox.Show("You Won!");
            OpenLeaderNameForm();

        }

        private void OpenLeaderNameForm()
        {
            using (LeaderNameForm NameForm = new LeaderNameForm())
            {
                if (NameForm.ShowDialog() == DialogResult.OK)
                {
                    CurrLeaderName = NameForm.LeaderName;
                    Console.WriteLine(CurrLeaderName);
                }
                else
                {
                    return;
                }
            }
        }
    }
    
}
