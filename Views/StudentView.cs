using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.Views
{
    public partial class StudentView : SampleView
    {
        public StudentView()
        {
            InitializeComponent();
        }
        public override void btnSave_Click(object sender, EventArgs e)
        {
            UserAdd userAdd = new UserAdd();
            userAdd.Show();
            userAdd.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
