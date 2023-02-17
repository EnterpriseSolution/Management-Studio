#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  LookupGenerator.cs 
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
using System.Data.SqlClient;
using System.IO;
using ManagementStudio;

namespace ManagementStudio
{
    [FunctionCode("LookupGenerator")]    
    public partial class LookupGenerator : System.Windows.Forms.Form
    {
        DataTable _table = new DataTable();
        string SystemDatabase =Shared.SystemDatabase; //System.Configuration.ConfigurationManager.ConnectionStrings["SystemDatabase"].ConnectionString;

        public LookupGenerator()
        {
            InitializeComponent();
            SqlConnection SystemSqlConnection = new SqlConnection(SystemDatabase);
            SqlDataAdapter Adp = new SqlDataAdapter("select udqtable.queryid ,udqtable.EntityName , LookupDialog.LookupName ,  LookupDialog.Description, LookupDialog.KeyField1 from udqtable ,LookupDialog"
                + " where udqtable.queryid=LookupDialog.queryid", SystemSqlConnection);
            Adp.Fill(_table);
            this.KeyPreview = true;
        }

        public LookupGenerator(string[] row)
        {
            InitializeComponent();
            this.txtLookupID.Text = row[0].ToString();
            this.txtEntityName.Text = row[1].ToString();
            this.txtLookupName.Text = row[2].ToString();
            this.txtDescription.Text = row[3].ToString();
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //GetIdOrLookupName();
                if (this.txtLookupID.Text == "" && this.txtLookupName.Text == "")
                    return;
                if (this.txtLookupID.Text == "" || this.txtLookupName.Text == "")
                {                    
                    return;
                }
                string queryid_sqlstring = "If not exists(Select * From udq Where QueryId='" + this.txtLookupID.Text + "') Begin" + "\n\n";
                string lookupName_sqlstring = "If not exists(Select * From LookupDialog Where LookupName='" + this.txtLookupName.Text + "') Begin" + "\n\n";

                string addSql = string.Empty;
                if(RdbChange.Checked)
                 addSql = "Delete udq where QueryId='" + txtLookupID.Text.Trim() + "'\n" +
                                "Delete LookupDialog Where LookupName='" + txtLookupName.Text.Trim() + "'\n\n";

                this.codeEditorControl1.Text =addSql+
                    queryid_sqlstring +
                    GetSqlString("udq", "QueryId") +
                    GetSqlString("udqcolumn", "QueryId") +
                    GetSqlString("udqcolumndrilldown", "QueryId") +
                    GetSqlString("udqrelation", "QueryId") +
                    GetSqlString("udqrelationdetail", "QueryId") +
                    GetSqlString("udqtable", "QueryId") + "\n" + "end" + "\n\n\n" +

                    lookupName_sqlstring +
                    GetSqlString("LookupDialog", "LookupName") +
                    GetSqlString("LookupDialogFilter", "LookupName") +
                    GetSqlString("LookupDialogFilterColumnDetail", "LookupName") +
                    GetSqlString("LookupDialogFilterDetail", "LookupName") + "\n\n" + "END"; ;

                //HVS.WinUI.Shared.ShowInfo("执行完成!");
            }
            catch (Exception err)
            {
                //HVS.WinUI.Shared.ShowInfo(err.Message);
            }
        }

        private void GetIdOrLookupName()
        {
            if (this.txtLookupID.Text != "" && this.txtLookupName.Text == "")
            {
                foreach (DataRow row in _table.Rows)
                {
                    if (row[0].ToString() == this.txtLookupID.Text)
                    {
                        this.txtLookupName.Text = row[2].ToString();
                        break;
                    }
                }
            }
            else if (this.txtLookupID.Text == "" && this.txtLookupName.Text != "")
            {
                foreach (DataRow row in _table.Rows)
                {
                    if (row[2].ToString() == this.txtLookupName.Text)
                    {
                        this.txtLookupID.Text = row[0].ToString();
                        break;
                    }
                }
            }
        }

        private string InsertColumnString(string TableName, string FieldName)
        {
            string sqlstr = "";
            if (FieldName == "QueryId")
            {
                sqlstr = "select * from " + TableName + " where " + FieldName + "='" + this.txtLookupID.Text + "'";
            }
            if (FieldName == "LookupName")
            {
                sqlstr = "select * from " + TableName + " where " + FieldName + "='" + this.txtLookupName.Text + "'";
            }
            SqlConnection SystemSqlConnection = new SqlConnection(SystemDatabase);
    
            SqlDataAdapter adp = new SqlDataAdapter(sqlstr,SystemSqlConnection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string insertColumnString = "";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                insertColumnString += "[" + dt.Columns[i].ColumnName + "]";
                if (i != dt.Columns.Count - 1)
                    insertColumnString += ",";
            }
            return insertColumnString;
        }

