#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  ReportDialogGenerator.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
namespace ManagementStudio
{
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using ManagementStudio;

     // Table: 1.ReportDialog 2.ReportDialogOption 3.ReportDialogOptionItem 4.ReportDialogAlternateReport";
    [FunctionCode("ReportGenerator")]
    public class ReportDialogGenerator : Form
    {

        private TextBox txtReportID;
        private Button btnGenerate;
        private Button btnCopy;
        private RichTextBox rtfRpt;
        private Button btnPreview;
        private Label label1;
        private TextBox txtDesc;
        private IContainer components;

        public ReportDialogGenerator()
        {
            this.InitializeComponent();
            _table = new DataTable();
        }

        private string SystemDatabase = Shared.SystemDatabase; //System.Configuration.ConfigurationManager.ConnectionStrings["SystemDatabase"].ConnectionString;

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SqlConnection connection2 = new SqlConnection();
            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            DataSet dataSet = new DataSet();
            try
            {
                int num;
                string str;
                int num2 = 0;
                int num3;

                connection2.ConnectionString = SystemDatabase;
                connection2.Open();
                command = new SqlCommand("select * from ReportDialog where ReportId='" + this.txtReportID.Text + "'", connection2);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 600;
                command.ExecuteNonQuery();
                command.Dispose();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, "ds1");
                string str2 = "";
                int num4 = dataSet.Tables[0].Columns.Count - 1;
                for (num = 0; num <= num4; num++)
                {
                    str2 = str2 + "[" + dataSet.Tables[0].Columns[num].ColumnName + "]";
                    if (num != (dataSet.Tables[0].Columns.Count - 1))
                    {
                        str2 = str2 + ",";
                    }
                }
                string str5 = "";
                string str4 = "";
                str4 = (str4 + "\r\nIf not exists(Select * From ReportDialog Where ReportId='" + dataSet.Tables[0].Rows[num2][0].ToString() + "') Begin\r\n\r\n") + "--ReportDialog\r\n\r\n";
                int num5 = dataSet.Tables[0].Rows.Count - 1;
                for (num2 = 0; num2 <= num5; num2++)
                {
                    str4 = (str4 + "Insert Into [ReportDialog] (" + str2 + ")") + "\r\nValues (";
                    int num6 = dataSet.Tables[0].Columns.Count - 1;
                    num3 = 0;
                    while (num3 <= num6)
                    {
                        if (Strings.Len(dataSet.Tables[0].Rows[num2][num3].ToString()) == 0)
                        {
                            str = "";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime")
                        {
                            str = Strings.Format(RuntimeHelpers.GetObjectValue(dataSet.Tables[0].Rows[num2][num3]), "yyyy-MM-dd");
                        }
                        else
                        {
                            str = Strings.Trim(dataSet.Tables[0].Rows[num2][num3].ToString());
                        }
                        if ((dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.String") | (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime"))
                        {
                            str4 = str4 + "N'" + str + "'";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.Boolean")
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataSet.Tables[0].Rows[num2][num3], false, false))
                            {
                                str4 = str4 + "'0'";
                            }
                            else
                            {
                                str4 = str4 + "'1'";
                            }
                        }
                        else
                        {
                            str4 = str4 + "'" + str + "'";
                        }
                        if (num3 == (dataSet.Tables[0].Columns.Count - 1))
                        {
                            str4 = str4 + ")\r\n";
                        }
                        else
                        {
                            str4 = str4 + ",";
                        }
                        num3++;
                    }
                    str4 = str4 + "\r\n";
                }
                str5 = str4;
                string cmdText = "select * from ReportDialogOption where ReportId='" + this.txtReportID.Text + "'";
                dataSet = new DataSet();
                command = new SqlCommand(cmdText, connection2);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 600;
                command.ExecuteNonQuery();
                command.Dispose();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, "ds1");
                str2 = "";
                int num7 = dataSet.Tables[0].Columns.Count - 1;
                for (num = 0; num <= num7; num++)
                {
                    str2 = str2 + "[" + dataSet.Tables[0].Columns[num].ColumnName + "]";
                    if (num != (dataSet.Tables[0].Columns.Count - 1))
                    {
                        str2 = str2 + ",";
                    }
                }
                string str7 = "";
                str4 = "";
                str4 = str4 + "--ReportDialogOption\r\n\r\n";
                int num8 = dataSet.Tables[0].Rows.Count - 1;
                for (num2 = 0; num2 <= num8; num2++)
                {
                    str4 = (str4 + "Insert Into [ReportDialogOption] (" + str2 + ")") + "\r\nValues (";
                    int num9 = dataSet.Tables[0].Columns.Count - 1;
                    num3 = 0;
                    while (num3 <= num9)
                    {
                        if (Strings.Len(dataSet.Tables[0].Rows[num2][num3].ToString()) == 0)
                        {
                            str = "";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime")
                        {
                            str = Strings.Format(RuntimeHelpers.GetObjectValue(dataSet.Tables[0].Rows[num2][num3]), "yyyy-MM-dd");
                        }
                        else
                        {
                            str = Strings.Trim(dataSet.Tables[0].Rows[num2][num3].ToString());
                        }
                        if ((dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.String") | (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime"))
                        {
                            str4 = str4 + "N'" + str + "'";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.Boolean")
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataSet.Tables[0].Rows[num2][num3], false, false))
                            {
                                str4 = str4 + "'0'";
                            }
                            else
                            {
                                str4 = str4 + "'1'";
                            }
                        }
                        else
                        {
                            str4 = str4 + "'" + str + "'";
                        }
                        if (num3 == (dataSet.Tables[0].Columns.Count - 1))
                        {
                            str4 = str4 + ")\r\n";
                        }
                        else
                        {
                            str4 = str4 + ",";
                        }
                        num3++;
                    }
                    str4 = str4 + "\r\n";
                }
                str7 = str4;
                cmdText = "select * from ReportDialogOptionItem where ReportId='" + this.txtReportID.Text + "'";
                dataSet = new DataSet();
                command = new SqlCommand(cmdText, connection2);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 600;
                command.ExecuteNonQuery();
                command.Dispose();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, "ds1");
                str2 = "";
                int num10 = dataSet.Tables[0].Columns.Count - 1;
                for (num = 0; num <= num10; num++)
                {
                    str2 = str2 + "[" + dataSet.Tables[0].Columns[num].ColumnName + "]";
                    if (num != (dataSet.Tables[0].Columns.Count - 1))
                    {
                        str2 = str2 + ",";
                    }
                }
                string str8 = "";
                str4 = "";
                str4 = str4 + "--ReportDialogOptionItem\r\n\r\n";
                int num11 = dataSet.Tables[0].Rows.Count - 1;
                for (num2 = 0; num2 <= num11; num2++)
                {
                    str4 = (str4 + "Insert Into [ReportDialogOptionItem] (" + str2 + ")") + "\r\nValues (";
                    int num12 = dataSet.Tables[0].Columns.Count - 1;
                    num3 = 0;
                    while (num3 <= num12)
                    {
                        if (Strings.Len(dataSet.Tables[0].Rows[num2][num3].ToString()) == 0)
                        {
                            str = "";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime")
                        {
                            str = Strings.Format(RuntimeHelpers.GetObjectValue(dataSet.Tables[0].Rows[num2][num3]), "yyyy-MM-dd");
                        }
                        else
                        {
                            str = Strings.Trim(dataSet.Tables[0].Rows[num2][num3].ToString());
                        }
                        if ((dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.String") | (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime"))
                        {
                            str4 = str4 + "N'" + str + "'";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.Boolean")
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataSet.Tables[0].Rows[num2][num3], false, false))
                            {
                                str4 = str4 + "'0'";
                            }
                            else
                            {
                                str4 = str4 + "'1'";
                            }
                        }
                        else
                        {
                            str4 = str4 + "'" + str + "'";
                        }
                        if (num3 == (dataSet.Tables[0].Columns.Count - 1))
                        {
                            str4 = str4 + ")\r\n";
                        }
                        else
                        {
                            str4 = str4 + ",";
                        }
                        num3++;
                    }
                    str4 = str4 + "\r\n";
                }
                str8 = str4;
                cmdText = "select * from ReportDialogAlternateReport where ReportId='" + this.txtReportID.Text + "'";
                dataSet = new DataSet();
                command = new SqlCommand(cmdText, connection2);
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 600;
                command.ExecuteNonQuery();
                command.Dispose();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet, "ds1");
                str2 = "";
                int num13 = dataSet.Tables[0].Columns.Count - 1;
                for (num = 0; num <= num13; num++)
                {
                    str2 = str2 + "[" + dataSet.Tables[0].Columns[num].ColumnName + "]";
                    if (num != (dataSet.Tables[0].Columns.Count - 1))
                    {
                        str2 = str2 + ",";
                    }
                }
                string str6 = "";
                str4 = "";
                str4 = str4 + "--ReportDialogAlternateReport\r\n\r\n";
                int num14 = dataSet.Tables[0].Rows.Count - 1;
                for (num2 = 0; num2 <= num14; num2++)
                {
                    str4 = (str4 + "Insert Into [ReportDialogAlternateReport] (" + str2 + ")") + "\r\nValues (";
                    int num15 = dataSet.Tables[0].Columns.Count - 1;
                    for (num3 = 0; num3 <= num15; num3++)
                    {
                        if (Strings.Len(dataSet.Tables[0].Rows[num2][num3].ToString()) == 0)
                        {
                            str = "";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime")
                        {
                            str = Strings.Format(RuntimeHelpers.GetObjectValue(dataSet.Tables[0].Rows[num2][num3]), "yyyy-MM-dd");
                        }
                        else
                        {
                            str = Strings.Trim(dataSet.Tables[0].Rows[num2][num3].ToString());
                        }
                        if ((dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.String") | (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.DateTime"))
                        {
                            str4 = str4 + "N'" + str + "'";
                        }
                        else if (dataSet.Tables[0].Rows[num2][num3].GetType().ToString() == "System.Boolean")
                        {
                            if (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(dataSet.Tables[0].Rows[num2][num3], false, false))
                            {
                                str4 = str4 + "'0'";
                            }
                            else
                            {
                                str4 = str4 + "'1'";
                            }
                        }
                        else
                        {
                            str4 = str4 + "'" + str + "'";
                        }
                        if (num3 == (dataSet.Tables[0].Columns.Count - 1))
                        {
                            str4 = str4 + ")\r\n";
                        }
                        else
                        {
                            str4 = str4 + ",";
                        }
                    }
                    str4 = str4 + "\r\n";
                }
                str6 = str4;
                this.rtfRpt.Text = str5 + str7 + str8 + str6 + "\r\nEnd";
                Clipboard.SetText(this.rtfRpt.Text);
                //Interaction.MsgBox("执行完成!", MsgBoxStyle.OkOnly, null);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Interaction.MsgBox(exception1.ToString(), MsgBoxStyle.OkOnly, null);
                Interaction.MsgBox("执行失败,请检查错误!", MsgBoxStyle.OkOnly, null);
                ProjectData.ClearProjectError();
            }
            finally
            {
                connection2.Close();
                connection.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (((disposing && (this.components != null)) ? 1 : 0) != 0)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtReportID = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.rtfRpt = new System.Windows.Forms.RichTextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtReportID
            // 
            this.txtReportID.Location = new System.Drawing.Point(80, 18);
            this.txtReportID.Name = "txtReportID";
            this.txtReportID.Size = new System.Drawing.Size(120, 23);
            this.txtReportID.TabIndex = 1;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(637, 16);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(104, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "生成报表";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(757, 16);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(102, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "拷贝到剪贴板";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // rtfRpt
            // 
            this.rtfRpt.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                         | System.Windows.Forms.AnchorStyles.Left)
                                                                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfRpt.Location = new System.Drawing.Point(6, 50);
            this.rtfRpt.Name = "rtfRpt";
            this.rtfRpt.Size = new System.Drawing.Size(853, 363);
            this.rtfRpt.TabIndex = 5;
            this.rtfRpt.Text = "";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(520, 16);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(104, 23);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "预览报表";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "报表ID";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(207, 17);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(303, 23);
            this.txtDesc.TabIndex = 8;
            // 
            // ReportDialogGenerator
            // 
            this.ClientSize = new System.Drawing.Size(871, 425);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.rtfRpt);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtReportID);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Name = "ReportDialogGenerator";
            this.Text = "Report Dialog Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataTable _table;

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string sql = " SELECT ReportId,Description FROM  ReportDialog ";
            SqlConnection SystemSqlConnection = new SqlConnection(SystemDatabase);
            SqlDataAdapter Adp = new SqlDataAdapter(sql, SystemSqlConnection);
            Adp.Fill(_table);

            ReportPreview dlg = new ReportPreview(_table);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                txtReportID.Text = dlg.ReportId;
                txtDesc.Text = dlg.Description;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(rtfRpt.Text))
                Clipboard.SetText(rtfRpt.Text);
        }
    }
}

