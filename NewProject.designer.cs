namespace ManagementStudio
{
    partial class NewProject
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Id", 7);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Url", 8);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Text", 9);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Help File", 23);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("DataSet Reader", 17);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Translation", 32);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Music", 25);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Flash", 29);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Image", 30);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Database Builder", 15);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Script Editor", "Script.bmp");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProject));
            this.lstTask = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTask
            // 
            this.lstTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            listViewItem1.Tag = "Id";
            listViewItem2.Tag = "Url";
            listViewItem3.Tag = "Text";
            listViewItem4.Tag = "Default";
            listViewItem5.Tag = "DataSetReader";
            listViewItem6.Tag = "Translation";
            listViewItem11.Tag = "ScriptEditor";
            this.lstTask.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11});
            this.lstTask.LargeImageList = this.imageList1;
            this.lstTask.Location = new System.Drawing.Point(3, 4);
            this.lstTask.Margin = new System.Windows.Forms.Padding(4);
            this.lstTask.Name = "lstTask";
            this.lstTask.Size = new System.Drawing.Size(638, 329);
            this.lstTask.SmallImageList = this.imageList1;
            this.lstTask.TabIndex = 1;
            this.lstTask.UseCompatibleStateImageBehavior = false;
            this.lstTask.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstTask_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SQL.ico");
            this.imageList1.Images.SetKeyName(1, "C.ico");
            this.imageList1.Images.SetKeyName(2, "Form.ico");
            this.imageList1.Images.SetKeyName(3, "Studio.ico");
            this.imageList1.Images.SetKeyName(4, "Form.ico");
            this.imageList1.Images.SetKeyName(5, "PROC.ico");
            this.imageList1.Images.SetKeyName(6, "Report.ico");
            this.imageList1.Images.SetKeyName(7, "Id.bmp");
            this.imageList1.Images.SetKeyName(8, "Text.bmp");
            this.imageList1.Images.SetKeyName(9, "Url.bmp");
            this.imageList1.Images.SetKeyName(10, "Trans.bmp");
            this.imageList1.Images.SetKeyName(11, "function_lang_setup_32.png");
            this.imageList1.Images.SetKeyName(12, "3_3.bmp");
            this.imageList1.Images.SetKeyName(13, "Report.ico");
            this.imageList1.Images.SetKeyName(14, "Lic.bmp");
            this.imageList1.Images.SetKeyName(15, "29022_3.bmp");
            this.imageList1.Images.SetKeyName(16, "CompanyRegistry.png");
            this.imageList1.Images.SetKeyName(17, "Access.ico");
            this.imageList1.Images.SetKeyName(18, "Download.ico");
            this.imageList1.Images.SetKeyName(19, "Fireware.ico");
            this.imageList1.Images.SetKeyName(20, "Windows.ico");
            this.imageList1.Images.SetKeyName(21, "book.bmp");
            this.imageList1.Images.SetKeyName(22, "149_6.bmp");
            this.imageList1.Images.SetKeyName(23, "chm.gif");
            this.imageList1.Images.SetKeyName(24, "exe.gif");
            this.imageList1.Images.SetKeyName(25, "music.gif");
            this.imageList1.Images.SetKeyName(26, "pdf.gif");
            this.imageList1.Images.SetKeyName(27, "rar.gif");
            this.imageList1.Images.SetKeyName(28, "Image.bmp");
            this.imageList1.Images.SetKeyName(29, "Flash.bmp");
            this.imageList1.Images.SetKeyName(30, "Picture.bmp");
            this.imageList1.Images.SetKeyName(31, "Script.bmp");
            this.imageList1.Images.SetKeyName(32, "LangSetup_32.png");
            this.imageList1.Images.SetKeyName(33, "Microsoft.VisualStudio.QualityTools.Tips.TuipPackageUI.dll_I013c_0409.ico");
            this.imageList1.Images.SetKeyName(34, "QueryDesigner.ico");
            this.imageList1.Images.SetKeyName(35, "Lookup.ico");
            this.imageList1.Images.SetKeyName(36, "Report.ico");
            this.imageList1.Images.SetKeyName(37, "QueryLookup.ico");
            this.imageList1.Images.SetKeyName(38, "DatabaseUpdate.ico");
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(476, 343);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(557, 341);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // NewProject
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(644, 377);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstTask);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task List";
            this.Load += new System.EventHandler(this.NewProject_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstTask;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}