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
    public partial class StudentAdd : Sample
    {
        public StudentAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
        private void StudentAdd_Load(object sender, EventArgs e)
        {
            string qryClass = "Select classID as ID, cName as Name from tblClass";
            MainClass.CBFill(qryClass, ComboxClass);
            if (id == 0)
            {
                CreateNo();
            }
            if (id > 0)
            {
                DataTable dt = MainClass.GetData("Select * from tblStudent where studentID= " + id + "");
                foreach (DataRow row in dt.Rows)
                {
                    txtRollNo.Text = row["sRollNo"].ToString();
                    txtName.Text = row["sName"].ToString();
                    ComboBoxGender.Text = row["sGender"].ToString();
                    txtDOB.Text = Convert.ToDateTime(row["sdob"]).ToString("dd-MM-yyyy");
                    txtParentName.Text = row["sParentName"].ToString();
                    txtParentID.Text = row["sParentIDNo"].ToString();
                    txtParentEmail.Text = row["sParentEmail"].ToString();
                    txtAddress.Text = row["sAddress"].ToString();
                    ComboxClass.SelectedValue = Convert.ToInt32(row["sClassID"].ToString());
                    txtAdmissionDate.Text = Convert.ToDateTime(row["admissionDate"]).ToString("dd-MM-yyyy");
                    txtPreviousSchool.Text = row["PreviousSchool"].ToString();
                    txtFee.Text = row["monthlyFee"].ToString();
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
                string qry = "Delete from tblStudent where studentID=" + id + "";
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
                    qry = @"INSERT INTO tblStudent 
                    (sRollNo, sName, sGender, sdob, sImage, sParentName, sParentIDNo, sParentEmail, 
                     sAddress, sClassID, PreviousSchool, admissionDate, monthlyFee, sStatus)
                    VALUES 
                    (@rollno, @name, @gender, @dob, @image, @parentName, @parentId, @email, 
                     @address, @class, @preSchool, @admissionDate, @fee, @status)";
                }
                else
                {
                    qry = @"UPDATE tblStudent SET 
                        sRollNo = @rollno, 
                        sName = @name, 
                        sGender = @gender,  
                        sdob = @dob, 
                        sImage = @image, 
                        sParentName = @parentName,
                        sParentIDNo = @parentId,
                        sParentEmail = @email, 
                        sAddress = @address,
                        sClassID = @class,
                        PreviousSchool = @preSchool,
                        admissionDate = @admissionDate,
                        monthlyFee = @fee, 
                        sStatus = @status 
                    WHERE studentID = @id";
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
                ht.Add("@rollno", txtRollNo.Text);
                ht.Add("@name", txtName.Text);
                ht.Add("@gender", ComboBoxGender.Text);
                ht.Add("@parentName", txtParentName.Text);
                ht.Add("@parentId", txtParentID.Text);
                ht.Add("@email", txtParentEmail.Text);
                ht.Add("@address", txtAddress.Text);
                ht.Add("@class", ComboxClass.SelectedValue);
                ht.Add("@preSchool", txtPreviousSchool.Text);
                ht.Add("@status", ComboBoxStatus.Text);

                if (DateTime.TryParseExact(txtDOB.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dob))
                {
                    ht.Add("@dob", dob);
                }
                else
                {
                    ht.Add("@dob", DBNull.Value);
                }

                if (DateTime.TryParseExact(txtAdmissionDate.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime admissionDate))
                {
                    ht.Add("@admissionDate", admissionDate);
                }
                else
                {
                    ht.Add("@admissionDate", DBNull.Value);
                }

                if (decimal.TryParse(txtFee.Text, out decimal fee))
                {
                    ht.Add("@fee", fee); // ✅ fixed
                }
                else
                {
                    ht.Add("@fee", 0); // or DBNull.Value
                }

                ht.Add("@image", imageByteArray);

                if (id > 0)
                {
                    ht.Add("@id", id); // Required for UPDATE
                }

                int r = MainClass.data_insert_update_delete(qry, ht);
                if (r > 0)
                {
                    MessageBox.Show("Saved Successfully");
                    MainClass.Enable_Reset(this);
                    id = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
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
                string qry = @"SELECT ISNULL(MAX(CAST(SUBSTRING(sRollNo, 3, LEN(sRollNo) - 2) AS INT)), 0) AS maxNum 
                              FROM tblStudent 
                              WHERE sRollNO IS NOT NULL AND sRollNo LIKE 'S%' AND LEN(sRollNo) > 2";

                DataTable dt = MainClass.GetData(qry);

                int nextID = 1; // Default starting number
                if (dt.Rows.Count > 0 && dt.Rows[0]["maxNum"] != DBNull.Value)
                {
                    nextID = Convert.ToInt32(dt.Rows[0]["maxNum"]) + 1;
                }

                string sNo = "S" + nextID.ToString("D3");
                txtRollNo.Text = sNo;
            }
            catch (Exception ex)
            {
                // Fallback if query fails
                txtRollNo.Text = "S001";
                MessageBox.Show("Error generating ID: " + ex.Message);
            }
        }

    }
}
