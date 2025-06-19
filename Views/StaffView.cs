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
    public partial class StaffView : SampleView
    {
        public StaffView()
        {
            InitializeComponent();
        }

        private void StaffView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            StaffAdd staffAdd = new StaffAdd();
            staffAdd.Show();
            staffAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }
        private void LoadData()
        {
            string qry = "Select * from tblStaff where sName like '%" + txtSearch.Text + "%' order by sName ASC";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvGender);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvEmail);
            lb.Items.Add(dgvId);
            MainClass.loadData(qry, DataGridView, lb);
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["dgvId"].Value);
            UserAdd userAdd = new UserAdd();
            userAdd.id = id;
            userAdd.ShowDialog();
            LoadData();
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

    }
}
