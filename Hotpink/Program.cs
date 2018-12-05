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
                client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/cursor.cur"), $@"{user}\Documents\cursor.cur");
                client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/Back.PNG"), $@"{user}\Documents\Back.PNG");
                client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/hotpink.wav"), $@"{user}\Documents\hotpink.wav");
            }

            Thread.Sleep(1000);

            SoundPlayer player = new SoundPlayer("hotpink.wav");
            player.Play();

            Thread.Sleep(1000);

            //Sets new cursor
            var key1 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors\Arrow");
            var path1 = $@"{user}\Documents\cursor.cur";
            key1?.SetValue("", path1);

            Thread.Sleep(1000);
            Process.Start("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/Back.PNG");

            Thread.Sleep(1000);
            SystemParametersInfo(0x0014, 0, $@"{user}\Documents\Back.PNG", 0x0001);

            


            //Sets new sound on folder navigation
            var key2 = Registry.CurrentUser.CreateSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current");
            var path2 = $@"{user}\Documents\hotpink.wav";
            key2?.SetValue("", path2);

            Thread.Sleep(200000);
        }
    }
}
