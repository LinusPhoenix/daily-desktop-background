using DailyDesktopBackground.Helper;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace DailyDesktopBackground
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var accessKey = LoadAccessKey();
            var unsplashApi = new UnsplashApiClient(accessKey);
            var photo = await unsplashApi.GetRandomDesktopBackground();
            WallpaperHelper.SetWallpaper(new Uri(photo.Urls.Full));
            unsplashApi.CallDownloadTrackingEndpoint(photo);
        }

        private static string LoadAccessKey()
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DailyDesktopBackground..access-key");
            return new StreamReader(stream).ReadToEnd();
        }
    }
}
