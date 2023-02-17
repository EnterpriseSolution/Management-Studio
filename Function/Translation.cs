#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  Translation.cs 
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
using System.IO;
using ManagementStudio;
/*
 * 当翻译的字符串本身包含'时，需要转义
 */
namespace ManagementStudio
{
    [FunctionCode("Translation")]
    public partial class Translation : FormBase
    {
        public Translation()
        {
            InitializeComponent();
        }

        private void FanyiForm_Load(object sender, EventArgs e)
        {
            this.txtMakeDate.Text = DateTime.Now.ToShortDateString();
            this.txtFanyiFunction.Text = "exec spAddTranslationText ";
            // this.lstContent.Items.Add("/*excute  translate*/");
            txtMaker.Text = System.Environment.UserName;
        }

        public string Convert(string s)
        {
            return (Microsoft.VisualBasic.Strings.StrConv(s as string, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0));
        }

        private void btnMakeSql_Click(object sender, EventArgs e)
        {
            StringBuilder sqlStr = new StringBuilder();
            //string str = "BIG5";
            //if (!twStr.Equals(new string(twStr.getB(str)), str))
            //    Shared.ShowInfo("不是繁体");
            if (!string.IsNullOrEmpty(txtFanyiFunction.Text.Trim()) && !string.IsNullOrEmpty(txtEnContent.Text.Trim()) && !string.IsNullOrEmpty(txtTWContent.Text.Trim()) && !string.IsNullOrEmpty(txtCNContent.Text.Trim()))
            {
                sqlStr.Append(txtFanyiFunction.Text);
                sqlStr.Append(" N'" + txtEnContent.Text + "',");
                sqlStr.Append(" null,");
                sqlStr.Append(" N'" + txtTWContent.Text + "',");
                sqlStr.Append(" N'" + txtCNContent.Text + "'");
                lstContent.AppendText(sqlStr+Environment.NewLine);
                ClearTextBox();
            }
            else
            {
                //Shared.ShowInfo("请填写完整数据！");
            }
        }

        private void ClearTextBox()
        {
            this.txtTWContent.Text = "";
            this.txtEnContent.Text = "";
            this.txtCNContent.Text = "";
        }

        private void txtMaker_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMaker.Text.Trim()))
            {
                DateTime dt = DateTime.Parse(txtMakeDate.Text.Trim());
                this.txtFileName.Text = txtMaker.Text.Trim() + dt.Month.ToString() + dt.Day.ToString() + ".sql";
            }
            else
            {
                DateTime dt = DateTime.Parse(txtMakeDate.Text.Trim());
                this.txtFileName.Text = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + ".sql";
            }
        }            

        private void btnSave_Click(object sender, EventArgs e)
        {
            myyFolderBrowserDialog.ShowDialog();
            myyFolderBrowserDialog.ShowNewFolderButton = true;
            string filePath = myyFolderBrowserDialog.SelectedPath;
            try
            {            
                string file=Path.Combine(filePath,txtFileName.Text);
                File.WriteAllText(file, lstContent.Text,Encoding.UTF8);
            }
            catch (IOException ioEx)
            {
               MessageBox.Show(ioEx.Message);
            }
        }

        private void lstItemClear_Click(object sender, EventArgs e)
        {
           
            lstContent.Clear();
        }

        private void txtEnContent_Leave(object sender, EventArgs e)
        {

        }

        private void txtCNContent_Leave(object sender, EventArgs e)
        {
            this.txtTWContent.Text = Convert(this.txtCNContent.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lstContent.Text.Trim().Length>0)
             Clipboard.SetText(lstContent.Text, TextDataFormat.UnicodeText);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
                lstContent.Text = Clipboard.GetText(TextDataFormat.UnicodeText);
        }
    }
}
