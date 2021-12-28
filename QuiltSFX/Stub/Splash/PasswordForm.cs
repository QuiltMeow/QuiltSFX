using QuiltSFXPackage;
using System;
using System.Resources;
using System.Windows.Forms;

namespace QuiltSFXSplashStub
{
    public partial class PasswordForm : Form
    {
        public string password
        {
            get;
            private set;
        }

        public PasswordForm()
        {
            InitializeComponent();
            ResourceManager resource = SplashStub.resource;
            Icon = SFXLibrary.byteArrayToIcon((byte[])resource.GetObject("Icon"));
            pbLock.Image = SFXLibrary.byteArrayToImage((byte[])resource.GetObject("Lock"));
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string input = txtPassword.Text;
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("請輸入安裝密碼", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            password = input;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}