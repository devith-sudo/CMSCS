using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.Reports
{
    public partial class StudentAttendanceReports : Sample
    {
        public StudentAttendanceReports()
        {
            InitializeComponent();
        }

        private void StudentReports_Load(object sender, EventArgs e)
        {

            this.studentAttendanceReport.RefreshReport();
            this.studentAttendanceReport.RefreshReport();
        }
    }
}
