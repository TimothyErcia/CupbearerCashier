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

namespace Cashier_CB
{
    public partial class Form1 : Form
    {
        static string conString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\Database1.accdb";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd, cmd2, cmdInsert, cmdweek;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataTable dtable = new DataTable();
        DateTimePicker dtm;
        private int i = 0;
        private double sum;
        private int tracker, num_sl, tracker_get;
        public static int tracker_pass;
        public static string num_pass;
        private string try_lang, dts;
        private double d_sum;
        private int dYear = DateTime.Now.Year;
        private int dMonth = DateTime.Now.Month;
        private int dDay = DateTime.Now.Day;
        private double UpdateSum;

        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Columns.Add("No.", 50);
            listView2.Columns.Add("Description", 240);
            listView2.Columns.Add("Price", 50);
            listView1.Columns.Add("Item", 140);
            listView1.Columns.Add("Price", 50);
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void loaddata()
        {
            string sqlCmd = "SELECT * FROM Item_Final";
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

        private void populate(String item, String price)
        {
            String[] row = { item, price };
            ListViewItem lvi = new ListViewItem(row);
            listView1.Items.Add(lvi);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Update();
            listView2.Items.Clear();
            textBox1.Text = "Search..";
            loaddata();
            label2.Text = "0.00";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtm = new DateTimePicker();
            dtm.Value = DateTime.Now.AddDays(0);
            dts = dtm.Value.ToString();
 //----------------------------------------------------
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
//----------------------------------------------------
            if (tracker_get == 0)
            {
                //----------------------------------------------------
                string sqlCmd2_6 = "INSERT INTO NoCustomer_today([Customer_today], [Date]) VALUES(" + tracker_get + ",'" + dts + "')" + "";
                OleDbCommand cmd2_6 = new OleDbCommand(sqlCmd2_6, con);
                try
                {
                    con.Open();
                    cmd2_6.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                    con.Close();
                }

                //-----------------------------------------------------
            }
            tracker_get += 1;
            double num = Convert.ToDouble(textBox2.Text);
            double chc = num - sum;
            double discount_num = Convert.ToInt32(textBox3.Text);
            d_sum = (sum - ((discount_num / 100) * sum));
            double chc_dsum = num - d_sum;
            if (num < d_sum || num < sum)
             {
                    MessageBox.Show("Insufficient Cash");
                    textBox2.Text = "";
                    num = 0;
                    sum = 0;
                    d_sum = 0;
                    if (tracker_get < 0)
                    {
                        tracker_get = 1;
                    }
                    else
                    {
                        tracker_get -= 1;
                    }
               richTextBox1.Text = "INVALID";
              }
            else
             {
                if (d_sum != 0)
                {
                    richTextBox1.Text = "Cash: " + num + "\n" + "Change: " + chc_dsum + "\n" + "Profit gained: " + label2.Text;
                    string sqlCmd = "INSERT into Profit_report([Sum],[Date]) VALUES(" + d_sum + ",'" + dts + "')";
                    cmd = new OleDbCommand(sqlCmd, con);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }

                }
                else
                {
                    richTextBox1.Text = "Cash: " + num + "\n" + "Change: " + chc + "\n" + "Profit gained: " + label2.Text;
                    string sqlCmd = "INSERT into Profit_report([Sum],[Date]) VALUES(" + sum + ",'" + dts + "')";
                    cmd = new OleDbCommand(sqlCmd, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
                   
//----------------------------------------------------
                string sqlCmd2_5 = "UPDATE NoCustomer_today SET[Customer_today]=" + tracker_get + ",[Date] = '" + dts + "'";
                OleDbCommand cmd2_5 = new OleDbCommand(sqlCmd2_5, con);
                try
                {
                    con.Open();
                    cmd2_5.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.Message);
                    con.Close();
                }

//-----------------------------------------------------
                for (int k = 0; k < listView2.Items.Count; k++)
                {
                    ListViewItem lvi = listView2.Items[k];
                    string itm = lvi.SubItems[1].Text;
                    string prc_s = lvi.SubItems[2].Text;
                    int prc = Convert.ToInt32(prc_s);
                    DateTimePicker dtm_2 = new DateTimePicker();
                    string acc = Login_Screen.n_string;
                    dtm_2.Value = DateTime.Now.AddDays(0);
                    string dts_2 = dtm_2.Value.ToString();
                    string sqlCmd_2 = "INSERT INTO Today_report([Item],[Price],[Date],[Account]) VALUES('" + itm + "'," + prc_s + ",'" + dts_2 + "','" + acc + "')";
                    cmd = new OleDbCommand(sqlCmd_2, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }

                }

            }

            string sqlCmdRead = "SELECT * FROM weekly_report";
            cmdweek = new OleDbCommand(sqlCmdRead, con);
            OleDbDataReader drRead;
            try
            {
                con.Open();
                drRead = cmdweek.ExecuteReader();
                drRead.Read();
                UpdateSum = drRead.GetInt32(1);
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            string sqlCmdInsert = "INSERT into weekly_report([Sum],[Date]) VALUES(" + UpdateSum + ",'" + dts + "')";
            OleDbCommand cmdInsert = new OleDbCommand(sqlCmdInsert, con);
            var dtMax = new DateTime(dYear, dMonth, dDay, 23, 58, 59);
            try
            {
                con.Open();
                if (UpdateSum == 0 || DateTime.Now >= dtMax)
                {
                    cmdInsert.ExecuteNonQuery();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
            if (d_sum != 0)
            {
                UpdateSum += d_sum;
            }
            else
            {
                UpdateSum += sum;
            }
            string sqlCmdweeklyUpdateIn = "UPDATE weekly_report SET[Sum]=" + UpdateSum + ",[Date]='" + dts + "'";
            OleDbCommand cmdUpdateIn = new OleDbCommand(sqlCmdweeklyUpdateIn, con);
            try
            {
                con.Open();
                cmdUpdateIn.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string acc = Login_Screen.n_string;
            ListViewItem lvi = listView1.SelectedItems[0];
            string itm = lvi.SubItems[0].Text;
            tracker += 1;
            num_pass = tracker.ToString();
            listView2.Items.Add(tracker.ToString());
            listView2.Items[i].SubItems.Add(lvi.SubItems[0].Text);
            listView2.Items[i].SubItems.Add(lvi.SubItems[1].Text);
            if (listView2.Items.Count != 0)
            {
                i += 1;
            }
            int j = Convert.ToInt32(lvi.SubItems[1].Text);
            sum += j;
            label2.Text = sum.ToString();
//----------------------------------------------------
            string sqlCmd2 = "SELECT * FROM report_graph WHERE [Item]='"+listView1.SelectedItems[0].Text+"'";
            OleDbCommand cmd2 = new OleDbCommand(sqlCmd2, con);
            try
            {
                con.Open();
                dr = cmd2.ExecuteReader();
                dr.Read();
                num_sl = dr.GetInt32(2);
                con.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
                con.Close();
            }
            num_sl += 1;
//-----------------------------------------------------
            string sqlCmd2_5 = "UPDATE report_graph SET[Item]='" + itm + "',[No_ItemBought]=" + num_sl + " WHERE [Item]='" + itm + "'";
            OleDbCommand cmd2_5 = new OleDbCommand(sqlCmd2_5, con);
            try
            {
                con.Open();
                cmd2_5.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            sum = 0;
            i = 0;
            richTextBox1.Text = "";
            textBox2.Text = "";
            num_sl = 0;
            label2.Text = "0.00";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Update();
            loaddata();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {  
            if (textBox1.Text != "")
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    var item = listView1.Items[i];
                    if (item.Text.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        item.BackColor = SystemColors.Highlight;
                        item.ForeColor = SystemColors.HighlightText;
                    }
                    else
                    {
                        listView1.Items.Remove(item);
                    }
                }
                if (listView1.SelectedItems.Count == 1)
                {
                    listView1.Focus();
                }
            }
            else
            {
                listView1.Items.Clear();
                loaddata();
            }

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        contextMenuStrip1.Show(this, new Point(e.X + 250, e.Y + 40));
                    }
                    break;
                case MouseButtons.Left:
                    {
                        ListViewItem lvt = listView2.SelectedItems[0];
                        string itm = lvt.SubItems[1].Text;
                        try_lang = itm;
                    }
                    break;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvt = listView2.SelectedItems[0];
            lvt.Remove();
//----------------------------------------------------      
            string sqlCmd_graph = "SELECT * FROM report_graph WHERE[Item]='"+try_lang+"'";
            OleDbCommand cmd_graph = new OleDbCommand(sqlCmd_graph, con);
                try
                {
                    con.Open();
                    dr = cmd_graph.ExecuteReader();
                    dr.Read();
                    dr.Close();
                    num_sl = dr.GetInt32(2);
                    con.Close();
                }
                catch (Exception ex1)
                {
                    con.Close();
                }
            num_sl -= 1;
 //-----------------------------------------------------
            string sqlCmd2_5 = "UPDATE report_graph SET[Item]='"+ try_lang +"',[No_ItemBought]=" + num_sl + " WHERE [Item]='"+ try_lang +"'";
            OleDbCommand cmd2_5 = new OleDbCommand(sqlCmd2_5, con);
            try
            {
                con.Open();
                cmd2_5.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
                con.Close();
            }
           
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                double discount_d;
                discount_d = Convert.ToDouble(textBox3.Text.ToString());
                d_sum = (sum - ((discount_d / 100) * sum));
                label2.Text = d_sum.ToString();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}