        private string GetSqlString(string TableName, string FieldName)
        {
            string sqlstr = "";
            if (FieldName == "QueryId")
            {
                sqlstr = "select * from " + TableName + " where " + FieldName + "='" + this.txtLookupID.Text + "'";
            }
            if (FieldName == "LookupName")
            {
                sqlstr = "select * from " + TableName + " where " + FieldName + "='" + this.txtLookupName.Text + "'";
            }

            SqlConnection SystemSqlConnection = new SqlConnection(SystemDatabase);
    
            SqlDataAdapter adp = new SqlDataAdapter(sqlstr, SystemSqlConnection);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string sqlstring = "";
            string tempstring = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sqlstring = sqlstring + "   Insert Into [" + TableName + "] \n (" + InsertColumnString(TableName, FieldName) + ") \n" + "    Values (";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString() == "")
                    {
                        tempstring = "''";
                    }
                    else
                    {
                        if (dt.Rows[i][j].GetType().ToString() == "System.DateTime")
                        {
                            DateTime time = DateTime.Parse(dt.Rows[i][j].ToString());
                            tempstring = string.Format("{0}-{1}-{2} {3}:{4}:{5}", new object[] { time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second });

                        }
                        else
                        {
                            tempstring = dt.Rows[i][j].ToString().Trim();
                        }
                    }

                    if (dt.Rows[i][j].GetType().ToString() == "System.String" || dt.Rows[i][j].GetType().ToString() == "System.DateTime")
                    {
                        if (dt.Rows[i][j].ToString() == "")
                            sqlstring = sqlstring + "N" + tempstring;
                        else
                            sqlstring = sqlstring + "N'" + tempstring + "'";
                    }
                    else if (dt.Rows[i][j].GetType().ToString() == "System.Boolean")
                    {
                        if (bool.Parse(dt.Rows[i][j].ToString()) == false)
                            sqlstring = sqlstring + "'0'";
                        else
                            sqlstring = sqlstring + "'1'";
                    }
                    else
                    {
                        if (tempstring == "''")
                            tempstring = "N''";
                        sqlstring = sqlstring + tempstring;
                    }

                    if (j == dt.Columns.Count - 1)
                        sqlstring = sqlstring + ")" + "\n";
                    else
                        sqlstring = sqlstring + ",";
                }
                sqlstring = sqlstring + "\n";
            }
            return sqlstring;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection SystemSqlConnection = new SqlConnection(SystemDatabase);
    
                SqlCommand cmd = new SqlCommand(this.codeEditorControl1.Text, SystemSqlConnection);
                if (SystemSqlConnection.State == ConnectionState.Closed)
                    SystemSqlConnection.Open();
                cmd.ExecuteNonQuery();
                SystemSqlConnection.Close();
                Show("执行成功!");
                
            }
            catch (Exception err)
            {
                Show("执行失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (this.codeEditorControl1.Text.Trim().Length < 1)
            //{
            //    return;
            //}
            //SaveFileDialog save = new SaveFileDialog();
            //save.FileName =DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Day.ToString() + txtLookupName.Text;
            //save.Filter = "SQL文件(*.sql)|*.sql|所有文件(*.*)|*.*";
            //if (save.ShowDialog() == DialogResult.OK)
            //{
            //    FileStream file = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
            //    StreamWriter writer = new StreamWriter(file, Encoding.Unicode);
            //    writer.Write(this.codeEditorControl1.Text);
            //    writer.Close();
            //    file.Close();
            //}
            if (!String.IsNullOrEmpty(this.codeEditorControl1.Text))
                Clipboard.SetText(this.codeEditorControl1.Text);
        }     
   
        private void btnPreview_Click(object sender, EventArgs e)
        {
            LookupPreview dlg = new LookupPreview(_table);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtLookupID.Text = dlg.LookupID;
                txtLookupName.Text = dlg.LookupName;
                txtEntityName.Text = dlg.EntityName;
                txtDescription.Text = dlg.Description;
            }
        }

        void Show(string message)
        {
            MessageBox.Show(message, "查询生成器", MessageBoxButtons.OK);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            //转换为ERP可以使用的查询语句
            if (!String.IsNullOrEmpty(codeEditorControl1.Text))
            {
                string sql = codeEditorControl1.Text;
                sql = sql.Replace("udq", "UserDefinedQuery");
                sql = sql.Replace("udqcolumn", "UserDefinedQueryColumn");
                codeEditorControl1.Text = sql;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ReportDialogGenerator dlg = new ReportDialogGenerator();
            dlg.Show();
        }
    }
}
