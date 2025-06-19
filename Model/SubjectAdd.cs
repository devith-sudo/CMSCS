using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.Model
{
    public partial class SubjectAdd : Sample
    {
        public int id = 0;
        public SubjectAdd()
        {
            InitializeComponent();
        }

        private void SubjectAdd_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DataTable dt = MainClass.GetData("Select * from tblSubject where subjectID= " + id);
                foreach (DataRow row in dt.Rows)
                {
                    txtName.Text = row["subjectName"].ToString(); // Also fix this if your column name is 'subjectName'
                }
            }
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
                string qry = "Delete from tblSubject where subjectID=" + id + "";
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
            string qry = "";
            if (id == 0)
            {
                qry = "INSERT INTO tblSubject VALUES (@name)";
            }
            else
            {
                qry = "UPDATE tblSubject SET subjectName = @name WHERE subjectID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@name", txtName.Text);

            int r = MainClass.data_insert_update_delete(qry, ht);
            if (r > 0)
            {
                MessageBox.Show("Save Successfully");
                MainClass.Enable_Reset(this);
                id = 0;
            }
        }
        #endregion
        #endregion
    }
}
