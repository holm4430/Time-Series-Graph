/*Name: Kevin Holmes
 * Description: Basic program to download time series data from Yahoo Finance and plot in a graph
 * Version 1.0
 * Date: January 24, 2015
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
         private System.DateTime[] arrdat;
         private double[] arrclos;
         private string tick;

        public Form2(System.DateTime[] xaxis, double[] yaxis, string ticker, string name)
        {
            //assign closing prices and dates arrays to object
            arrdat = xaxis;
            arrclos = yaxis;
            tick = ticker;
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Text = name;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
    
            chart = new Graph.Chart();
            chart.Location = new System.Drawing.Point(10, 10);
            chart.Size = new System.Drawing.Size(700, 500);
            //ensure resize with form
            chart.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);

            chart.ChartAreas.Add("timeseries");

            chart.ChartAreas["timeseries"].AxisX.Maximum = (arrdat[0].ToOADate());
            chart.ChartAreas["timeseries"].AxisX.Minimum = (arrdat[arrdat.Length - 1].ToOADate());
            chart.ChartAreas["timeseries"].AxisX.Interval = (arrdat[0].ToOADate() - arrdat[arrdat.Length - 1].ToOADate()) / 20;
            chart.ChartAreas["timeseries"].AxisX.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["timeseries"].AxisX.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;
            chart.ChartAreas["timeseries"].AxisY.Minimum = 0;
            chart.ChartAreas["timeseries"].AxisY.Maximum = arrclos.Max() + 10;
            chart.ChartAreas["timeseries"].AxisY.Interval = Math.Round(arrclos.Max() / 10, 0);
            chart.ChartAreas["timeseries"].AxisY.MajorGrid.LineColor = Color.White;
            chart.ChartAreas["timeseries"].AxisY.MajorGrid.LineDashStyle = Graph.ChartDashStyle.Dash;

            chart.ChartAreas["timeseries"].BackColor = Color.White;

            // Create a new function series
            chart.Series.Add("MyFunc");
            // Set the type to line      
            chart.Series["MyFunc"].ChartType = Graph.SeriesChartType.Line;
            // Color the line of the graph light green and give it a thickness of 3
            chart.Series["MyFunc"].Color = Color.Blue;
            chart.Series["MyFunc"].BorderWidth = 3;
            //add date and adj close to series of graph
            for (int x = arrdat.Length-1; x >= 0; x -= 1)
            {
                chart.Series["MyFunc"].Points.AddXY(arrdat[x], arrclos[x]);
           }
            chart.Series["MyFunc"].LegendText = tick;

            // Create a new legend called "MyLegend".
            chart.Legends.Add("MyLegend");
            chart.Legends["MyLegend"].BorderColor = Color.Tomato; // I like tomato juice!
            Controls.Add(this.chart); 
        }

     


    
    }
}
