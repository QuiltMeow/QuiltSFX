using Ionic.Zip;
using Ionic.Zlib;
using QuiltSFX.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace QuiltSFX
{
    public partial class MainForm : Form
    {
        private const int ERROR_RESULT = -1;
        private const long MAX_PACKAGE_SIZE_MB = 4000;
        private const long MAX_PACKAGE_SIZE_BYTE = MAX_PACKAGE_SIZE_MB * 1000 * 1000;

        private const string OUTPUT_LIBRARY_LIST_FILE_NAME = "Library.ew";
        private const string OUTPUT_ZIP_FILE_NAME = "Data.ew";

        private bool shouldDeleteDataFile;
        private Version version;
        private readonly SFXMaker sfx;
        private readonly IList<string> fileList;

        private string[] stubFile;
        private Exception error;

        public MainForm()
        {
            InitializeComponent();
            lvFile.ListViewItemSorter = new ListViewFileComparer();

            initToolTip();
            resetFileIcon();
            setDefaultCompressionLevel();

            version = new Version();
            sfx = new SFXMaker();
            fileList = new List<string>();
        }

        private void setDefaultCompressionLevel()
        {
            cbCompressionLevel.SelectedIndex = (int)CompressionLevel.Default;
        }

        private void initToolTip()
        {
            ToolTip icon = new ToolTip();
            icon.SetToolTip(btnBrowseIcon, Resources.IconToolTip);

            ToolTip stub = new ToolTip();
            stub.SetToolTip(btnBrowseStub, Resources.StubToolTip);

            ToolTip uac = new ToolTip();
            uac.SetToolTip(chkUAC, Resources.UACToolTip);

            ToolTip compressionLevel = new ToolTip();
            compressionLevel.SetToolTip(cbCompressionLevel, Resources.CompressionLevelToolTip);

            ToolTip fileSize = new ToolTip();
            fileSize.SetToolTip(btnCalculateFileSize, Resources.FileSizeToolTip);

            ToolTip now = new ToolTip();
            now.SetToolTip(progressNow, Resources.ProgressNowToolTip);

            ToolTip all = new ToolTip();
            all.SetToolTip(progressAll, Resources.ProgressAllToolTip);
        }

        public static decimal roundDown(decimal value, int dot)
        {
            decimal power = Convert.ToDecimal(Math.Pow(10, dot));
            return Math.Floor(value * power) / power;
        }

        public static FileType getFileType(string path)
        {
            if (File.Exists(path))
            {
                return FileType.FILE;
            }
            if (Directory.Exists(path))
            {
                return FileType.DIRECTORY;
            }
            return FileType.NOT_FOUND;
        }

        private async Task<long> calculateFileSize()
        {
            return await Task.Run(() =>
            {
                long ret = 0;
                try
                {
                    foreach (string file in fileList)
                    {
                        FileType type = getFileType(file);
                        if (type == FileType.NOT_FOUND)
                        {
                            throw new Exception($"找不到檔案 {file}");
                        }

                        switch (type)
                        {
                            case FileType.DIRECTORY:
                                {
                                    ret += Util.getDirectorySize(file);
                                    break;
                                }
                            case FileType.FILE:
                                {
                                    ret += Util.getFileSize(file);
                                    break;
                                }
                        }
                    }
                    return ret;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"計算檔案大小時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ERROR_RESULT;
                }
            });
        }

        private async Task<bool> updatePackageSize()
        {
            labelFileSize.Text = "計算中 ...";
            long size = await calculateFileSize();
            if (size == ERROR_RESULT)
            {
                labelFileSize.ForeColor = Color.Red;
                labelFileSize.Text = $"檔案大小 : 發生錯誤 / {MAX_PACKAGE_SIZE_MB} MB";
                return false;
            }
            else
            {
                bool ret = size <= MAX_PACKAGE_SIZE_BYTE;
                labelFileSize.ForeColor = ret ? Color.Black : Color.Red;

                decimal sizeMB = roundDown(Convert.ToDecimal(size) / 1000 / 1000, 2);
                if (sizeMB >= 10000)
                {
                    sizeMB = 9999.99M;
                }
                labelFileSize.Text = $"檔案大小 : {sizeMB} / {MAX_PACKAGE_SIZE_MB} MB";
                return ret;
            }
        }

        private bool existItem(string key)
        {
            if (lvFile.Items.ContainsKey(key))
            {
                MessageBox.Show($"檔案 {key} 已存在", "無法加入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        // Key / Text : 檔案名稱 Tag : 檔案完整路徑
        private void addItem(params string[] item)
        {
            lvFile.BeginUpdate();
            foreach (string file in item)
            {
                FileType type = getFileType(file);
                if (type == FileType.NOT_FOUND)
                {
                    MessageBox.Show($"找不到檔案 {file}", "無法加入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                ListViewItem add = null;
                try
                {
                    switch (type)
                    {
                        case FileType.FILE:
                            {
                                string fileName = new FileInfo(file).Name;
                                if (existItem(fileName))
                                {
                                    continue;
                                }

                                ilFileIcon.Images.Add(fileName, Icon.ExtractAssociatedIcon(file));
                                add = lvFile.Items.Add(fileName, fileName, fileName);
                                break;
                            }
                        case FileType.DIRECTORY:
                            {
                                string directoryName = new DirectoryInfo(file).Name;
                                if (existItem(directoryName))
                                {
                                    continue;
                                }

                                add = lvFile.Items.Add(directoryName, directoryName, ListViewFileComparer.FOLDER_KEY);
                                break;
                            }
                    }
                    add.Tag = file;
                    fileList.Add(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"新增檔案 {file} 時發生例外狀況 : {ex.Message}", "無法加入", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            lvFile.EndUpdate();
        }

        private static void exit(int code = 0)
        {
            Environment.Exit(code);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.Help, "說明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            using (AboutForm form = new AboutForm())
            {
                form.ShowDialog();
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,
                Title = "請選擇加入檔案"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    addItem(dialog.FileNames);
                }
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                Description = "請選擇加入資料夾"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    addItem(dialog.SelectedPath);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection select = lvFile.SelectedItems;
            if (select.Count <= 0)
            {
                MessageBox.Show("請選擇移除項目", "移除", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lvFile.BeginUpdate();
            foreach (ListViewItem item in select)
            {
                string imageKey = item.ImageKey;
                string file = item.Tag.ToString();

                lvFile.Items.Remove(item);
                if (imageKey != ListViewFileComparer.FOLDER_KEY)
                {
                    ilFileIcon.Images.RemoveByKey(imageKey);
                }
                fileList.Remove(file);
            }
            lvFile.EndUpdate();
        }

        private void resetFileIcon()
        {
            ilFileIcon.Images.Clear();
            ilFileIcon.Images.Add(ListViewFileComparer.FOLDER_KEY, Resources.Folder);
        }

        private void clearItem()
        {
            lvFile.Items.Clear();
            resetFileIcon();
            fileList.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定清除所有檔案 ?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clearItem();
            }
        }

        private void updateStub()
        {
            labelStub.Text = $"Stub 程式組 : {(stubFile == null ? 0 : stubFile.Length)} 檔案";
        }

        private void btnBrowseStub_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,
                Title = "請選擇 Stub 程式組"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    stubFile = dialog.FileNames;
                    updateStub();
                }
            }
        }

        private async Task<bool> createZIP(string password)
        {
            bool canPackage = await updatePackageSize();
            if (!canPackage)
            {
                MessageBox.Show("封裝大小不符合要求", "建置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            CompressionLevel level = (CompressionLevel)cbCompressionLevel.SelectedIndex;
            appendLog(Color.Black, "製作壓縮檔案");
            return await Task.Run(() =>
            {
                try
                {
                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AlternateEncoding = Encoding.UTF8;
                        zip.AlternateEncodingUsage = ZipOption.Always;
                        zip.SaveProgress += zipProgressEventHandler;

                        zip.UseZip64WhenSaving = Zip64Option.Always;
                        zip.CompressionLevel = level;
                        if (password != null)
                        {
                            zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                            zip.Password = password;
                        }

                        foreach (string file in fileList)
                        {
                            FileType type = getFileType(file);
                            if (type == FileType.NOT_FOUND)
                            {
                                throw new Exception($"找不到檔案 {file}");
                            }

                            switch (type)
                            {
                                case FileType.FILE:
                                    {
                                        zip.AddFile(file, string.Empty);
                                        break;
                                    }
                                case FileType.DIRECTORY:
                                    {
                                        string folder = new DirectoryInfo(file).Name;
                                        zip.AddDirectory(file, folder);
                                        break;
                                    }
                            }
                        }
                        zip.Comment = Util.getHeader();
                        zip.Save(OUTPUT_ZIP_FILE_NAME);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex;
                    MessageBox.Show($"製作壓縮檔案時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            });
        }

        private string[] handleStub()
        {
            List<string> sourceFile = new List<string>();
            IList<string> dllFile = new List<string>();
            foreach (string file in stubFile)
            {
                string extension = Path.GetExtension(file).ToLowerInvariant();
                if (extension.Equals(".resources"))
                {
                    sfx.addResourceFile(file);
                    continue;
                }
                else if (extension.Equals(".dll"))
                {
                    sfx.addReference(file);
                    sfx.addResourceFile(file);
                    dllFile.Add(Path.GetFileName(file));
                    continue;
                }
                sourceFile.Add(file);
            }

            using (FileStream fs = new FileStream(OUTPUT_LIBRARY_LIST_FILE_NAME, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (string dll in dllFile)
                    {
                        bw.Write(dll);
                    }
                }
            }
            sfx.addResourceFile(OUTPUT_LIBRARY_LIST_FILE_NAME);
            return sourceFile.ToArray();
        }

        private async Task<bool> createSFX(string output)
        {
            appendLog(Color.Black, "讀取程式設定");
            string icon = txtIcon.Text;
            if (icon == string.Empty)
            {
                icon = null;
            }

            bool password = chkPassword.Checked;
            bool noPack = tsmiNoPack.Checked;
            bool console = tsmiCompileConsole.Checked;
            bool uac = chkUAC.Checked;

            shouldDeleteDataFile = true;
            if (!noPack)
            {
                sfx.addResourceFile(OUTPUT_ZIP_FILE_NAME);
            }
            appendLog(Color.Black, "產生版本資訊檔案");
            await Task.Run(() =>
            {
                try
                {
                    version.writeVersion();

                    appendLog(Color.Black, "編譯程式");
                    updateProgressText(Color.Black, "編譯程式中");
                    sfx.compile(output, icon, password, noPack, console, uac, handleStub());

                    if (noPack)
                    {
                        string copyPath = Path.Combine(Path.GetDirectoryName(output), OUTPUT_ZIP_FILE_NAME);
                        if (Path.GetFullPath(OUTPUT_ZIP_FILE_NAME) != copyPath)
                        {
                            File.Copy(OUTPUT_ZIP_FILE_NAME, copyPath, true);
                        }
                        else
                        {
                            shouldDeleteDataFile = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = ex;
                    MessageBox.Show($"編譯程式時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            sfx.reset();
            return error == null;
        }

        #region UI 狀態控制
        private void setWorking(bool work)
        {
            tsmiNewProject.Enabled = tsmiOpenProject.Enabled = tsmiSaveProject.Enabled
                = tsmiSaveAsProject.Enabled = tsmiVersion.Enabled = tsmiCreateUninstallConfig.Enabled
                = tsmiNoPack.Enabled = tsmiCompileConsole.Enabled = lvFile.Enabled
                = btnAddFile.Enabled = btnAddFolder.Enabled = btnRemove.Enabled
                = btnClear.Enabled = btnBrowseStub.Enabled = btnCalculateFileSize.Enabled
                = btnBrowseIcon.Enabled = chkPassword.Enabled = chkUAC.Enabled
                = cbCompressionLevel.Enabled = btnProcess.Enabled = !work;

            if (work)
            {
                updateStatusBar("執行中");
                txtPassword.Enabled = false;
                clearPassTime();
                timerPassTime.Start();
            }
            else
            {
                updatePasswordControl();
                timerPassTime.Stop();
                updateStatusBar("就緒");
            }
        }

        private void enableFileOperation(bool enable)
        {
            tsmiNewProject.Enabled = tsmiOpenProject.Enabled = tsmiSaveProject.Enabled
                = tsmiSaveAsProject.Enabled = tsmiCreateUninstallConfig.Enabled = lvFile.Enabled
                = btnAddFile.Enabled = btnAddFolder.Enabled = btnRemove.Enabled
                = btnClear.Enabled = btnCalculateFileSize.Enabled = btnProcess.Enabled
                = enable;
        }

        private void updatePasswordControl()
        {
            txtPassword.Enabled = chkPassword.Checked;
        }
        #endregion UI 狀態控制

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (fileList.Count <= 0)
            {
                MessageBox.Show("尚未加入任何檔案", "建置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = chkPassword.Checked ? txtPassword.Text : null;
            if (password == string.Empty)
            {
                MessageBox.Show("請輸入密碼", "建置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (stubFile == null)
            {
                MessageBox.Show("請指定 Stub 程式組", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "程式檔案 (*.exe)|*.exe",
                Title = "請指定輸出位置"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    setWorking(true);
                    string output = dialog.FileName;
                    appendLog(Color.Green, $"開始處理封裝 : {output}");

                    bool success = false;
                    if (await createZIP(password))
                    {
                        success = await createSFX(output);
                    }

                    appendLog(Color.Black, "清理中繼資料");
                    cleanUp();

                    if (success)
                    {
                        const string SUCCESS_MESSAGE = "封裝製作完成";
                        appendLog(Color.Green, SUCCESS_MESSAGE);
                        updateProgressText(Color.Green, SUCCESS_MESSAGE);
                        SystemSound.playSystemSound("Notification.IM");
                    }
                    else
                    {
                        const string FAIL_MESSAGE = "封裝製作失敗";
                        appendLog(Color.Red, FAIL_MESSAGE);
                        updateProgressText(Color.Red, FAIL_MESSAGE);

                        if (error != null)
                        {
                            appendLog(Color.Red, $"例外狀況 : {error}");
                            error = null;
                        }
                    }
                    setWorking(false);
                }
            }
        }

        private void cleanUp()
        {
            try
            {
                File.Delete(OUTPUT_LIBRARY_LIST_FILE_NAME);
                File.Delete(Version.FILE_NAME);
                if (shouldDeleteDataFile)
                {
                    File.Delete(OUTPUT_ZIP_FILE_NAME);
                }
            }
            catch (Exception ex)
            {
                appendLog(Color.Red, $"發生例外狀況 : {ex.Message}");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit();
        }

        private void lvFile_DragDrop(object sender, DragEventArgs e)
        {
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
            addItem(file);
        }

        private void lvFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private async void btnCalculateFileSize_Click(object sender, EventArgs e)
        {
            enableFileOperation(false);
            await updatePackageSize();
            enableFileOperation(true);
        }

        private void updateStatusBar(string status)
        {
            tsslStatus.Text = status;
        }

        private void updateProgressText(Color color, string progress)
        {
            labelProgress.Invoke((MethodInvoker)delegate
            {
                labelProgress.ForeColor = color;
                labelProgress.Text = progress;
            });
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            updatePasswordControl();
        }

        private void zipProgressEventHandler(object sender, SaveProgressEventArgs e)
        {
            switch (e.EventType)
            {
                case ZipProgressEventType.Saving_BeforeWriteEntry:
                    {
                        int total = e.EntriesTotal;
                        if (total > 0)
                        {
                            updateProgressText(Color.Black, $"正在處理 {e.CurrentEntry.FileName}");

                            int percent = (int)((double)e.EntriesSaved / total * 100);
                            progressAll.Invoke((MethodInvoker)delegate
                            {
                                progressAll.Value = percent;
                            });
                        }
                        break;
                    }
                case ZipProgressEventType.Saving_EntryBytesRead:
                    {
                        int filePercent = 0;
                        long totalTransfer = e.TotalBytesToTransfer;
                        if (totalTransfer > 0)
                        {
                            filePercent = (int)((double)e.BytesTransferred / totalTransfer * 100);
                        }

                        progressNow.Invoke((MethodInvoker)delegate
                        {
                            progressNow.Value = filePercent;
                        });
                        break;
                    }
                case ZipProgressEventType.Saving_Completed:
                    {
                        updateProgressText(Color.Black, "壓縮檔案建立完成");
                        Invoke((MethodInvoker)delegate
                        {
                            progressNow.Value = progressAll.Value = 100;
                        });
                        break;
                    }
            }
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "圖標檔案 (*.ico)|*.ico",
                Title = "請選擇程式圖標"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtIcon.Text = dialog.FileName;
                }
            }
        }

        private void btnCopyLog_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtLog.Text);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
        }

        private void appendLog(Color color, string message)
        {
            txtLog.Invoke((MethodInvoker)delegate
            {
                txtLog.SelectionColor = color;
                txtLog.AppendText($"[{Util.getCurrentTime()}] {message}{Environment.NewLine}");
            });
        }

        private async void tsmiCreateUninstallConfig_Click(object sender, EventArgs e)
        {
            const string output = "Uninstall.dat";
            enableFileOperation(false);
            await Task.Run(() =>
            {
                try
                {
                    using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write))
                    {
                        using (BinaryWriter bw = new BinaryWriter(fs))
                        {
                            foreach (string file in fileList)
                            {
                                bw.Write(file);
                            }
                        }
                    }
                    MessageBox.Show($"解除安裝設定檔案輸出完成 檔案名稱 : {output}", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"輸出解除安裝設定檔案時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            enableFileOperation(true);
        }

        private void tsmiVersion_Click(object sender, EventArgs e)
        {
            using (VersionSetting form = new VersionSetting(version))
            {
                form.ShowDialog();
            }
        }

        #region 視窗大小變更

        private static readonly Size NORMAL_SIZE = new Size(695, 715);
        private static readonly Size EXTEND_SIZE = new Size(1060, 715);

        private void tsmiShowLog_Click(object sender, EventArgs e)
        {
            bool status = !tsmiShowLog.Checked;
            tsmiShowLog.Checked = status;
            Size = status ? EXTEND_SIZE : NORMAL_SIZE;
        }

        #endregion 視窗大小變更

        private void tsmiShowPassword_Click(object sender, EventArgs e)
        {
            bool status = !tsmiShowPassword.Checked;
            tsmiShowPassword.Checked = status;
            txtPassword.UseSystemPasswordChar = !status;
        }

        private void tsmiCompileConsole_Click(object sender, EventArgs e)
        {
            bool status = !tsmiCompileConsole.Checked;
            tsmiCompileConsole.Checked = status;
            if (status)
            {
                MessageBox.Show("僅有當 Stub 程式組為主控台應用程式時才開啟本選項", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region 專案處理
        private string lastSave;

        private void tsmiSaveProject_Click(object sender, EventArgs e)
        {
            if (lastSave == null || !File.Exists(lastSave))
            {
                lastSave = openProjectSaveDialog();
                if (lastSave == null)
                {
                    return;
                }
            }
            saveProject(lastSave);
        }

        private static string openProjectSaveDialog()
        {
            using (SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "SFX 專案檔案 (*.sfxproj)|*.sfxproj",
                Title = "請指定輸出位置"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
            }
            return null;
        }

        private void saveProject(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.writeStringList(fileList);
                        bw.writeStringList(stubFile);

                        bw.Write(txtIcon.Text);
                        bw.Write(txtPassword.Text);
                        bw.Write(cbCompressionLevel.SelectedIndex);

                        bw.Write(tsmiNoPack.Checked);
                        bw.Write(tsmiCompileConsole.Checked);
                        bw.Write(chkPassword.Checked);
                        bw.Write(chkUAC.Checked);

                        bw.Write(version.title);
                        bw.Write(version.description);
                        bw.Write(version.company);
                        bw.Write(version.product);
                        bw.Write(version.copyright);
                        bw.Write(version.trademark);
                        bw.Write(version.assemblyVersion);
                        bw.Write(version.fileVersion);
                    }
                }
                MessageBox.Show("專案儲存完成", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"專案儲存時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiOpenProject_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "SFX 專案檔案 (*.sfxproj)|*.sfxproj",
                Title = "請選擇專案"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = dialog.FileName;
                    try
                    {
                        ProjectConfig config = ConfigManager.loadProject(fileName);
                        newProject();

                        string[] file = config.file;
                        if (file != null)
                        {
                            addItem(file);
                        }

                        stubFile = config.stub;
                        updateStub();

                        txtIcon.Text = config.icon;
                        txtPassword.Text = config.password;
                        cbCompressionLevel.SelectedIndex = config.compressionLevel;

                        tsmiNoPack.Checked = config.noPack;
                        tsmiCompileConsole.Checked = config.console;
                        chkPassword.Checked = config.hasPassword;
                        chkUAC.Checked = config.uac;

                        version = config.version;
                        lastSave = fileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"專案讀取時發生例外狀況 : {ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsmiNewProject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"確定開始新專案 ?{Environment.NewLine}將清除目前設定", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lastSave = null;
                newProject();
            }
        }

        private void newProject()
        {
            version.loadDefault();
            tsmiNoPack.Checked = tsmiCompileConsole.Checked = chkPassword.Checked
                = chkUAC.Checked = false;

            clearItem();
            stubFile = null;
            updateStub();

            labelFileSize.ForeColor = labelProgress.ForeColor = Color.Black;
            labelFileSize.Text = "等待中";

            txtIcon.Text = txtPassword.Text = string.Empty;
            setDefaultCompressionLevel();

            labelProgress.Text = "等待中 ...";
            labelPassTime.Text = "經過時間 00 : 00 : 00";
            progressNow.Value = progressAll.Value = 0;
        }

        private void tsmiSaveAsProject_Click(object sender, EventArgs e)
        {
            string savePath = openProjectSaveDialog();
            if (savePath == null)
            {
                return;
            }
            lastSave = savePath;
            saveProject(lastSave);
        }
        #endregion 專案處理

        private void tsmiOpenNotepad_Click(object sender, EventArgs e)
        {
            using (Process.Start("notepad.exe"))
            {
            }
        }

        #region 經過時間
        private int passTime;

        private void clearPassTime()
        {
            passTime = 0;
            updatePassTime();
        }

        private void updatePassTime()
        {
            int hour = passTime / 3600;
            int minute = (passTime - hour * 3600) / 60;
            int second = passTime - (hour * 3600 + minute * 60);

            if (hour > 99)
            {
                hour = 99;
            }
            labelPassTime.Text = $"經過時間 {string.Format("{0:D2} : {1:D2} : {2:D2}", hour, minute, second)}";
        }

        private void timerPassTime_Tick(object sender, EventArgs e)
        {
            ++passTime;
            updatePassTime();
        }
        #endregion 經過時間
    }
}