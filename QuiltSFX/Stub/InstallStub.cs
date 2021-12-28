using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QuiltSFXPackage
{
    public partial class InstallStub : Form
    {
        #region 使用者設定
        // 是否顯示使用條款
        public const bool SHOW_LICENSE = true;

        // 安裝程式標題
        public const string INSTALL_NAME = "應用程式";

        // 使用條款內容
        public const string LICENSE_CONTENT = "<p style=\"font-family: Microsoft JhengHei; font-size: 11pt\">警告：本電腦軟體受著作權法和國際公約的保護。未經授權擅自複製或散發本程式的全部或任何部分，都會導致嚴厲的民事和刑事懲罰，並接受到法律允許範圍內最大限度的起訴。</p>";

        // 安裝程式內容
        public const string MAIN_TEXT = "<p style=\"font-family: Microsoft JhengHei; font-weight: bold; font-size: 16pt\">歡迎使用 " + INSTALL_NAME + " 安裝程式</p><p style=\"font-family: Microsoft JhengHei; font-size: 11pt\">本安裝程式會引導您完成安裝 " + INSTALL_NAME + "<br /><br />在開始安裝之前．建議先關閉其他所有應用程式。這將允許安裝程式更新相關的系統檔案<br /><br />按下 [下一步] 繼續</p>";
        public const string FINISH_TEXT = "<p style=\"font-family: Microsoft JhengHei; font-weight: bold; font-size: 16pt\">完成安裝 " + INSTALL_NAME + "</p><p style=\"font-family: Microsoft JhengHei; font-size: 11pt\">已在電腦安裝 " + INSTALL_NAME + "<br /><br />按下 [完成] 關閉安裝程式</p>";

        // 使用者選擇附加資料夾
        public static readonly string APPEND_FOLDER = string.Empty;

        // 安裝完畢後執行程式、建立捷徑 ...
        private void afterExtract()
        {
        }

        // 安裝失敗執行程式
        private void failExtract(Exception ex)
        {
        }

        // 設定預設安裝路徑
        private void setDefaultPath()
        {
            defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Software");
        }
        #endregion 使用者設定

        public string defaultPath
        {
            get;
            private set;
        }

        public enum InstallStep
        {
            WELCOME,
            LICENSE,
            PASSWORD,
            COMPONENT,
            PATH,
            INSTALL,
            FINISH
        }

        private InstallStep step;
        private readonly Panel[] stepPanel;

        private delegate void InstallHandler();
        private readonly IDictionary<InstallStep, IList<InstallHandler>> installOperation;

        public InstallStub()
        {
            InitializeComponent();
            step = InstallStep.WELCOME;
            stepPanel = new Panel[] { panelMain, panelLicense, panelPassword, panelComponent, panelPath, panelInstall, panelMain };
            installOperation = new Dictionary<InstallStep, IList<InstallHandler>>();
            loadOperation();
        }

        private void updatePanelUI(int disable, int enable)
        {
            stepPanel[disable].Visible = false;
            stepPanel[enable].Visible = true;
        }

        private void loadOperation()
        {
            installOperation.Add(InstallStep.WELCOME, new List<InstallHandler>()
            {
                () =>
                {
                },
                () =>
                {
                    btnPrev.Visible = true;
                    btnNext.Enabled = false;
                    agreeLicenseHandler();
                }
            });

            installOperation.Add(InstallStep.LICENSE, new List<InstallHandler>()
            {
                () =>
                {
                    btnPrev.Visible = false;
                },
                () =>
                {
#if !HAS_PASSWORD
                    ++step;
#endif
                }
            });

            installOperation.Add(InstallStep.PASSWORD, new List<InstallHandler>()
            {
                () =>
                {

                },
                () =>
                {

                }
            });

            installOperation.Add(InstallStep.COMPONENT, new List<InstallHandler>()
            {
                () =>
                {

                },
                () =>
                {

                }
            });

            installOperation.Add(InstallStep.PATH, new List<InstallHandler>()
            {
                () =>
                {

                },
                () =>
                {

                }
            });

            installOperation.Add(InstallStep.INSTALL, new List<InstallHandler>()
            {
                () =>
                {

                },
                () =>
                {

                }
            });

            installOperation.Add(InstallStep.FINISH, new List<InstallHandler>()
            {
                () =>
                {

                },
                () =>
                {

                }
            });
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            installOperation[step][0]();
            updatePanelUI((int)step, (int)--step);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            installOperation[step][1]();
            if (Enum.IsDefined(typeof(InstallStep), step + 1))
            {
                updatePanelUI((int)step, (int)++step);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnDefaultPath_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {

        }

        private void agreeLicenseHandler()
        {
            btnNext.Enabled = chkAgreeLicense.Checked;
        }

        private void chkAgreeLicense_CheckedChanged(object sender, EventArgs e)
        {
            agreeLicenseHandler();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

        }
    }
}