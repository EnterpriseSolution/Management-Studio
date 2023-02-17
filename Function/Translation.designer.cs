using System.Windows.Forms;
namespace ManagementStudio
{
    partial class Translation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Translation));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMakeDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFanyiFunction = new System.Windows.Forms.TextBox();
            this.txtEnContent = new System.Windows.Forms.TextBox();
            this.txtTWContent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCNContent = new System.Windows.Forms.TextBox();
            this.btnMakeSql = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.myyFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lstContent = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "制作人：";
            // 
            // txtMaker
            // 
            this.txtMaker.BackColor = System.Drawing.SystemColors.Window;
            this.txtMaker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaker.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMaker.Location = new System.Drawing.Point(82, 14);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(100, 20);
            this.txtMaker.TabIndex = 1;
            this.txtMaker.TextChanged += new System.EventHandler(this.txtMaker_TextChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.SystemColors.Window;
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFileName.Location = new System.Drawing.Point(422, 14);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 20);
            this.txtFileName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "文件名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "制作时间：";
            // 
            // txtMakeDate
            // 
            this.txtMakeDate.BackColor = System.Drawing.SystemColors.Window;
            this.txtMakeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMakeDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMakeDate.Location = new System.Drawing.Point(261, 15);
            this.txtMakeDate.Name = "txtMakeDate";
            this.txtMakeDate.Size = new System.Drawing.Size(100, 20);
            this.txtMakeDate.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "翻译函数：";
            // 
            // txtFanyiFunction
            // 
            this.txtFanyiFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFanyiFunction.BackColor = System.Drawing.SystemColors.Window;
            this.txtFanyiFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFanyiFunction.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFanyiFunction.Location = new System.Drawing.Point(82, 52);
            this.txtFanyiFunction.Name = "txtFanyiFunction";
            this.txtFanyiFunction.Size = new System.Drawing.Size(893, 20);
            this.txtFanyiFunction.TabIndex = 3;
            // 
            // txtEnContent
            // 
            this.txtEnContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEnContent.BackColor = System.Drawing.SystemColors.Window;
            this.txtEnContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEnContent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEnContent.Location = new System.Drawing.Point(82, 81);
            this.txtEnContent.Name = "txtEnContent";
            this.txtEnContent.Size = new System.Drawing.Size(893, 20);
            this.txtEnContent.TabIndex = 4;
            this.txtEnContent.Leave += new System.EventHandler(this.txtEnContent_Leave);
            // 
            // txtTWContent
            // 
            this.txtTWContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTWContent.BackColor = System.Drawing.SystemColors.Window;
            this.txtTWContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTWContent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTWContent.Location = new System.Drawing.Point(82, 140);
            this.txtTWContent.Name = "txtTWContent";
            this.txtTWContent.Size = new System.Drawing.Size(893, 20);
            this.txtTWContent.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "英文：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "繁体：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "简体：";
            // 
            // txtCNContent
            // 
            this.txtCNContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCNContent.BackColor = System.Drawing.SystemColors.Window;
            this.txtCNContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCNContent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCNContent.Location = new System.Drawing.Point(82, 111);
            this.txtCNContent.Name = "txtCNContent";
            this.txtCNContent.Size = new System.Drawing.Size(893, 20);
            this.txtCNContent.TabIndex = 5;
            this.txtCNContent.Leave += new System.EventHandler(this.txtCNContent_Leave);
            // 
            // btnMakeSql
            // 
            this.btnMakeSql.Location = new System.Drawing.Point(82, 169);
            this.btnMakeSql.Name = "btnMakeSql";
            this.btnMakeSql.Size = new System.Drawing.Size(107, 33);
            this.btnMakeSql.TabIndex = 7;
            this.btnMakeSql.Text = "生 成 翻 译(&S)";
            this.btnMakeSql.Click += new System.EventHandler(this.btnMakeSql_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(295, 171);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "生 成 SQL 文 件";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "清空所有项";
            this.button1.Click += new System.EventHandler(this.lstItemClear_Click);
            // 
            // lstContent
            // 
            this.lstContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstContent.Location = new System.Drawing.Point(82, 208);
            this.lstContent.Name = "lstContent";
            this.lstContent.Size = new System.Drawing.Size(893, 260);
            this.lstContent.TabIndex = 8;
            this.lstContent.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(428, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 30);
            this.button2.TabIndex = 14;
            this.button2.Text = "拷贝到剪贴板";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(561, 169);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 30);
            this.button3.TabIndex = 15;
            this.button3.Text = "读取剪贴板";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Translation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 481);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lstContent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMakeSql);
            this.Controls.Add(this.txtCNContent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTWContent);
            this.Controls.Add(this.txtEnContent);
            this.Controls.Add(this.txtFanyiFunction);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMakeDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtMaker);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Translation";
            this.Text = "翻译";
            this.Load += new System.EventHandler(this.FanyiForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMakeSql;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog myyFolderBrowserDialog;
        private System.Windows.Forms.RichTextBox lstContent;
        private System.Windows.Forms.TextBox txtMaker;
        private TextBox txtFileName;
        private TextBox txtMakeDate;
        private TextBox txtFanyiFunction;
        private TextBox txtEnContent;
        private TextBox txtTWContent;
        private TextBox txtCNContent;
        private Button button2;
        private Button button3;
    }
}