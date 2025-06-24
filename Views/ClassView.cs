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
    public partial class ClassView : SampleView
    {
        public ClassView()
        {
            InitializeComponent();
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            ClassAdd classAdd = new ClassAdd();
            classAdd.ShowDialog();
            classAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }
        private void LoadData()
        {
            string qry = "Select classID, cName, tblStaff.sName from tblClass inner join tblStaff on "+
                "tblStaff.staffID = teacherID where cName like '%" + txtSearch.Text + "%' order by classID";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvClassName);
            lb.Items.Add(dgvTeacherName);
            MainClass.loadData(qry, DataGridView, lb);
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["dgvId"].Value);
            ClassAdd classAdd = new ClassAdd();
            classAdd.id = id;
            classAdd.ShowDialog();
            LoadData();
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.SrNo(DataGridView);
        }
    }
}
