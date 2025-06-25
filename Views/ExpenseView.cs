using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SchoolManagementSystem.Views
{
    public partial class ExpenseView : SampleView
    {
        public ExpenseView()
        {
            InitializeComponent();
        }

        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            ExpenseAdd expenseAdd = new ExpenseAdd();
            expenseAdd.Show();
            expenseAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }


        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string qry = "SELECT expDate, ec.expCatName, expDescription FROM tblExpense e INNER JOIN tblExpenseCat ec ON e.expCatID = ec.expCatID " +
                         "WHERE expDescription LIKE '%" + txtSearch.Text + "%' ORDER BY expID ASC";

            ListBox lb = new ListBox();
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvexpCatName);
            lb.Items.Add(dgvexpDescription);

            MainClass.loadData(qry, DataGridView, lb);
        }

        #region
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["dgvId"].Value);
            ExpenseAdd expenseAdd = new ExpenseAdd();
            expenseAdd.id = id;
            expenseAdd.ShowDialog();
            LoadData();
        }
        #endregion

        #region
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.SrNo(DataGridView);
        }
        #endregion

        private void ExpenseView_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
