namespace Cashier_CB
{
    partial class accounts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label usernameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accounts));
            this.database1DataSet1 = new Cashier_CB.Database1DataSet1();
            this.login_dbBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.login_dbTableAdapter = new Cashier_CB.Database1DataSet1TableAdapters.Login_dbTableAdapter();
            this.tableAdapterManager = new Cashier_CB.Database1DataSet1TableAdapters.TableAdapterManager();
            this.login_dbBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.login_dbBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.login_dbDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.Delete = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            iDLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_dbBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_dbBindingNavigator)).BeginInit();
            this.login_dbBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_dbDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(12, 42);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(21, 13);
            iDLabel.TabIndex = 1;
            iDLabel.Text = "ID:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(12, 68);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(58, 13);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username:";
            // 
            // database1DataSet1
            // 
            this.database1DataSet1.DataSetName = "Database1DataSet1";
            this.database1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // login_dbBindingSource
            // 
            this.login_dbBindingSource.DataMember = "Login_db";
            this.login_dbBindingSource.DataSource = this.database1DataSet1;
            // 
            // login_dbTableAdapter
            // 
            this.login_dbTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.graph_reportTableAdapter = null;
            this.tableAdapterManager.Item_FinalTableAdapter = null;
            this.tableAdapterManager.Items_CB2TableAdapter = null;
            this.tableAdapterManager.Login_dbTableAdapter = this.login_dbTableAdapter;
            this.tableAdapterManager.NoCustomer_todayTableAdapter = null;
            this.tableAdapterManager.Profit_reportTableAdapter = null;
            this.tableAdapterManager.Today_reportTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Cashier_CB.Database1DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // login_dbBindingNavigator
            // 
            this.login_dbBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.login_dbBindingNavigator.BindingSource = this.login_dbBindingSource;
            this.login_dbBindingNavigator.CountItem = null;
            this.login_dbBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.login_dbBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator2,
            this.toolStripLabel1,
            this.bindingNavigatorAddNewItem,
            this.toolStripSeparator1,
            this.Delete,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.login_dbBindingNavigatorSaveItem});
            this.login_dbBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.login_dbBindingNavigator.MoveFirstItem = null;
            this.login_dbBindingNavigator.MoveLastItem = null;
            this.login_dbBindingNavigator.MoveNextItem = null;
            this.login_dbBindingNavigator.MovePreviousItem = null;
            this.login_dbBindingNavigator.Name = "login_dbBindingNavigator";
            this.login_dbBindingNavigator.PositionItem = null;
            this.login_dbBindingNavigator.Size = new System.Drawing.Size(362, 25);
            this.login_dbBindingNavigator.TabIndex = 0;
            this.login_dbBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // login_dbBindingNavigatorSaveItem
            // 
            this.login_dbBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.login_dbBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("login_dbBindingNavigatorSaveItem.Image")));
            this.login_dbBindingNavigatorSaveItem.Name = "login_dbBindingNavigatorSaveItem";
            this.login_dbBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.login_dbBindingNavigatorSaveItem.Text = "Save Data";
            this.login_dbBindingNavigatorSaveItem.Click += new System.EventHandler(this.login_dbBindingNavigatorSaveItem_Click);
            // 
            // iDTextBox
            // 
            this.iDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.login_dbBindingSource, "ID", true));
            this.iDTextBox.Enabled = false;
            this.iDTextBox.Location = new System.Drawing.Point(76, 39);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.Size = new System.Drawing.Size(100, 20);
            this.iDTextBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.login_dbBindingSource, "Username", true));
            this.usernameTextBox.Location = new System.Drawing.Point(76, 65);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(100, 20);
            this.usernameTextBox.TabIndex = 4;
            // 
            // login_dbDataGridView
            // 
            this.login_dbDataGridView.AutoGenerateColumns = false;
            this.login_dbDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.login_dbDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.login_dbDataGridView.DataSource = this.login_dbBindingSource;
            this.login_dbDataGridView.Location = new System.Drawing.Point(12, 91);
            this.login_dbDataGridView.Name = "login_dbDataGridView";
            this.login_dbDataGridView.Size = new System.Drawing.Size(340, 220);
            this.login_dbDataGridView.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "Add";
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(40, 22);
            this.Delete.Text = "Delete";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel3.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Username";
            this.dataGridViewTextBoxColumn2.HeaderText = "Username";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 245;
            // 
            // accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 318);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.login_dbDataGridView);
            this.Controls.Add(iDLabel);
            this.Controls.Add(this.iDTextBox);
            this.Controls.Add(usernameLabel);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.login_dbBindingNavigator);
            this.Name = "accounts";
            this.Text = "accounts";
            this.Load += new System.EventHandler(this.accounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_dbBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.login_dbBindingNavigator)).EndInit();
            this.login_dbBindingNavigator.ResumeLayout(false);
            this.login_dbBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_dbDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Database1DataSet1 database1DataSet1;
        private System.Windows.Forms.BindingSource login_dbBindingSource;
        private Database1DataSet1TableAdapters.Login_dbTableAdapter login_dbTableAdapter;
        private Database1DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator login_dbBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton login_dbBindingNavigatorSaveItem;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.DataGridView login_dbDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}