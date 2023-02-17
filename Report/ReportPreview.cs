#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  ReportPreview.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
namespace ManagementStudio
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Data;

    public class ReportPreview : Form
    {       
     
        private DataGridView grid;
        private Button btnOK;
        private Button btnCancel;
        private IContainer components;
        private Label label1;
        private TextBox txtReportID;
        DataTable _table;

        public ReportPreview(DataTable table)
        {         
            this.InitializeComponent();
            _table = table;
        }

      

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
      
        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReportID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(1, 1);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 23;
            this.grid.Size = new System.Drawing.Size(698, 280);
            this.grid.TabIndex = 0;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(548, 295);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(63, 22);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(625, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 22);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Report ID";
            // 
            // txtReportID
            // 
            this.txtReportID.Location = new System.Drawing.Point(72, 295);
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.Size = new System.Drawing.Size(165, 20);
            this.txtReportID.TabIndex = 4;
            this.txtReportID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtReportID_KeyUp);
            // 
            // ReportPreview
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(716, 327);
            this.Controls.Add(this.txtReportID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grid);
            this.Name = "ReportPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Preview";
            this.Load += new System.EventHandler(this.ReportPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ReportPreview_Load(object sender, EventArgs e)
        {
            grid.DataSource = _table;
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = grid.CurrentRow;
            if (row != null)
            {
                ReportId = row.Cells["ReportId"].Value.ToString();
                Description = row.Cells["Description"].Value.ToString();               
            }
        }

        public string ReportId;
        public string Description;

        private void txtReportID_KeyUp(object sender, KeyEventArgs e)
        {
            DataView dv = _table.DefaultView;
            dv.RowFilter = "ReportId like '" + txtReportID.Text + "%'";
            DataTable tbl = dv.ToTable();
            grid.DataSource = tbl;    
        }
    }
}

