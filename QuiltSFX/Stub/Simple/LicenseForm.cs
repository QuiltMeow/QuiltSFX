using QuiltSFXPackage;
using System;
using System.Resources;
using System.Windows.Forms;

namespace QuiltSFXSimpleStub
{
    public partial class LicenseForm : Form
    {
        public bool accept
        {
            get;
            private set;
        }

        public LicenseForm()
        {
            InitializeComponent();
            ResourceManager resource = SimpleStub.resource;
            Icon = SFXLibrary.byteArrayToIcon((byte[])resource.GetObject("Icon"));
            pbBanner.Image = SFXLibrary.byteArrayToImage((byte[])resource.GetObject("Banner"));
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            accept = true;
            Close();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            Text = SimpleStub.LICENSE_TITLE;
            wbContent.DocumentText = Environment.NewLine + SimpleStub.LICENSE_CONTENT;
        }
    }
}