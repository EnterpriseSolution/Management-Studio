using System.Windows.Forms;
namespace ManagementStudio
{
    partial class LookupGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLookupID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLookupName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.codeEditorControl1 = new System.Windows.Forms.RichTextBox();
            this.RdbChange = new System.Windows.Forms.RadioButton();
            this.rdbAdd = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID:";
            // 
            // txtLookupID
            // 
            this.txtLookupID.BackColor = System.Drawing.SystemColors.Window;
            this.txtLookupID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLookupID.Location = new System.Drawing.Point(52, 15);
            this.txtLookupID.Name = "txtLookupID";
            this.txtLookupID.Size = new System.Drawing.Size(227, 21);
            this.txtLookupID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lookup Name:";
            // 
            // txtLookupName
            // 
            this.txtLookupName.Location = new System.Drawing.Point(362, 15);
            this.txtLookupName.Name = "txtLookupName";
            this.txtLookupName.Size = new System.Drawing.Size(257, 21);
            this.txtLookupName.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "生  成";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(442, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "执行";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(527, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "拷贝到剪贴板";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(362, 44);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(257, 21);
            this.txtDescription.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "标  题 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "实体名";
            // 
            // txtEntityName
            // 
            this.txtEntityName.Location = new System.Drawing.Point(52, 44);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(227, 21);
            this.txtEntityName.TabIndex = 0;
            // 
            // codeEditorControl1
            // 
            this.codeEditorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.codeEditorControl1.Location = new System.Drawing.Point(8, 118);
            this.codeEditorControl1.Name = "codeEditorControl1";
            this.codeEditorControl1.Size = new System.Drawing.Size(932, 295);
            this.codeEditorControl1.TabIndex = 8;
            this.codeEditorControl1.Text = "";
            // 
            // RdbChange
            // 
            this.RdbChange.AutoSize = true;
            this.RdbChange.Checked = true;
            this.RdbChange.Location = new System.Drawing.Point(113, 83);
            this.RdbChange.Name = "RdbChange";
            this.RdbChange.Size = new System.Drawing.Size(47, 16);
            this.RdbChange.TabIndex = 0;
            this.RdbChange.TabStop = true;
            this.RdbChange.Text = "修改";
            this.RdbChange.UseVisualStyleBackColor = true;
            // 
            // rdbAdd
            // 
            this.rdbAdd.AutoSize = true;
            this.rdbAdd.Location = new System.Drawing.Point(59, 81);
            this.rdbAdd.Name = "rdbAdd";
            this.rdbAdd.Size = new System.Drawing.Size(47, 16);
            this.rdbAdd.TabIndex = 0;
            this.rdbAdd.TabStop = true;
            this.rdbAdd.Text = "新增";
            this.rdbAdd.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "动作 :";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(267, 82);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(635, 82);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(92, 23);
            this.btnTransfer.TabIndex = 12;
            this.btnTransfer.Text = "代码转换";
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // LookupSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 424);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.RdbChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdbAdd);
            this.Controls.Add(this.codeEditorControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtLookupName);
            this.Controls.Add(this.txtEntityName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLookupID);
            this.Controls.Add(this.label1);
            this.Name = "LookupSql";
            this.Text = "查询生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TextBox txtLookupID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLookupName;
        private Button button1;
        private Button button2;
        private Button button3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEntityName;
        private RichTextBox codeEditorControl1;
        private System.Windows.Forms.RadioButton RdbChange;
        private System.Windows.Forms.RadioButton rdbAdd;
        private Label label5;
        private Button btnPreview;
        private Button btnTransfer;
    }
}