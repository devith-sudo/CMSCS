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
    public partial class ExpenseCategoryAdd : Sample
    {
        public ExpenseCategoryAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void ExpenseCategoryAdd_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DataTable dt = MainClass.GetData("SELECT * FROM tblExpenseCat WHERE expCatID=" + id);
                foreach (DataRow dr in dt.Rows)
                {
                    txtExpenseName.Text = dr["expCatName"].ToString();
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
                string qry = "Delete from tblExpenseCat where expCatID=" + id + "";
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

            string qry = "";
            if (id == 0)
            {
                qry = "INSERT INTO tblExpenseCat VALUES (@name)";
            }
            else
            {
                qry = "UPDATE tblClass SET expCatName = @name WHERE expCatID = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@name", txtExpenseName.Text);

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
