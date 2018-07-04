using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier_CB
{    
    public partial class Login_Screen : Form
    {
        public static string n_string;
        static string conString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\Database1.accdb";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataReader dr;
        private bool mouseDown;
        private Point lastLocation;
        DataTable dtable = new DataTable();
        public Login_Screen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n_string = textBox1.Text;
            try
            {
                string sqlCmd = "SELECT Username FROM Login_db WHERE Username='" + textBox1.Text.ToString() +"'";
                cmd = new OleDbCommand(sqlCmd, con);
                con.Open();
                dr = cmd.ExecuteReader();
                int num = 0;
                while (dr.Read())
                {
                    num += 1;
                }

                if (num == 1 && textBox1.Text == "admin")
                {
                    dashboard dsb = new dashboard();
                    n_string = textBox1.Text;
                    dsb.Show();
                    this.Hide();
                }
                else if (dr.HasRows)
                {
                    Employee_view emv = new Employee_view();
                    n_string = textBox1.Text;
                    emv.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("INCORRECT ACCOUNT");
                }
                
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                n_string = textBox1.Text;
                try
                {
                    string sqlCmd = "SELECT Username FROM Login_db WHERE Username='" + textBox1.Text.ToString() + "'";
                    cmd = new OleDbCommand(sqlCmd, con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    int num = 0;
                    while (dr.Read())
                    {
                        num += 1;
                    }

                    if (num == 1 && textBox1.Text == "admin")
                    {
                        dashboard dsb = new dashboard();
                        n_string = textBox1.Text;
                        dsb.Show();
                        this.Hide();
                    }
                    else if (dr.HasRows)
                    {
                        Employee_view emv = new Employee_view();
                        n_string = textBox1.Text;
                        emv.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("INCORRECT ACCOUNT");
                    }

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.ExitThread();
                this.Close();
            }
        }

        private void Login_Screen_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Login_Screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Login_Screen_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
