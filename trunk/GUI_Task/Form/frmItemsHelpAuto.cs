using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Task
{
    public partial class frmItemsHelpAuto : Form
    {
        public frmItemsHelpAuto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmItemsHelpAuto_Load(object sender, EventArgs e)
        {
            // Dataset problem faizan
            // TODO: This line of code loads data into the 'dataSet2.dsItems' table. You can move, or remove it, as needed.
            //this.dsItemsTableAdapter.Fill(this.dataSet2.dsItems);

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.dsItemsTableAdapter.Fill(this.dataSet2.dsItems, itemNameToolStripTextBox.Text, pItemGroupNameToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private int myItems;

        public int Ret_ItemID
        {
            get { return myItems; }
            set { myItems = value; }
        }

        private string myItemCode;

        public string Ret_ItemCode
        {
            get { return myItemCode; }
            set { myItemCode = value; }
        }

        private string myItemName;

        public string Ret_ItemName
        {
            get { return myItemName; }
            set { myItemName = value; }
        }

        private void dsItemsDataGridView_DoubleClick(object sender, EventArgs e)
        {
            //Ret_ItemID= dsItemsDataGridView.Rows[dsItemsDataGridView.CurrentRow.Index].Cells[0].Value.ToString();
            Ret_ItemID = Convert.ToInt32(dsItemsDataGridView.Rows[dsItemsDataGridView.CurrentRow.Index].Cells[0].Value.ToString());
            Ret_ItemCode = dsItemsDataGridView.Rows[dsItemsDataGridView.CurrentRow.Index].Cells[1].Value.ToString();
            Ret_ItemName = dsItemsDataGridView.Rows[dsItemsDataGridView.CurrentRow.Index].Cells[2].Value.ToString();
            this.Close();
        }

        private void dsItemsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }

    }
}
