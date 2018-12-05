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
                System.IO.Directory.CreateDirectory($@"{user}\Documents\SecretHotPinkFolder");
                client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/cursor.cur"), $@"{user}\Documents\SecretHotPinkFolder\cursor.cur");
                client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/Back.PNG"), $@"{user}\Documents\SecretHotPinkFolder\Back.PNG");
                client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/hotpinkmono.wav"), $@"{user}\Documents\SecretHotPinkFolder\hotpinkmono.wav");
            }

            SoundPlayer player = new SoundPlayer("hotpinkmono.wav");
            player.Play();

            Thread.Sleep(1000);
            
            Thread.Sleep(1000);
            Process.Start("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/Back.PNG");

            //Sets new cursor
            var key1 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            var path1 = $@"{user}\Documents\SecretHotPinkFolder\cursor.cur";
            key1?.SetValue("Arrow", path1);

            Thread.Sleep(1000);
            SystemParametersInfo(0x0014, 0, $@"{user}\Documents\SecretHotPinkFolder\Back.PNG", 0x0001);

            Thread.Sleep(1000);

            Thread.Sleep(1000);

            //Sets new sound on folder navigation
            var key2 = Registry.CurrentUser.CreateSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current");
            var path2 = $@"{user}\Documents\SecretHotPinkFolder\hotpinkmono.wav";
            key2?.SetValue("", path2);

            Thread.Sleep(200000);
        }
    }
}
