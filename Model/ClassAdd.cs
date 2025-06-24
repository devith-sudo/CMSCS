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
using System.Xml.Linq;

namespace SchoolManagementSystem.Model
{
    public partial class ClassAdd : Sample
    {
        public ClassAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void ClassAdd_Load(object sender, EventArgs e)
        {
            string qry = "SELECT staffID AS id, sName AS name FROM tblStaff";
            MainClass.CBFill(qry, ComboBoxTeacher);

            if (id > 0)
            {
                DataTable dt = MainClass.GetData("SELECT * FROM tblClass WHERE classID=" + id);
                foreach (DataRow dr in dt.Rows)
                {
                    txtClassName.Text = dr["cName"].ToString();
                    ComboBoxTeacher.SelectedValue = Convert.ToInt32(dr["teacherID"]);
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
            if(MainClass.Validatation(this) == false)
                { return; }

            string qry = "";
            if (id == 0)
            {
                qry = "INSERT INTO tblClass VALUES (@name, @teacher)";
            }
            else
            {
                qry = "UPDATE tblClass SET cName = @name, teacherID = @teacher WHERE classID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@name", txtClassName.Text);
            ht.Add("@teacher", Convert.ToInt32(ComboBoxTeacher.SelectedValue));

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
