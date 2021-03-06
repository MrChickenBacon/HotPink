﻿using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
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

            var location = $@"{user}\Documents\SecretHotPinkFolder";

            //Folder exist=Skip
            //Does not exist=Create and dl files.
            try
            {
                if (!Directory.Exists(location))
                {
                    using (WebClient client = new WebClient())
                    {
                        System.IO.Directory.CreateDirectory($@"{user}\Documents\SecretHotPinkFolder");
                        client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/cursor.cur"), $@"{user}\Documents\SecretHotPinkFolder\cursor.cur");
                        client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/Back.PNG"), $@"{user}\Documents\SecretHotPinkFolder\Back.PNG");
                        client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/hot.PNG"), $@"{user}\Documents\SecretHotPinkFolder\hot.PNG");
                        client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/pink.PNG"), $@"{user}\Documents\SecretHotPinkFolder\pink.PNG");
                        client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/load2.ani"), $@"{user}\Documents\SecretHotPinkFolder\load2.ani");
                        client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/startup.wav"), $@"{user}\Documents\SecretHotPinkFolder\startup.wav");
                        client.DownloadFile(new Uri("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/hotpinkmono.wav"), $@"{user}\Documents\SecretHotPinkFolder\hotpinkmono.wav");
                    }
                }
            }
            catch (Exception)
            {
                //Fail silently.
            }

            Thread.Sleep(1000);

            //Plays audio from resource
            SoundPlayer player = new SoundPlayer(Properties.Resources.hotpinkmono);
            player.Play();

            Thread.Sleep(1000);

            //Sets new cursor
            var key1 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            var path1 = $@"{user}\Documents\SecretHotPinkFolder\cursor.cur";
            key1?.SetValue("Arrow", path1);

            //Sets new cursor animation1
            var key3 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            var path3 = $@"{user}\Documents\SecretHotPinkFolder\load2.ani";
            key3?.SetValue("AppStarting", path3);

            //Sets new cursor animation2
            var key4 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
            var path4 = $@"{user}\Documents\SecretHotPinkFolder\load2.ani";
            key4?.SetValue("Wait", path4);

            ////Enable startup sound
            //var key7 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\BootAnimation", true);
            //var path7 = "0";
            //key7.SetValue("DisableStartupSound", path7, RegistryValueKind.DWord);

            ////Sets custom startupsound to be avaiable
            //var key6 = Registry.CurrentUser.CreateSubKey(@"AppEvents\EventLabels\WindowsLogon");
            //var path6 = "0";
            //key6.SetValue("ExcludeFromCPL", path6);

            ////Sets new logon sound
            //var key5 = Registry.CurrentUser.CreateSubKey(@"AppEvents\Schemes\Apps\.Default\WindowsLogon\.Current");
            //var path5 = $@"{user}\Documents\SecretHotPinkFolder\startup.wav";
            //key5.SetValue("", path5);

            Thread.Sleep(9300);
            Process.Start("https://github.com/MrChickenBacon/HotPink/raw/master/Hotpink/Back.PNG");
            Thread.Sleep(5300);
            //New desktop background
            SystemParametersInfo(0x0014, 0, $@"{user}\Documents\SecretHotPinkFolder\Back.PNG", 0x0001);

            //Sets new sound on folder navigation
            var key2 = Registry.CurrentUser.CreateSubKey(@"AppEvents\Schemes\Apps\Explorer\Navigating\.Current");
            var path2 = $@"{user}\Documents\SecretHotPinkFolder\hotpinkmono.wav";
            key2?.SetValue("", path2);

            //Sets new sound on folder navigation
            var key8 = Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse");
            key8?.SetValue("MouseTrails", "10");

            Thread.Sleep(3000);

            Thread.Sleep(1100);

            Thread.Sleep(190);
            Process.Start($@"{user}\Documents\SecretHotPinkFolder\hot.PNG");
            Thread.Sleep(190);
            Process.Start($@"{user}\Documents\SecretHotPinkFolder\hot.PNG");
            Thread.Sleep(190);
            Process.Start($@"{user}\Documents\SecretHotPinkFolder\hot.PNG");
            Thread.Sleep(100);
            Process.Start($@"{user}\Documents\SecretHotPinkFolder\pink.PNG");





            Thread.Sleep(1000);



            Thread.Sleep(8000);
        }
    }
}
