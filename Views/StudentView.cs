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
    public partial class StudentView : SampleView
    {
        public StudentView()
        {
            InitializeComponent();
        }

        private void StudentView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            StudentAdd studentAdd = new StudentAdd();
            studentAdd.Show();
            studentAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }


        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string qry = "SELECT studentID, sRollNo, sName, sGender, c.cName AS ClassName, monthlyFee " +
                         "FROM tblStudent s INNER JOIN tblClass c ON c.classID = s.sClassID " +
                         "WHERE sName LIKE '%" + txtSearch.Text + "%' ORDER BY sName ASC";

            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvRollID);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvGender);
            lb.Items.Add(dgvClass);
            lb.Items.Add(dgvFee);

            MainClass.loadData(qry, DataGridView, lb);
        }

        #region
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["dgvId"].Value);
            StudentAdd studentAdd = new StudentAdd();
            studentAdd.id = id;
            studentAdd.ShowDialog();
            LoadData();
        }
        #endregion

        #region
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.SrNo(DataGridView);
        }
        #endregion

    }
}