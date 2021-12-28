using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuiltSFX
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Click(object sender, EventArgs e)
        {
            if (wbMedia.Visible)
            {
                return;
            }
            wbMedia.Url = new Uri("https://smallquilt.quilt.idv.tw:8923/webVideo/resource3.php");
            wbMedia.Visible = true;
        }

        private void pbProfile_Click(object sender, EventArgs e)
        {
            using (Process.Start("https://intro.quilt.idv.tw/"))
            {
            }
        }
    }
}