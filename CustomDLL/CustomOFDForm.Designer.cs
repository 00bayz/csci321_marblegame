
namespace CustomDLL
{
    partial class CustomOFDForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomOFDForm));
            this.OFDListView = new System.Windows.Forms.ListView();
            this.Filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Filesize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OFDPrevDirButton = new System.Windows.Forms.Button();
            this.OFDFilePath = new System.Windows.Forms.TextBox();
            this.OFDPreview = new System.Windows.Forms.PictureBox();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.BallsLabel = new System.Windows.Forms.Label();
            this.WallsLabel = new System.Windows.Forms.Label();
            this.OFDLoadButton = new System.Windows.Forms.Button();
            this.OFDCancelButton = new System.Windows.Forms.Button();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OFDPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // OFDListView
            // 
            this.OFDListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Filename,
            this.DateModified,
            this.Type,
            this.Filesize});
            this.OFDListView.HideSelection = false;
            this.OFDListView.Location = new System.Drawing.Point(13, 13);
            this.OFDListView.Name = "OFDListView";
            this.OFDListView.Size = new System.Drawing.Size(1030, 556);
            this.OFDListView.SmallImageList = this.Icons;
            this.OFDListView.TabIndex = 0;
            this.OFDListView.UseCompatibleStateImageBehavior = false;
            this.OFDListView.View = System.Windows.Forms.View.Details;
            this.OFDListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OFDItem_Single_Click);
            this.OFDListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OFDItem_Double_Click);
            // 
            // Filename
            // 
            this.Filename.Text = "Name";
            this.Filename.Width = 320;
            // 
            // DateModified
            // 
            this.DateModified.Text = "Date Modified";
            this.DateModified.Width = 240;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 200;
            // 
            // Filesize
            // 
            this.Filesize.Text = "Size";
            this.Filesize.Width = 160;
            // 
            // OFDPrevDirButton
            // 
            this.OFDPrevDirButton.Font = new System.Drawing.Font("Liberation Mono", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFDPrevDirButton.Location = new System.Drawing.Point(13, 575);
            this.OFDPrevDirButton.Name = "OFDPrevDirButton";
            this.OFDPrevDirButton.Size = new System.Drawing.Size(61, 32);
            this.OFDPrevDirButton.TabIndex = 1;
            this.OFDPrevDirButton.Text = "▲";
            this.OFDPrevDirButton.UseVisualStyleBackColor = true;
            this.OFDPrevDirButton.Click += new System.EventHandler(this.OFDPrevDirButton_Click);
            // 
            // OFDFilePath
            // 
            this.OFDFilePath.Font = new System.Drawing.Font("Liberation Mono", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFDFilePath.Location = new System.Drawing.Point(82, 577);
            this.OFDFilePath.Name = "OFDFilePath";
            this.OFDFilePath.Size = new System.Drawing.Size(961, 29);
            this.OFDFilePath.TabIndex = 2;
            this.OFDFilePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OFDFilePath_KeyPress);
            // 
            // OFDPreview
            // 
            this.OFDPreview.Location = new System.Drawing.Point(1073, 13);
            this.OFDPreview.Name = "OFDPreview";
            this.OFDPreview.Size = new System.Drawing.Size(240, 240);
            this.OFDPreview.TabIndex = 3;
            this.OFDPreview.TabStop = false;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.Location = new System.Drawing.Point(1070, 300);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(68, 18);
            this.SizeLabel.TabIndex = 4;
            this.SizeLabel.Text = "label1";
            // 
            // BallsLabel
            // 
            this.BallsLabel.AutoSize = true;
            this.BallsLabel.Location = new System.Drawing.Point(1070, 350);
            this.BallsLabel.Name = "BallsLabel";
            this.BallsLabel.Size = new System.Drawing.Size(68, 18);
            this.BallsLabel.TabIndex = 5;
            this.BallsLabel.Text = "label1";
            // 
            // WallsLabel
            // 
            this.WallsLabel.AutoSize = true;
            this.WallsLabel.Location = new System.Drawing.Point(1070, 400);
            this.WallsLabel.Name = "WallsLabel";
            this.WallsLabel.Size = new System.Drawing.Size(68, 18);
            this.WallsLabel.TabIndex = 6;
            this.WallsLabel.Text = "label1";
            // 
            // OFDLoadButton
            // 
            this.OFDLoadButton.Location = new System.Drawing.Point(1053, 575);
            this.OFDLoadButton.Name = "OFDLoadButton";
            this.OFDLoadButton.Size = new System.Drawing.Size(125, 32);
            this.OFDLoadButton.TabIndex = 7;
            this.OFDLoadButton.Text = "Load";
            this.OFDLoadButton.UseVisualStyleBackColor = true;
            this.OFDLoadButton.Click += new System.EventHandler(this.OFDLoadButton_Click);
            // 
            // OFDCancelButton
            // 
            this.OFDCancelButton.Location = new System.Drawing.Point(1188, 575);
            this.OFDCancelButton.Name = "OFDCancelButton";
            this.OFDCancelButton.Size = new System.Drawing.Size(125, 32);
            this.OFDCancelButton.TabIndex = 8;
            this.OFDCancelButton.Text = "Cancel";
            this.OFDCancelButton.UseVisualStyleBackColor = true;
            this.OFDCancelButton.Click += new System.EventHandler(this.OFDCancelButton_Click);
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "mrb_icon.png");
            this.Icons.Images.SetKeyName(1, "folder_icon.png");
            this.Icons.Images.SetKeyName(2, "txt_icon.png");
            this.Icons.Images.SetKeyName(3, "image_icon.png");
            this.Icons.Images.SetKeyName(4, "misc_icon.png");
            // 
            // CustomOFDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1333, 623);
            this.Controls.Add(this.OFDCancelButton);
            this.Controls.Add(this.OFDLoadButton);
            this.Controls.Add(this.WallsLabel);
            this.Controls.Add(this.BallsLabel);
            this.Controls.Add(this.SizeLabel);
            this.Controls.Add(this.OFDPreview);
            this.Controls.Add(this.OFDFilePath);
            this.Controls.Add(this.OFDPrevDirButton);
            this.Controls.Add(this.OFDListView);
            this.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CustomOFDForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Load Game File";
            ((System.ComponentModel.ISupportInitialize)(this.OFDPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView OFDListView;
        private System.Windows.Forms.ColumnHeader Filename;
        private System.Windows.Forms.ColumnHeader DateModified;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Filesize;
        private System.Windows.Forms.Button OFDPrevDirButton;
        private System.Windows.Forms.TextBox OFDFilePath;
        private System.Windows.Forms.PictureBox OFDPreview;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label BallsLabel;
        private System.Windows.Forms.Label WallsLabel;
        private System.Windows.Forms.Button OFDLoadButton;
        private System.Windows.Forms.Button OFDCancelButton;
        private System.Windows.Forms.ImageList Icons;
    }
}