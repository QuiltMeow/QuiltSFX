using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuiltSFX
{
    public static class ConfigManager
    {
        public static string[] readStringList(this BinaryReader binaryReader)
        {
            IList<string> ret = new List<string>();
            int count = binaryReader.ReadInt32();
            if (count <= 0)
            {
                return null;
            }
            else
            {
                for (int i = 1; i <= count; ++i)
                {
                    ret.Add(binaryReader.ReadString());
                }
                return ret.ToArray();
            }
        }

        public static void writeStringList(this BinaryWriter binaryWriter, IEnumerable<string> data)
        {
            if (data == null)
            {
                binaryWriter.Write(0);
            }
            else
            {
                binaryWriter.Write(data.Count());
                foreach (string output in data)
                {
                    binaryWriter.Write(output);
                }
            }
        }

        public static ProjectConfig loadProject(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    ProjectConfig ret = new ProjectConfig();
                    ret.file = br.readStringList();
                    ret.stub = br.readStringList();

                    ret.icon = br.ReadString();
                    ret.password = br.ReadString();

                    int compressionLevel = br.ReadInt32();
                    if (compressionLevel < (int)CompressionLevel.None || compressionLevel > (int)CompressionLevel.BestCompression)
                    {
                        throw new Exception("無效的壓縮等級");
                    }
                    ret.compressionLevel = compressionLevel;
                    
                    ret.noPack = br.ReadBoolean();
                    ret.console = br.ReadBoolean();
                    ret.hasPassword = br.ReadBoolean();
                    ret.uac = br.ReadBoolean();

                    Version version = new Version();
                    version.title = br.ReadString();
                    version.description = br.ReadString();
                    version.company = br.ReadString();
                    version.product = br.ReadString();
                    version.copyright = br.ReadString();
                    version.trademark = br.ReadString();

                    string assemblyVersion = br.ReadString();
                    string fileVersion = br.ReadString();
                    if (!Version.isLegalVersionNumber(assemblyVersion) || !Version.isLegalVersionNumber(fileVersion))
                    {
                        throw new Exception("無效的版本號碼");
                    }

                    version.assemblyVersion = assemblyVersion;
                    version.fileVersion = fileVersion;
                    ret.version = version;
                    return ret;
                }
            }
        }
    }

    public class FileConfig
    {
        public string[] file
        {
            get;
            set;
        }
    }

    public class ProjectConfig : FileConfig
    {
        public string[] stub
        {
            get;
            set;
        }

        public string icon
        {
            get;
            set;
        }

        public bool noPack
        {
            get;
            set;
        }

        public bool console
        {
            get;
            set;
        }

        public bool hasPassword
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }

        public int compressionLevel
        {
            get;
            set;
        }

        public bool uac
        {
            get;
            set;
        }

        public Version version
        {
            get;
            set;
        }
    }
}