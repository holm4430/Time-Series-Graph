/*Name: Kevin Holmes
 * Description: Basic program to download time series data from Yahoo Finance and plot in a graph
 * Version 1.1
 * Date: February 3, 2015
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graph = System.Windows.Forms.DataVisualization.Charting;

namespace WebDL
{
    public partial class Form2 : Form
    {
        private Graph.Chart chart;
        private Graph.Chart volumechart;
        private System.DateTime[] arrdat;
        private double[] arrclos;
        private double[] arrvol;
        private string tick;
        private string sertype;
        private PointF _point = new PointF(2, 2);
      

        public Form2(System.DateTime[] xaxis, double[] yaxis, double[] volume, string ticker, string name)
        {
            //assign closing prices and dates arrays to object
            arrdat = xaxis;
            arrclos = yaxis;
            arrvol = volume;
            tick = ticker;
            InitializeComponent();
            //old this.ClientSize = new System.Drawing.Size(750, 530);
            this.ClientSize = new System.Drawing.Size(1150, 675);
            this.MinimumSize = new System.Drawing.Size(1150, 675);
            this.MaximumSize = new System.Drawing.Size(1150, 675);
            this.Text = name;
            sertype = name;

        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            _point.X = e.Location.X;
            _point.Y = e.Location.Y;

            chart.ChartAreas["timeseries"].CursorY.SetCursorPixelPosition(_point, true);
            chart.ChartAreas["timeseries"].CursorX.SetCursorPixelPosition(_point, true);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //only let user use daily moving average if data is daily
            if (sertype != "Daily Time Series Data" || arrclos.Length <= 200)
            {
                this.cb200daySMA.Enabled = false;
                this.cb20daySMA.Enabled = false;
                this.cb50daySMA.Enabled = false;
            }

            chart = new Graph.Chart();
            chart.Location = new System.Drawing.Point(5, 20);
            chart.Size = new System.Drawing.Size(1150, 450);
            chart.MouseMove += new MouseEventHandler(chart_MouseMove);

            //ensure resize with form
            chart.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            //time series data
            chart.ChartAreas.Add("timeseries");

            var cursor_Y = chart.ChartAreas["timeseries"].CursorY;
            var cursor_X = chart.ChartAreas["timeseries"].CursorX;
            cursor_Y.LineWidth = 1;
            cursor_Y.LineDashStyle = Graph.ChartDashStyle.DashDot;
            cursor_Y.LineColor = Color.Red;
            cursor_Y.SelectionColor = Color.Yellow;

            cursor_X.LineWidth = 1;
            cursor_X.LineDashStyle = Graph.ChartDashStyle.DashDot;
            cursor_X.LineColor = Color.Red;
           

            

            chart.ChartAreas["timeseries"].AxisX.Maximum = (arrdat[0].ToOADate()+5);
            chart.ChartAreas["timeseries"].AxisX.Minimum = (arrdat[arrdat.Length - 1].ToOADate());
            chart.ChartAreas["timeseries"].AxisX.Interval = (arrdat[0].ToOADate() - arrdat[arrdat.Length - 1].ToOADate()) / 20;
            chart.ChartAreas["timeseries"].AxisX.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["timeseries"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart.ChartAreas["timeseries"].AxisY.Minimum = Math.Round(Math.Max(arrclos.Min() - 3, 0),0);
            chart.ChartAreas["timeseries"].AxisY.Maximum = arrclos.Max() + 5;
            chart.ChartAreas["timeseries"].AxisY.LabelStyle.Format = "{  0,0.00}";
            chart.ChartAreas["timeseries"].AxisY.Interval = Math.Round(arrclos.Max() / 10, 0);
            chart.ChartAreas["timeseries"].AxisY.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["timeseries"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart.ChartAreas["timeseries"].BackColor = Color.White;
            
            

            // Create a new function series
            chart.Series.Add("MyFunc");
            // Set the type to line      
            chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;

            chart.Series["MyFunc"].ToolTip = " #VALX, #VALY";
            // Color the line of the graph light green and give it a thickness of 3
            chart.Series["MyFunc"].Color = Color.Blue;
            chart.Series["MyFunc"].BorderWidth = 2;

            chart.Series["MyFunc"].LegendText = tick;
            // Create a new legend called "MyLegend".
            chart.Legends.Add("MyLegend");
            chart.Legends["MyLegend"].BackColor = Color.Transparent;
            chart.Legends["MyLegend"].BorderColor = Color.Tomato;
            // Set legend docking
            chart.Legends["MyLegend"].DockedToChartArea = "timeseries";
            chart.Legends["MyLegend"].IsDockedInsideChartArea = true;

            //add date and adj close to series of graph
            for (int x = arrdat.Length - 1; x >= 0; x -= 1)
            {
                chart.Series["MyFunc"].Points.AddXY(arrdat[x], arrclos[x]);

            }
           

            //volume bar graph
            volumechart = new Graph.Chart();
            volumechart.Location = new System.Drawing.Point(5, 475);
            volumechart.Size = new System.Drawing.Size(1150, 125);
            //ensure resize with form
            volumechart.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom);
            volumechart.ChartAreas.Add("volseries");
            volumechart.ChartAreas[0].RecalculateAxesScale();
            volumechart.ChartAreas["volseries"].AxisX.Maximum = (arrdat[0].ToOADate()+5);
            volumechart.ChartAreas["volseries"].AxisX.Minimum = (arrdat[arrdat.Length - 1].ToOADate());
            volumechart.ChartAreas["volseries"].AxisX.Interval = (arrdat[0].ToOADate() - arrdat[arrdat.Length - 1].ToOADate()) / 20;
            volumechart.ChartAreas["volseries"].AxisX.MajorGrid.LineColor = Color.White;
            volumechart.ChartAreas["volseries"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            volumechart.ChartAreas["volseries"].AxisY.Minimum = 0;
            volumechart.ChartAreas["volseries"].AxisY.Maximum = arrvol.Max()+5;
            volumechart.ChartAreas["volseries"].AxisY.LabelStyle.Format = "{  0,0.00}";
            volumechart.ChartAreas["volseries"].AxisY.Interval = Math.Round((double) arrvol.Max(), 0);
            volumechart.ChartAreas["volseries"].AxisY.MajorGrid.LineColor = Color.White;
            volumechart.ChartAreas["volseries"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            volumechart.ChartAreas["volseries"].BackColor = Color.White;


            // Create a new function series
            volumechart.Series.Add("VolGrp");
       
            // Set the type to line      
            volumechart.Series["VolGrp"].ChartType = Graph.SeriesChartType.Column;
            // Color the line of the graph light green and give it a thickness of 3
            volumechart.Series["VolGrp"].Color = Color.Blue;
            volumechart.Series["VolGrp"].BorderWidth = 1;

            volumechart.Series["VolGrp"].LegendText = "Volume (M)";

            // Create a new legend
            volumechart.Legends.Add("MyLegend2");
            volumechart.Legends["MyLegend2"].BorderColor = Color.Transparent;
            volumechart.Legends["MyLegend2"].DockedToChartArea = "volseries";
            volumechart.Legends["MyLegend2"].IsDockedInsideChartArea = true;

            //add date and adj close to series of graph
            for (int x = arrdat.Length - 1; x >= 0; x -= 1)
            {
                volumechart.Series["VolGrp"].Points.AddXY(arrdat[x], arrvol[x]);

            }

             //add graph to form
            Controls.Add(this.chart);
            Controls.Add(this.volumechart);
            this.labelpercent.Text = "Chg: " + Convert.ToString(Math.Round(((arrclos[0] / arrclos[arrclos.Length - 1])-1.0)*100,2)) + "%";


        }

        private void cb20daySMA_CheckedChanged(object sender, EventArgs e)
        {
            //check if it is on or off
            if (cb20daySMA.Checked == true)
            {
                double[] arr20day = TechnicalAnalysis.SMA(20, arrclos);
                chart.Series.Add("20daySMA");
                // Set the type to line      
                chart.Series["20daySMA"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["20daySMA"].Color = Color.Green;
                chart.Series["20daySMA"].BorderWidth = 2;
                //add date and 20day SMA to series of graph
                for (int x = arr20day.Length - 1; x >= 0; x -= 1)
                {
                    chart.Series["20daySMA"].Points.AddXY(arrdat[x], arr20day[x]);
                }

            }
            //box is unchecked, remove 20 day SMA
            else
            {
                chart.Series.Remove(chart.Series["20daySMA"]);
            }

        }

        private void cb50daySMA_CheckedChanged(object sender, EventArgs e)
        {
            //check if it is on or off
            if (cb50daySMA.Checked == true)
            {
                double[] arr50day = TechnicalAnalysis.SMA(50, arrclos);
                chart.Series.Add("50daySMA");
                // Set the type to line      
                chart.Series["50daySMA"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["50daySMA"].Color = Color.Red;
                chart.Series["50daySMA"].BorderWidth = 2;
                //add date and 50day SMA to series of graph
                for (int x = arr50day.Length - 1; x >= 0; x -= 1)
                {
                    chart.Series["50daySMA"].Points.AddXY(arrdat[x], arr50day[x]);
                }
            }
            //box is unchecked, remove 50 day SMA
            else
            {
                chart.Series.Remove(chart.Series["50daySMA"]);
            }

        }

        private void cb200daySMA_CheckedChanged(object sender, EventArgs e)
        {
            //check if it is on or off
            if (cb200daySMA.Checked == true)
            {
                double[] arr200day = TechnicalAnalysis.SMA(200, arrclos);
                chart.Series.Add("200daySMA");
                // Set the type to line      
                chart.Series["200daySMA"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["200daySMA"].Color = Color.Purple;
                chart.Series["200daySMA"].BorderWidth = 2;
                //add date and 200day SMA to series of graph
                for (int x = arr200day.Length - 1; x >= 0; x -= 1)
                {
                    chart.Series["200daySMA"].Points.AddXY(arrdat[x], arr200day[x]);
                }
            }
            //box is unchecked, remove 200 day SMA
            else
            {
                chart.Series.Remove(chart.Series["200daySMA"]);
            }

        }

        private void cbBoll_CheckedChanged(object sender, EventArgs e)
        {
            double[] stdarr = TechnicalAnalysis.BOLL(arrclos);
            double[] arr20day = TechnicalAnalysis.SMA(20, arrclos);
            if (cbBoll.Checked == true)
            {
                //uncheck regular 20day SMA
                if (cb20daySMA.Checked == true)
                {
                    cb20daySMA.Checked = false;
                    cb20daySMA.Enabled = false;

                }
                else
                {
                    cb20daySMA.Enabled = false;
                }

                chart.Series.Add("UPPER BOLL");
                chart.Series.Add("20 Day SMA");
                chart.Series.Add("LOWER BOLL");

                // Set the type to line      
                chart.Series["UPPER BOLL"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["UPPER BOLL"].Color = Color.Brown;
                chart.Series["UPPER BOLL"].BorderWidth = 2;

                chart.Series["20 Day SMA"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["20 Day SMA"].Color = Color.Green;
                chart.Series["20 Day SMA"].BorderWidth = 2;

                chart.Series["LOWER BOLL"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["LOWER BOLL"].Color = Color.Orange;
                chart.Series["LOWER BOLL"].BorderWidth = 2;
                //add date and BOLL band to series of graph
                int z = 0;
                for (int x = stdarr.Length - 1; x >= 0; x -= 1)
                {
                    chart.Series["UPPER BOLL"].Points.AddXY(arrdat[x], 2 * stdarr[x] + arr20day[x]);
                    chart.Series["LOWER BOLL"].Points.AddXY(arrdat[x], -2 * stdarr[x] + arr20day[x]);
                    chart.Series["20 Day SMA"].Points.AddXY(arrdat[x], arr20day[x]);
                    z += 1;

                }
            }
            else
            {
                chart.Series.Remove(chart.Series["UPPER BOLL"]);
                chart.Series.Remove(chart.Series["LOWER BOLL"]);
                chart.Series.Remove(chart.Series["20 Day SMA"]);
                cb20daySMA.Enabled = true;

            }
        }

        private void cb50dayEMA_CheckedChanged(object sender, EventArgs e)
        {
            //check if it is on or off
            if (cb50dayEMA.Checked == true)
            {
                double[] arr50day = TechnicalAnalysis.EMA(50, arrclos);
                chart.Series.Add("50dayEMA");
                // Set the type to line      
                chart.Series["50dayEMA"].ChartType = Graph.SeriesChartType.Line;
                chart.Series["50dayEMA"].Color = Color.Gray;
                chart.Series["50dayEMA"].BorderWidth = 2;
                //add date and 50day EMA to series of graph
                for (int x = arr50day.Length - 1; x >= 0; x -= 1)
                {
                    chart.Series["50dayEMA"].Points.AddXY(arrdat[x], arr50day[x]);
                }
            }
            //box is unchecked, remove 50 day EMA
            else
            {
                chart.Series.Remove(chart.Series["50dayEMA"]);
            }

        }

        private void cbMACD_CheckedChanged(object sender, EventArgs e)
        {
            //check if it is on or off
            if (cbMACD.Checked == true)
            {


                var t = TechnicalAnalysis.MACD(arrclos);

                double[] arrMACD = t.Item2;
                double[] arr9day = t.Item1;


                volumechart.Series.Add("9dayEMA");
                // Set the type to line      
                volumechart.Series["9dayEMA"].ChartType = Graph.SeriesChartType.Line;
                volumechart.Series["9dayEMA"].Color = Color.Purple;
                volumechart.Series["9dayEMA"].BorderWidth = 1;

                volumechart.Series.Add("cross");
                volumechart.Series["cross"].ChartType = Graph.SeriesChartType.Line;
                volumechart.Series["cross"].Color = Color.Red;
                volumechart.Series["cross"].BorderWidth = 1;

                //reset old chart

                volumechart.Series.Remove(volumechart.Series["VolGrp"]);
                volumechart.ChartAreas["volseries"].AxisY.Minimum = Math.Min(arr9day.Min(), arrMACD.Min()) - 1;
                volumechart.ChartAreas["volseries"].AxisY.Maximum = Math.Max(arr9day.Max(), arrMACD.Max()) + 1;
                volumechart.ChartAreas["volseries"].AxisY.Interval = Math.Round((double)arrMACD.Max(), 0);
                
                //add date and series to series of graph
                for (int x = arr9day.Length - 1; x >= 0; x -= 1)
                {
                    volumechart.Series["9dayEMA"].Points.AddXY(arrdat[x], arr9day[x]);
                    volumechart.Series["cross"].Points.AddXY(arrdat[x], arrMACD[x]);
                }
            }
            //box is unchecked, remove series
            else
            {
                volumechart.Series.Remove(volumechart.Series["cross"]);
                volumechart.Series.Remove(volumechart.Series["9dayEMA"]);

                volumechart.ChartAreas["volseries"].AxisY.Minimum = 0;
                volumechart.ChartAreas["volseries"].AxisY.Maximum = arrvol.Max()+5;
                volumechart.ChartAreas["volseries"].AxisY.LabelStyle.Format = "{  0,0.00}";
                volumechart.ChartAreas["volseries"].AxisY.Interval = Math.Round((double)arrvol.Max(), 0);
                volumechart.ChartAreas["volseries"].AxisY.MajorGrid.LineColor = Color.White;
                volumechart.ChartAreas["volseries"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
                volumechart.ChartAreas["volseries"].BackColor = Color.White;
           

                // Create a new function series
                volumechart.Series.Add("VolGrp");

                // Set the type to line      
                volumechart.Series["VolGrp"].ChartType = Graph.SeriesChartType.Column;
                // Color the line of the graph light green and give it a thickness of 3
                volumechart.Series["VolGrp"].Color = Color.Blue;
                volumechart.Series["VolGrp"].BorderWidth = 1;

                volumechart.Series["VolGrp"].LegendText = "Volume (M)";

                //add date and adj close to series of graph
                for (int x = arrdat.Length - 1; x >= 0; x -= 1)
                {
                    volumechart.Series["VolGrp"].Points.AddXY(arrdat[x], arrvol[x]);

                }


            }

        }


    }
}
