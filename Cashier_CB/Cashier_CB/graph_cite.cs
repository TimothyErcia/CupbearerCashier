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
    public partial class graph_cite : Form
    {
        static string conString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\Database1.accdb";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbDataAdapter da, da2;
        OleDbCommand cmd, cmd2;
        DataTable dtable = new DataTable();
        DataTable dtable2 = new DataTable();
        DataSet dts = new DataSet();
        //DateTime dtime;
        string string_graph;
        private int tracker_get;
        DateTimePicker dtm = new DateTimePicker();
 
        public graph_cite()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Item Bought", 140);
            listView1.Columns.Add("NO. Item Bought", 140);
            listView1.Columns.Add("% of Item Bought", 140);
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Columns.Add("NO. Customers", 80);
            listView2.Columns.Add("Date", 120);
        }

        private void graph_cite_Load(object sender, EventArgs e)
        {
            this.Update();
            string_graph = "Profit";
            chart1.Series.Add(string_graph);
            loaddata_ch2();
            loaddata();
            loaddata_people();
        }

        private void loaddata_people()
        {
            string sqlCmd2 = "SELECT * FROM NoCustomer_today";
            cmd2 = new OleDbCommand(sqlCmd2, con);
            listView2.Items.Clear();
            try
            {
                con.Open();
                da2 = new OleDbDataAdapter(cmd2);
                da2.Fill(dtable2);

                foreach (DataRow row in dtable2.Rows)
                {
                    populate_people(row[1].ToString(), row[2].ToString());
                }
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    listView2.Items[i].SubItems.Add(Form1.tracker_pass.ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            removeDupli(listView2);
        }
        private void populate_people(String item, String dtm)
        {
            String[] row = { item, dtm };
            ListViewItem lvi = new ListViewItem(row);
            listView2.Items.Add(lvi);
        }

        private void loaddata_ch2()
        {
            string sqlCmd = "SELECT * FROM Profit_report";
            cmd = new OleDbCommand(sqlCmd, con);
            try
            {
                con.Open();
                da = new OleDbDataAdapter(cmd);
                da.Fill(dts, "Sum");
                chart1.DataSource = dts.Tables["Sum"];
                chart1.Series[string_graph].YValueMembers = "Sum";
                //chart1.Series[string_graph].XValueMember = "Date";
                this.chart1.Titles.Add("Profit Report");
                chart1.Series[string_graph].ChartType = SeriesChartType.Line;
                chart1.Series[string_graph].IsValueShownAsLabel = true;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void loaddata()
        {
//---------------------------------------------------
             string sqlCmd2 = "SELECT * FROM NoCustomer_today";
            OleDbCommand cmd2 = new OleDbCommand(sqlCmd2, con);
            OleDbDataReader dr2;
            try
            {
                con.Open();
                dr2 = cmd2.ExecuteReader();
                dr2.Read();
                tracker_get = dr2.GetInt32(1);
                con.Close();
            }
            catch (Exception ex1)
            {
                con.Close();
            }
//------------------------------------------------------
            string sqlCmd = "SELECT * FROM report_graph ORDER BY No_ItemBought DESC";
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
                for(int i=0; i<listView1.Items.Count; i++)
                {
                    string get_column = listView1.Items[i].SubItems[1].Text;
                    double percent = Convert.ToDouble(get_column);
                    double total_num = (percent / tracker_get) * 100;
                    listView1.Items[i].SubItems.Add(total_num.ToString("#.##") + "%");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            removeDupli(listView1);
        }
        private void removeDupli(ListView listview)
        {
            var tags = new HashSet<string>();
            var dupli = new List<ListViewItem>();
            foreach (ListViewItem itm in listView1.Items)
            {
                if (!tags.Add(itm.Text))
                {
                    dupli.Add(itm);
                }
            }
            foreach (ListViewItem itm in dupli)
            {
                itm.Remove();
            }
        }
        private void populate(String item, String itmBought)
        {
            String[] row = { item, itmBought };
            ListViewItem lvi = new ListViewItem(row);
            listView1.Items.Add(lvi);
        }
    }
}
