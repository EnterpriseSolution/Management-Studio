#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  MainForm.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagementStudio.Misc;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinTabs;
using System.Reflection;
using ManagementStudio;

namespace ManagementStudio
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Child frm = new Child();
            //frm.MdiParent = this;
            //frm.Show();

            NewProject frm = new NewProject();
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                OpenFunctionForm(frm.Task);
            }         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolStripManager.Renderer = new Office2007Renderer();
            statusStrip.Renderer = new Office2007Renderer();

             Startup frm = new Startup();
             frm.MdiParent = this;
             frm.Show();
        
            this.ultraTabbedMdiManager.TabGroupSettings.TextOrientation = TextOrientation.Horizontal;          
        }    
         

        private Dictionary<string, Type> _formBaseType = new Dictionary<string, Type>();

        public void ExecuteFunction(string functionCode)
        {
            OpenFunctionForm(functionCode);
        }
        public void OpenFunctionForm(string functionCode)
        {
            functionCode = functionCode.ToUpper().Trim();
            Type formBaseType = null;

            //if (functionCode == "17")
            //{
            //    配置程序.PerformClick();
            //    return;
            //}
            if (!_formBaseType.TryGetValue(functionCode, out formBaseType))
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                foreach (Type type in assembly.GetTypes())
                {
                    try
                    {
                        object[] attributes = type.GetCustomAttributes(typeof(FunctionCode), true);
                        foreach (object obj in attributes)
                        {
                            FunctionCode attribute = (FunctionCode)obj;
                            if (!string.IsNullOrEmpty(attribute.Value))
                            {
                                if (!_formBaseType.ContainsKey(attribute.Value))
                                    _formBaseType.Add(attribute.Value, type);

                                if (formBaseType == null && attribute.Value.Equals(functionCode,StringComparison.InvariantCultureIgnoreCase))
                                    formBaseType = type;
                            }

                            if (formBaseType != null)
                            {
                                goto Found;                               
                            }
                        }

                    }
                    catch
                    {

                    }
                }
            }
            Found:
            if (formBaseType != null)
            {
                object entryForm = Activator.CreateInstance(formBaseType) as Form;
                Form functionForm = (Form)entryForm;
                OpenFunctionForm(functionForm);
            }

        }

        private void OpenFunctionForm(Form functionForm)
        {
            try
            {
                functionForm.MdiParent = this;
                functionForm.Show();
                Application.DoEvents();
                functionForm.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开功能失败" + "\n" + ex.Message);
            }
        }
    }
}
