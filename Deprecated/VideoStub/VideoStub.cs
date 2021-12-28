using QuartzTypeLib;
using QuiltSFXPackage;
using System;
using System.Drawing;
using System.Net;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace QuiltSFXVideoStub
{
    [Obsolete("影片壓縮效果不佳且需要額外函式庫 部分功能已整合至 DSPlayer 詳情請見 : https://smallquilt.quilt.idv.tw:8923/ouo/project/MikuMikuPlayer/o_o%20Source.rar")]
    public partial class VideoStub : Form
    {
        #region 使用者設定

        // 是否在記憶體中播放影片
        public static readonly bool LOAD_IN_MEMORY = true;

        // 影片視窗標題
        public const string TITLE = "影片";

        // 預設視窗大小
        public const int DEFAULT_WIDTH = 1366, DEFAULT_HEIGHT = 768;

        #endregion 使用者設定

        public static readonly ResourceManager resource = new ResourceManager("VideoStubResource", typeof(VideoStub).Assembly);

        private FilgraphManager filterGraphManager;
        private IVideoWindow videoWindow;
        private IMediaEventEx mediaEventExtra;
        private IMediaPosition mediaPosition;

        private const int WM_APP = 0x8000;
        private const int WM_GRAPHNOTIFY = WM_APP + 1;
        private const int EC_COMPLETE = 0x01;
        private const int WS_CHILD = 0x40000000;
        private const int WS_CLIPCHILDREN = 0x2000000;

        private string password;
        private byte[] data;

        public VideoStub()
        {
            InitializeComponent();
            Icon = SFXLibrary.byteArrayToIcon((byte[])resource.GetObject("Icon"));
            pbLock.Image = SFXLibrary.byteArrayToImage((byte[])resource.GetObject("Lock"));
        }

        private void playVideo()
        {
            applySize();
            loadVideo();
            Show();
        }

        private void applySize()
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            panelVideo.BackColor = Color.Black;
            Size = new Size(DEFAULT_WIDTH + 16, DEFAULT_HEIGHT + 39);
        }

        public string createServer()
        {
            const int tryTime = 10;
            const string prefix = "http://127.0.0.1:";

            Random random = new Random();
            Exception exception = null;
            for (int i = 1; i <= tryTime; ++i)
            {
                try
                {
                    string url = prefix + random.Next(10000, 60000) + "/";
                    SimplifyMediaServer server = new SimplifyMediaServer(url, videoResponse);
                    server.run();
                    return url;
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }
            throw exception;
        }

        private byte[] videoResponse(HttpListenerRequest request)
        {
            return data;
        }

        private string extractResource()
        {
            try
            {
                if (LOAD_IN_MEMORY)
                {
                    data = SFXLibrary.extractFirstFileMemory(password).Value;
                    return createServer();
                }
                else
                {
                    return SFXLibrary.extractFirstFileDisk(SFXLibrary.getUniqueTempFolder(), password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("檔案讀取時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SFXLibrary.exit(1);
                return null;
            }
        }

        private void loadVideo()
        {
            string video = extractResource();
            filterGraphManager = new FilgraphManager();
            try
            {
                filterGraphManager.RenderFile(video);
            }
            catch (Exception ex)
            {
                MessageBox.Show("渲染影片時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SFXLibrary.exit(1);
            }

            try
            {
                videoWindow = filterGraphManager as IVideoWindow;
                videoWindow.Owner = (int)panelVideo.Handle;
                videoWindow.WindowStyle = WS_CHILD | WS_CLIPCHILDREN;
                videoWindow.SetWindowPosition(panelVideo.ClientRectangle.Left, panelVideo.ClientRectangle.Top, panelVideo.ClientRectangle.Width, panelVideo.ClientRectangle.Height);
            }
            catch
            {
            }

            mediaEventExtra = filterGraphManager as IMediaEventEx;
            mediaEventExtra.SetNotifyWindow((int)Handle, WM_GRAPHNOTIFY, 0);

            mediaPosition = filterGraphManager as IMediaPosition;
            filterGraphManager.Run();
        }

        private void updateVideoPosition()
        {
            if (videoWindow == null)
            {
                return;
            }
            try
            {
                videoWindow.SetWindowPosition(0, 0, 0, 0);
                videoWindow.SetWindowPosition(panelVideo.ClientRectangle.Left, panelVideo.ClientRectangle.Top, panelVideo.ClientRectangle.Width, panelVideo.ClientRectangle.Height);
            }
            catch
            {
            }
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_GRAPHNOTIFY)
            {
                int eventCode;
                int leftParameter, rightParameter;
                while (true)
                {
                    try
                    {
                        mediaEventExtra.GetEvent(out eventCode, out leftParameter, out rightParameter, 0);
                        mediaEventExtra.FreeEventParams(eventCode, leftParameter, rightParameter);
                        if (eventCode == EC_COMPLETE)
                        {
                            mediaPosition.CurrentPosition = 0;
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            base.WndProc(ref message);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string input = txtPassword.Text;
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("請輸入有效密碼", "密碼", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            password = input;
            hidePasswordInput();
            Hide();
            playVideo();
        }

        private void hidePasswordInput()
        {
            labelPassword.Visible = pbLock.Visible = txtPassword.Visible
                = btnConfirm.Visible = btnCancel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VideoStub_Load(object sender, EventArgs e)
        {
            Text = TITLE;
#if !HAS_PASSWORD
            hidePasswordInput();
            Hide();
            playVideo();
#endif
        }

        private void VideoStub_FormClosing(object sender, FormClosingEventArgs e)
        {
            SFXLibrary.exit();
        }

        private void VideoStub_SizeChanged(object sender, EventArgs e)
        {
            updateVideoPosition();
        }
    }

    public class SimplifyMediaServer
    {
        private readonly HttpListener listener;
        private readonly Func<HttpListenerRequest, byte[]> responseHandler;

        public SimplifyMediaServer(string prefix, Func<HttpListenerRequest, byte[]> responseHandler)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(prefix);
            this.responseHandler = responseHandler;
            listener.Start();
        }

        ~SimplifyMediaServer()
        {
            if (listener != null)
            {
                try
                {
                    listener.Close();
                }
                catch
                {
                }
            }
        }

        public void run()
        {
            ThreadPool.QueueUserWorkItem(voidCallback =>
            {
                try
                {
                    while (listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem(callback =>
                        {
                            HttpListenerContext context = callback as HttpListenerContext;
                            try
                            {
                                byte[] buffer = responseHandler(context.Request);
                                context.Response.ContentLength64 = buffer.Length;
                                context.Response.ContentType = "application/octet-stream";
                                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                            catch (Exception ex)
                            {
                                Console.Error.WriteLine("處理請求時發生例外狀況 : " + ex.Message);
                            }
                            finally
                            {
                                try
                                {
                                    context.Response.OutputStream.Close();
                                }
                                catch
                                {
                                }
                            }
                        }, listener.GetContext());
                    }
                }
                catch
                {
                }
            });
        }
    }

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SFXLibrary.resolveLibrary();
            Application.Run(new VideoStub());
        }
    }
}