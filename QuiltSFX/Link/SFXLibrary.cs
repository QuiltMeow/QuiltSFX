using Ionic.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace QuiltSFXPackage
{
    public static class SFXLibrary
    {
        public const int EXIT_SUCCESS = 0;
        public const int EXIT_FAILURE = 1;

        public const string DATA_NAME = "Data.ew";
        public const string LIBRARY_LIST = "Library.ew";
        public const string ZIP_LIBRARY_NAME = "DotNetZip.dll";

        private static readonly IDictionary<string, Assembly> LIBRARY = new Dictionary<string, Assembly>();
        public delegate void MemoryExtractProgressHandler(int now, int total, string file);

        public static void resolveLibrary()
        {
            try
            {
                loadLibrary(ZIP_LIBRARY_NAME);
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(LIBRARY_LIST))
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        while (stream.Length != stream.Position)
                        {
                            string library = br.ReadString();
                            loadLibrary(library);
                        }
                    }
                }
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += resolveLibraryEventHandler;
                AppDomain.CurrentDomain.AssemblyResolve += resolveLibraryEventHandler;
            }
            catch (Exception ex)
            {
                MessageBox.Show("函式庫載入失敗 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit(EXIT_FAILURE);
            }
        }

        private static void loadLibrary(string library)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(library))
            {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                Assembly assembly = Assembly.Load(buffer);
                LIBRARY.Add(assembly.FullName, assembly);
            }
        }

        private static Assembly resolveLibraryEventHandler(object sender, ResolveEventArgs e)
        {
            Assembly ret;
            LIBRARY.TryGetValue(e.Name, out ret);
            return ret;
        }

        public static Stream getDataStream()
        {
#if !NO_PACK
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(DATA_NAME);
#else
            return new FileStream(DATA_NAME, FileMode.Open, FileAccess.Read);
#endif
        }

        public static void exit(int code = EXIT_SUCCESS)
        {
            try
            {
                Environment.Exit(code);
            }
            catch
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    process.Kill();
                }
            }
        }

        public static void extractDisk(string path, string password = null, EventHandler<ExtractProgressEventArgs> handler = null)
        {
            Directory.CreateDirectory(path);
            using (Stream stream = getDataStream())
            {
                using (ZipFile zip = ZipFile.Read(stream))
                {
                    zip.AlternateEncoding = Encoding.UTF8;
                    zip.AlternateEncodingUsage = ZipOption.Always;

                    if (handler != null)
                    {
                        zip.ExtractProgress += handler;
                    }

                    if (password != null)
                    {
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        zip.Password = password;
                    }
                    zip.ExtractAll(path, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static IOrderedDictionary extractMemory(string password = null, MemoryExtractProgressHandler handler = null)
        {
            IOrderedDictionary ret = new OrderedDictionary();
            using (Stream stream = getDataStream())
            {
                using (ZipFile zip = ZipFile.Read(stream))
                {
                    zip.AlternateEncoding = Encoding.UTF8;
                    zip.AlternateEncodingUsage = ZipOption.Always;

                    if (password != null)
                    {
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        zip.Password = password;
                    }

                    int now = 0, total = zip.Entries.Count;
                    foreach (ZipEntry entry in zip)
                    {
                        string path = entry.FileName;
                        if (handler != null)
                        {
                            handler.Invoke(++now, total, path);
                        }

                        using (MemoryStream ms = new MemoryStream())
                        {
                            entry.Extract(ms);
                            ret.Add(path, ms.ToArray());
                        }
                    }
                }
            }
            return ret;
        }

        public static string extractFirstFileDisk(string folder, string password = null)
        {
            Directory.CreateDirectory(folder);
            using (Stream stream = getDataStream())
            {
                using (ZipFile zip = ZipFile.Read(stream))
                {
                    zip.AlternateEncoding = Encoding.UTF8;
                    zip.AlternateEncodingUsage = ZipOption.Always;

                    if (password != null)
                    {
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        zip.Password = password;
                    }

                    ZipEntry entry = zip[0];
                    string path = Path.Combine(folder, entry.FileName);
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        entry.Extract(fs);
                        return path;
                    }
                }
            }
        }

        public static void executeFirstFileDisk(string folder, string password = null)
        {
            string file = extractFirstFileDisk(folder, password);
            Process.Start(file);
        }

        public static KeyValuePair<string, byte[]> extractFirstFileMemory(string password = null)
        {
            using (Stream stream = getDataStream())
            {
                using (ZipFile zip = ZipFile.Read(stream))
                {
                    zip.AlternateEncoding = Encoding.UTF8;
                    zip.AlternateEncodingUsage = ZipOption.Always;

                    if (password != null)
                    {
                        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                        zip.Password = password;
                    }

                    ZipEntry entry = zip[0];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        entry.Extract(ms);
                        return new KeyValuePair<string, byte[]>(entry.FileName, ms.ToArray());
                    }
                }
            }
        }

        public static RegistryKey getUninstallRegistry()
        {
            return Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true);
        }

        public static Image byteArrayToImage(byte[] data)
        {
            using (Stream stream = new MemoryStream(data))
            {
                Image ret = Image.FromStream(stream);
                return ret;
            }
        }

        public static Icon byteArrayToIcon(byte[] data)
        {
            using (Stream stream = new MemoryStream(data))
            {
                return new Icon(stream);
            }
        }

        public static string getUniqueTempFolder()
        {
            const int tryTime = 1000;
            const string prefix = "QuiltSFX$";

            Random random = new Random();
            for (int i = 1; i <= tryTime; ++i)
            {
                string ret = Path.Combine(Path.GetTempPath(), prefix + random.Next());
                if (!Directory.Exists(ret) && !File.Exists(ret))
                {
                    return ret;
                }
            }
            throw new Exception("無法建立臨時資料夾");
        }

        public static void appendInstallText(RichTextBox control, Color color, string text)
        {
            control.Invoke((MethodInvoker)delegate
            {
                control.SelectionColor = color;
                control.AppendText(text + Environment.NewLine);
            });
        }

        public static string repeat(string origin, int repeat)
        {
            return string.Concat(Enumerable.Repeat(origin, repeat));
        }

        public static string newLine(int line = 1)
        {
            return repeat(Environment.NewLine, line);
        }

        public static void zipProgressEventHandler(ExtractProgressEventArgs argument, RichTextBox installText, ProgressBar progressNow, ProgressBar progressAll)
        {
            switch (argument.EventType)
            {
                case ZipProgressEventType.Extracting_BeforeExtractEntry:
                    {
                        int total = argument.EntriesTotal;
                        if (total > 0)
                        {
                            if (installText != null)
                            {
                                appendInstallText(installText, Color.Black, "抽取 " + argument.CurrentEntry.FileName + " ...");
                            }

                            if (progressAll != null)
                            {
                                int percent = (int)((double)argument.EntriesExtracted / total * 100);
                                progressAll.Invoke((MethodInvoker)delegate
                                {
                                    progressAll.Value = percent;
                                });
                            }
                        }
                        break;
                    }
                case ZipProgressEventType.Extracting_EntryBytesWritten:
                    {
                        if (progressNow != null)
                        {
                            int filePercent = 0;
                            long totalTransfer = argument.TotalBytesToTransfer;
                            if (totalTransfer > 0)
                            {
                                filePercent = (int)((double)argument.BytesTransferred / totalTransfer * 100);
                            }

                            progressNow.Invoke((MethodInvoker)delegate
                            {
                                progressNow.Value = filePercent;
                            });
                        }
                        break;
                    }
                case ZipProgressEventType.Extracting_AfterExtractAll:
                    {
                        if (progressNow != null)
                        {
                            progressNow.Invoke((MethodInvoker)delegate
                            {
                                progressNow.Value = 100;
                            });
                        }

                        if (progressAll != null)
                        {
                            progressAll.Invoke((MethodInvoker)delegate
                            {
                                progressAll.Value = 100;
                            });
                        }
                        break;
                    }
            }
        }
    }
}