using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void StaffAdd_Load(object sender, EventArgs e)
        {
            if (id == 0)
            {
                CreateNo();
            }
            if (id > 0)
            {
                DataTable dt = MainClass.GetData("Select * from tblStaff where staffID= " + id + "");
                foreach (DataRow row in dt.Rows)
                {
                    txtID.Text = row["sIDNo"].ToString();
                    txtName.Text = row["sName"].ToString();
                    txtPhone.Text = row["sPhone"].ToString();
                    txtDOB.Text = Convert.ToDateTime(row["sdob"]).ToString("dd-MM-yyyy");
                    ComboBoxGender.Text = row["sGender"].ToString();
                    txtEmail.Text = row["sEmail"].ToString();
                    txtAddress.Text = row["sAddress"].ToString();
                    txtSalary.Text = row["monthlySalary"].ToString();
                    ComboBoxStatus.Text = row["sStatus"].ToString();

                    if (row["sImage"] != DBNull.Value)
                    {
                        byte[] imageArray = (byte[])row["sImage"];
                        pictureBox.Image = Image.FromStream(new MemoryStream(imageArray));
                    }
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
            try
            {
                string qry = "";
                if (id == 0)
                {
                    qry = @"INSERT INTO tblStaff (sIDNo, sName, sGender, sPhone, sdob, sEmail, sAddress, monthlySalary, sImage, sStatus) 
                           VALUES (@idno, @name, @gender, @phone, @dob, @email, @address, @salary, @image, @status)";
                }
                else
                {
                    qry = @"UPDATE tblStaff SET 
                           sIDNo = @idno, 
                           sName = @name, 
                           sGender = @gender, 
                           sPhone = @phone, 
                           sdob = @dob, 
                           sEmail = @email, 
                           sAddress = @address, 
                           monthlySalary = @salary, 
                           sImage = @image, 
                           sStatus = @status 
                           WHERE staffID = @id";
                }

                byte[] imageByteArray = null;
                if (pictureBox.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imageByteArray = ms.ToArray();
                    }
                }

                Hashtable ht = new Hashtable();
                if (id > 0) // Only add @id parameter for updates
                {
                    ht.Add("@id", id);
                }
                ht.Add("@idno", txtID.Text);
                ht.Add("@name", txtName.Text);
                ht.Add("@gender", ComboBoxGender.Text);
                ht.Add("@phone", txtPhone.Text);

                // Better date handling
                DateTime dob;
                if (DateTime.TryParseExact(txtDOB.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dob))
                {
                    ht.Add("@dob", dob);
                }
                else
                {
                    ht.Add("@dob", DBNull.Value);
                }

                ht.Add("@email", txtEmail.Text);
                ht.Add("@address", txtAddress.Text);

                // Handle salary conversion
                decimal salary;
                if (decimal.TryParse(txtSalary.Text, out salary))
                {
                    ht.Add("@salary", salary);
                }
                else
                {
                    ht.Add("@salary", 0);
                }

                ht.Add("@image", imageByteArray);
                ht.Add("@status", ComboBoxStatus.Text);

                int r = MainClass.data_insert_update_delete(qry, ht);
                if (r > 0)
                {
                    MessageBox.Show("Save Successfully");
                    MainClass.Enable_Reset(this);
                    id = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
            MainClass.Enable_Reset(this);
        }
        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image(.jpg, .png)|*.png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                pictureBox.Image = new Bitmap(filePath);
            }
        }
        #endregion

        private void CreateNo()
        {
            try
            {
                string qry = @"SELECT ISNULL(MAX(CAST(SUBSTRING(sIDNo, 3, LEN(sIDNo) - 2) AS INT)), 0) AS maxNum 
                              FROM tblStaff 
                              WHERE sIDNo IS NOT NULL AND sIDNo LIKE 'ST%' AND LEN(sIDNo) > 2";

                DataTable dt = MainClass.GetData(qry);

                int nextID = 1; // Default starting number
                if (dt.Rows.Count > 0 && dt.Rows[0]["maxNum"] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dt.Rows[0]["maxNum"]) + 1;
                }

                string sNo = "ST" + nextID.ToString("D3");
                txtID.Text = sNo;
            }
            catch (Exception ex)
            {
                // Fallback if query fails
                txtID.Text = "ST001";
                MessageBox.Show("Error generating ID: " + ex.Message);
            }
        }
    }
}