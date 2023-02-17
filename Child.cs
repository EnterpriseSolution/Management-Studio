#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  Child.cs 
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

namespace ManagementStudio
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }

        private void ChildForm2_Load(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(richTextBox1.Text, false);
           // webBrowser1.Url =new Uri(richTextBox1.Text);

           // StreamReader read = new StreamReader(richTextBox1.Text);
           // string data = read.ReadToEnd();
           // webBrowser1.DocumentText = data;
        }
    }
}
