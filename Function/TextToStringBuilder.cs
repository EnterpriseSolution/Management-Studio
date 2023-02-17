#region Enterprise Solution
// Copyright © 2006-2015 Enterprise Solution Limited
// Solution:  Enterprise Solution
// Project:   Management Studio/Management Studio
// File:  TextToStringBuilder.cs 
// Date: 2015/08/19 14:13
// Reference: http://www.cnblogs.com/JamesLi2015
#endregion
using System.Reflection;

namespace ManagementStudio
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using ManagementStudio;

    [FunctionCode("TextToStringBuilder")]
    public class TextToStringBuilder : FormBase
    {
        private string test = @" [assembly: AssemblyCopyright(Copyright ©  2015)]
                                 [assembly: AssemblyTrademark()]
                                 [assembly: AssemblyCulture()]";

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private RichTextBox tbSource;
        private RichTextBox tbResult;
        private CheckBox cbPreserveCRLF;
        private RadioButton _rbCSharp;
        private RadioButton rbVB;
        private Button _btnGenerate;
        private Button _btnCopy;
        private IContainer components;

        public TextToStringBuilder()
        {
            this.InitializeComponent();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.CopyToClipboard();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (this.rbVB.Checked)
            {
                this.tbResult.Text = this.GenerateVBStringBuilderCode();
            }
            else
            {
                this.tbResult.Text = this.GenerateCSharpStringBuilderCode();
            }
        }

        private void CopyToClipboard()
        {
            try
            {
                Clipboard.SetDataObject(this.tbResult.Text);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                MessageBox.Show("The code could not be copied to the clipboard.", "Error Copying to Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                ProjectData.ClearProjectError();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string EscapeString(string source)
        {
            if (source != null)
            {
                return source.Replace("\"", "\"\"");
            }
            return string.Empty;
        }

        private string GenerateCSharpStringBuilderCode()
        {
            StringBuilder builder = new StringBuilder(0x1388);
            builder.Append("System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);");
            builder.Append("\r\n");
            foreach (string str2 in this.tbSource.Lines)
            {
                builder.Append("sb.Append(@\"");
                builder.Append(this.EscapeString(str2));
                builder.Append("\");");
                builder.Append("\r\n");
                if (this.cbPreserveCRLF.Checked)
                {
                    builder.Append("sb.Append(Environment.NewLine);");
                    builder.Append("\r\n");
                }
            }
            return builder.ToString();
        }

        private string GenerateVBStringBuilderCode()
        {
            StringBuilder builder = new StringBuilder(0x1388);
            builder.Append("Dim sb As New System.Text.StringBuilder(5000)");
            builder.Append("\r\n");
            foreach (string str2 in this.tbSource.Lines)
            {
                builder.Append("sb.Append(\"");
                builder.Append(this.EscapeString(str2));
                builder.Append("\")");
                builder.Append("\r\n");
                if (this.cbPreserveCRLF.Checked)
                {
                    builder.Append("sb.Append(vbCrLf)");
                    builder.Append("\r\n");
                }
            }
            return builder.ToString();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextToStringBuilder));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tbSource = new System.Windows.Forms.RichTextBox();
            this.tbResult = new System.Windows.Forms.RichTextBox();
            this._btnGenerate = new System.Windows.Forms.Button();
            this._btnCopy = new System.Windows.Forms.Button();
            this.cbPreserveCRLF = new System.Windows.Forms.CheckBox();
            this._rbCSharp = new System.Windows.Forms.RadioButton();
            this.rbVB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._btnGenerate);
            this.splitContainer1.Panel2.Controls.Add(this._btnCopy);
            this.splitContainer1.Panel2.Controls.Add(this.cbPreserveCRLF);
            this.splitContainer1.Panel2.Controls.Add(this._rbCSharp);
            this.splitContainer1.Panel2.Controls.Add(this.rbVB);
            this.splitContainer1.Size = new System.Drawing.Size(979, 461);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tbSource);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbResult);
            this.splitContainer2.Size = new System.Drawing.Size(979, 386);
            this.splitContainer2.SplitterDistance = 285;
            this.splitContainer2.TabIndex = 0;
            // 
            // tbSource
            // 
            this.tbSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSource.Location = new System.Drawing.Point(0, 0);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(979, 285);
            this.tbSource.TabIndex = 0;
            this.tbSource.Text = "";
            // 
            // tbResult
            // 
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbResult.Location = new System.Drawing.Point(0, 0);
            this.tbResult.Name = "tbResult";
            this.tbResult.ReadOnly = true;
            this.tbResult.Size = new System.Drawing.Size(979, 97);
            this.tbResult.TabIndex = 1;
            this.tbResult.Text = "";
            // 
            // _btnGenerate
            // 
            this._btnGenerate.Location = new System.Drawing.Point(452, 21);
            this._btnGenerate.Name = "_btnGenerate";
            this._btnGenerate.Size = new System.Drawing.Size(92, 22);
            this._btnGenerate.TabIndex = 4;
            this._btnGenerate.Text = "Generate Code";
            this._btnGenerate.UseVisualStyleBackColor = true;
            this._btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // _btnCopy
            // 
            this._btnCopy.Location = new System.Drawing.Point(183, 18);
            this._btnCopy.Name = "_btnCopy";
            this._btnCopy.Size = new System.Drawing.Size(63, 21);
            this._btnCopy.TabIndex = 3;
            this._btnCopy.Text = "Copy";
            this._btnCopy.UseVisualStyleBackColor = true;
            this._btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbPreserveCRLF
            // 
            this.cbPreserveCRLF.AutoSize = true;
            this.cbPreserveCRLF.Checked = true;
            this.cbPreserveCRLF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPreserveCRLF.Location = new System.Drawing.Point(268, 25);
            this.cbPreserveCRLF.Name = "cbPreserveCRLF";
            this.cbPreserveCRLF.Size = new System.Drawing.Size(121, 17);
            this.cbPreserveCRLF.TabIndex = 2;
            this.cbPreserveCRLF.Text = "Presever New Lines";
            this.cbPreserveCRLF.UseVisualStyleBackColor = true;
            // 
            // _rbCSharp
            // 
            this._rbCSharp.AutoSize = true;
            this._rbCSharp.Checked = true;
            this._rbCSharp.Location = new System.Drawing.Point(399, 37);
            this._rbCSharp.Name = "_rbCSharp";
            this._rbCSharp.Size = new System.Drawing.Size(39, 17);
            this._rbCSharp.TabIndex = 1;
            this._rbCSharp.TabStop = true;
            this._rbCSharp.Text = "C#";
            this._rbCSharp.UseVisualStyleBackColor = true;
            // 
            // rbVB
            // 
            this.rbVB.AutoSize = true;
            this.rbVB.Location = new System.Drawing.Point(399, 17);
            this.rbVB.Name = "rbVB";
            this.rbVB.Size = new System.Drawing.Size(39, 17);
            this.rbVB.TabIndex = 0;
            this.rbVB.Text = "VB";
            this.rbVB.UseVisualStyleBackColor = true;
            // 
            // TextToStringBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(979, 461);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(5, 13);
            this.Name = "TextToStringBuilder";
            this.Text = "Text to String Builder";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //[STAThread]
        //public static void Main()
        //{
        //    Application.Run(new Form1());
        //}

        //internal virtual Button btnCopy
        //{
        //    get
        //    {
        //        return this._btnCopy;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._btnCopy != null)
        //        {
        //            this._btnCopy.Click -= new EventHandler(this.btnCopy_Click);
        //        }
        //        this._btnCopy = value;
        //        if (this._btnCopy != null)
        //        {
        //            this._btnCopy.Click += new EventHandler(this.btnCopy_Click);
        //        }
        //    }
        //}

        //internal virtual Button btnGenerate
        //{
        //    get
        //    {
        //        return this._btnGenerate;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._btnGenerate != null)
        //        {
        //            this._btnGenerate.Click -= new EventHandler(this.btnGenerate_Click);
        //        }
        //        this._btnGenerate = value;
        //        if (this._btnGenerate != null)
        //        {
        //            this._btnGenerate.Click += new EventHandler(this.btnGenerate_Click);
        //        }
        //    }
        //}

        //internal virtual CheckBox cbPreserveCRLF
        //{
        //    get
        //    {
        //        return this._cbPreserveCRLF;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._cbPreserveCRLF != null)
        //        {
        //        }
        //        this._cbPreserveCRLF = value;
        //        if (this._cbPreserveCRLF != null)
        //        {
        //        }
        //    }
        //}

        //internal virtual Panel pnlButtons
        //{
        //    get
        //    {
        //        return this._pnlButtons;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._pnlButtons != null)
        //        {
        //        }
        //        this._pnlButtons = value;
        //        if (this._pnlButtons != null)
        //        {
        //        }
        //    }
        //}

        //internal virtual RadioButton rbCSharp
        //{
        //    get
        //    {
        //        return this._rbCSharp;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._rbCSharp != null)
        //        {
        //        }
        //        this._rbCSharp = value;
        //        if (this._rbCSharp != null)
        //        {
        //        }
        //    }
        //}

        //internal virtual RadioButton rbVB
        //{
        //    get
        //    {
        //        return this._rbVB;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._rbVB != null)
        //        {
        //        }
        //        this._rbVB = value;
        //        if (this._rbVB != null)
        //        {
        //        }
        //    }
        //}

        //internal virtual Splitter Splitter1
        //{
        //    get
        //    {
        //        return this._Splitter1;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._Splitter1 != null)
        //        {
        //        }
        //        this._Splitter1 = value;
        //        if (this._Splitter1 != null)
        //        {
        //        }
        //    }
        //}

        //internal virtual TextBox tbResult
        //{
        //    get
        //    {
        //        return this._tbResult;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._tbResult != null)
        //        {
        //        }
        //        this._tbResult = value;
        //        if (this._tbResult != null)
        //        {
        //        }
        //    }
        //}

        //internal virtual TextBox tbSource
        //{
        //    get
        //    {
        //        return this._tbSource;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized)]
        //    set
        //    {
        //        if (this._tbSource != null)
        //        {
        //        }
        //        this._tbSource = value;
        //        if (this._tbSource != null)
        //        {
        //        }
        //    }
        //}
    }
}

