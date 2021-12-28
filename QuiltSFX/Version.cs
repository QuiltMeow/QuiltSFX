using QuiltSFX.Properties;
using System;
using System.IO;

namespace QuiltSFX
{
    public class Version
    {
        private const int VERSION_NUMBER_LENGTH = 4;
        public const string FILE_NAME = "SFXVersion.cs";

        public string title
        {
            get;
            set;
        }

        public string description
        {
            get;
            set;
        }

        public string company
        {
            get;
            set;
        }

        public string product
        {
            get;
            set;
        }

        public string copyright
        {
            get;
            set;
        }

        public string trademark
        {
            get;
            set;
        }

        public string assemblyVersion
        {
            get;
            set;
        }

        public string fileVersion
        {
            get;
            set;
        }

        public Version()
        {
            loadDefault();
        }

        public void loadDefault()
        {
            title = "Quilt SFX Content";
            description = "Quilt SFX Package";
            company = "Quilt Corporation";
            product = "Quilt SFX";
            copyright = "Copyright © 2019 Quilt All Rights Reserved";
            trademark = string.Empty;
            assemblyVersion = "1.0.0.3";
            fileVersion = "1.0.0.5";
        }

        public void writeVersion()
        {
            string output = Resources.Version
                .Replace("{Title}", title)
                .Replace("{Description}", description)
                .Replace("{Company}", company)
                .Replace("{Product}", product)
                .Replace("{Copyright}", copyright)
                .Replace("{Trademark}", trademark)
                .Replace("{Guid}", Guid.NewGuid().ToString())
                .Replace("{AssemblyVersion}", assemblyVersion)
                .Replace("{FileVersion}", fileVersion);
            File.WriteAllText(FILE_NAME, output);
        }

        public static bool isLegalVersionNumber(string data)
        {
            string[] split = data.Split('.');
            if (split.Length != VERSION_NUMBER_LENGTH)
            {
                return false;
            }

            foreach (string number in split)
            {
                if (!int.TryParse(number, out _))
                {
                    return false;
                }
            }
            return true;
        }
    }
}