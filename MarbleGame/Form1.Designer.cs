
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
            this.MainLayout.Size = new System.Drawing.Size(840, 500);
            this.MainLayout.TabIndex = 0;
            // 
            // ControlsBox
            // 
            this.ControlsBox.Controls.Add(this.LeftButton);
            this.ControlsBox.Controls.Add(this.DownButton);
            this.ControlsBox.Controls.Add(this.RightButton);
            this.ControlsBox.Controls.Add(this.UpButton);
            this.ControlsBox.Controls.Add(this.LoadButton);
            this.ControlsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlsBox.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlsBox.ForeColor = System.Drawing.Color.Lime;
            this.ControlsBox.Location = new System.Drawing.Point(603, 3);
            this.ControlsBox.Name = "ControlsBox";
            this.ControlsBox.Size = new System.Drawing.Size(234, 494);
            this.ControlsBox.TabIndex = 0;
            this.ControlsBox.TabStop = false;
            this.ControlsBox.Text = "Controls";
            // 
            // LeftButton
            // 
            this.LeftButton.Enabled = false;
            this.LeftButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeftButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeftButton.Location = new System.Drawing.Point(45, 150);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(50, 50);
            this.LeftButton.TabIndex = 4;
            this.LeftButton.Text = "🠔";
            this.LeftButton.UseVisualStyleBackColor = true;
            // 
            // DownButton
            // 
            this.DownButton.Enabled = false;
            this.DownButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DownButton.Location = new System.Drawing.Point(95, 200);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(50, 50);
            this.DownButton.TabIndex = 3;
            this.DownButton.Text = "🠗";
            this.DownButton.UseVisualStyleBackColor = true;
            // 
            // RightButton
            // 
            this.RightButton.Enabled = false;
            this.RightButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RightButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RightButton.Location = new System.Drawing.Point(145, 150);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(50, 50);
            this.RightButton.TabIndex = 2;
            this.RightButton.Text = "🠖";
            this.RightButton.UseVisualStyleBackColor = true;
            // 
            // UpButton
            // 
            this.UpButton.Enabled = false;
            this.UpButton.Font = new System.Drawing.Font("Liberation Mono", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UpButton.Location = new System.Drawing.Point(95, 100);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(50, 50);
            this.UpButton.TabIndex = 1;
            this.UpButton.Text = "🠕";
            this.UpButton.UseVisualStyleBackColor = true;
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoadButton.Location = new System.Drawing.Point(6, 425);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(222, 60);
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
            this.ClientSize = new System.Drawing.Size(840, 500);
            this.Controls.Add(this.MainLayout);
            this.Font = new System.Drawing.Font("Liberation Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Game";
            this.Text = "Marble Game";
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
    }
}

