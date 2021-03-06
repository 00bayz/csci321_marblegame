
namespace TypingSpeed
{
    partial class TypingGame
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
            this.clock1 = new CustomDLL.Clock();
            this.startBtn = new System.Windows.Forms.Button();
            this.resTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.easyRad = new System.Windows.Forms.RadioButton();
            this.mediumRad = new System.Windows.Forms.RadioButton();
            this.hardRad = new System.Windows.Forms.RadioButton();
            this.diffLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clock1
            // 
            this.clock1.BackColor = System.Drawing.SystemColors.Control;
            this.clock1.ElapsedMins = 0;
            this.clock1.ElapsedSecs = 0;
            this.clock1.Location = new System.Drawing.Point(12, 428);
            this.clock1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(460, 160);
            this.clock1.TabIndex = 0;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 220);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(460, 50);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // resTextBox
            // 
            this.resTextBox.Location = new System.Drawing.Point(12, 360);
            this.resTextBox.Name = "resTextBox";
            this.resTextBox.Size = new System.Drawing.Size(460, 26);
            this.resTextBox.TabIndex = 2;
            this.resTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resTextBox_KeyPress);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Liberation Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(460, 159);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "Instructions:\n\n1) Click \"Start\" to generate random string of characters\n\n2) Type " +
    "characters in text field (NOT case-sensitive)\n\n3) Press \"Enter\" when done\n\n4) Se" +
    "e how fast you type!";
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(12, 280);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(460, 50);
            this.pauseBtn.TabIndex = 4;
            this.pauseBtn.Text = "PAUSE";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Visible = false;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // easyRad
            // 
            this.easyRad.AutoSize = true;
            this.easyRad.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.easyRad.Location = new System.Drawing.Point(242, 192);
            this.easyRad.Name = "easyRad";
            this.easyRad.Size = new System.Drawing.Size(66, 22);
            this.easyRad.TabIndex = 5;
            this.easyRad.Text = "Easy";
            this.easyRad.UseVisualStyleBackColor = true;
            // 
            // mediumRad
            // 
            this.mediumRad.AutoSize = true;
            this.mediumRad.Checked = true;
            this.mediumRad.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.mediumRad.Location = new System.Drawing.Point(314, 192);
            this.mediumRad.Name = "mediumRad";
            this.mediumRad.Size = new System.Drawing.Size(86, 22);
            this.mediumRad.TabIndex = 6;
            this.mediumRad.TabStop = true;
            this.mediumRad.Text = "Medium";
            this.mediumRad.UseVisualStyleBackColor = true;
            // 
            // hardRad
            // 
            this.hardRad.AutoSize = true;
            this.hardRad.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.hardRad.Location = new System.Drawing.Point(406, 192);
            this.hardRad.Name = "hardRad";
            this.hardRad.Size = new System.Drawing.Size(66, 22);
            this.hardRad.TabIndex = 7;
            this.hardRad.Text = "Hard";
            this.hardRad.UseVisualStyleBackColor = true;
            // 
            // diffLabel
            // 
            this.diffLabel.AutoSize = true;
            this.diffLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.diffLabel.Location = new System.Drawing.Point(12, 194);
            this.diffLabel.Name = "diffLabel";
            this.diffLabel.Size = new System.Drawing.Size(198, 18);
            this.diffLabel.TabIndex = 8;
            this.diffLabel.Text = "Select Difficulty: ";
            // 
            // TypingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(484, 601);
            this.Controls.Add(this.diffLabel);
            this.Controls.Add(this.hardRad);
            this.Controls.Add(this.mediumRad);
            this.Controls.Add(this.easyRad);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.resTextBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.clock1);
            this.Font = new System.Drawing.Font("Liberation Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "TypingGame";
            this.Text = "Typing Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomDLL.Clock clock1;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.TextBox resTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.RadioButton easyRad;
        private System.Windows.Forms.RadioButton mediumRad;
        private System.Windows.Forms.RadioButton hardRad;
        private System.Windows.Forms.Label diffLabel;
    }
}