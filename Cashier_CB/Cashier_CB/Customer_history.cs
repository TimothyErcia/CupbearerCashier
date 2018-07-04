using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Cashier_CB
{
    public partial class Customer_history : Form
    {
        static string conString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\Database1.accdb";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataTable dtable = new DataTable();
        DataSet dts = new DataSet();

        public Customer_history()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("NO. Item Bought", 80);
            listView1.Columns.Add("Date", 50);
        }

        private void Customer_history_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            string sqlCmd = "SELECT * FROM NoCustomer_today";
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
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].SubItems.Add(Form1.tracker_pass.ToString());
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

        private void populate(String item, String dtm)
        {
            String[] row = { item, dtm };
            ListViewItem lvi = new ListViewItem(row);
            listView1.Items.Add(lvi);
        }

    }
}
