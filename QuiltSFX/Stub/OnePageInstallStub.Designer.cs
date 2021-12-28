namespace QuiltSFXPackage
{
    partial class OnePageInstallStub
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMainTitle = new System.Windows.Forms.Label();
            this.labelLicenseTip = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.llLicense = new System.Windows.Forms.LinkLabel();
            this.btnBrowsePath = new System.Windows.Forms.Button();
            this.btnDefaultPath = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.panelInstall = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.progressAll = new System.Windows.Forms.ProgressBar();
            this.progressNow = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelInstallTitle = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panelFinish = new System.Windows.Forms.Panel();
            this.labelFinishTip = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.labelFinishTitle = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.labelClose = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelInstall.SuspendLayout();
            this.panelFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(90, 35);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(53, 12);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "應用程式";
            // 
            // labelMainTitle
            // 
            this.labelMainTitle.AutoSize = true;
            this.labelMainTitle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelMainTitle.Location = new System.Drawing.Point(225, 30);
            this.labelMainTitle.Name = "labelMainTitle";
            this.labelMainTitle.Size = new System.Drawing.Size(199, 27);
            this.labelMainTitle.TabIndex = 0;
            this.labelMainTitle.Text = "{應用程式} 安裝程式";
            // 
            // labelLicenseTip
            // 
            this.labelLicenseTip.AutoSize = true;
            this.labelLicenseTip.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelLicenseTip.Location = new System.Drawing.Point(175, 70);
            this.labelLicenseTip.Name = "labelLicenseTip";
            this.labelLicenseTip.Size = new System.Drawing.Size(320, 17);
            this.labelLicenseTip.TabIndex = 1;
            this.labelLicenseTip.Text = "安裝本產品及代表您同意我們的授權合約與隱私權政策";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(65, 155);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(41, 12);
            this.labelPath.TabIndex = 3;
            this.labelPath.Text = "安裝至";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(130, 152);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(300, 22);
            this.txtPath.TabIndex = 4;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(255, 285);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(150, 55);
            this.btnInstall.TabIndex = 9;
            this.btnInstall.Text = "一鍵安裝";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.llLicense);
            this.panelMain.Controls.Add(this.btnBrowsePath);
            this.panelMain.Controls.Add(this.btnDefaultPath);
            this.panelMain.Controls.Add(this.txtPassword);
            this.panelMain.Controls.Add(this.labelPassword);
            this.panelMain.Controls.Add(this.labelMainTitle);
            this.panelMain.Controls.Add(this.labelLicenseTip);
            this.panelMain.Controls.Add(this.btnInstall);
            this.panelMain.Controls.Add(this.labelPath);
            this.panelMain.Controls.Add(this.txtPath);
            this.panelMain.Location = new System.Drawing.Point(30, 100);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(680, 410);
            this.panelMain.TabIndex = 2;
            // 
            // llLicense
            // 
            this.llLicense.AutoSize = true;
            this.llLicense.Location = new System.Drawing.Point(290, 95);
            this.llLicense.Name = "llLicense";
            this.llLicense.Size = new System.Drawing.Size(77, 12);
            this.llLicense.TabIndex = 2;
            this.llLicense.TabStop = true;
            this.llLicense.Text = "檢視授權合約";
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Location = new System.Drawing.Point(540, 150);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePath.TabIndex = 6;
            this.btnBrowsePath.Text = "更改路徑";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // btnDefaultPath
            // 
            this.btnDefaultPath.Location = new System.Drawing.Point(450, 150);
            this.btnDefaultPath.Name = "btnDefaultPath";
            this.btnDefaultPath.Size = new System.Drawing.Size(75, 23);
            this.btnDefaultPath.TabIndex = 5;
            this.btnDefaultPath.Text = "預設路徑";
            this.btnDefaultPath.UseVisualStyleBackColor = true;
            this.btnDefaultPath.Click += new System.EventHandler(this.btnDefaultPath_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(130, 197);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 22);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Visible = false;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(65, 200);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 12);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "安裝密碼";
            this.labelPassword.Visible = false;
            // 
            // panelInstall
            // 
            this.panelInstall.Controls.Add(this.btnDetail);
            this.panelInstall.Controls.Add(this.progressAll);
            this.panelInstall.Controls.Add(this.progressNow);
            this.panelInstall.Controls.Add(this.labelProgress);
            this.panelInstall.Controls.Add(this.labelInstallTitle);
            this.panelInstall.Controls.Add(this.txtLog);
            this.panelInstall.Location = new System.Drawing.Point(30, 100);
            this.panelInstall.Name = "panelInstall";
            this.panelInstall.Size = new System.Drawing.Size(680, 410);
            this.panelInstall.TabIndex = 3;
            this.panelInstall.Visible = false;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(255, 285);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(150, 55);
            this.btnDetail.TabIndex = 4;
            this.btnDetail.Text = "顯示詳細資料";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // progressAll
            // 
            this.progressAll.Location = new System.Drawing.Point(118, 155);
            this.progressAll.Name = "progressAll";
            this.progressAll.Size = new System.Drawing.Size(450, 15);
            this.progressAll.TabIndex = 3;
            // 
            // progressNow
            // 
            this.progressNow.Location = new System.Drawing.Point(118, 125);
            this.progressNow.Name = "progressNow";
            this.progressNow.Size = new System.Drawing.Size(450, 15);
            this.progressNow.TabIndex = 2;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelProgress.Location = new System.Drawing.Point(115, 90);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(34, 17);
            this.labelProgress.TabIndex = 1;
            this.labelProgress.Text = "進度";
            // 
            // labelInstallTitle
            // 
            this.labelInstallTitle.AutoSize = true;
            this.labelInstallTitle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelInstallTitle.Location = new System.Drawing.Point(225, 30);
            this.labelInstallTitle.Name = "labelInstallTitle";
            this.labelInstallTitle.Size = new System.Drawing.Size(199, 27);
            this.labelInstallTitle.TabIndex = 0;
            this.labelInstallTitle.Text = "{應用程式} 安裝程式";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(118, 200);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(450, 185);
            this.txtLog.TabIndex = 5;
            this.txtLog.Visible = false;
            // 
            // panelFinish
            // 
            this.panelFinish.Controls.Add(this.labelFinishTip);
            this.panelFinish.Controls.Add(this.btnFinish);
            this.panelFinish.Controls.Add(this.labelFinishTitle);
            this.panelFinish.Location = new System.Drawing.Point(30, 100);
            this.panelFinish.Name = "panelFinish";
            this.panelFinish.Size = new System.Drawing.Size(680, 410);
            this.panelFinish.TabIndex = 4;
            this.panelFinish.Visible = false;
            // 
            // labelFinishTip
            // 
            this.labelFinishTip.AutoSize = true;
            this.labelFinishTip.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelFinishTip.Location = new System.Drawing.Point(235, 180);
            this.labelFinishTip.Name = "labelFinishTip";
            this.labelFinishTip.Size = new System.Drawing.Size(214, 17);
            this.labelFinishTip.TabIndex = 1;
            this.labelFinishTip.Text = "{應用程式} 已經成功安裝在您的電腦";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(255, 285);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(150, 55);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // labelFinishTitle
            // 
            this.labelFinishTitle.AutoSize = true;
            this.labelFinishTitle.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelFinishTitle.Location = new System.Drawing.Point(210, 130);
            this.labelFinishTitle.Name = "labelFinishTitle";
            this.labelFinishTitle.Size = new System.Drawing.Size(262, 27);
            this.labelFinishTitle.TabIndex = 0;
            this.labelFinishTitle.Text = "{應用程式} 安裝程式已完成";
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(30, 15);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(48, 48);
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // labelClose
            // 
            this.labelClose.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelClose.ForeColor = System.Drawing.Color.DarkGray;
            this.labelClose.Location = new System.Drawing.Point(700, 20);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(25, 30);
            this.labelClose.TabIndex = 1;
            this.labelClose.Text = "×";
            this.labelClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            this.labelClose.MouseEnter += new System.EventHandler(this.labelClose_MouseEnter);
            this.labelClose.MouseLeave += new System.EventHandler(this.labelClose_MouseLeave);
            // 
            // OnePageInstallStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(740, 540);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelInstall);
            this.Controls.Add(this.panelFinish);
            this.Controls.Add(this.labelClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "OnePageInstallStub";
            this.Text = "OnePageInstallStub";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelInstall.ResumeLayout(false);
            this.panelInstall.PerformLayout();
            this.panelFinish.ResumeLayout(false);
            this.panelFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMainTitle;
        private System.Windows.Forms.Label labelLicenseTip;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelInstall;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressAll;
        private System.Windows.Forms.ProgressBar progressNow;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelInstallTitle;
        private System.Windows.Forms.Panel panelFinish;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label labelFinishTitle;
        private System.Windows.Forms.Label labelFinishTip;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.LinkLabel llLicense;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.Button btnDefaultPath;
        private System.Windows.Forms.Button btnDetail;
    }
}