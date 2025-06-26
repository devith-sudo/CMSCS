using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.Model
{
    public partial class ClassSubjectAdd : Sample
    {
        public ClassSubjectAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void ClassSubjectAdd_Load(object sender, EventArgs e)
        {
            string qryClass = "Select classID as ID, cName as Name from tblClass";
            MainClass.CBFill(qryClass, ComboBoxClass);

            string qrySubject = "Select subjectID as ID, subjectName as Name from tblSubject";
            MainClass.CBFill(qrySubject, ComboBoxSubject);

            string qryTeacher = "Select staffID as ID, sName as Name from tblStaff";
            MainClass.CBFill(qryTeacher, ComboBoxTeacher);
        }

        #region Event validate
        #region btnClose
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                string qry = "Delete from tblClass where classID=" + id + "";
                Hashtable ht = new Hashtable();
                MainClass.data_insert_update_delete(qry, ht);
                MessageBox.Show("Delete Successfully");
                MainClass.Enable_Reset(this);
                id = 0;
            }
        }
        #endregion
        #region btnSave
        public void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validatation(this) == false)
            { return; }
            int mID = 0;
            string qryMain = "";
            string qryDetail = "";
            int r = 0;
            if (id == 0)
                qryMain = "INSERT INTO tblClassSubject VALUES (@classID);" + "Select SCOPE_IDENTITY()";
            //To get the latest enter id
            else
                qryMain = "UPDATE tblClassSubject SET classID = @classID, teacherID = @teacher WHERE csID = @id";


            SqlCommand cmd = new SqlCommand(qryMain, MainClass.con);
            MainClass.con.Open();

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@classID", Convert.ToInt32(ComboBoxClass.SelectedValue));

            if (id == 0)
                mID = Convert.ToInt32(cmd.ExecuteScalar());
            else
                mID = id; //for update

            MainClass.con.Close();

            //Detail Table Insert
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                if (Convert.ToString(row.Cells["dgvID"].Value) == "0")
                    qryDetail = "Insert into tblClassSubjectDetails values (@classSubID, @SubjectID, @TeacherID, @MaxNumber, @MinNumber)";
                else
                    qryDetail = "Update tblClassSubjectDetails set classSubID = @classSubID, SubjectID= @SubjectID, TeacherID = @TeacherID, MaxNumber = @MaxNumber, MinNumber = @MinNumber";

                Hashtable ht2 = new Hashtable();
                ht2.Add("@id", Convert.ToInt32(row.Cells["dgvId"].Value));
                ht2.Add("@classSubID", mID);
                ht2.Add("@SubjectID", Convert.ToInt32(row.Cells["dgvSubID"].Value));
                ht2.Add("@TeacherID", Convert.ToInt32(row.Cells["dgvStaffID"].Value));
                ht2.Add("@MinNumber", Convert.ToInt32(row.Cells["dgvMinNum"].Value));
                ht2.Add("@MaxNumber", Convert.ToInt32(row.Cells["dgvMaxNum"].Value));

                r = MainClass.data_insert_update_delete(qryDetail, ht2);
                ht2.Clear();
            }

            if (r > 0)
            {
                MessageBox.Show("Save Successfully");
                MainClass.Enable_Reset(this);
                id = 0;
                MainClass.con.Close();
            }
        }
        #endregion

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ComboBoxSubject.SelectedIndex != -1)
            {
                object[] obj = { 0, 0, ComboBoxSubject.SelectedValue, ComboBoxSubject.Text, ComboBoxTeacher.SelectedValue, ComboBoxTeacher.Text, txtMinNum.Text, txtMaxNum.Text };
                DataGridView.Rows.Add(obj);

                ComboBoxSubject.SelectedIndex = -1;
                ComboBoxTeacher.SelectedIndex = -1;
                txtMaxNum.Text = "";
                txtMinNum.Text = "";
            }
        }

        #region DGV_CellFormatting
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.SrNo(DataGridView);
        }
        #endregion
    }
}
