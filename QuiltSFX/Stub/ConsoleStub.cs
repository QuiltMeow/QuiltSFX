using Ionic.Zip;
using QuiltSFXPackage;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpProject
{
    public static class ConsoleStub
    {
        #region 使用者設定
        // 是否顯示使用條款
        public const bool SHOW_LICENSE = true;

        // 使用條款標題
        public const string LICENSE_TITLE = "使用條款";

        // 使用條款內容
        public const string LICENSE_CONTENT = "警告：本電腦軟體受著作權法和國際公約的保護。未經授權擅自複製或散發本程式的全部或任何部分，都會導致嚴厲的民事和刑事懲罰，並接受到法律允許範圍內最大限度的起訴。";

        // 安裝程式標題
        public const string TITLE = "安裝程式";

        // 安裝程式內容
        public static string MAIN_TEXT = "歡迎進入 「應用程式」 安裝精靈程式。本程式將安裝 「應用程式」 到您的電腦中。" + SFXLibrary.newLine(2) + "強烈建議您在執行本安裝程式之前首先退出所有其它正在執行的程式。" + SFXLibrary.newLine(2) + "如果您現在不想安裝，請按一下「取消」將中止並關閉本程式。否則，請按一下「安裝」繼續。";

        // 使用者選擇附加資料夾
        public static readonly string APPEND_FOLDER = string.Empty;

        // 安裝完畢後執行程式、建立捷徑 ...
        private static void afterExtract()
        {
            Console.Write("安裝完成，按下任意鍵離開程式 ... ");
            waitKeyExit();
        }

        // 安裝失敗執行程式
        private static void failExtract(Exception ex)
        {
            Console.Write("安裝失敗，按下任意鍵離開程式 ... ");
            waitKeyExit();
        }

        // 設定預設安裝路徑
        private static void setDefaultPath()
        {
            defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Software");
        }
        #endregion 使用者設定

        public static string path
        {
            get;
            private set;
        }

        public static string defaultPath
        {
            get;
            private set;
        }

        private static void waitKeyExit()
        {
            Console.ReadKey(true);
            SFXLibrary.exit();
        }

        private static async void uiThread()
        {
            try
            {
                if (SHOW_LICENSE)
                {
                    Console.Title = LICENSE_TITLE;
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine(LICENSE_CONTENT + Environment.NewLine);
                        Console.Write("[Y] 接受 [N] 拒絕 : ");
                        ConsoleKey read = Console.ReadKey().Key;
                        if (read == ConsoleKey.Y)
                        {
                            break;
                        }
                        else if (read == ConsoleKey.N)
                        {
                            SFXLibrary.exit();
                        }
                    }
                }

                Console.Title = TITLE;
                while (true)
                {
                    outputInstallInformation();
                    Console.Write("[D] 預設安裝路徑 [P] 變更安裝路徑 [I] 安裝 [E] 離開 : ");
                    ConsoleKey read = Console.ReadKey().Key;
                    switch (read)
                    {
                        case ConsoleKey.D:
                            {
                                path = defaultPath;
                                break;
                            }
                        case ConsoleKey.P:
                            {
                                processPath();
                                break;
                            }
                        case ConsoleKey.I:
                            {
                                await install();
                                break;
                            }
                        case ConsoleKey.E:
                            {
                                SFXLibrary.exit();
                                break;
                            }
                    }
                }
            }
            catch
            {
                SFXLibrary.exit(SFXLibrary.EXIT_FAILURE);
            }
        }

        private static void outputInstallInformation()
        {
            Console.Clear();
            Console.WriteLine(MAIN_TEXT + Environment.NewLine);
            Console.WriteLine("目前安裝路徑 : " + path);
        }

        private static async Task install()
        {
            string password = null;
#if HAS_PASSWORD
            Console.WriteLine();
            Console.Write("請輸入安裝密碼 : ");
            password = Console.ReadLine();
            Console.WriteLine();
#else
            Console.WriteLine(Environment.NewLine);
#endif

            Exception exception = null;
            await Task.Run(() =>
            {
                const int progressBuffer = 5;
                try
                {
                    SFXLibrary.extractDisk(path, password, (source, argument) =>
                    {
                        switch (argument.EventType)
                        {
                            case ZipProgressEventType.Extracting_BeforeExtractEntry:
                                {
                                    int total = argument.EntriesTotal;
                                    if (total > 0)
                                    {
                                        Console.Write("(" + (argument.EntriesExtracted + 1) + " / " + total + ") 抽取 " + argument.CurrentEntry.FileName + " ...   0 %");
                                    }
                                    break;
                                }
                            case ZipProgressEventType.Extracting_EntryBytesWritten:
                                {
                                    int filePercent = 0;
                                    long totalTransfer = argument.TotalBytesToTransfer;
                                    if (totalTransfer > 0)
                                    {
                                        filePercent = (int)((double)argument.BytesTransferred / totalTransfer * 100);
                                    }
                                    Console.Write(SFXLibrary.repeat("\b", progressBuffer) + string.Format("{0," + progressBuffer + "}", filePercent + " %"));
                                    break;
                                }
                            case ZipProgressEventType.Extracting_AfterExtractEntry:
                                {
                                    Console.WriteLine(SFXLibrary.repeat("\b", progressBuffer) + "100 %");
                                    break;
                                }
                        }
                    });
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            if (exception == null)
            {
                Console.WriteLine();
                afterExtract();
            }
            else
            {
                Console.WriteLine();
                Console.Error.WriteLine("安裝過程發生例外狀況 : " + exception.Message);
                failExtract(exception);
            }
        }

        private static void processPath()
        {
            while (true)
            {
                outputInstallInformation();
                Console.Write("請指定安裝路徑 : ");
                try
                {
                    path = Path.GetFullPath(Console.ReadLine());
                    if (APPEND_FOLDER != string.Empty)
                    {
                        string folder = new DirectoryInfo(path).Name;
                        if (!folder.Equals(APPEND_FOLDER, StringComparison.InvariantCultureIgnoreCase))
                        {
                            path = Path.Combine(path, APPEND_FOLDER);
                        }
                    }
                    break;
                }
                catch
                {
                }
            }
        }

        [STAThread]
        public static void Main()
        {
            SFXLibrary.resolveLibrary();
            setDefaultPath();
            path = defaultPath;

            Thread thread = new Thread(uiThread);
            thread.Start();
            Application.Run();
        }
    }
}