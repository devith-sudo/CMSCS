using SchoolManagementSystem.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SchoolManagementSystem
{
    public partial class MainForm :Sample
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {

        }

        private void btnMin_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {              
                btnMax.PerformClick();
        }

        private void AddControls(Form F)
        {
            ControlsPanel.Controls.Clear();
            F.TopLevel = false;
            ControlsPanel.Controls.Add(F);
            F.Dock = DockStyle.Fill;
            F.Show();
        }

        #region NavigationMenu
        private void navigtionMenu_OnItemSelected(object sender, string path, EventArgs e)
        {
            switch (path)
            {
                case "Dashboard":
                    break;

                case "Admission Management.Admin Student":
                    break;

                case "Admission Management.Student Promotion":
                    break;

                case "Parent Management":
                    break;

                case "Staff Management":
                    break;

                case "ID Card Printing.Print Student Card":
                    AddControls(new frmUserView());
                    break;

                case "Settings.Logout":
                    break;

                case "Reports":
                    break;

                case "Settings.Users":
                    AddControls(new frmUserView());
                    break;

                case "Settings.School Information":
                    AddControls(new SchoolInfo());
                    break;
            }
        }
        #endregion
    }
}
