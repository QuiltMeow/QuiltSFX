using QuiltSFXPackage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuiltSFXSplashStub
{
    public partial class SplashStub : Form
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

        public SplashStub()
        {
            setDefaultPath();
            InitializeComponent();
            string password = null;
#if !HAS_PASSWORD
            using (PasswordForm form = new PasswordForm())
            {
                form.ShowDialog();
                password = form.password;
                if (password == null)
                {
                    Close();
                    return;
                }
            }
#endif
            extract();
            Close();
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
    }

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SFXLibrary.resolveLibrary();
            Application.Run(new SplashStub());
        }
    }
}