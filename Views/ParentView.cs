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
    public partial class ParentView : SampleView
    {
        public ParentView()
        {
            InitializeComponent();
        }

        public int id = 0;
        #region LoadData
        private void LoadData()
        {
            string qry = "Select * from tblParent where pName like '%" + txtSearch.Text + "%' order by pName ASC";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvIDNo);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvGender);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvEmail);
            lb.Items.Add(dgvAddress);
            MainClass.loadData(qry, DataGridView, lb);
        }
        #endregion

        #region ParentView_Load
        private void Parentview_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region Text Search
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region btnSave_Click
        public override void btnSave_Click(object sender, EventArgs e)
        {
            ParentAdd parentAdd = new ParentAdd();
            parentAdd.Show();
            parentAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }
        #endregion

        #region CellDoubleClick
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["dgvID"].Value);
            ParentAdd parentAdd = new ParentAdd();
            parentAdd.id = id;
            parentAdd.ShowDialog();
            LoadData();
        }
        #endregion

        #region DGV_CellFormatting
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.SrNo(DataGridView);
        }
        #endregion
    }
}
