using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Adware
{
    internal static class Program
    {
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr WindowHandle, NCmdShow nCmdShow);

        private static readonly Dictionary<string, string> PageTitleParts = new Dictionary<string, string>
        {
            { "garden", "https://play.google.com/store/apps/details?id=com.mortens.kertmester" },
            { "developer", "https://github.com/Mortens4444" }
        };

        static void Main()
        {
            ShowWindow(Process.GetCurrentProcess().MainWindowHandle, NCmdShow.SW_HIDE);

            var advertisementOpener = new AdvertisementOpener(PageTitleParts);
            while (true)
            {
                var advertisementOpened = advertisementOpener.OpenUnwantedAdvertisements();
                Thread.Sleep(advertisementOpened ? (int)TimeSpan.FromHours(1).TotalMilliseconds : 1000);
            }
        }
    }
}
