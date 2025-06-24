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

        #region LoadData
        private void LoadData()
        {
            string qry = "Select userID, uName, uUsername, uPhone, uStatus from tblUser where uName like '%" + txtSearch.Text + "%' order by uName ASC";
            string qry1 = QueryClass.UserView(txtSearch.Text);
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvUser);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvStatus);
            MainClass.loadData(qry1, DataGridView, lb);
        }
        #endregion

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
            MainClass.SrNo(DataGridView);
        }
    }
}
