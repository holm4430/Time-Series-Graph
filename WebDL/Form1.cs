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
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDL
{
    public partial class Form1 : Form
    {
        private string[] myArr;
        public Form1()
        {

            string[] timearr = {"Daily", "Weekly", "Monthly"};
            InitializeComponent();
            lstDataType.DataSource = timearr;
        }



        private void btnDownload_Click(object sender, EventArgs e)
        {
            //check if user has chosen a later start date
            if (dtpStart.Value >= dtpEnd.Value)
            {
                MessageBox.Show("Please choose an End Date that is later than the Start Date.");
            }
                //check if either date is later than today
            else if (dtpStart.Value >= DateTime.Now || dtpEnd.Value >= DateTime.Now)
            {
                MessageBox.Show("Please ensure both Start Date and End Date are not later than today.");
            }
                //ok to proceed
            else if (tbName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please fill out a Ticker.");
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                WebClient webClient = new WebClient();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                   
                    //parse the datepicker times for URL construction
                    string tic = tbName.Text;
                    string yrstart = dtpStart.Value.Year.ToString();
                    string monstart = (dtpStart.Value.Month-1).ToString("00");
                    string daystart = dtpStart.Value.Day.ToString();
                    
                    string yrend = dtpEnd.Value.Year.ToString();
                    string monend = (dtpEnd.Value.Month - 1).ToString("00");
                    string dayend = dtpEnd.Value.Day.ToString();
                    string timetype;

                    //see which type of time series was chosen
                    if (lstDataType.GetItemText(lstDataType.SelectedItem) == "Monthly")
                    {
                        timetype = "m";
                    }
                    else if (lstDataType.GetItemText(lstDataType.SelectedItem) == "Weekly")
                    {
                        timetype = "w";
                    }
                    else{
                        timetype = "d";
                    }
                    
                    label2.Text = fbd.SelectedPath;
                        
                    Uri url = new Uri(@"http://real-chart.finance.yahoo.com/table.csv?s=" + tic + "&d=" + monend + "&e=" + dayend + "&f=" + yrend + "&g=" + timetype + "&a=" + monstart + "&b=" + daystart + "&c=" + yrstart + "&ignore=.csv");
                    try
                    {
                        webClient.DownloadFile(url, label2.Text + @"\finance.csv");
                        FileStream fs = new FileStream(label2.Text + @"\finance.csv", FileMode.Open);
                        StreamReader sr = new StreamReader(fs);

                        DataSet dataset = new DataSet();

                        dataset.Tables.Add("FinData");
                        dataset.Tables["FinData"].Columns.Add("Date");
                        dataset.Tables["FinData"].Columns.Add("Open");
                        dataset.Tables["FinData"].Columns.Add("High");
                        dataset.Tables["FinData"].Columns.Add("Low");
                        dataset.Tables["FinData"].Columns.Add("Close");
                        dataset.Tables["FinData"].Columns.Add("Volume");
                        dataset.Tables["FinData"].Columns.Add("Adj Close");


                        string item;
                        while ((item = sr.ReadLine()) != null)
                        {
                            myArr = item.Split(',');
                            dataset.Tables["FinData"].Rows.Add(myArr);

                        }
                        dgData.DataSource = dataset.Tables[0].DefaultView;
                        dgData.Rows.Remove(dgData.Rows[0]);
                        dgData.Sort(dgData.Columns[0], ListSortDirection.Descending);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: INVALID TICKER ENTERED!");
                    }
                }
            }
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            DateTime[] arrdate = new System.DateTime[dgData.RowCount];
            double[] arrclose = new double[dgData.RowCount];
            double[] arrvol = new double[dgData.RowCount];
            long i = 0;

            if (dgData.Rows.Count == 0)
            {
                MessageBox.Show("Please download data first!");

            }
            else{
            foreach (DataGridViewRow row in dgData.Rows)
            {
                //check if row is empty
                if (row.Cells[0].Value != DBNull.Value)
                {
                    arrdate[i] = DateTime.Parse(row.Cells[0].Value.ToString());
                    arrclose[i] = double.Parse(row.Cells[6].Value.ToString());
                    arrvol[i] = double.Parse(row.Cells[5].Value.ToString())/1000000.0;
                }
                i = i + 1;
            }
            Form2 frmwithgraph = new Form2(arrdate,arrclose,arrvol,tbName.Text, lstDataType.GetItemText(lstDataType.SelectedItem) + " Time Series Data");
            frmwithgraph.Show();
            }

        }



    }
}
