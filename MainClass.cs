using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    class MainClass
    {
        #region Database Connection
        //Connecting Database
        public static readonly string cons = "Data Source=UR Computer Name;Initiial Catalog=School; User ID=sa; Password=092498933";
        public static SqlConnection con = new SqlConnection(cons);
        #endregion

        #region ValidUser
        public static bool IsValidUser(string user, string pass)
        {
            bool isValid = false;

            string qry = "Select * from users where name = '" + user + "' and upassword = '" + pass + "' ";
            SqlCommand cmd = new SqlCommand(qry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0) { isValid = true; }
            return isValid;
        }
        #endregion

        #region For ComboBox Fill
        public static void CBFill(string qry, ComboBox cb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cb.DisplayMember = "Name";
                cb.ValueMember = "ID";
                cb.DataSource = dt;
                cb.SelectedIndex = 0;
                cb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region For Loading Data from Database to DataGrid
        public static void loadData(string qry, DataGridView gv, ListBox lb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName1 = ((DataGridView)lb.Items[i]).Name;
                    gv.Columns[colName1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region For GridView serail no
        public static void SrNo(Guna.UI2.WinForms.Guna2DataGridView gv)
        {
            try
            {
                int count = 0;
                foreach (DataGridViewRow row in gv.Rows)
                {
                    count++;
                    row.Cells[0].Value = count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
        #endregion

        private static Color vColor = Color.FromArgb(245, 29, 70);

        #region For Validation, u can see in my form validation for more detail
        public static bool Validatation(Form F)
        {
            bool isValid = true;
            int count = 0;
            int x;
            int y;

            //Remove old Labels
            var dynamicLabels = F.Controls.OfType<Label>().Where(c => c.Tag != null && c.Tag.ToString() == "remove").ToList();
            foreach (var lbl in dynamicLabels)
            {
                F.Controls.Remove(lbl);
            }

            foreach (var lbl in dynamicLabels)
            {
                F.Controls.Add(lbl);
            }

            return isValid;
        }
        #endregion

        #region For CUD (Create, Update, Delete)
        public static int data_insert_update_delete(string qry, Hashtable ht)
        {
            int res = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                MainClass.con.Open();
                res = cmd.ExecuteNonQuery();
                MainClass.con.Close();
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.Message);
            }
            return res;
        }
        #endregion

        #region

        #endregion
    }
}