﻿using SchoolManagementSystem.Model;
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
    public partial class frmUserView : SampleView
    {
        public frmUserView()
        {
            InitializeComponent();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            UserAdd userAdd = new UserAdd();
            userAdd.Show();
            userAdd.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }

        #region LoadData
        private void LoadData()
        {
            string qry = "Select uName, uUsername, uPhone, uStatus, userID from tblUser where uName like '%" + txtSearch.Text + "%' order by uName ASC";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvUser);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvId);
            MainClass.loadData(qry, DataGridView, lb);
        }
        #endregion

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridView.CurrentRow.Cells["dgvId"].Value);
            UserAdd userAdd = new UserAdd();
            userAdd.id = id;
            userAdd.ShowDialog();
            LoadData();
        }
    }
}
