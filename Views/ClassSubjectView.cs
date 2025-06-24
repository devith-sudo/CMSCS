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
    public partial class ClassSubjectView : SampleView
    {
        public ClassSubjectView()
        {
            InitializeComponent();
        }

        private void ClassSubjectView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            ClassSubjectAdd classSubjectAdd = new ClassSubjectAdd();
            classSubjectAdd.ShowDialog();
            classSubjectAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }
        private void LoadData()
        {
            string qry = @"SELECT cs.csID, c.cName, st.sName, sub.subjectName, sd.MinNumber, sd.MaxNumber 
               FROM tblClassSubject cs
               INNER JOIN tblClassSubjectDetails sd ON sd.classSubID = cs.csID
               INNER JOIN tblClass c ON c.classID = cs.classID
               INNER JOIN tblStaff st ON st.staffID = sd.teacherID
               INNER JOIN tblSubject sub ON sub.subjectID = sd.SubjectID
               WHERE c.cName LIKE '%" + txtSearch.Text + @"%' 
               ORDER BY c.cName ASC";

            ListBox lb = new ListBox();
            lb.Items.Add(dgvID);
            lb.Items.Add(dgvClassName);
            lb.Items.Add(dgvSubject);
            lb.Items.Add(dgvTeacherName);
            lb.Items.Add(dgvMinMark);
            lb.Items.Add(dgvMaxMark);

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


    }
}
