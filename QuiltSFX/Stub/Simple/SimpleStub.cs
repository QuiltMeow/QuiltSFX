using QuiltSFXPackage;
using System;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuiltSFXSimpleStub
{
    public partial class SimpleStub : Form
    {
        #region 使用者設定
        // 是否顯示使用條款
        public const bool SHOW_LICENSE = true;

        // 使用條款標題
        public const string LICENSE_TITLE = "使用條款";

        // 使用條款內容
        public const string LICENSE_CONTENT = "<p style=\"font-family: Microsoft JhengHei; font-size: 11pt\">警告：本電腦軟體受著作權法和國際公約的保護。未經授權擅自複製或散發本程式的全部或任何部分，都會導致嚴厲的民事和刑事懲罰，並接受到法律允許範圍內最大限度的起訴。</p>";

        // 安裝程式標題
        public const string TITLE = "安裝程式";

        // 安裝程式內容
        public const string MAIN_TEXT = "<p style=\"font-family: Microsoft JhengHei; font-size: 11pt\">歡迎進入 「應用程式」 安裝精靈程式。本程式將安裝 「應用程式」 到您的電腦中。<br /><br />強烈建議您在執行本安裝程式之前首先退出所有其它正在執行的程式。<br /><br />如果您現在不想安裝，請按一下「取消」將中止並關閉本程式。否則，請按一下「安裝」繼續。</p>";

        // 使用者選擇附加資料夾
        public static readonly string APPEND_FOLDER = string.Empty;

        // 安裝完畢後執行程式、建立捷徑 ...
        private void afterExtract()
        {
            MessageBox.Show("安裝完成，按下 「確定」 離開程式", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 安裝失敗執行程式
        private void failExtract(Exception ex)
        {
            MessageBox.Show("安裝失敗，請檢查錯誤訊息", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // 設定預設安裝路徑
        private void setDefaultPath()
        {
            defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Software");
        }
        #endregion 使用者設定

        public static readonly ResourceManager resource = new ResourceManager("SimpleStubResource", typeof(SimpleStub).Assembly);

        public string defaultPath
        {
            get;
            private set;
        }

        public SimpleStub()
        {
            if (SHOW_LICENSE)
            {
                using (LicenseForm form = new LicenseForm())
                {
                    form.ShowDialog();
                    if (!form.accept)
                    {
                        SFXLibrary.exit();
                    }
                }
            }
            InitializeComponent();
            Icon = SFXLibrary.byteArrayToIcon((byte[])resource.GetObject("Icon"));
            pbBanner.Image = SFXLibrary.byteArrayToImage((byte[])resource.GetObject("Banner"));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SFXLibrary.exit();
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            string password = null;
#if HAS_PASSWORD
            using (PasswordForm form = new PasswordForm())
            {
                form.ShowDialog();
                string result = form.password;
                if (result == null)
                {
                    return;
                }
                password = result;
            }
#endif

            btnDefaultPath.Enabled = btnBrowsePath.Enabled = btnInstall.Enabled = false;
            txtInstall.Visible = true;
            wbContent.Visible = false;

            string path = txtPath.Text;
            Exception exception = null;
            await Task.Run(() =>
            {
                try
                {
                    SFXLibrary.extractDisk(path, password, (source, argument) => SFXLibrary.zipProgressEventHandler(argument, txtInstall, progressNow, progressAll));
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            if (exception == null)
            {
                SFXLibrary.appendInstallText(txtInstall, Color.Green, "安裝完成");
                afterExtract();
                Close();
            }
            else
            {
                SFXLibrary.appendInstallText(txtInstall, Color.Red, "安裝過程發生例外狀況 : " + exception.Message);
                failExtract(exception);
            }
        }

        private void SimpleStub_Load(object sender, EventArgs e)
        {
            Text = TITLE;
            wbContent.DocumentText = MAIN_TEXT;

            setDefaultPath();
            resetInstallPath();
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                Description = "請選擇安裝目錄"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.SelectedPath;
                    if (APPEND_FOLDER != string.Empty)
                    {
                        try
                        {
                            string folder = new DirectoryInfo(path).Name;
                            if (!folder.Equals(APPEND_FOLDER, StringComparison.InvariantCultureIgnoreCase))
                            {
                                path = Path.Combine(path, APPEND_FOLDER);
                            }
                        }
                        catch
                        {
                        }
                    }
                    txtPath.Text = path;
                }
            }
        }

        private void SimpleStub_FormClosing(object sender, FormClosingEventArgs e)
        {
            SFXLibrary.exit();
        }

        private void resetInstallPath()
        {
            txtPath.Text = defaultPath;
        }

        private void btnDefaultPath_Click(object sender, EventArgs e)
        {
            resetInstallPath();
        }
    }

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SFXLibrary.resolveLibrary();
            Application.Run(new SimpleStub());
        }
    }
}