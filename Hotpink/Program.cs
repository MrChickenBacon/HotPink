using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace Hotpink
{
    class Program
    {
        [DllImport("User32", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uiAction, int uiParam,
            string pvParam, uint fWinIni);

        static void Main(string[] args)
        {
            var user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri("https://i.imgur.com/YaryvoN.jpg"), $@"{user}\Documents\hp.jpg");
            }

            var key = Registry.CurrentUser.CreateSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current");
            var path = @"C:\Windows\media\tada.wav";
            key?.SetValue("", path);

            SoundPlayer player = new SoundPlayer("hotpink.wav");
            player.Play();

            Thread.Sleep(1000);
            Process.Start("https://i.kym-cdn.com/photos/images/newsfeed/000/779/581/e7a.png");



        }
    }
}
