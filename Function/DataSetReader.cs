#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  DataSetReader.cs 
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
using System.IO;
using ManagementStudio;

namespace ManagementStudio
{
    [FunctionCode("DataSetReader")]
    public partial class DataSetReader : FormBase
    {
        public DataSetReader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(dlg.FileName);
                dataGridView1.DataSource = ds.Tables[0];
                rtfXml.Text = File.ReadAllText(dlg.FileName);
            }
        }
    }
}
