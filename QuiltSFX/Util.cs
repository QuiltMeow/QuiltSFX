using System;
using System.IO;
using System.Text;

namespace QuiltSFX
{
    public static class Util
    {
        private static readonly byte[] HEADER = new byte[] // TO DO : (Legacy) Change This
        {
            0x41, 0x4A
        };

        public static readonly byte[] LONG_HEADER = new byte[] // TO DO : (Legacy) Change This
        {
            0x41, 0x6B, 0x61, 0x74, 0x73, 0x75,
            0x6B, 0x69, 0x4A, 0x69, 0x61, 0x49,
            0x73, 0x56, 0x65, 0x72, 0x79, 0x43,
            0x75, 0x74, 0x65
        };

        public static string getHeader()
        {
            return Encoding.Default.GetString(HEADER);
        }

        public static long getDirectorySize(DirectoryInfo directory)
        {
            long ret = 0;
            FileInfo[] fileInfo = directory.GetFiles();
            foreach (FileInfo info in fileInfo)
            {
                ret += info.Length;
            }

            DirectoryInfo[] subDirectory = directory.GetDirectories();
            foreach (DirectoryInfo sub in subDirectory)
            {
                ret += getDirectorySize(sub);
            }
            return ret;
        }

        public static long getDirectorySize(string path)
        {
            return getDirectorySize(new DirectoryInfo(path));
        }

        public static long getFileSize(string path)
        {
            FileInfo info = new FileInfo(path);
            return info.Length;
        }

        public static string getCurrentTime()
        {
            return DateTime.Now.ToString("tt hh : mm : ss");
        }
    }
}