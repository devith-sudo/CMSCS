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
    public partial class ParentAdd : Sample
    {
        public ParentAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void ParentAdd_Load(object sender, EventArgs e)
        {
            string parentID = "";
            if (id > 0)
            {
                DataTable dt = MainClass.GetData("Select * from tblParent where parentID = " + id);
                foreach (DataRow row in dt.Rows)
                {
                    parentID = row["pIDNO"].ToString();
                    txtIDNo.Text = row["pIDNO"].ToString();
                    txtName.Text = row["pName"].ToString();
                    ComboBoxGender.Text = row["pGender"].ToString();
                    txtEmail.Text = row["pEmail"].ToString();
                    txtPhone.Text = row["pPhone"].ToString();
                    txtAddress.Text = row["pAddress"].ToString();
                }

                //Loading Children Info
                string qry = "SELECT c.cName, s.sName\r\nFROM tblStudent s\r\nINNER JOIN tblClass c ON c.classID = s.sClassID WHERE s.sParentIDNo = '" + parentID + "'";
                ListBox lb = new ListBox();
                lb.Items.Add(dgvClass);
                lb.Items.Add(dgvChildren);
                MainClass.loadData(qry, DataGridView, lb);
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
                string qry = "Delete from tblParent where parentID=" + id + "";
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
                qry = "INSERT INTO tblParent VALUES (@idNo, @name, @gender, @phone, @email, @address)";
            }
            else
            {
                qry = "UPDATE tblParent SET pIDNO = @idNo, pName = @name, pGender = @gender, pPhone = @phone, pEmail = @email, pAddress = @address WHERE pName = @id";
            }

            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@idNo", txtIDNo.Text);
            ht.Add("@name", txtName.Text);
            ht.Add("@gender", ComboBoxGender.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@email", txtEmail.Text);
            ht.Add("@address", txtAddress.Text);

            int r = MainClass.data_insert_update_delete(qry, ht);
            if (r > 0)
            {
                MessageBox.Show(
                    "Data has been saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                MainClass.Enable_Reset(this);
                id = 0;
            }

        }
        #endregion
        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.SrNo(DataGridView);
        }
        #endregion

    }
}
