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
    public partial class frmUserView : SampleView
    {
        public frmUserView()
        {
            InitializeComponent();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            UserAdd userAdd = new UserAdd();
            userAdd.Show();
            userAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }
        private void LoadData()
        {
            string qry = "Select uName, uUsername, uPhone, uStatus from tblUser where uName like '%" + txtSearch.Text + "%' order by uName ASC";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvUser);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvStatus);
            MainClass.loadData(qry, DataGridView, lb);
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
