namespace QuiltSFXSimpleStub
{
    partial class SimpleStub
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
            this.labelPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressAll = new System.Windows.Forms.ProgressBar();
            this.progressNow = new System.Windows.Forms.ProgressBar();
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.labelNow = new System.Windows.Forms.Label();
            this.labelAll = new System.Windows.Forms.Label();
            this.btnBrowsePath = new System.Windows.Forms.Button();
            this.wbContent = new System.Windows.Forms.WebBrowser();
            this.txtInstall = new System.Windows.Forms.RichTextBox();
            this.btnDefaultPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(35, 338);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(53, 12);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "安裝目錄";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.White;
            this.txtPath.Location = new System.Drawing.Point(125, 335);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(290, 22);
            this.txtPath.TabIndex = 3;
            // 
            // btnInstall
            // 
            this.btnInstall.Location = new System.Drawing.Point(335, 450);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(100, 23);
            this.btnInstall.TabIndex = 10;
            this.btnInstall.Text = "安裝";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(485, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "離開";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progressAll
            // 
            this.progressAll.Location = new System.Drawing.Point(125, 405);
            this.progressAll.Name = "progressAll";
            this.progressAll.Size = new System.Drawing.Size(460, 23);
            this.progressAll.TabIndex = 9;
            // 
            // progressNow
            // 
            this.progressNow.Location = new System.Drawing.Point(125, 370);
            this.progressNow.Name = "progressNow";
            this.progressNow.Size = new System.Drawing.Size(460, 23);
            this.progressNow.TabIndex = 7;
            // 
            // pbBanner
            // 
            this.pbBanner.Location = new System.Drawing.Point(15, 15);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(93, 302);
            this.pbBanner.TabIndex = 8;
            this.pbBanner.TabStop = false;
            // 
            // labelNow
            // 
            this.labelNow.AutoSize = true;
            this.labelNow.Location = new System.Drawing.Point(35, 375);
            this.labelNow.Name = "labelNow";
            this.labelNow.Size = new System.Drawing.Size(29, 12);
            this.labelNow.TabIndex = 6;
            this.labelNow.Text = "目前";
            // 
            // labelAll
            // 
            this.labelAll.AutoSize = true;
            this.labelAll.Location = new System.Drawing.Point(35, 410);
            this.labelAll.Name = "labelAll";
            this.labelAll.Size = new System.Drawing.Size(29, 12);
            this.labelAll.TabIndex = 8;
            this.labelAll.Text = "整體";
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Location = new System.Drawing.Point(510, 333);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePath.TabIndex = 5;
            this.btnBrowsePath.Text = "瀏覽";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // wbContent
            // 
            this.wbContent.AllowWebBrowserDrop = false;
            this.wbContent.IsWebBrowserContextMenuEnabled = false;
            this.wbContent.Location = new System.Drawing.Point(125, 15);
            this.wbContent.Name = "wbContent";
            this.wbContent.ScrollBarsEnabled = false;
            this.wbContent.Size = new System.Drawing.Size(460, 302);
            this.wbContent.TabIndex = 0;
            this.wbContent.WebBrowserShortcutsEnabled = false;
            // 
            // txtInstall
            // 
            this.txtInstall.BackColor = System.Drawing.Color.White;
            this.txtInstall.Location = new System.Drawing.Point(125, 15);
            this.txtInstall.Name = "txtInstall";
            this.txtInstall.ReadOnly = true;
            this.txtInstall.Size = new System.Drawing.Size(460, 302);
            this.txtInstall.TabIndex = 1;
            this.txtInstall.Text = "";
            this.txtInstall.Visible = false;
            // 
            // btnDefaultPath
            // 
            this.btnDefaultPath.Location = new System.Drawing.Point(425, 333);
            this.btnDefaultPath.Name = "btnDefaultPath";
            this.btnDefaultPath.Size = new System.Drawing.Size(75, 23);
            this.btnDefaultPath.TabIndex = 4;
            this.btnDefaultPath.Text = "預設";
            this.btnDefaultPath.UseVisualStyleBackColor = true;
            this.btnDefaultPath.Click += new System.EventHandler(this.btnDefaultPath_Click);
            // 
            // SimpleStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(604, 491);
            this.Controls.Add(this.btnDefaultPath);
            this.Controls.Add(this.wbContent);
            this.Controls.Add(this.btnBrowsePath);
            this.Controls.Add(this.labelAll);
            this.Controls.Add(this.labelNow);
            this.Controls.Add(this.pbBanner);
            this.Controls.Add(this.progressNow);
            this.Controls.Add(this.progressAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.txtInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "SimpleStub";
            this.Text = "Simple Stub";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimpleStub_FormClosing);
            this.Load += new System.EventHandler(this.SimpleStub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressAll;
        private System.Windows.Forms.ProgressBar progressNow;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.Label labelNow;
        private System.Windows.Forms.Label labelAll;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.WebBrowser wbContent;
        private System.Windows.Forms.RichTextBox txtInstall;
        private System.Windows.Forms.Button btnDefaultPath;
    }
}