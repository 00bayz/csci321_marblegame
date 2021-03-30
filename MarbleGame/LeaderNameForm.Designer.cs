
namespace MarbleGame
{
    partial class LeaderNameForm
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
            this.LeaderNameTextBox = new System.Windows.Forms.TextBox();
            this.LeaderNameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LeaderNameTextBox
            // 
            this.LeaderNameTextBox.Font = new System.Drawing.Font("Liberation Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeaderNameTextBox.Location = new System.Drawing.Point(12, 48);
            this.LeaderNameTextBox.Name = "LeaderNameTextBox";
            this.LeaderNameTextBox.Size = new System.Drawing.Size(360, 32);
            this.LeaderNameTextBox.TabIndex = 0;
            // 
            // LeaderNameBtn
            // 
            this.LeaderNameBtn.Location = new System.Drawing.Point(12, 86);
            this.LeaderNameBtn.Name = "LeaderNameBtn";
            this.LeaderNameBtn.Size = new System.Drawing.Size(360, 38);
            this.LeaderNameBtn.TabIndex = 1;
            this.LeaderNameBtn.Text = "Submit";
            this.LeaderNameBtn.UseVisualStyleBackColor = true;
            this.LeaderNameBtn.Click += new System.EventHandler(this.LeaderNameBtn_Click);
            // 
            // LeaderNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.LeaderNameBtn);
            this.Controls.Add(this.LeaderNameTextBox);
            this.Font = new System.Drawing.Font("Liberation Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "LeaderNameForm";
            this.Text = "New Highscore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LeaderNameForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LeaderNameTextBox;
        private System.Windows.Forms.Button LeaderNameBtn;
    }
}