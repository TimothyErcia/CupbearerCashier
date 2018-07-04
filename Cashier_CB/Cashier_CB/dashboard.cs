using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier_CB
{
    public partial class dashboard : Form
    {
        private int state = 1;
        private bool mouseDown;
        private Point lastLocation;
        Form1 frm = new Form1();
        graph_cite lgc = new graph_cite();
        profit_today prt = new profit_today();
        Boolean frm_b, lgc_b, prt_b;
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.ExitThread();
                this.Close();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            Billing_tracker blt = new Billing_tracker();
            blt.MdiParent = this;
            blt.Show();
            if (state == 1)
            {
                blt.Location = new Point(61, 40);
                blt.Size = new Size(850, 620);
            }
            else { blt.Location = new Point(172, 37); }
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = Color.White;
            }
        }
       

        private void profitTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prt.StartPosition = FormStartPosition.CenterScreen;
            prt.Show();
            prt.MdiParent = this;
            prt_b = true;
            frm_b = false;
            
            lgc_b = false;
            if(state ==1)
            {
                prt.Location = new Point(61, 40);
                prt.Size = new Size(850, 620);
            }
            else { prt.Location = new Point(172, 37);  }
            lgc.Hide();
            frm.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Size sz = new Size(61, 681);
            if(panel2.Size == sz)
            {
                pictureBox2.Enabled = false;
                pictureBox3.Enabled = false;
                pictureBox4.Enabled = false;
                pictureBox1.Enabled = false;
            }
            else
            {
                pictureBox2.Enabled = true;
                pictureBox3.Enabled = true;
                pictureBox4.Enabled = true;
                pictureBox1.Enabled = true;
            }
            if (state == 1)
            {
                //icon only
                panel2.Size = new Size(61, 681);
                state = 2;
                if (frm_b == true)
                {
                    frm.Location = new Point(61, 40);
                    frm.Size = new Size(850, 620);
                    prt_b = false;
                    lgc_b = false; 
                }
                else if (prt_b == true)
                {
                    prt.Location = new Point(61, 40);
                    prt.Size = new Size(850, 620);
                    frm_b = false;   
                    lgc_b = false;
                }
                else if (lgc_b == true)
                {
                    lgc.Location = new Point(61, 40);
                    lgc.Size = new Size(850, 620);
                    prt_b = false;
                    frm_b = false;
                }
            }
            else if (state == 2)
            {
                //icon and label
                panel2.Size = new Size(156, 681);
                state = 1;
                if (frm_b == true)
                {
                    frm.Location = new Point(172, 37);
                    frm.Size = new Size(739, 626);
                    prt_b = false;
                    lgc_b = false;
                }
                else if (prt_b == true)
                {
                    prt.Location = new Point(172, 37);
                    prt.Size = new Size(739, 626);
                    frm_b = false;
                    lgc_b = false;
                }
                else if (lgc_b == true)
                {
                    lgc.Location = new Point(172, 37);
                    lgc.Size = new Size(739, 626);
                    prt_b = false;
                    frm_b = false;
                }
            }

        }
        //cashier icon
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frm.Update();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.MdiParent = this;
            prt_b = false;
            lgc_b = false;
            frm.Location = new Point(61, 40);
            frm.Size = new Size(850, 620);
            lgc.Close();
            prt.Close();
             
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Employee_view emv = new Employee_view();
            emv.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login_Screen log = new Login_Screen();
            log.Show();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        contextMenuStrip2.Show(this, new Point(e.X + 650, e.Y + 15));
                    }
                    break;
            }
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_tab edt = new Edit_tab();
            edt.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            accounts acc = new accounts();
            acc.Show();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(16, 33, 56);
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightSlateGray;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.LightSlateGray;
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.LightSlateGray;
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightSlateGray;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(16, 33, 56);
        }

        //profit icon
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            profit_today prt = new profit_today();
            prt.Update();
            prt.StartPosition = FormStartPosition.CenterScreen;
            prt.Show();
            prt.MdiParent = this;
            prt_b = true;
            prt.Location = new Point(61, 40);
            prt.Size = new Size(850, 620);
            lgc.Hide();
            frm.Hide();
        }

        //cashier
        private void panel4_Click(object sender, EventArgs e)
        {
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.MdiParent = this;
            frm_b = true;
            prt_b = false;
            lgc_b = false;
            frm.Location = new Point(172, 37);
            lgc.Hide();
            prt.Hide();
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.LightSlateGray;
            pictureBox2.BackColor = Color.LightSlateGray;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox2.BackColor = Color.FromArgb(16, 33, 56);
        }

        //graph
        private void panel3_Click(object sender, EventArgs e)
        {
            graph_cite lgc = new graph_cite();
            lgc.Update();
            lgc.StartPosition = FormStartPosition.CenterScreen;
            lgc.Show();
            lgc.MdiParent = this;
            lgc_b = true;
            lgc.Location = new Point(172, 37);
            frm.Hide();
            prt.Hide();
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.LightSlateGray;
            pictureBox1.BackColor = Color.LightSlateGray;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox1.BackColor = Color.FromArgb(16, 33, 56);
        }
        //profit
        private void panel5_Click(object sender, EventArgs e)
        {
            profit_today prt = new profit_today();
            prt.Update();
            prt.StartPosition = FormStartPosition.CenterScreen;
            prt.Show();
            prt.MdiParent = this;
            prt_b = true;
            prt.Location = new Point(172, 37);
            lgc.Hide();
            frm.Hide();
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox3.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.LightSlateGray;
            pictureBox3.BackColor = Color.LightSlateGray;
        }
        //info
        private void panel6_Click(object sender, EventArgs e)
        {
            Info_guide ifg = new Info_guide();
            ifg.Show();
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox4.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.LightSlateGray;
            pictureBox4.BackColor = Color.LightSlateGray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox2.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.LightSlateGray;
            pictureBox2.BackColor = Color.LightSlateGray;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox1.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.LightSlateGray;
            pictureBox1.BackColor = Color.LightSlateGray;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox3.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.LightSlateGray;
            pictureBox3.BackColor = Color.LightSlateGray;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(16, 33, 56);
            pictureBox4.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = Color.LightSlateGray;
            pictureBox4.BackColor = Color.LightSlateGray;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(16, 33, 56);
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightSlateGray;
        }

        //graph icon
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            graph_cite lgc = new graph_cite();
            lgc.Update();
            lgc.StartPosition = FormStartPosition.CenterScreen;
            lgc.Show();
            lgc.MdiParent = this;
            lgc_b = true;
            lgc.Location = new Point(61, 40);
            lgc.Size = new Size(850, 620);
            frm.Hide();
            prt.Hide();
        }

        //info icon
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Info_guide ifg = new Info_guide();
            ifg.Show();
        }

    }
}
