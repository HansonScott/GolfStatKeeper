using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using GolfStatKeeper.CoreObjects;

namespace GolfStatKeeper
{
    public class AccuracyMap : Panel
    {
        public enum AccuracyLength
        {
            VeryLong = 0,
            Long = 1,
            EdgeLong = 2,
            AsIntended = 3,
            EdgeShort = 4,
            Short = 5,
            VeryShort = 6,
        }
        public enum AccuracyWidth
        {
            VeryLeft = 0,
            Left = 1,
            EdgeLeft = 2,
            AsIntended = 3,
            EdgeRight = 4,
            Right = 5,
            VeryRight = 6,
        }

        private int[,] m_DataSource;

        public AccuracyMap()
        {
            this.DoubleBuffered = true;
        }

        public int[,] DataSource
        {
            get { return m_DataSource; }
            set { m_DataSource = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            int hInset = this.Width / 6;
            int vInset = this.Height / 6;

            int TargetWidth = this.Width / 2;
            int TargetHeight = this.Height / 2;

            Graphics g = e.Graphics;

            #region draw background
            // dark gray outsides (corners)
            g.FillRectangle(new SolidBrush(Color.DarkGreen),0,0,this.Width,this.Height);

            // dark green outer ring (rough)
            g.FillEllipse(new SolidBrush(Color.DarkGreen), 0, 0, this.Width, this.Height);

            // green inner ring (fairway)
            g.FillEllipse(new SolidBrush(Color.Green), hInset, vInset, this.Width - (hInset * 2), this.Height - (vInset * 2));

            // light green (green)
            g.FillEllipse(new SolidBrush(Color.ForestGreen), 
                            (this.Width / 2) - (TargetWidth / 2), 
                            (this.Height / 2) - (TargetHeight / 2), 
                            TargetWidth, TargetHeight);

            // draw Pin
            int TopOfPin = this.Height / 2 - 40;
            g.DrawLine(new Pen(Color.Yellow, 2), this.Width / 2, this.Height / 2, this.Width / 2, TopOfPin);
            g.FillRectangle(new SolidBrush(Color.Red), this.Width / 2, TopOfPin, 10, 10);
            g.DrawLine(new Pen(Color.White, 1), this.Width / 2 - 2, this.Height / 2,
                                                this.Width / 2 + 1, this.Height / 2);
            #endregion

            if (DataSource == null) { return; }

            Random rand = new Random();

            int lcount = Enum.GetNames((typeof(AccuracyLength))).Length;
            int wcount = Enum.GetNames((typeof(AccuracyWidth))).Length;

            // loop through each width area
            for (int i = 0; i < wcount; i++)
            {
                // loop through each length area
                for (int j = 0; j < lcount; j++)
                {
                    int thisValue = DataSource[i,j];
                    if (thisValue < 1) { continue; }

                    Point ThisPoint = GetPointForArea(i, j);

                    int ThisArea_X = ThisPoint.X;
                    int ThisArea_Y = ThisPoint.Y;

                    int MarginX = this.Width / 9;
                    int MarginY = this.Height / 9;


                    for (int k = 0; k < thisValue; k++)
                    {
                        // calc variance
                        int rndX = rand.Next(MarginX * 2);
                        int rndY = rand.Next(MarginY * 2);

                        int ThisX = ThisArea_X - MarginX + rndX;
                        int ThisY = ThisArea_Y - MarginY + rndY;

                        // draw point
                        g.FillEllipse(new SolidBrush(Color.White), ThisX, ThisY, 3, 3);
                        g.DrawLine(new Pen(Color.Black), ThisX + 1, ThisY + 3, ThisX + 2, ThisY + 3);
                    }
                }
            }
        }

        private Point GetPointForArea(int W, int L)
        {
            int lcount = Enum.GetNames((typeof(AccuracyLength))).Length;
            int wcount = Enum.GetNames((typeof(AccuracyWidth))).Length;

            int tempX = (W + 1) * this.Width;
            int tempY = (L + 1)  * this.Height;

            int X = (tempX) / (wcount + 1);
            int Y = (tempY) / (lcount + 1);

            return new Point(X, Y);
        }
    }
}
