using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace MarbleGame
{
    public partial class CustomOFDForm : Form
    {
        private string CurrentPath = null;
        private string TempPath = null;
        public string GamePath = null;

        public CustomOFDForm()
        {
            InitializeComponent();
            ClearLabels();
            CurrentPath = System.Environment.CurrentDirectory;
            UpdatePathDisplay(CurrentPath);
            PopulateListView();
        }

        private void OFDFilePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string PathEntered = OFDFilePath.Text;
                try
                {
                    if (System.IO.Directory.Exists(PathEntered))
                    {
                        GoTo(PathEntered);
                    }
                    else
                    {
                        MessageBox.Show("Destination Does Not Exist");
                    }
                }
                catch (NullReferenceException)
                {
                    UpdatePathDisplay(CurrentPath);
                    PopulateListView();
                    MessageBox.Show("Invalid Path");
                }
                catch (System.UnauthorizedAccessException)
                {
                    UpdatePathDisplay(CurrentPath);
                    PopulateListView();
                    MessageBox.Show("Unauthorized Access");
                }
            }
        }

        private void OFDItem_Single_Click(object sender, MouseEventArgs e)
        {
            ListViewItem Item = this.OFDListView.SelectedItems[0];
            string SelectedName = Item.Text;
            string SelectedType = Item.SubItems[2].Text;
            string FullPath = $"{CurrentPath}\\{SelectedName}";
            UpdatePathDisplay(FullPath);

            if (SelectedType == ".mrb")
            {
                ExtractMrb(FullPath);
                GenMrbPreview();
                GenMrbLabels();
            }
            else
            {
                if (OFDPreview.Image != null)
                {
                    ClearPreview();
                    ClearLabels();
                }
            }
        }

        private void OFDItem_Double_Click(object sender, MouseEventArgs e)
        {
            ListViewItem Item = this.OFDListView.SelectedItems[0];
            string SelectedName = Item.Text;
            string SelectedType = Item.SubItems[2].Text;
            string FullPath = $"{CurrentPath}\\{SelectedName}";

            if (SelectedType == ".mrb")
            {
                this.DialogResult = DialogResult.OK;
                ExtractMrb(FullPath);
                SetGamePath();
                this.Close();
            }
            else if (SelectedType == "File Folder")
            {
                try
                {
                    GoTo(FullPath);
                }
                catch (System.UnauthorizedAccessException)
                {
                    UpdatePathDisplay(CurrentPath);
                    PopulateListView();
                    MessageBox.Show("Unauthorized access");
                }
            }

            UpdatePathDisplay(FullPath);
        }

        private void OFDLoadButton_Click(object sender, EventArgs e)
        {
            if (this.OFDListView.SelectedItems.Count > 0)
            {
                ListViewItem Item = this.OFDListView.SelectedItems[0];
                string SelectedName = Item.Text;
                string SelectedType = Item.SubItems[2].Text;
                string FullPath = $"{CurrentPath}\\{SelectedName}";

                if (SelectedType == ".mrb")
                {
                    this.DialogResult = DialogResult.OK;
                    ExtractMrb(FullPath);
                    SetGamePath();
                    this.Close();
                }
                else if (SelectedType == "File Folder")
                {
                    try
                    {
                        GoTo(FullPath);
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                        UpdatePathDisplay(CurrentPath);
                        PopulateListView();
                        MessageBox.Show("Unauthorized access");
                    }
                }

                UpdatePathDisplay(FullPath);
            }
        }

        private void OFDPrevDirButton_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.GetParent(CurrentPath) == null)
            {
                MessageBox.Show("Invalid Path");
            }
            else
            {
                ClearPreview();
                ClearLabels();
                string ParentPath = System.IO.Directory.GetParent(CurrentPath).ToString();
                GoTo(ParentPath);
            }
        }

        private void OFDCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateListView()
        {
            string[] FilesList;
            string[] DirsList;
            try
            {
                FilesList = System.IO.Directory.GetFiles(CurrentPath);
                DirsList = System.IO.Directory.GetDirectories(CurrentPath);
            }
            catch (System.UnauthorizedAccessException)
            {
                string ParentPath = System.IO.Directory.GetParent(CurrentPath).ToString();
                UpdatePathDisplay(ParentPath);
                CurrentPath = ParentPath;
                MessageBox.Show("Unauthorized Access");
                return;
            }
            if (OFDListView.Items.Count > 0)
            {
                OFDListView.Items.Clear();
            }
            // Render Folder Icons
            for (int i = 0; i < DirsList.Length; i++)
            {
                System.IO.DirectoryInfo Info = new System.IO.DirectoryInfo(DirsList[i]);
                string Dirname = Info.Name;
                string DateMod = Info.LastWriteTime.ToString();
                string FileType = "File Folder";

                ListViewItem Item = new ListViewItem();
                Item.Text = Dirname;
                Item.SubItems.Add(DateMod);
                Item.SubItems.Add(FileType);
                Item.ImageIndex = 1;
                OFDListView.Items.Add(Item);
            }
            // Render Non-Folder Icons
            for (int i = 0; i < FilesList.Length; i++)
            {
                System.IO.FileInfo Info = new System.IO.FileInfo(FilesList[i]);
                string Filename = Info.Name;
                string Filesize = ConvertFileSize((int)Info.Length);
                string DateMod = Info.LastWriteTime.ToString();
                string FileType = System.IO.Path.GetExtension(FilesList[i]);
                int IconIndex = -1;

                ListViewItem Item = new ListViewItem();
                Item.Text = Filename;
                Item.SubItems.Add(DateMod);
                Item.SubItems.Add(FileType);
                Item.SubItems.Add(Filesize);

                if (FileType == ".mrb")
                {
                    IconIndex = 0;
                }
                else if (FileType == ".txt")
                {
                    IconIndex = 2;
                }
                else if (FileType == ".jpg")
                {
                    IconIndex = 3;
                }
                else
                {
                    IconIndex = 4;
                }
                Item.ImageIndex = IconIndex;
                OFDListView.Items.Add(Item);
            }
        }

        private void ExtractMrb(string Path)
        {
            if (TempPath != null)
            {
                RemoveTempFolder();
            }
            TempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());
            System.IO.Directory.CreateDirectory(TempPath);
            System.IO.Compression.ZipArchive mrb = System.IO.Compression.ZipFile.OpenRead(Path);
            foreach (System.IO.Compression.ZipArchiveEntry entry in mrb.Entries)
            {
                entry.ExtractToFile(System.IO.Path.Combine(TempPath, entry.FullName), true);
            }
        }

        private void GenMrbPreview()
        {
            float ratio = 0;
            using (Image tempImage = Image.FromFile(System.IO.Path.Combine(TempPath, "puzzle.jpg")))
            {
                if (tempImage.Width > tempImage.Height) // wide
                {
                    if (tempImage.Width > 240) // shrink image
                    {
                        ratio = (float)tempImage.Width / 240;
                    }
                    else // expand image
                    {
                        ratio = 240 / (float)tempImage.Width;
                    }
                }
                else // tall
                {
                    if (tempImage.Height > 240) // shrink image
                    {
                        ratio = (float)tempImage.Height / 240;
                    }
                    else // expand image
                    {
                        ratio = 240 / (float)tempImage.Height;
                    }
                }
                float adjWidth = tempImage.Width / ratio;
                float adjHeight = tempImage.Height / ratio;
                Bitmap bm = new Bitmap(OFDPreview.Width, OFDPreview.Height);
                Rectangle r = new Rectangle(0, 0, (int)adjWidth, (int)adjHeight);
                Graphics g = Graphics.FromImage(bm);
                g.DrawImage(tempImage, r, 0, 0, tempImage.Width, tempImage.Height, GraphicsUnit.Pixel);
                OFDPreview.Image = bm;
            }
        }

        private void GenMrbLabels()
        {
            string TxtPath = System.IO.Path.Combine(TempPath, "puzzle.txt");
            string[] Lines = System.IO.File.ReadAllLines(TxtPath);
            string[] Counts = Lines[0].Split(' ');
            int Size = Convert.ToInt32(Counts[0]);
            int Balls = Convert.ToInt32(Counts[1]);
            int Walls = Convert.ToInt32(Counts[2]);
            this.SizeLabel.Text = $"Board Size: {Size} x {Size}";
            this.BallsLabel.Text = $"No. of Balls: {Balls}";
            this.WallsLabel.Text = $"No. of Walls: {Walls}";
        }

        private void RemoveTempFolder()
        {
            System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(TempPath);
            System.IO.FileInfo[] fileList = dirInfo.GetFiles();
            foreach (System.IO.FileInfo file in fileList)
            {
                System.IO.File.Delete(file.FullName);
            }
            System.IO.Directory.Delete(TempPath);
        }

        private void UpdatePathDisplay(string Path)
        {
            this.OFDFilePath.Text = Path;
        }

        private void SetGamePath()
        {
            GamePath = TempPath;
        }

        private void GoTo(string Path)
        {
            CurrentPath = Path;
            UpdatePathDisplay(Path);
            PopulateListView();
        }

        private void ClearPreview()
        {
            OFDPreview.Image = null;
            OFDPreview.Invalidate();
        }

        private void ClearLabels()
        {
            this.SizeLabel.Text = System.String.Empty;
            this.BallsLabel.Text = System.String.Empty;
            this.WallsLabel.Text = System.String.Empty;
        }

        private string ConvertFileSize(int SizeInBytes)
        {
            string Result = SizeInBytes.ToString() + " B";
            if (SizeInBytes > 1000)
            {
                Result = (SizeInBytes / 1000).ToString() + " KB";
            }
            else if (SizeInBytes > 1000000)
            {
                Result = (SizeInBytes / 1000000).ToString() + " MB";
            }
            return Result;
        }
    }
}
