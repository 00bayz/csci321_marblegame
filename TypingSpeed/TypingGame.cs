using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingSpeed
{
    public partial class TypingGame : Form
    {
        bool isGameRunning = false;

        public TypingGame()
        {
            InitializeComponent();
        }

        private int stringLength()
        {
            if (easyRad.Checked)
            {
                return 5;
            }
            else if (hardRad.Checked)
            {
                return 15;
            }
            else
            {
                return 10;
            }
        }

        private string generateRandomString()
        {
            string randomString = "";
            char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Random randIndex = new Random();
            for (int i = 0; i < stringLength(); i++)
            {
                randomString += characters[randIndex.Next(0, 25)].ToString();
            }
            return randomString;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (!isGameRunning)
            {
                clock1.Reset();
                isGameRunning = true;
                clock1.Start();
                pauseBtn.Visible = true;
                startBtn.Text = generateRandomString();
                startBtn.Enabled = false;
                resTextBox.Focus();
                resTextBox.CharacterCasing = CharacterCasing.Upper;
            }
        }

        private void resTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && isGameRunning)
            {
                string res = resTextBox.Text.ToUpper();
                if (res == startBtn.Text)
                {
                    clock1.Stop();
                    pauseBtn.Visible = false;
                    startBtn.Text = $"Time taken: {clock1.ElapsedMins}:{clock1.ElapsedSecs}. Click to try again.";
                    isGameRunning = false;
                    resTextBox.Text = "";
                    startBtn.Enabled = true;
                }
            }
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (pauseBtn.Text == "PAUSE")
            {
                clock1.Pause();
                startBtn.Visible = false;
                resTextBox.Enabled = false;
                pauseBtn.Text = "RESUME";
            }
            else if (pauseBtn.Text == "RESUME")
            {
                clock1.Resume();
                startBtn.Visible = true;
                resTextBox.Enabled = true;
                pauseBtn.Text = "PAUSE";
                resTextBox.Focus();
            }
        }
    }
}
