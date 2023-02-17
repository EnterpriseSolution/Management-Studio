#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  QueueLookUpForm.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using ManagementStudio;

namespace ManagementStudio
{
    [FunctionCode("QueueLookUpForm")]    
    public partial class QueueLookUpForm :Form
    {
        DataTable _table = new DataTable();
        string lookupname = string.Empty;
        

        public QueueLookUpForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        SqlConnection SystemSqlConnection;
        protected override void InitLayout()
        {
            base.InitLayout();
            try
            {
                string SystemDatabase = Shared.SystemDatabase;//System.Configuration.ConfigurationManager.ConnectionStrings["SystemDatabase"].ConnectionString;
                SystemSqlConnection = new SqlConnection(SystemDatabase);     

                SqlDataAdapter Adp = new SqlDataAdapter("select udqtable.queryid ,udqtable.EntityName , LookupDialog.LookupName ,  LookupDialog.Description, LookupDialog.KeyField1 from udqtable ,LookupDialog"
               + " where udqtable.queryid=LookupDialog.queryid", SystemSqlConnection);
                Adp.Fill(_table);
                this.gridView.DataSource = _table;
                gridView.Columns[0].Width = 100;
                gridView.Columns[1].Width = 280;
                gridView.Columns[2].Width = 200;
                gridView.Columns[3].Width = 250;
            }
            catch
            {

            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            _table.Rows.Clear();
            SqlDataAdapter Adp;
            if (textBox2.Text.Trim() == "")
            {
                Adp = new SqlDataAdapter("select udqtable.queryid ,udqtable.EntityName , LookupDialog.LookupName ,  LookupDialog.Description, LookupDialog.KeyField1 from udqtable ,LookupDialog"
                + " where udqtable.queryid=LookupDialog.queryid", SystemSqlConnection);
                Adp.Fill(_table);
                this.gridView.DataSource = _table;
            }
            else
            {
                Adp = new SqlDataAdapter("select udqtable.queryid ,udqtable.EntityName , LookupDialog.LookupName ,  LookupDialog.Description, LookupDialog.KeyField1 from udqtable ,LookupDialog"
                + " where udqtable.queryid=LookupDialog.queryid and udqtable.QueryId like '%" + textBox2.Text.Trim() + "%'", SystemSqlConnection);
                Adp.Fill(_table);
                this.gridView.DataSource = _table;
            }
            gridView.Columns[0].Width = 100;
            gridView.Columns[1].Width = 280;
            gridView.Columns[2].Width = 200;
            gridView.Columns[3].Width = 250;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            _table.Rows.Clear();
            SqlDataAdapter Adp;
            if (textBox1.Text.Trim() == "")
            {
                Adp = new SqlDataAdapter("select udqtable.queryid ,udqtable.EntityName , LookupDialog.LookupName ,  LookupDialog.Description, LookupDialog.KeyField1 from udqtable ,LookupDialog"
                + " where udqtable.queryid=LookupDialog.queryid", SystemSqlConnection);
                Adp.Fill(_table);
                this.gridView.DataSource = _table;
            }
            else
            {
                Adp = new SqlDataAdapter("select udqtable.queryid ,udqtable.EntityName , LookupDialog.LookupName ,  LookupDialog.Description, LookupDialog.KeyField1 from udqtable ,LookupDialog"
                + " where udqtable.queryid=LookupDialog.queryid and udqtable.EntityName like '%" + textBox1.Text.Trim() + "%'", SystemSqlConnection);
                Adp.Fill(_table);
                this.gridView.DataSource = _table;
            }
            gridView.Columns[0].Width = 100;
            gridView.Columns[1].Width = 280;
            gridView.Columns[2].Width = 200;
            gridView.Columns[3].Width = 250;
        }

        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string[] row = new string[4];
                row[0] = this.gridView.CurrentRow.Cells[0].Value.ToString();
                row[1] = this.gridView.CurrentRow.Cells[1].Value.ToString();
                row[2] = this.gridView.CurrentRow.Cells[2].Value.ToString();
                row[3] = this.gridView.CurrentRow.Cells[3].Value.ToString();
                // LookupSql lookupSql = new LookupSql(this._sqlConnection, this.gridView.CurrentRow.Cells[0].Value.ToString());
                LookupGenerator lookupSql = new LookupGenerator(row);
                lookupSql.MdiParent = this.MdiParent;
                lookupSql.Show();
            }
            catch
            {

            }
        }

        private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string row = string.Empty;
            lookupname = this.gridView.CurrentRow.Cells[2].Value.ToString();
            this.gridView2.DataSource = null;

            if (string.IsNullOrEmpty(lookupname))
            {
                this.gridView3.DataSource = null;
                this.gridView2.DataSource = null;
                this.gridView1.DataSource = null;
                return; 
            }
            row = this.gridView.CurrentRow.Cells[0].Value.ToString();
            SqlDataAdapter Adp;
            string cmd = "select [EntityName],[ColumnName] from udqcolumn where QueryId='" + row + "'";
            Adp = new SqlDataAdapter(cmd, SystemSqlConnection);
            DataTable table = new DataTable();
            Adp.Fill(table);
            this.gridView1.DataSource = table;

            cmd = "select filtername,description from lookupdialogfilter where lookupname='" + lookupname + "'";
            Adp = new SqlDataAdapter(cmd, SystemSqlConnection);
            DataTable table3 = new DataTable();
            Adp.Fill(table3);
            this.gridView3.DataSource = table3;

            gridView3_CellClick(gridView3,new DataGridViewCellEventArgs(0,0));
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(textBox3.Text))
            {
                string entityName = "";
                //if (Shared.CachedSourceEntity.TryGetValue(textBox3.Text.Trim().ToUpper(), out entityName))
                //{
                //    textBox1.Text = entityName;
                //    textBox1_KeyUp(null, null);
                //}
                //else
                //{
                //    //HVS.WinUI.Shared.ShowInfo("找不到此表的实体,可能是表名错误");
                //}
            }
        }

        private void gridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.gridView3.Rows[e.RowIndex].Cells[0].Value == null)
            {
                this.gridView2.DataSource = null;
                return;
            }
            string filterName = this.gridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(filterName))
            {
                this.gridView2.DataSource = null;
                return;
            }
            string cmd = "select entityname ,fieldname,fieldvalue ,operator from lookupdialogfilterdetail " +
                   " where lookupdialogfilterdetail.lookupname='" + lookupname + "' and filtername='" + filterName+"'";

            SqlDataAdapter Adp = new SqlDataAdapter(cmd, SystemSqlConnection);
            DataTable table2 = new DataTable();
            Adp.Fill(table2);
            this.gridView2.DataSource = table2;
        }

    }
}
