using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

namespace GolfStatKeeper
{
    public class Chart: System.Windows.Forms.Panel
    {
        private DataTable m_DataSource;
        public Round[] TheseRounds;
        public bool[] ShowTheseColumns;
        public decimal[] Scales;
        public decimal[] Mins;
        public Color[] LineColors;
        public Color EdgeColor = Color.White;
        public int Inset = 30;
        public Font TextFont = new Font("Ariel", 10f);
        public Brush TextBrush = new SolidBrush(Color.White);

        public Chart()
        {
            this.DoubleBuffered = true;
        }

        public void GenerateStats()
        {
            GenerateStats(DateTime.Now.AddYears(-1), DateTime.Now);
        }
        public void GenerateStats(DateTime dFrom, DateTime dTo)
        {
            GenerateStats(DAC.GetCourses(), dFrom, dTo);
        }
        public void GenerateStats(Course[] Courses, DateTime dFrom, DateTime dTo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score");
            dt.Columns.Add("Fairways");
            dt.Columns.Add("Greens");
            dt.Columns.Add("Putts");
            dt.Columns.Add("Penalties");

            TheseRounds = DAC.GetRoundsByCoursesAndDates(Courses, dFrom, dTo, false);

            // go through "TheseRounds" and their holes and shots, and calculate each particular stat.
            for (int i = 0; i < TheseRounds.Length; i++)
            {
                Round ThisRound = TheseRounds[i];
                if (ThisRound == null) { continue; }

                DataRow row = dt.NewRow();

                row["Score"] = ThisRound.TotalScore;
                row["Fairways"] = (decimal)((decimal)(ThisRound.TotalFairwaysHit * 100) / (decimal)ThisRound.Course.GetTotalFairways());
                row["Greens"] = (decimal)((decimal)(ThisRound.TotalGreensHit * 100) / (decimal)18);
                row["Putts"] = ThisRound.TotalPutts;
                row["Penalties"] = ThisRound.TotalPenaltyStrokes;

                dt.Rows.Add(row);
            } // end for loop

            this.DataSource = dt;
        }

