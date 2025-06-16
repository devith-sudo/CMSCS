namespace SchoolManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.navigtionMenu = new Kimtoo.NavigtionMenu();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnMin = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMax = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigtionMenu
            // 
            this.navigtionMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.navigtionMenu.AutoScroll = true;
            this.navigtionMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(61)))));
            this.navigtionMenu.BackColor_Click = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(49)))), ((int)(((byte)(70)))));
            this.navigtionMenu.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(49)))), ((int)(((byte)(70)))));
            this.navigtionMenu.BackColor_Selected = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(104)))), ((int)(((byte)(240)))));
            this.navigtionMenu.DisableToggling = new string[0];
            this.navigtionMenu.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navigtionMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navigtionMenu.ForeColor_Selected = System.Drawing.Color.Empty;
            this.navigtionMenu.IsExpandable = false;
            this.navigtionMenu.IsExpanded = true;
            this.navigtionMenu.ItemHeight = 35;
            this.navigtionMenu.ItemImageSize = new System.Drawing.Size(20, 20);
            this.navigtionMenu.ItemPadding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.navigtionMenu.ItemRightImageMargin = 20;
            this.navigtionMenu.ItemRightImageSize = new System.Drawing.Size(15, 15);
            this.navigtionMenu.Items = new Kimtoo.ButtonItem[] {
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items1"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items2"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items3"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items4"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items5"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items6"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items7"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items8"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items9"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items10"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items11"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items12"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items13"))),
        ((Kimtoo.ButtonItem)(resources.GetObject("navigtionMenu.Items14")))};
            this.navigtionMenu.ItemTextMargin = 8;
            this.navigtionMenu.Location = new System.Drawing.Point(0, 93);
            this.navigtionMenu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.navigtionMenu.Name = "navigtionMenu";
            this.navigtionMenu.Size = new System.Drawing.Size(317, 696);
            this.navigtionMenu.TabIndex = 3;
            this.navigtionMenu.OnItemSelected += new Kimtoo.NavigtionMenu.OnSelectEventHandler(this.navigtionMenu_OnItemSelected);
            // 
            // topPanel
            // 
            this.topPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topPanel.Controls.Add(this.btnMin);
            this.topPanel.Controls.Add(this.btnMax);
            this.topPanel.Controls.Add(this.btnExit);
            this.topPanel.Location = new System.Drawing.Point(285, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(863, 87);
            this.topPanel.TabIndex = 2;
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BorderRadius = 6;
            this.btnMin.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.btnMin.IconColor = System.Drawing.Color.White;
            this.btnMin.Location = new System.Drawing.Point(705, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(45, 29);
            this.btnMin.TabIndex = 5;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BorderRadius = 6;
            this.btnMax.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btnMax.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.btnMax.IconColor = System.Drawing.Color.White;
            this.btnMax.Location = new System.Drawing.Point(756, 12);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(45, 29);
            this.btnMax.TabIndex = 4;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BorderRadius = 6;
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(807, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 29);
            this.btnExit.TabIndex = 3;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlsPanel.Location = new System.Drawing.Point(317, 93);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(831, 696);
            this.ControlsPanel.TabIndex = 1;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.topPanel;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 789);
            this.Controls.Add(this.navigtionMenu);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.ControlsPanel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.Panel topPanel;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
        private Guna.UI2.WinForms.Guna2ControlBox btnMin;
        private Guna.UI2.WinForms.Guna2ControlBox btnMax;
        private Kimtoo.NavigtionMenu navigtionMenu;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}