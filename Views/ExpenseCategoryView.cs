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

namespace SchoolManagementSystem.Views
{
    public partial class ExpenseCategoryView : SampleView
    {
        public ExpenseCategoryView()
        {
            InitializeComponent();
        }

        private void ExpenseCategoryView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            ExpenseCategoryAdd expenseCatAdd = new ExpenseCategoryAdd();
            expenseCatAdd.Show();
            expenseCatAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }
        private void LoadData()
        {
            string qry = "SELECT * FROM tblExpenseCat WHERE expCatName LIKE '%" + txtSearch.Text + "%' ORDER BY expCatName ASC";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            MainClass.loadData(qry, DataGridView, lb);
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["dgvId"].Value);
            ExpenseCategoryAdd expenseCatAdd = new ExpenseCategoryAdd();
            expenseCatAdd.id = id;
            expenseCatAdd.ShowDialog();
            LoadData();
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.SrNo(DataGridView);
        }
    }
}
