#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  NewProject.cs 
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
using ManagementStudio;
using System.Xml;
using System.Reflection;
using System.IO;

namespace ManagementStudio
{
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private string _task;
        public string Task
        {
            get
            {                
                if (lstTask.SelectedItems.Count > 0&&string.IsNullOrEmpty(_task))
                    _task = lstTask.SelectedItems[0].Tag as string;

                return _task;
            }
            set
            {
                _task = value;
            }
        }

        private void lstTask_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            //ListViewItem item = lstTask.GetItemAt(e.X, e.Y);
            //if (item != null && item.Tag != null)
            //{
            //    MainForm main = this.Owner as MainForm;
            //    main.ExecuteFunction(item.Tag.ToString());
            //}    
            ListViewItem item = lstTask.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag != null)
            {
                _task = item.Tag.ToString();
            }
            DialogResult = DialogResult.OK; 
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            lstTask.Items.Clear();
            List<ListViewItem> items = new List<ListViewItem>();
            string path = "ManagementStudio.ListItem.xml";
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream(path);           
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            XmlNode root = doc.SelectSingleNode("/Items");
            foreach (XmlNode item in root.ChildNodes)
            {
                ListViewItem litem = new ListViewItem(item.Attributes["Text"].Value, Convert.ToInt16(item.Attributes["ImageIndex"].Value));
                litem.Tag = item.Attributes["Tag"].Value;
                items.Add(litem);
            }

            try
            {
                this.lstTask.SuspendLayout();
                this.lstTask.BeginUpdate();
                this.lstTask.Items.Clear();
                this.lstTask.Groups.Clear();
                this.lstTask.SmallImageList =this.lstTask.LargeImageList= imageList1;
                this.lstTask.Items.AddRange(items.ToArray());
            }
            finally
            {
                this.lstTask.EndUpdate();
                this.lstTask.ResumeLayout(false);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //用这种方式打开，会出现焦点不在新打开的窗体中
            //if (!string.IsNullOrEmpty(Task))
            //{
            //    MainForm main = this.Owner as MainForm;
            //    main.ExecuteFunction(Task);
            //}
            DialogResult = DialogResult.OK;           
        }

       
    }
}