namespace Client
{
    partial class NASClient
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NASClient));
            this.statusListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.uploadButton = new System.Windows.Forms.Button();
            this.statusButton = new System.Windows.Forms.Button();
            this.filelistButton = new System.Windows.Forms.Button();
            this.filelistPanel = new System.Windows.Forms.Panel();
            this.deleteButton = new MetroFramework.Controls.MetroButton();
            this.refreshButton = new MetroFramework.Controls.MetroButton();
            this.fileListview = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusPanel = new System.Windows.Forms.Panel();
            this.reDownloadButton = new MetroFramework.Controls.MetroButton();
            this.panel1.SuspendLayout();
            this.filelistPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusListview
            // 
            this.statusListview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.statusListview.HideSelection = false;
            this.statusListview.Location = new System.Drawing.Point(3, 36);
            this.statusListview.Name = "statusListview";
            this.statusListview.Size = new System.Drawing.Size(800, 584);
            this.statusListview.TabIndex = 0;
            this.statusListview.UseCompatibleStateImageBehavior = false;
            this.statusListview.View = System.Windows.Forms.View.Details;
            this.statusListview.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.statusListview_ColumwChanging);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "파일 이름";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "파일 크기";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "진행 상황";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "상태";
            this.columnHeader4.Width = 150;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.uploadButton);
            this.panel1.Controls.Add(this.statusButton);
            this.panel1.Controls.Add(this.filelistButton);
            this.panel1.Location = new System.Drawing.Point(14, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 590);
            this.panel1.TabIndex = 2;
            // 
            // uploadButton
            // 
            this.uploadButton.BackColor = System.Drawing.Color.SlateGray;
            this.uploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadButton.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uploadButton.ForeColor = System.Drawing.Color.White;
            this.uploadButton.Location = new System.Drawing.Point(0, 352);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(152, 114);
            this.uploadButton.TabIndex = 2;
            this.uploadButton.Text = "업로드";
            this.uploadButton.UseVisualStyleBackColor = false;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // statusButton
            // 
            this.statusButton.BackColor = System.Drawing.Color.SlateGray;
            this.statusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusButton.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.statusButton.ForeColor = System.Drawing.Color.White;
            this.statusButton.Location = new System.Drawing.Point(0, 232);
            this.statusButton.Name = "statusButton";
            this.statusButton.Size = new System.Drawing.Size(152, 114);
            this.statusButton.TabIndex = 1;
            this.statusButton.Text = "전송 상황";
            this.statusButton.UseVisualStyleBackColor = false;
            this.statusButton.Click += new System.EventHandler(this.statusButton_Click);
            // 
            // filelistButton
            // 
            this.filelistButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.filelistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filelistButton.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.filelistButton.ForeColor = System.Drawing.Color.White;
            this.filelistButton.Location = new System.Drawing.Point(0, 112);
            this.filelistButton.Name = "filelistButton";
            this.filelistButton.Size = new System.Drawing.Size(152, 114);
            this.filelistButton.TabIndex = 0;
            this.filelistButton.Text = "파일 목록";
            this.filelistButton.UseVisualStyleBackColor = false;
            this.filelistButton.Click += new System.EventHandler(this.filelistButton_Click);
            // 
            // filelistPanel
            // 
            this.filelistPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filelistPanel.Controls.Add(this.deleteButton);
            this.filelistPanel.Controls.Add(this.refreshButton);
            this.filelistPanel.Controls.Add(this.fileListview);
            this.filelistPanel.Location = new System.Drawing.Point(170, 40);
            this.filelistPanel.Name = "filelistPanel";
            this.filelistPanel.Size = new System.Drawing.Size(820, 623);
            this.filelistPanel.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(601, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(98, 30);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "파일 삭제";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(705, 0);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(98, 30);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "새로고침";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // fileListview
            // 
            this.fileListview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileListview.BackgroundImageTiled = true;
            this.fileListview.HideSelection = false;
            this.fileListview.LargeImageList = this.imageList1;
            this.fileListview.Location = new System.Drawing.Point(3, 33);
            this.fileListview.Name = "fileListview";
            this.fileListview.Size = new System.Drawing.Size(800, 587);
            this.fileListview.TabIndex = 1;
            this.fileListview.UseCompatibleStateImageBehavior = false;
            this.fileListview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileLIstview_MouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon.png");
            // 
            // statusPanel
            // 
            this.statusPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusPanel.Controls.Add(this.reDownloadButton);
            this.statusPanel.Controls.Add(this.statusListview);
            this.statusPanel.Location = new System.Drawing.Point(170, 40);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(820, 623);
            this.statusPanel.TabIndex = 4;
            // 
            // reDownloadButton
            // 
            this.reDownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reDownloadButton.Location = new System.Drawing.Point(705, 3);
            this.reDownloadButton.Name = "reDownloadButton";
            this.reDownloadButton.Size = new System.Drawing.Size(98, 30);
            this.reDownloadButton.TabIndex = 1;
            this.reDownloadButton.Text = "다시 다운로드";
            this.reDownloadButton.Click += new System.EventHandler(this.reDownloadButton_Click);
            // 
            // NASClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 672);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.filelistPanel);
            this.Controls.Add(this.panel1);
            this.Name = "NASClient";
            this.Text = "NASClone";
            this.Shown += new System.EventHandler(this.Form_Shown);
            this.panel1.ResumeLayout(false);
            this.filelistPanel.ResumeLayout(false);
            this.statusPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView statusListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button filelistButton;
        private System.Windows.Forms.Button statusButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Panel filelistPanel;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.ListView fileListview;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private MetroFramework.Controls.MetroButton reDownloadButton;
        private MetroFramework.Controls.MetroButton refreshButton;
        private MetroFramework.Controls.MetroButton deleteButton;
    }
}

