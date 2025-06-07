using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Testing : Form
    {

        public Testing()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = ofd.FileName;
                    pictureBox.Image = Image.FromFile(imageLocation);
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = "my_connection";

            if (pictureBox.Image == null)
            {
                MessageBox.Show("Please upload an image first.");
                return;
            }

            try
            {
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                    imageBytes = ms.ToArray();
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO tblProduct (photo) VALUES (@ImageData)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@ImageData", SqlDbType.VarBinary).Value = imageBytes;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Image saved to database.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
