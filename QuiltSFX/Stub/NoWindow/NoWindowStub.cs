using QuiltSFXPackage;
using System;
using System.Resources;
using System.Windows.Forms;

namespace QuiltSFXNoWindowStub
{
    public partial class NoWindowStub : Form
    {
        #region 使用者設定
        // 安裝完畢後執行程式、建立捷徑 ...
        private void afterExtract()
        {
            MessageBox.Show("安裝完成，按下 「確定」 離開程式", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 安裝失敗執行程式
        private void failExtract(Exception ex)
        {
            MessageBox.Show("安裝過程發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // 設定預設安裝路徑
        private void setDefaultPath()
        {
            try
            {
                defaultPath = SFXLibrary.getUniqueTempFolder();
            }
            catch (Exception ex)
            {
                MessageBox.Show("安裝過程發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SFXLibrary.exit(SFXLibrary.EXIT_FAILURE);
            }
        }
        #endregion 使用者設定

        public static readonly ResourceManager resource = new ResourceManager("NoWindowStubResource", typeof(NoWindowStub).Assembly);

        public string defaultPath
        {
            get;
            private set;
        }

        public NoWindowStub()
        {
            setDefaultPath();
#if HAS_PASSWORD
            InitializeComponent();
            Icon = SFXLibrary.byteArrayToIcon((byte[])resource.GetObject("Icon"));
            pbLock.Image = SFXLibrary.byteArrayToImage((byte[])resource.GetObject("Lock"));
#else
            extract();
            Close();
#endif
        }

        private void extract(string password = null)
        {
            try
            {
                SFXLibrary.extractDisk(defaultPath, password, null);
                afterExtract();
            }
            catch (Exception ex)
            {
                failExtract(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("請輸入有效密碼", "密碼", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Hide();
            extract(password);
            Close();
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
            Application.Run(new NoWindowStub());
        }
    }
}