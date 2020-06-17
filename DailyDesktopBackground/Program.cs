using DailyDesktopBackground.Helper;
using System;
using System.IO;
using System.Reflection;

namespace DailyDesktopBackground
{
    public class Program
    {
        public async static void Main(string[] args)
        {
            var accessKey = LoadAccessKey();
            var unsplashApi = new UnsplashApiClient(accessKey);
            var photo = await unsplashApi.GetRandomDesktopBackground();
            WallpaperHelper.SetWallpaper(new Uri(photo.Urls.Full));
            unsplashApi.CallDownloadTrackingEndpoint(photo);
        }

        private static string LoadAccessKey()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("DailyDesktopBackground..access-key"))
            {
                return new StreamReader(stream).ReadToEnd();
            }
        }
    }
}
