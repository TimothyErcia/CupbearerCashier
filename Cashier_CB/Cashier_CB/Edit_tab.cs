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
    public partial class Edit_tab : Form
    {
        static string conString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\Database1.accdb";
        OleDbConnection con = new OleDbConnection(conString);
        DataTable dtable;
        OleDbDataAdapter da;
        BindingSource bs;
        OleDbCommand cmd, cmdSearch;
        private int numberS = 0;
        public Edit_tab()
        {
            InitializeComponent();
        }

        private void Edit_tab_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Item_Final' table. You can move, or remove it, as needed.
            this.item_FinalTableAdapter.Fill(this.database1DataSet1.Item_Final);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dsb = new dashboard();
            dsb.Show();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            string itm = itemTextBox.Text;
            string sqlCmd2 = "UPDATE report_graph SET[Item] = '"+ itm.ToString() +"',[No_ItemBought]=" + numberS + " WHERE[Item]='"+ itm.ToString() +"'";
            OleDbCommand cmd2 = new OleDbCommand(sqlCmd2, con);
            try
            {
                con.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd2);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sqlCmd2;
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            } 
        }

        private void item_FinalBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            string itm = itemTextBox.Text;
            int prc = 0;
            string sqlCmd = "INSERT into report_graph([Item],[No_ItemBought]) VALUES('" + itm + "'," + prc + ")";
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

            this.Validate();
            this.item_FinalBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sqlCmdSearch = "SELECT * FROM Item_Final WHERE Item LIKE '" + textBox1.Text + "%'";
            string sqlCmd = "SELECT * FROM Item_Final";
                if (textBox1.Text == "")
                {
                    cmd = new OleDbCommand(sqlCmd, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        dtable = new DataTable();
                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dtable);
                        item_FinalDataGridView.DataSource = dtable;
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
                    cmdSearch = new OleDbCommand(sqlCmdSearch, con);
                    try
                    {
                        con.Open();
                        cmdSearch.ExecuteNonQuery();
                        dtable = new DataTable();
                        da = new OleDbDataAdapter(cmdSearch);
                        da.Fill(dtable);
                        item_FinalDataGridView.DataSource = dtable;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sqlCmdSearch = "SELECT * FROM Item_Final WHERE Item LIKE '" + textBox1.Text +"%'";
            string sqlCmd = "SELECT * FROM Item_Final";
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (textBox1.Text == "")
                {
                    cmd = new OleDbCommand(sqlCmd, con);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        dtable = new DataTable();
                        da = new OleDbDataAdapter(cmd);
                        da.Fill(dtable);
                        item_FinalDataGridView.DataSource = dtable;
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
                    cmdSearch = new OleDbCommand(sqlCmdSearch, con);
                    try
                    {
                        con.Open();
                        cmdSearch.ExecuteNonQuery();
                        dtable = new DataTable();
                        da = new OleDbDataAdapter(cmdSearch);
                        da.Fill(dtable);
                        item_FinalDataGridView.DataSource = dtable;
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        con.Close();
                    }
                }
            }
        }

    }
}
