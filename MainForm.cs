using SchoolManagementSystem.Model;
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
    public partial class MainForm : Sample
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        #region AddControls
        private void AddControls(Form F)
        {
            ControlsPanel.Controls.Clear();
            F.TopLevel = false;
            ControlsPanel.Controls.Add(F);
            F.Dock = DockStyle.Fill;
            F.Show();
        }
        #endregion

        #region NavigationMenu
        private void navigtionMenu_OnItemSelected(object sender, string path, EventArgs e)
        {
            switch (path)
            {
                case "Dashboard":
                    AddControls(new Dashboard());
                    break;

                case "Admission Management.Admin Student":
                    break;

                case "Admission Management.Student Promotion":
                    break;

                case "Parent Management":
                    break;

                case "Staff Management":
                    break;

                case "Staff Management.Staff Management":
                    AddControls(new StaffView());
                    break;

                case "ID Card Printing.Print Student Card":
                    //AddControls();
                    break;

                case "ID Card Printing.Print Staff Card":
                    //AddControls();
                    break;

                case "Classes.Manage Classes":
                    AddControls(new ClassView());
                    break;

                case "Classes.Class Subjects":
                    break;

                case "Subjects Management":
                    AddControls(new Subjectview());
                    break;

                case "Attendance Management.Student Attendance":
                    break;

                case "Attendance Management.Staff Attendance":
                    break;

                case "Timetable Management":
                    break;

                case "Fee Management.Generate Voucher":
                    break;

                case "Fee Management.Fee Payment":
                    break;

                case "Settings.Logout":
                    break;

                case "Reports":
                    break;

                case "Settings.Users":
                    AddControls(new frmUserView());
                    break;

                case "Settings.School Information":
                    School school = new School();
                    school.Show();
                    break;
            }
        }
        #endregion
    }
}
