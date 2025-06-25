using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Model
{
    public partial class ExpenseAdd : Sample
    {
        public ExpenseAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void ExpenseAdd_Load(object sender, EventArgs e)
        {
            string qry = "SELECT expCatID AS ID, expCatName AS Name FROM tblExpenseCat";
            MainClass.CBFill(qry, ComboBoxExpenseType);

            if (id > 0)
            {
                DataTable dt = MainClass.GetData("SELECT * FROM tblExpense WHERE expID = " + id);
                foreach (DataRow dr in dt.Rows)
                {
                    txtDate.Text = Convert.ToDateTime(dr["expDate"]).ToString("dd-MM-yyyy");
                    ComboBoxExpenseType.SelectedValue = Convert.ToInt32(dr["expCatID"]);
                    txtDescription.Text = dr["expDescription"].ToString();
                    txtAmount.Text = dr["expAmount"].ToString();
                }
            }
        }

        #region Event Handlers

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                string qry = "DELETE FROM tblExpense WHERE expID = " + id + "'";
                Hashtable ht = new Hashtable();
                MainClass.data_insert_update_delete(qry, ht);
                MessageBox.Show("Deleted successfully.");
                MainClass.Enable_Reset(this);
                id = 0;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validatation(this) == false)
                return;

            string qry = "";
            Hashtable ht = new Hashtable();

            if (id == 0)
            {
                qry = "INSERT INTO tblExpense (expCatID, expDate, expDescription, expAmount) " +
                      "VALUES (@cat, @date, @desc, @amount)";
            }
            else
            {
                qry = "UPDATE tblExpense SET expCatID = @cat, expDate = @date, expDescription = @desc, expAmount = @amount " +
                      "WHERE expID = @id";
                ht.Add("@id", id);
            }

            ht.Add("@cat", Convert.ToInt32(ComboBoxExpenseType.SelectedValue));
            // Better date handling
            DateTime dob;
            if (DateTime.TryParseExact(txtDate.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dob))
            {
                ht.Add("@date", dob);
            }
            else
            {
                ht.Add("@dob", DBNull.Value);
            }
            ht.Add("@desc", txtDescription.Text);
            ht.Add("@amount", Convert.ToDecimal(txtAmount.Text));

            int r = MainClass.data_insert_update_delete(qry, ht);
            if (r > 0)
            {
                MessageBox.Show("Saved successfully.");
                MainClass.Enable_Reset(this);
                id = 0;
            }
        }

        #endregion
    }
}
