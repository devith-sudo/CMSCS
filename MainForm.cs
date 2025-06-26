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
            AddControls(new Dashboard());
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

                case "Admission Management":
                    break;

                case "Parent Management":
                    AddControls(new ParentView());
                    break;

                case "Student Management.Student Information":
                    AddControls(new StudentView());
                    break;

                case "Student Management.Student Promotion":
                    break;

                case "Staff Management":
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
                    AddControls(new ClassSubjectView());
                    break;

                case "Subjects Management":
                    AddControls(new Subjectview());
                    break;

                case "Attendance Management.Student Attendance":
                    AddControls(new StudentAttendanceView());
                    break;

                case "Attendance Management.Staff Attendance":
                    AddControls(new StaffAttendanceView());
                    break;

                case "Timetable Management":

                    break;

                case "Fee Management.Generate Voucher":
                    break;

                case "Fee Management.Fee Payment":
                    break;

                case "Expense Management.Manage Expense":
                    AddControls(new ExpenseView());
                    break;

                case "Expense Management.Expense Category":
                    AddControls(new ExpenseCategoryView());
                    break;

                case "Exam Management.Exam Terms":
                    break;

                case "Exam Management.Exam Grade":
                    break;

                case "Exam Management.Exam Entry":
                    break;

                case "Exam Management.Exam Timetable":
                    break;

                case "Reports":
                    //AddControls(new Reports());
                    break;

                case "Settings.Logout":
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
