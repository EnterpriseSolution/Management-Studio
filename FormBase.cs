#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  FormBase.cs 
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

namespace ManagementStudio
{
    public partial class FormBase : Form
    {

        public FormBase()
        {
            InitializeComponent();
        }

        private string _FunctionCode = string.Empty;

        public string FunctionCode
        {
            get { return _FunctionCode; }
            set { _FunctionCode = value; }
        }               

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //ChangeSystemMenuColor.SystemMenuColor(this.Handle, Color.FromArgb(255, 213, 103), Color.White, 1);            
            //ToolStripManager.Renderer = new CRD.WinUI.Misc.Office2007Renderer();           
            //if (!DesignMode)
            //{
            //    this.BackColor = Color.FromArgb(214, 238, 255);
            //}
        }

       

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }          
    }

}