using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    #region Main Class use for all action in the project
    class MainClass
    {
        #region Database Connection
        //Connecting Database
        public static readonly string cons = "Data Source=Ravith;Initial Catalog=School; User ID=sa; Password=092498933";
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
                    string colName1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colName1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.ToString()); // Keep full trace
            }
        }

        #endregion

        #region For Getting to update Data
        public static DataTable GetData(string qry)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MainClass.con.Close();
                MessageBox.Show(ex.ToString());
            }
            return dt;
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

            foreach (Control c in F.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button)
                {

                }
                else
                {
                    if (c.Tag == null || c.Tag.ToString() == string.Empty)
                    {

                    }
                    else
                    {
                        Label lbl = new Label();
                        lbl.Font = new Font("A", 10, FontStyle.Regular);
                        lbl.AutoSize = true;

                        #region textbox
                        if (c is Guna.UI2.WinForms.Guna2TextBox)
                        {
                            Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)(c);
                            if (t.AutoRoundedCorners == true)
                            {
                                x = int.Parse(c.Location.X.ToString()) + 10;
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString());
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            if (t.Text == "")
                            {
                                string cname = "vlbl" + c.Name;
                                lbl.Name = cname;
                                lbl.Tag = "remove";
                                lbl.Text = "Required";
                                lbl.ForeColor = vColor;
                                F.Controls.Add(lbl);

                                lbl.Location = new System.Drawing.Point(x, y);

                                count++;
                            }
                        }
                        #endregion

                        #region Number
                        if(c is Guna.UI2.WinForms.Guna2TextBox)
                        {
                            Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                            if (t.AutoRoundedCorners == true)
                            {
                                x = int.Parse(c.Location.X.ToString()) + 10;
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString());
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            if(t.Tag.ToString() == "n" && t.Text != "")
                            {
                                Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");
                                Match match = regex.Match(t.Text);
                                if (match.Success) { }
                                else
                                {
                                    string cname = "nlbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "Remove";
                                    lbl.Text = "Invalid Number";
                                    lbl.ForeColor = vColor;
                                    //lbl.Font = new Font("Kantumruy", 12, FontStyle.Regular);
                                    F.Controls.Add(lbl);
                                    lbl.Location = new System.Drawing.Point(x, y);
                                    count++;
                                }

                                
                            }
                        }
                        #endregion

                        #region Email
                        if (c is Guna.UI2.WinForms.Guna2TextBox)
                        {
                            Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                            if (t.AutoRoundedCorners == true)
                            {
                                x = int.Parse(c.Location.X.ToString()) + 10;
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString());
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            if (t.Tag.ToString() == "n" && t.Text != "")
                            {
                                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                                Match match = regex.Match(t.Text);
                                if (match.Success) { }
                                else
                                {
                                    string cname = "nlbl" + c.Name;
                                    lbl.Name = cname;
                                    lbl.Tag = "Remove";
                                    lbl.Text = "Invalid Email";
                                    lbl.ForeColor = vColor;
                                    //lbl.Font = new Font("Kantumruy", 12, FontStyle.Regular);
                                    F.Controls.Add(lbl);
                                    lbl.Location = new System.Drawing.Point(x, y);
                                    count++;
                                }
                            }
                        }

                        #endregion

                        #region Date
                        if (c is Guna.UI2.WinForms.Guna2TextBox)
                        {
                            Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                            if (t.AutoRoundedCorners == true)
                            {
                                x = int.Parse(c.Location.X.ToString()) + 10;
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString());
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            if (t.Tag.ToString() == "d" && t.Text != "")
                            {
                                DateTime dt = new DateTime(1990, 1, 1).Date;
                                Regex regex = new Regex("^([0]?[0-9]|[12][0-9]|[3][01])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4}|[0-9]{2})$");
                                Match match = regex.Match(t.Text);

                            }
                        }
                        #endregion

                        #region Dropdown
                        //Dropdown
                        if (c is Guna.UI2.WinForms.Guna2ComboBox)
                        {
                            Guna.UI2.WinForms.Guna2ComboBox t = (Guna.UI2.WinForms.Guna2ComboBox)(c);
                            if (t.AutoRoundedCorners == true)
                            {
                                x = int.Parse(c.Location.X.ToString()) + 10;
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString());
                                y = int.Parse((c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString()));
                            }
                            if (t.Text == "" || t.Text == null)
                            {
                                string cname = "lbl" + c.Name;
                                lbl.Name = cname;
                                lbl.Tag = "Remove";
                                lbl.Text = "Require";
                                lbl.ForeColor = vColor;
                                //lbl.font = new Font("Kantumruy", 9, FontStyle.Regular);
                                F.Controls.Add(lbl);
                                lbl.Location = new System.Drawing.Point(x, y);
                                count++;
                            }
                        }

                        #endregion
                    }
                }

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

        #region Enable Reset after save code
        public static void Enable_Reset(Form F)
        {
            foreach (Control c in F.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2TextBox)
                {
                    Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                    t.Text = "";
                }

                if (c is Guna.UI2.WinForms.Guna2ComboBox)
                {
                    Guna.UI2.WinForms.Guna2ComboBox cb = (Guna.UI2.WinForms.Guna2ComboBox)c;
                    cb.SelectedIndex = 0;
                    cb.SelectedIndex = -1;
                }

                if (c is Guna.UI2.WinForms.Guna2RadioButton)
                {
                    Guna.UI2.WinForms.Guna2RadioButton rb = (Guna.UI2.WinForms.Guna2RadioButton)c;
                    rb.Checked = false;
                }

                if (c is Guna.UI2.WinForms.Guna2CheckBox)
                {
                    Guna.UI2.WinForms.Guna2CheckBox ck = (Guna.UI2.WinForms.Guna2CheckBox)c;
                    ck.Checked = false;
                }

                if (c is Guna.UI2.WinForms.Guna2DateTimePicker)
                {
                    Guna.UI2.WinForms.Guna2DateTimePicker dp = (Guna.UI2.WinForms.Guna2DateTimePicker)c;
                    dp.Value = DateTime.Today;
                }

                if (c is ListBox)
                {
                    ListBox listBox = (ListBox)c;
                }

                if (c is NumericUpDown)
                {
                    NumericUpDown cb = (NumericUpDown)c;
                }

                if (c is MaskedTextBox)
                {
                    MaskedTextBox cb = (MaskedTextBox)c;
                    cb.Text = "";
                }
            }
            F.Close();
        }
        #endregion
    }
    #endregion
}