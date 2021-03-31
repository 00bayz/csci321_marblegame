using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class Clock: UserControl
    {
        private BufferedGraphicsContext CurrentContext;
        private bool Running = false;
        private float OuterRadius;
        private Point OuterCenter;
        private float InnerRadius;
        private Point InnerCenter;
        private DateTime StartTime;
        private DateTime StopTime;

        private int elapsedMins = 0;
        private int elapsedSecs = 0;
        public int ElapsedMins
        {
            get
            {
                return elapsedMins;
            }
            set
            {
                elapsedMins = value;
            }
        }
        public int ElapsedSecs
        {
            get
            {
                return elapsedSecs;
            }
            set
            {
                elapsedSecs = value;
            }
        }
        public Clock()
        {
            InitializeComponent();

            SetOuterRadius();
            SetOuterCenter();
            SetInnerRadius();
            SetInnerCenter();
        }

        public void Start()
        {
            Running = true;
            StartTime = DateTime.Now;
        }

        public void Stop()
        {
            Running = false;
            StopTime = DateTime.Now;
            ElapsedMins += (StopTime - StartTime).Minutes;
            ElapsedSecs += (StopTime - StartTime).Seconds;
        }

        public void Pause()
        {
            Running = false;
            StopTime = DateTime.Now;
            ElapsedMins += (StopTime - StartTime).Minutes;
            ElapsedSecs += (StopTime - StartTime).Seconds;
        }

        public void Reset()
        {
            Running = false;
            ElapsedMins = 0;
            ElapsedSecs = 0;
        }

        public void Resume()
        {
            Running = true;
            StartTime = DateTime.Now;
        }

        private void SetOuterRadius()
        {
            if (Height > Width)
            {
                OuterRadius = Width / 2;
            }
            else
            {
                OuterRadius = Height / 2;
            }
        }

        private void SetOuterCenter()
        {
            OuterCenter = new Point(Width / 2, Height / 2);
        }

        private void SetInnerRadius()
        {
            InnerRadius = OuterRadius * .33f;
        }

        private void SetInnerCenter()
        {
            InnerCenter = new Point(Width / 2, Height / 3);
        }

        private void Clock_Paint(object sender, PaintEventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics, OuterRadius, OuterCenter);
            DrawNumbers(bg.Graphics, OuterRadius, OuterCenter);
            DrawHands(bg.Graphics, OuterRadius, OuterCenter, false);
            DrawLines(bg.Graphics, InnerRadius, InnerCenter);
            DrawNumbers(bg.Graphics, InnerRadius, InnerCenter);
            DrawHands(bg.Graphics, InnerRadius, InnerCenter, true);

            bg.Render();
        }

        private void DrawLines(Graphics g, float Radius, Point Center)
        {
            Pen myPen1 = new Pen(Color.Red, Radius * 0.07f);
            Pen myPen2 = new Pen(Color.Black, Radius * 0.05f);
            Pen myPen3 = new Pen(Color.Black, Radius * 0.02f);

            for (int i = 0; i < 4; i++)
            {
                float x = (float)Math.Cos(i * 90 * Math.PI / 180) * Radius * .7f + Center.X;
                float y = (float)Math.Sin(i * 90 * Math.PI / 180) * Radius * .7f + Center.Y;

                float x2 = (float)Math.Cos(i * 90 * Math.PI / 180) * Radius * .8f + Center.X;
                float y2 = (float)Math.Sin(i * 90 * Math.PI / 180) * Radius * .8f + Center.Y;

                g.DrawLine(myPen1, x, y, x2, y2);
            }

            for (int i = 0; i < 12; i++)
            {

                if (i % 3 != 0)
                {
                    float x = (float)Math.Cos(i * 30 * Math.PI / 180) * Radius * .7f + Center.X;
                    float y = (float)Math.Sin(i * 30 * Math.PI / 180) * Radius * .7f + Center.Y;

                    float x2 = (float)Math.Cos(i * 30 * Math.PI / 180) * Radius * .8f + Center.X;
                    float y2 = (float)Math.Sin(i * 30 * Math.PI / 180) * Radius * .8f + Center.Y;

                    g.DrawLine(myPen2, x, y, x2, y2);
                }
            }

            for (int i = 0; i < 60; i++)
            {
                if (i % 5 != 0)
                {
                    float x = (float)Math.Cos(i * 6 * Math.PI / 180) * Radius * .7f + Center.X;
                    float y = (float)Math.Sin(i * 6 * Math.PI / 180) * Radius * .7f + Center.Y;

                    float x2 = (float)Math.Cos(i * 6 * Math.PI / 180) * Radius * .8f + Center.X;
                    float y2 = (float)Math.Sin(i * 6 * Math.PI / 180) * Radius * .8f + Center.Y;

                    g.DrawLine(myPen3, x, y, x2, y2);
                }
            }
        }

        private void DrawNumbers(Graphics g, float Radius, Point Center)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Font numfont = new Font("Tahoma", Radius * 0.11f, FontStyle.Bold);
            Brush numberBrush = new SolidBrush(Color.Black);

            for (int i = 1; i <= 12; i++)
            {
                float x = (float)Math.Cos((i * 30 - 90) * Math.PI / 180) * Radius * .9f + Center.X;
                float y = (float)Math.Sin((i * 30 - 90) * Math.PI / 180) * Radius * .9f + Center.Y;
                g.DrawString((i * 5).ToString(), numfont, numberBrush, x, y, sf);
            }

        }

        private void DrawHands(Graphics g, float Radius, Point Center, bool IsInnerClock)
        {
            if (Running == true)
            {
                DateTime now = DateTime.Now;
                TimeSpan elapsed = now - StartTime;
                if (IsInnerClock)
                {
                    Pen minutePen = new Pen(Color.Black, Radius * 0.03f);

                    int minutes = elapsed.Minutes + elapsedMins;

                    float mx = (float)Math.Cos((minutes * 6 - 90) * Math.PI / 180) * Radius * .7f + Center.X;
                    float my = (float)Math.Sin((minutes * 6 - 90) * Math.PI / 180) * Radius * .7f + Center.Y;

                    g.DrawLine(minutePen, Center.X, Center.Y, mx, my);
                }
                else
                {
                    Pen secondPen = new Pen(Color.Red, Radius * 0.01f);

                    int seconds = elapsed.Seconds + elapsedSecs;

                    float sx = (float)Math.Cos((seconds * 6 - 90) * Math.PI / 180) * Radius * .75f + Center.X;
                    float sy = (float)Math.Sin((seconds * 6 - 90) * Math.PI / 180) * Radius * .75f + Center.Y;

                    g.DrawLine(secondPen, Center.X, Center.Y, sx, sy);
                }
            }
            else
            {
                if (IsInnerClock)
                {
                    Pen minutePen = new Pen(Color.Black, Radius * 0.03f);

                    int minutes = elapsedMins;

                    float mx = (float)Math.Cos((minutes * 6 - 90) * Math.PI / 180) * Radius * .7f + Center.X;
                    float my = (float)Math.Sin((minutes * 6 - 90) * Math.PI / 180) * Radius * .7f + Center.Y;

                    g.DrawLine(minutePen, Center.X, Center.Y, mx, my);
                }
                else
                {
                    Pen secondPen = new Pen(Color.Red, Radius * 0.01f);

                    int seconds = elapsedSecs;

                    float sx = (float)Math.Cos((seconds * 6 - 90) * Math.PI / 180) * Radius * .75f + Center.X;
                    float sy = (float)Math.Sin((seconds * 6 - 90) * Math.PI / 180) * Radius * .75f + Center.Y;

                    g.DrawLine(secondPen, Center.X, Center.Y, sx, sy);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics, OuterRadius, OuterCenter);
            DrawNumbers(bg.Graphics, OuterRadius, OuterCenter);
            DrawHands(bg.Graphics, OuterRadius, OuterCenter, false);
            DrawLines(bg.Graphics, InnerRadius, InnerCenter);
            DrawNumbers(bg.Graphics, InnerRadius, InnerCenter);
            DrawHands(bg.Graphics, InnerRadius, InnerCenter, true);

            bg.Render();
        }

        private void Clock_Resize(object sender, EventArgs e)
        {
            SetOuterRadius();
            SetOuterCenter();
            SetInnerRadius();
            SetInnerCenter();

            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.White);

            DrawLines(bg.Graphics, OuterRadius, OuterCenter);
            DrawNumbers(bg.Graphics, OuterRadius, OuterCenter);
            DrawHands(bg.Graphics, OuterRadius, OuterCenter, false);
            DrawLines(bg.Graphics, InnerRadius, InnerCenter);
            DrawNumbers(bg.Graphics, InnerRadius, InnerCenter);
            DrawHands(bg.Graphics, InnerRadius, InnerCenter, true);

            bg.Render();
        }
    }
}