        public DataTable DataSource
        {
            get { return m_DataSource; }
            set 
            { 
                m_DataSource = value;

                if (m_DataSource != null &&
                    m_DataSource.Columns.Count > 0)
                {
                    Scales = new decimal[m_DataSource.Columns.Count];
                    Mins = new decimal[m_DataSource.Columns.Count];
                    for (int m = 0; m < Mins.Length; m++)
                    {
                        Mins[m] = 100;
                    }

                    ShowTheseColumns = new bool[m_DataSource.Columns.Count];
                    for (int s = 0; s < ShowTheseColumns.Length; s++)
                    {
                        ShowTheseColumns[s] = true;
                    }

                    LineColors = new Color[m_DataSource.Columns.Count];
                    for(int c = 0; c < LineColors.Length; c++)
                    {
                        switch(c)
                        {
                            case 0:
                                LineColors[c] = Color.White;
                                break;
                            case 1:
                                LineColors[c] = Color.Yellow;
                                break;
                            case 2:
                                LineColors[c] = Color.Blue;
                                break;
                            case 3:
                                LineColors[c] = Color.Orange;
                                break;
                            case 4:
                                LineColors[c] = Color.Red;
                                break;
                            case 5:
                                LineColors[c] = Color.Purple;
                                break;
                            case 6:
                                LineColors[c] = Color.Gray;
                                break;
                            default:
                                LineColors[c] = Color.Black;
                                break;
                        }
                    }

                    // file each scale value with the max of each row
                    for(int i = 0; i < m_DataSource.Rows.Count; i++)
                    {
                        for(int j = 0; j < m_DataSource.Columns.Count; j++)
                        {
                            string thisValue = (m_DataSource.Rows[i][j].ToString());
                            decimal dThisValue = 0;
                            Decimal.TryParse(thisValue, out dThisValue);
                            Scales[j] = Math.Max(dThisValue, Scales[j]);
                            Mins[j] = Math.Min(dThisValue, Mins[j]);
                        }
                    }
                }
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //base.OnPaint(e);
            Graphics g = e.Graphics;

            // draw background color
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, this.Width, this.Height);

            // draw edges
            Pen Pen_Edge = new Pen(EdgeColor);
            int BaseLine = this.Height - Inset;

            // left-vertical
            g.DrawLine(Pen_Edge, Inset, Inset, Inset, BaseLine);

            // bottom-horizontal
            g.DrawLine(Pen_Edge, Inset, BaseLine, this.Width - Inset, BaseLine);

            // draw all data lines
            if (this.DataSource == null) { return; }

            // go through each line group
            for (int c = 0; c < this.DataSource.Columns.Count; c++)
            {
                if (!ShowTheseColumns[c])
                {
                    // then don't draw this one.
                    continue;
                }

                // if no rounds, then show a label.
                if (this.DataSource.Rows.Count == 0)
                {
                    string msg = "There are no rounds within the given dates and courses.";
                    g.DrawString(msg,
                        TextFont, 
                        TextBrush, 
                        (this.Width / 2) - (msg.Length * 3), 
                        this.Height / 3);
                }

                // go through each point
                for (int r = 0; r < this.DataSource.Rows.Count - 1; r++) // -1 keeps us from going off the end.
                {
                    // get the values for point r to r + 1
                    string thisValue = this.DataSource.Rows[r][c].ToString();
                    string nextValue = this.DataSource.Rows[r + 1][c].ToString();

                    decimal dThisValue = 0;
                    decimal dNextValue = 0;

                    Decimal.TryParse(thisValue, out dThisValue);
                    Decimal.TryParse(nextValue, out dNextValue);

                    // calculate the location based on values
                    int xValue1 = (this.Width / (this.DataSource.Rows.Count + 1)) * (r + 1);
                    int xValue2 = (this.Width / (this.DataSource.Rows.Count + 1)) * (r + 2);

                    // top  = Inset;
                    // bottom = this.Height - Inset;
                    // % = val * height / Scale

                    int yValue1 = this.Height - (int)(((dThisValue - Mins[c]) * this.Height) / (decimal)((Scales[c] - Mins[c]) * (decimal)(1.3))) - Inset - 10;
                    int yValue2 = this.Height - (int)(((dNextValue - Mins[c]) * this.Height) / (decimal)((Scales[c] - Mins[c]) * (decimal)(1.3))) - Inset - 10;

                    Pen linePen = new Pen(LineColors[c]);
                    linePen.Width = 2;

                    // draw text above point
                    DrawTextAtPoint(g, c, dThisValue, xValue1, yValue1);

                    // cross line
                    g.DrawLine(linePen, xValue1, yValue1 - 5, xValue1, yValue1);

                    // base cross line
                    g.DrawLine(Pen_Edge, xValue1, BaseLine - 5, xValue1, BaseLine);

                    // date at base
                    g.DrawString(TheseRounds[r].When.ToString("MM.dd.yy"), 
                        TextFont, TextBrush, xValue1 - 27, BaseLine + 1);

                    // draw the line from this point to the next
                    g.DrawLine(linePen, xValue1, yValue1, xValue2, yValue2);

                    // if we're on the last one, draw the last point too
                    if (r == this.DataSource.Rows.Count - 2)
                    {
                        // draw text above point
                        DrawTextAtPoint(g, c, dNextValue, xValue2, yValue2);

                        // cross line
                        g.DrawLine(linePen, xValue2, yValue2 - 5, xValue2, yValue2);

                        // base cross line
                        g.DrawLine(Pen_Edge, xValue2, BaseLine - 5, xValue2, BaseLine);

                        // date at base
                        g.DrawString(TheseRounds[r + 1].When.ToString("MM.dd.yy"),
                            TextFont, TextBrush, xValue2 - 27, BaseLine + 2);

                    }
                }
            }
        }

        private void DrawTextAtPoint(Graphics g, int c, decimal dThisValue, int xValue1, int yValue1)
        {
            Color color = LineColors[c];
            int vAdjust = -30;
            int hAdjust = 0;

            if (dThisValue > (decimal)(9.99))
            {
                g.DrawString(String.Format("{0:#.##}", dThisValue),
                                TextFont, new SolidBrush(color), xValue1 - 8 + hAdjust, yValue1 + vAdjust);
            }
            else
            {
                g.DrawString(String.Format("{0:#.##}", dThisValue),
                                TextFont, new SolidBrush(color), xValue1 - 5 + hAdjust, yValue1 + vAdjust);
            }
        }
    }
}
