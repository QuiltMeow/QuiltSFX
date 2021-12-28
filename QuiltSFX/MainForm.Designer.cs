namespace QuiltSFX
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.lvFile = new System.Windows.Forms.ListView();
            this.ilFileIcon = new System.Windows.Forms.ImageList(this.components);
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAsProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tssFile = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreateUninstallConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExtra = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNoPack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCompileConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelpBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.labelStub = new System.Windows.Forms.Label();
            this.btnBrowseStub = new System.Windows.Forms.Button();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.chkUAC = new System.Windows.Forms.CheckBox();
            this.cbCompressionLevel = new System.Windows.Forms.ComboBox();
            this.labelCompressionLevel = new System.Windows.Forms.Label();
            this.btnCalculateFileSize = new System.Windows.Forms.Button();
            this.chkPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnBrowseIcon = new System.Windows.Forms.Button();
            this.txtIcon = new System.Windows.Forms.TextBox();
            this.labelIcon = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.gbFileOperation = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.ssStatus = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressNow = new System.Windows.Forms.ProgressBar();
            this.progressAll = new System.Windows.Forms.ProgressBar();
            this.gbProgress = new System.Windows.Forms.GroupBox();
            this.labelPassTime = new System.Windows.Forms.Label();
            this.labelProgressAll = new System.Windows.Forms.Label();
            this.labelProgressNow = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnCopyLog = new System.Windows.Forms.Button();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.timerPassTime = new System.Windows.Forms.Timer(this.components);
            this.msMenu.SuspendLayout();
            this.gbSetting.SuspendLayout();
            this.gbFileOperation.SuspendLayout();
            this.ssStatus.SuspendLayout();
            this.gbProgress.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(15, 35);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(137, 20);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "自解檔案打包工具";
            // 
            // lvFile
            // 
            this.lvFile.AllowDrop = true;
            this.lvFile.HideSelection = false;
            this.lvFile.LargeImageList = this.ilFileIcon;
            this.lvFile.Location = new System.Drawing.Point(30, 70);
            this.lvFile.Name = "lvFile";
            this.lvFile.Size = new System.Drawing.Size(500, 300);
            this.lvFile.TabIndex = 2;
            this.lvFile.UseCompatibleStateImageBehavior = false;
            this.lvFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFile_DragDrop);
            this.lvFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFile_DragEnter);
            // 
            // ilFileIcon
            // 
            this.ilFileIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilFileIcon.ImageSize = new System.Drawing.Size(32, 32);
            this.ilFileIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiTool,
            this.tsmiExtra,
            this.tsmiHelpBar});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(679, 24);
            this.msMenu.TabIndex = 0;
            this.msMenu.Text = "選單";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewProject,
            this.tsmiOpenProject,
            this.tsmiSaveProject,
            this.tsmiSaveAsProject,
            this.tssFile,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(43, 20);
            this.tsmiFile.Text = "檔案";
            // 
            // tsmiNewProject
            // 
            this.tsmiNewProject.Name = "tsmiNewProject";
            this.tsmiNewProject.Size = new System.Drawing.Size(180, 22);
            this.tsmiNewProject.Text = "開新專案";
            this.tsmiNewProject.Click += new System.EventHandler(this.tsmiNewProject_Click);
            // 
            // tsmiOpenProject
            // 
            this.tsmiOpenProject.Name = "tsmiOpenProject";
            this.tsmiOpenProject.Size = new System.Drawing.Size(180, 22);
            this.tsmiOpenProject.Text = "開啟專案";
            this.tsmiOpenProject.Click += new System.EventHandler(this.tsmiOpenProject_Click);
            // 
            // tsmiSaveProject
            // 
            this.tsmiSaveProject.Name = "tsmiSaveProject";
            this.tsmiSaveProject.Size = new System.Drawing.Size(180, 22);
            this.tsmiSaveProject.Text = "儲存專案";
            this.tsmiSaveProject.Click += new System.EventHandler(this.tsmiSaveProject_Click);
            // 
            // tsmiSaveAsProject
            // 
            this.tsmiSaveAsProject.Name = "tsmiSaveAsProject";
            this.tsmiSaveAsProject.Size = new System.Drawing.Size(180, 22);
            this.tsmiSaveAsProject.Text = "另存專案";
            this.tsmiSaveAsProject.Click += new System.EventHandler(this.tsmiSaveAsProject_Click);
            // 
            // tssFile
            // 
            this.tssFile.Name = "tssFile";
            this.tssFile.Size = new System.Drawing.Size(177, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(180, 22);
            this.tsmiExit.Text = "離開";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiTool
            // 
            this.tsmiTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVersion,
            this.tsmiCreateUninstallConfig,
            this.tsmiShowLog,
            this.tsmiOpenNotepad});
            this.tsmiTool.Name = "tsmiTool";
            this.tsmiTool.Size = new System.Drawing.Size(43, 20);
            this.tsmiTool.Text = "工具";
            // 
            // tsmiVersion
            // 
            this.tsmiVersion.Name = "tsmiVersion";
            this.tsmiVersion.Size = new System.Drawing.Size(254, 22);
            this.tsmiVersion.Text = "設定版本資訊";
            this.tsmiVersion.Click += new System.EventHandler(this.tsmiVersion_Click);
            // 
            // tsmiCreateUninstallConfig
            // 
            this.tsmiCreateUninstallConfig.Name = "tsmiCreateUninstallConfig";
            this.tsmiCreateUninstallConfig.Size = new System.Drawing.Size(254, 22);
            this.tsmiCreateUninstallConfig.Text = "將目前列表輸出解除安裝設定檔案";
            this.tsmiCreateUninstallConfig.Click += new System.EventHandler(this.tsmiCreateUninstallConfig_Click);
            // 
            // tsmiShowLog
            // 
            this.tsmiShowLog.Name = "tsmiShowLog";
            this.tsmiShowLog.Size = new System.Drawing.Size(254, 22);
            this.tsmiShowLog.Text = "顯示紀錄";
            this.tsmiShowLog.Click += new System.EventHandler(this.tsmiShowLog_Click);
            // 
            // tsmiOpenNotepad
            // 
            this.tsmiOpenNotepad.Name = "tsmiOpenNotepad";
            this.tsmiOpenNotepad.Size = new System.Drawing.Size(254, 22);
            this.tsmiOpenNotepad.Text = "開啟記事本";
            this.tsmiOpenNotepad.Click += new System.EventHandler(this.tsmiOpenNotepad_Click);
            // 
            // tsmiExtra
            // 
            this.tsmiExtra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNoPack,
            this.tsmiCompileConsole,
            this.tsmiShowPassword});
            this.tsmiExtra.Name = "tsmiExtra";
            this.tsmiExtra.Size = new System.Drawing.Size(43, 20);
            this.tsmiExtra.Text = "額外";
            // 
            // tsmiNoPack
            // 
            this.tsmiNoPack.CheckOnClick = true;
            this.tsmiNoPack.Name = "tsmiNoPack";
            this.tsmiNoPack.Size = new System.Drawing.Size(194, 22);
            this.tsmiNoPack.Text = "不對資料檔案進行封裝";
            // 
            // tsmiCompileConsole
            // 
            this.tsmiCompileConsole.Name = "tsmiCompileConsole";
            this.tsmiCompileConsole.Size = new System.Drawing.Size(194, 22);
            this.tsmiCompileConsole.Text = "編譯為主控台程式";
            this.tsmiCompileConsole.Click += new System.EventHandler(this.tsmiCompileConsole_Click);
            // 
            // tsmiShowPassword
            // 
            this.tsmiShowPassword.Name = "tsmiShowPassword";
            this.tsmiShowPassword.Size = new System.Drawing.Size(194, 22);
            this.tsmiShowPassword.Text = "顯示密碼";
            this.tsmiShowPassword.Click += new System.EventHandler(this.tsmiShowPassword_Click);
            // 
            // tsmiHelpBar
            // 
            this.tsmiHelpBar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiHelp,
            this.tsmiAbout});
            this.tsmiHelpBar.Name = "tsmiHelpBar";
            this.tsmiHelpBar.Size = new System.Drawing.Size(43, 20);
            this.tsmiHelpBar.Text = "說明";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(180, 22);
            this.tsmiHelp.Text = "說明";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(180, 22);
            this.tsmiAbout.Text = "關於";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Location = new System.Drawing.Point(255, 30);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(98, 12);
            this.labelFileSize.TabIndex = 2;
            this.labelFileSize.Text = "檔案大小 : 等待中";
            // 
            // labelStub
            // 
            this.labelStub.AutoSize = true;
            this.labelStub.Location = new System.Drawing.Point(30, 30);
            this.labelStub.Name = "labelStub";
            this.labelStub.Size = new System.Drawing.Size(107, 12);
            this.labelStub.TabIndex = 0;
            this.labelStub.Text = "Stub 程式組 : 0 檔案";
            // 
            // btnBrowseStub
            // 
            this.btnBrowseStub.Location = new System.Drawing.Point(165, 25);
            this.btnBrowseStub.Name = "btnBrowseStub";
            this.btnBrowseStub.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseStub.TabIndex = 1;
            this.btnBrowseStub.Text = "瀏覽";
            this.btnBrowseStub.UseVisualStyleBackColor = true;
            this.btnBrowseStub.Click += new System.EventHandler(this.btnBrowseStub_Click);
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.chkUAC);
            this.gbSetting.Controls.Add(this.cbCompressionLevel);
            this.gbSetting.Controls.Add(this.labelCompressionLevel);
            this.gbSetting.Controls.Add(this.btnCalculateFileSize);
            this.gbSetting.Controls.Add(this.chkPassword);
            this.gbSetting.Controls.Add(this.txtPassword);
            this.gbSetting.Controls.Add(this.btnBrowseIcon);
            this.gbSetting.Controls.Add(this.txtIcon);
            this.gbSetting.Controls.Add(this.labelIcon);
            this.gbSetting.Controls.Add(this.btnBrowseStub);
            this.gbSetting.Controls.Add(this.btnProcess);
            this.gbSetting.Controls.Add(this.labelFileSize);
            this.gbSetting.Controls.Add(this.labelStub);
            this.gbSetting.Location = new System.Drawing.Point(19, 385);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(641, 140);
            this.gbSetting.TabIndex = 4;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "打包設定";
            // 
            // chkUAC
            // 
            this.chkUAC.AutoSize = true;
            this.chkUAC.Location = new System.Drawing.Point(275, 100);
            this.chkUAC.Name = "chkUAC";
            this.chkUAC.Size = new System.Drawing.Size(72, 16);
            this.chkUAC.TabIndex = 9;
            this.chkUAC.Text = "要求權限";
            this.chkUAC.UseVisualStyleBackColor = true;
            // 
            // cbCompressionLevel
            // 
            this.cbCompressionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompressionLevel.FormattingEnabled = true;
            this.cbCompressionLevel.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbCompressionLevel.Location = new System.Drawing.Point(420, 98);
            this.cbCompressionLevel.Name = "cbCompressionLevel";
            this.cbCompressionLevel.Size = new System.Drawing.Size(75, 20);
            this.cbCompressionLevel.TabIndex = 11;
            // 
            // labelCompressionLevel
            // 
            this.labelCompressionLevel.AutoSize = true;
            this.labelCompressionLevel.Location = new System.Drawing.Point(357, 101);
            this.labelCompressionLevel.Name = "labelCompressionLevel";
            this.labelCompressionLevel.Size = new System.Drawing.Size(53, 12);
            this.labelCompressionLevel.TabIndex = 10;
            this.labelCompressionLevel.Text = "壓縮等級";
            // 
            // btnCalculateFileSize
            // 
            this.btnCalculateFileSize.Location = new System.Drawing.Point(420, 25);
            this.btnCalculateFileSize.Name = "btnCalculateFileSize";
            this.btnCalculateFileSize.Size = new System.Drawing.Size(75, 23);
            this.btnCalculateFileSize.TabIndex = 3;
            this.btnCalculateFileSize.Text = "計算";
            this.btnCalculateFileSize.UseVisualStyleBackColor = true;
            this.btnCalculateFileSize.Click += new System.EventHandler(this.btnCalculateFileSize_Click);
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new System.Drawing.Point(32, 100);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(72, 16);
            this.chkPassword.TabIndex = 7;
            this.chkPassword.Text = "密碼保護";
            this.chkPassword.UseVisualStyleBackColor = true;
            this.chkPassword.CheckedChanged += new System.EventHandler(this.chkPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(110, 98);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 22);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnBrowseIcon
            // 
            this.btnBrowseIcon.Location = new System.Drawing.Point(420, 60);
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseIcon.TabIndex = 6;
            this.btnBrowseIcon.Text = "瀏覽";
            this.btnBrowseIcon.UseVisualStyleBackColor = true;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // txtIcon
            // 
            this.txtIcon.BackColor = System.Drawing.Color.White;
            this.txtIcon.Location = new System.Drawing.Point(110, 62);
            this.txtIcon.Name = "txtIcon";
            this.txtIcon.ReadOnly = true;
            this.txtIcon.Size = new System.Drawing.Size(300, 22);
            this.txtIcon.TabIndex = 5;
            // 
            // labelIcon
            // 
            this.labelIcon.AutoSize = true;
            this.labelIcon.Location = new System.Drawing.Point(30, 65);
            this.labelIcon.Name = "labelIcon";
            this.labelIcon.Size = new System.Drawing.Size(53, 12);
            this.labelIcon.TabIndex = 4;
            this.labelIcon.Text = "程式圖標";
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.White;
            this.btnProcess.Image = global::QuiltSFX.Properties.Resources.Execute;
            this.btnProcess.Location = new System.Drawing.Point(546, 40);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 60);
            this.btnProcess.TabIndex = 12;
            this.btnProcess.Text = "開始處理";
            this.btnProcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // gbFileOperation
            // 
            this.gbFileOperation.Controls.Add(this.btnClear);
            this.gbFileOperation.Controls.Add(this.btnAddFile);
            this.gbFileOperation.Controls.Add(this.btnAddFolder);
            this.gbFileOperation.Controls.Add(this.btnRemove);
            this.gbFileOperation.Location = new System.Drawing.Point(545, 70);
            this.gbFileOperation.Name = "gbFileOperation";
            this.gbFileOperation.Size = new System.Drawing.Size(115, 300);
            this.gbFileOperation.TabIndex = 3;
            this.gbFileOperation.TabStop = false;
            this.gbFileOperation.Text = "檔案操作";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.White;
            this.btnClear.Image = global::QuiltSFX.Properties.Resources.Clear;
            this.btnClear.Location = new System.Drawing.Point(20, 223);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 60);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "全部清除";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.Color.White;
            this.btnAddFile.Image = global::QuiltSFX.Properties.Resources.File;
            this.btnAddFile.Location = new System.Drawing.Point(20, 25);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(75, 60);
            this.btnAddFile.TabIndex = 0;
            this.btnAddFile.Text = "加入檔案";
            this.btnAddFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddFile.UseVisualStyleBackColor = false;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.BackColor = System.Drawing.Color.White;
            this.btnAddFolder.Image = global::QuiltSFX.Properties.Resources.Folder;
            this.btnAddFolder.Location = new System.Drawing.Point(20, 91);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 60);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "加入資料夾";
            this.btnAddFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddFolder.UseVisualStyleBackColor = false;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.Image = global::QuiltSFX.Properties.Resources.Delete;
            this.btnRemove.Location = new System.Drawing.Point(20, 157);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 60);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "移除項目";
            this.btnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ssStatus
            // 
            this.ssStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.ssStatus.Location = new System.Drawing.Point(0, 654);
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Size = new System.Drawing.Size(679, 22);
            this.ssStatus.SizingGrip = false;
            this.ssStatus.TabIndex = 7;
            this.ssStatus.Text = "狀態列";
            // 
            // tsslStatus
            // 
            this.tsslStatus.BackColor = System.Drawing.SystemColors.Control;
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(31, 17);
            this.tsslStatus.Text = "就緒";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(30, 30);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(53, 12);
            this.labelProgress.TabIndex = 0;
            this.labelProgress.Text = "等待中 ...";
            // 
            // progressNow
            // 
            this.progressNow.Location = new System.Drawing.Point(70, 55);
            this.progressNow.Name = "progressNow";
            this.progressNow.Size = new System.Drawing.Size(200, 23);
            this.progressNow.TabIndex = 3;
            // 
            // progressAll
            // 
            this.progressAll.Location = new System.Drawing.Point(420, 55);
            this.progressAll.Name = "progressAll";
            this.progressAll.Size = new System.Drawing.Size(200, 23);
            this.progressAll.TabIndex = 5;
            // 
            // gbProgress
            // 
            this.gbProgress.Controls.Add(this.labelPassTime);
            this.gbProgress.Controls.Add(this.labelProgressAll);
            this.gbProgress.Controls.Add(this.labelProgressNow);
            this.gbProgress.Controls.Add(this.labelProgress);
            this.gbProgress.Controls.Add(this.progressAll);
            this.gbProgress.Controls.Add(this.progressNow);
            this.gbProgress.Location = new System.Drawing.Point(19, 540);
            this.gbProgress.Name = "gbProgress";
            this.gbProgress.Size = new System.Drawing.Size(641, 100);
            this.gbProgress.TabIndex = 5;
            this.gbProgress.TabStop = false;
            this.gbProgress.Text = "封裝進度";
            // 
            // labelPassTime
            // 
            this.labelPassTime.AutoSize = true;
            this.labelPassTime.Location = new System.Drawing.Point(380, 30);
            this.labelPassTime.Name = "labelPassTime";
            this.labelPassTime.Size = new System.Drawing.Size(110, 12);
            this.labelPassTime.TabIndex = 1;
            this.labelPassTime.Text = "經過時間 00 : 00 : 00";
            // 
            // labelProgressAll
            // 
            this.labelProgressAll.AutoSize = true;
            this.labelProgressAll.Location = new System.Drawing.Point(380, 60);
            this.labelProgressAll.Name = "labelProgressAll";
            this.labelProgressAll.Size = new System.Drawing.Size(29, 12);
            this.labelProgressAll.TabIndex = 4;
            this.labelProgressAll.Text = "整體";
            // 
            // labelProgressNow
            // 
            this.labelProgressNow.AutoSize = true;
            this.labelProgressNow.Location = new System.Drawing.Point(30, 60);
            this.labelProgressNow.Name = "labelProgressNow";
            this.labelProgressNow.Size = new System.Drawing.Size(29, 12);
            this.labelProgressNow.TabIndex = 2;
            this.labelProgressNow.Text = "目前";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(25, 25);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(290, 535);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(205, 570);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "清除";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnCopyLog
            // 
            this.btnCopyLog.Location = new System.Drawing.Point(55, 570);
            this.btnCopyLog.Name = "btnCopyLog";
            this.btnCopyLog.Size = new System.Drawing.Size(75, 23);
            this.btnCopyLog.TabIndex = 1;
            this.btnCopyLog.Text = "複製";
            this.btnCopyLog.UseVisualStyleBackColor = true;
            this.btnCopyLog.Click += new System.EventHandler(this.btnCopyLog_Click);
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.txtLog);
            this.gbLog.Controls.Add(this.btnClearLog);
            this.gbLog.Controls.Add(this.btnCopyLog);
            this.gbLog.Location = new System.Drawing.Point(685, 35);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(340, 605);
            this.gbLog.TabIndex = 6;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "紀錄";
            // 
            // timerPassTime
            // 
            this.timerPassTime.Interval = 1000;
            this.timerPassTime.Tick += new System.EventHandler(this.timerPassTime_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(679, 676);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbProgress);
            this.Controls.Add(this.ssStatus);
            this.Controls.Add(this.gbFileOperation);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.lvFile);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.msMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "自解檔案打包工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            this.gbFileOperation.ResumeLayout(false);
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            this.gbProgress.ResumeLayout(false);
            this.gbProgress.PerformLayout();
            this.gbLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListView lvFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelpBar;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Label labelStub;
        private System.Windows.Forms.Button btnBrowseStub;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.GroupBox gbFileOperation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.StatusStrip ssStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressNow;
        private System.Windows.Forms.ProgressBar progressAll;
        private System.Windows.Forms.GroupBox gbProgress;
        private System.Windows.Forms.Label labelProgressAll;
        private System.Windows.Forms.Label labelProgressNow;
        private System.Windows.Forms.Button btnBrowseIcon;
        private System.Windows.Forms.TextBox txtIcon;
        private System.Windows.Forms.Label labelIcon;
        private System.Windows.Forms.ImageList ilFileIcon;
        private System.Windows.Forms.CheckBox chkPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCalculateFileSize;
        private System.Windows.Forms.ComboBox cbCompressionLevel;
        private System.Windows.Forms.Label labelCompressionLevel;
        private System.Windows.Forms.CheckBox chkUAC;
        private System.Windows.Forms.ToolStripMenuItem tsmiTool;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreateUninstallConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnCopyLog;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiVersion;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtra;
        private System.Windows.Forms.ToolStripMenuItem tsmiNoPack;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiCompileConsole;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveProject;
        private System.Windows.Forms.ToolStripSeparator tssFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenNotepad;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAsProject;
        private System.Windows.Forms.Timer timerPassTime;
        private System.Windows.Forms.Label labelPassTime;
    }
}