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
    public partial class accounts : Form
    {
        public accounts()
        {
            InitializeComponent();
        }

        private void login_dbBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.login_dbBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void accounts_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.Login_db' table. You can move, or remove it, as needed.
            this.login_dbTableAdapter.Fill(this.database1DataSet1.Login_db);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dsb = new dashboard();
            dsb.Show();
        }
    }
}
