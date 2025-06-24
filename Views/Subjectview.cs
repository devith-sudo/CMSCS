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
    public partial class Subjectview : SampleView
    {
        public Subjectview()
        {
            InitializeComponent();
        }

        public int id = 0;
        #region LoadData
        private void LoadData()
        {
            string qry = "Select * from tblSubject where subjectName like '%" + txtSearch.Text + "%' order by subjectName ASC";
            ListBox lb = new ListBox();
            lb.Items.Add(subjectID);

            lb.Items.Add(dgvName);
            MainClass.loadData(qry, DataGridView, lb);
        }
        #endregion

        #region Subjectview Load
        private void Subjectview_Load(object sender, EventArgs e)
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
            SubjectAdd subjectAdd = new SubjectAdd();
            subjectAdd.Show();
            subjectAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }
        #endregion

        #region CellDoubleClick
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["subjectID"].Value);
            SubjectAdd subjectAdd = new SubjectAdd();
            subjectAdd.id = id;
            subjectAdd.ShowDialog();
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
