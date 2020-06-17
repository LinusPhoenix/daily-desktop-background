using DailyDesktopBackground.Helper;
using System;

namespace DailyDesktopBackground
{
    class Program
    {
        private const string _wallpaper1 =
            "https://images.unsplash.com/photo-1588288522163-375103610bbc?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjE0MjcwNn0&w=1920";
        private const string _wallpaper2 =
            "https://images.unsplash.com/photo-1487837647815-bbc1f30cd0d2?ixlib=rb-1.2.1&q=85&fm=jpg&crop=entropy&cs=srgb&ixid=eyJhcHBfaWQiOjE0MjcwNn0";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WallpaperHelper.SetWallpaper(
                new Uri(_wallpaper2));
        }
    }
}
