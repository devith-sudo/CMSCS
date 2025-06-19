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
    public partial class School : Sample
    {
        public School()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void School_Load(object sender, EventArgs e)
        {
            DataTable dt = MainClass.GetData("Select * from SchoolInfo");

            foreach (DataRow dr in dt.Rows)
            {
                txtName.Text = dr["sName"].ToString();
                txtPhone.Text = dr["sPhone"].ToString();
                txtEmail.Text = dr["sEmail"].ToString();
                txtAddress.Text = dr["sAddress"].ToString();
                id = Convert.ToInt32(dr["schoolID"].ToString());
            }
        }

        #region btnSave
        private void btnSave_Click(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0)
            {
                // INSERT query with correct column names and parameters
                qry = "INSERT INTO SchoolInfo (sName, sPhone, sEmail, sAddress) " +
                      "VALUES (@name, @phone, @email, @address)";
            }
            else
            {
                // UPDATE query
                qry = "UPDATE SchoolInfo SET sName = @name, sPhone = @phone, sEmail = @email, " +
                      "sAddress = @address WHERE schoolID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);  // Will be ignored in INSERT, used only in UPDATE
            ht.Add("@name", txtName.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@email", txtEmail.Text);
            ht.Add("@address", txtAddress.Text);

            int r = MainClass.data_insert_update_delete(qry, ht);
            if (r > 0)
            {
                MessageBox.Show("Save Successfully");
                MainClass.Enable_Reset(this);
                id = 0; // Reset to force insert on next save unless a row is selected
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
