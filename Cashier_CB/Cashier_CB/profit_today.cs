using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cashier_CB
{
    public partial class profit_today : Form
    {
        static string conString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\Database1.accdb";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd, cmd2, cmd3;
        OleDbDataAdapter da, da2, da3;
        DataTable dtable = new DataTable();
        DataTable dtable2 = new DataTable();
        DataTable dtableSum = new DataTable();
        DataSet dSet = new DataSet();
        string title_graph;
        public profit_today()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Sum", 50);
            listView1.Columns.Add("Date", 180);
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Columns.Add("Item", 110);
            listView2.Columns.Add("Price", 50);
            listView2.Columns.Add("Date", 110);
            listView2.Columns.Add("Account", 75);
        }
        private void loaddata2()
        {
            string sqlCmd2 = "SELECT * FROM Today_report";
            cmd2 = new OleDbCommand(sqlCmd2, con);
            try
            {
                con.Open();
                da2 = new OleDbDataAdapter(cmd2);
                da2.Fill(dtable2);

                foreach (DataRow row2 in dtable2.Rows)
                {
                    populate2(row2[1].ToString(), row2[2].ToString(), row2[3].ToString(), row2[4].ToString());
                }
                con.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
                con.Close();
            }
        }
        private void populate2(String item, String price, String date, String acc)
        {
            String[] row2 = { item, price, date, acc };
            ListViewItem lvi2 = new ListViewItem(row2);
            listView2.Items.Add(lvi2);
        }

        private void loaddata()
        {
            string sqlCmd = "SELECT * FROM Profit_report";
            cmd = new OleDbCommand(sqlCmd, con);
            listView1.Items.Clear();
            try
            {
                con.Open();
                da = new OleDbDataAdapter(cmd);
                da.Fill(dtable);

                foreach (DataRow row in dtable.Rows)
                {
                    populate(row[1].ToString(), row[2].ToString());
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            } 
        }         

        private void populate(String sum, String date)
        {
            String[] row = { sum, date };
            ListViewItem lvi = new ListViewItem(row);
            listView1.Items.Add(lvi);
        }

        private void profit_today_Load(object sender, EventArgs e)
        {
            this.Update();
            title_graph = "weekly_report";
            chart1.Series.Add(title_graph);
            listView1.Update();
            listView2.Update();
            loaddata();
            loaddata2();
            loadWeekly();
        }

        private void loadWeekly()
        {
            string sqlCmd3 = "SELECT * FROM weekly_report";
            cmd3 = new OleDbCommand(sqlCmd3, con);
            try
            {
                con.Open();
                da3 = new OleDbDataAdapter(cmd3);
                da3.Fill(dSet, "Sum");
                chart1.DataSource = dSet.Tables["Sum"];
                chart1.Series[title_graph].YValueMembers = "Sum";
                //chart1.Series[string_graph].XValueMember = "Date";
                this.chart1.Titles.Add("Weekly Report");
                chart1.Series[title_graph].ChartType = SeriesChartType.Bar;
                chart1.Series[title_graph].IsValueShownAsLabel = true;
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
