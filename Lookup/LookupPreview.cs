#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  LookupPreview.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ManagementStudio
{
    public partial class LookupPreview : Form
    {
        DataTable _table;
        public LookupPreview(DataTable table)
        {
            InitializeComponent();
            _table = table;
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          DataGridViewRow row=  grid.CurrentRow;
          if (row != null)
          {
              LookupID =row.Cells["queryid"].Value.ToString();
              LookupName = row.Cells["LookupName"].Value.ToString();
              Description = row.Cells["Description"].Value.ToString();
              EntityName = row.Cells["EntityName"].Value.ToString();
          }
        }
        public string LookupID;
        public string LookupName;
        public string EntityName;
        public string Description;

          
        private void LookupPreview_Load(object sender, EventArgs e)
        {
            grid.DataSource = _table;
        }

        private void txtLokkupName_KeyUp(object sender, KeyEventArgs e)
        {
            DataView dv = _table.DefaultView;
            dv.RowFilter = "LookupName like '" + txtLokkupName.Text + "%'";
            DataTable tbl = dv.ToTable();
            grid.DataSource = tbl;            
        }

      
    }
}
