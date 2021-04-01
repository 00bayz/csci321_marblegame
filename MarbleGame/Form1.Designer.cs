
namespace MarbleGame
{
    partial class Game
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
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ControlsBox = new System.Windows.Forms.GroupBox();
            this.LeaderBoard = new System.Windows.Forms.ListView();
            this.Rank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumberMoves = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeSolveFormatted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimerPauseBtn = new System.Windows.Forms.Button();
            this.clock1 = new CustomControls.Clock();
            this.LeftButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.RightButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.MainLayout.SuspendLayout();
            this.ControlsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.MainLayout.Controls.Add(this.ControlsBox, 1, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Size = new System.Drawing.Size(1040, 700);
            this.MainLayout.TabIndex = 0;
            // 
            // ControlsBox
            // 
            this.ControlsBox.Controls.Add(this.LeaderBoard);
            this.ControlsBox.Controls.Add(this.TimerPauseBtn);
            this.ControlsBox.Controls.Add(this.clock1);
            this.ControlsBox.Controls.Add(this.LeftButton);
            this.ControlsBox.Controls.Add(this.DownButton);
            this.ControlsBox.Controls.Add(this.RightButton);
            this.ControlsBox.Controls.Add(this.UpButton);
            this.ControlsBox.Controls.Add(this.LoadButton);
            this.ControlsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsBox.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlsBox.ForeColor = System.Drawing.Color.Lime;
            this.ControlsBox.Location = new System.Drawing.Point(803, 3);
            this.ControlsBox.Name = "ControlsBox";
            this.ControlsBox.Size = new System.Drawing.Size(234, 694);
            this.ControlsBox.TabIndex = 0;
            this.ControlsBox.TabStop = false;
            this.ControlsBox.Text = "Controls";
            // 
            // LeaderBoard
            // 
            this.LeaderBoard.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rank,
            this.PlayerName,
            this.NumberMoves,
            this.TimeSolveFormatted});
            this.LeaderBoard.Font = new System.Drawing.Font("Liberation Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaderBoard.HideSelection = false;
            this.LeaderBoard.Location = new System.Drawing.Point(6, 455);
            this.LeaderBoard.Name = "LeaderBoard";
            this.LeaderBoard.Size = new System.Drawing.Size(222, 230);
            this.LeaderBoard.TabIndex = 7;
            this.LeaderBoard.UseCompatibleStateImageBehavior = false;
            this.LeaderBoard.View = System.Windows.Forms.View.Details;
            // 
            // Rank
            // 
            this.Rank.Text = "#";
            this.Rank.Width = 20;
            // 
            // PlayerName
            // 
            this.PlayerName.Text = "Name";
            this.PlayerName.Width = 66;
            // 
            // NumberMoves
            // 
            this.NumberMoves.Text = "Moves";
            this.NumberMoves.Width = 54;
            // 
            // TimeSolveFormatted
            // 
            this.TimeSolveFormatted.Text = "Time";
            this.TimeSolveFormatted.Width = 75;
            // 
            // TimerPauseBtn
            // 
            this.TimerPauseBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TimerPauseBtn.Location = new System.Drawing.Point(37, 368);
            this.TimerPauseBtn.Name = "TimerPauseBtn";
            this.TimerPauseBtn.Size = new System.Drawing.Size(160, 23);
            this.TimerPauseBtn.TabIndex = 6;
            this.TimerPauseBtn.Text = "Pause";
            this.TimerPauseBtn.UseVisualStyleBackColor = true;
            this.TimerPauseBtn.Click += new System.EventHandler(this.TimerPauseBtn_Click);
            // 
            // clock1
            // 
            this.clock1.BackColor = System.Drawing.SystemColors.Control;
            this.clock1.ElapsedMins = 0;
            this.clock1.ElapsedSecs = 0;
            this.clock1.Location = new System.Drawing.Point(37, 199);
            this.clock1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(160, 161);
            this.clock1.TabIndex = 5;
            // 
            // LeftButton
            // 
            this.LeftButton.Enabled = false;
            this.LeftButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftButton.Location = new System.Drawing.Point(63, 106);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(36, 36);
            this.LeftButton.TabIndex = 4;
            this.LeftButton.Text = "🠔";
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Enabled = false;
            this.DownButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DownButton.Location = new System.Drawing.Point(99, 142);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(36, 36);
            this.DownButton.TabIndex = 3;
            this.DownButton.Text = "🠗";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // RightButton
            // 
            this.RightButton.Enabled = false;
            this.RightButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RightButton.Location = new System.Drawing.Point(135, 106);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(36, 36);
            this.RightButton.TabIndex = 2;
            this.RightButton.Text = "🠖";
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Enabled = false;
            this.UpButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UpButton.Location = new System.Drawing.Point(99, 70);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(36, 36);
            this.UpButton.TabIndex = 1;
            this.UpButton.Text = "🠕";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoadButton.Location = new System.Drawing.Point(6, 25);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(222, 30);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load Game";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1040, 700);
            this.Controls.Add(this.MainLayout);
            this.Font = new System.Drawing.Font("Liberation Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Game";
            this.Text = "Marble Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Game_ResizeEnd);
            this.MainLayout.ResumeLayout(false);
            this.ControlsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.GroupBox ControlsBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button LeftButton;
        private CustomControls.Clock clock1;
        private System.Windows.Forms.Button TimerPauseBtn;
        private System.Windows.Forms.ListView LeaderBoard;
        private System.Windows.Forms.ColumnHeader PlayerName;
        private System.Windows.Forms.ColumnHeader NumberMoves;
        private System.Windows.Forms.ColumnHeader TimeSolveFormatted;
        private System.Windows.Forms.ColumnHeader Rank;
    }
}

