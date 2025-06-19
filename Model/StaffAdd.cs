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
    public partial class StaffAdd : Sample
    {
        public int id = 0;
        public StaffAdd()
        {
            InitializeComponent();
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
                string qry = "Delete from tblStaff where staffID=" + id + "";
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
                qry = "INSERT INTO tblStaff VALUES (@name, @user, @pass, @phone, @status)";
            }
            else
            {
                qry = "UPDATE tblStaff SET sName = @name, uUsername = @user, uPass = @pass, " +
                      "uPhone = @phone, uStatus = @status WHERE staffID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@name", txtName.Text);
            ht.Add("@user", txtDOB.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@status", ComboBoxStatus.Text);

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
