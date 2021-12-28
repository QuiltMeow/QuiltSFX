using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace QuiltSFX
{
    public partial class VersionSetting : Form
    {
        private readonly Version version;
        private readonly TextBox[] assemblyVersion, fileVersion;

        public VersionSetting(Version version)
        {
            InitializeComponent();
            assemblyVersion = new TextBox[] {
                txtAssemblyVersion1, txtAssemblyVersion2, txtAssemblyVersion3, txtAssemblyVersion4
            };
            fileVersion = new TextBox[] {
                txtFileVersion1, txtFileVersion2, txtFileVersion3, txtFileVersion4
            };

            this.version = version;
        }

        private void updateVersionInformation()
        {
            txtTitle.Text = version.title;
            txtDescription.Text = version.description;
            txtCompany.Text = version.company;
            txtProduct.Text = version.product;
            txtCopyright.Text = version.copyright;
            txtTrademark.Text = version.trademark;

            setTextBoxValue(assemblyVersion, version.assemblyVersion.Split('.'));
            setTextBoxValue(fileVersion, version.fileVersion.Split('.'));
        }

        private static void setTextBoxValue(TextBox[] control, string[] value)
        {
            for (int i = 0; i < control.Length; ++i)
            {
                control[i].Text = value[i];
            }
        }

        private void VersionSetting_Load(object sender, EventArgs e)
        {
            updateVersionInformation();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static bool isLegalText(string input)
        {
            return !input.Contains("{") && !input.Contains("}");
        }

        private static string getVersionNumber(TextBox[] control)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TextBox box in control)
            {
                string text = box.Text;
                if (!int.TryParse(text, out _))
                {
                    throw new Exception("無效的版本號碼");
                }
                sb.Append(text).Append(".");
            }
            sb.Length -= 1;
            return sb.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Type type = typeof(Version);
            try
            {
                IDictionary<PropertyInfo, string> setting = new Dictionary<PropertyInfo, string>()
                {
                    { type.GetProperty("title"), txtTitle.Text },
                    { type.GetProperty("description"), txtDescription.Text },
                    { type.GetProperty("company"), txtCompany.Text },
                    { type.GetProperty("product"), txtProduct.Text },
                    { type.GetProperty("copyright"), txtCopyright.Text },
                    { type.GetProperty("trademark"), txtTrademark.Text },
                    { type.GetProperty("assemblyVersion"), getVersionNumber(assemblyVersion) },
                    { type.GetProperty("fileVersion"), getVersionNumber(fileVersion) }
                };

                foreach (string text in setting.Values)
                {
                    if (!isLegalText(text))
                    {
                        MessageBox.Show("版本資訊包含不允許字元", "版本", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                foreach (KeyValuePair<PropertyInfo, string> data in setting)
                {
                    data.Key.SetValue(version, data.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "版本", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定重置版本資訊 ?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            version.loadDefault();
            updateVersionInformation();
        }
    }
}