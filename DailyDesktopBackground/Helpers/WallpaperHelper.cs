using System;
using System.IO;
using System.Runtime.InteropServices;
using ImageMagick;
using Microsoft.Win32;

namespace DailyDesktopBackground.Helper
{
    public class WallpaperHelper
    {
        /// <summary>
        /// uiAction Desktop parameter for setting the desktop wallpaper.
        /// </summary>
        const int SPI_SETDESKWALLPAPER = 0x0014;

        /// <summary>
        /// fWinIni parameter to save the changed setting in the user profile.
        /// </summary>
        const int SPIF_UPDATEINIFILE = 0x01;

        /// <summary>
        /// fWinIni parameter to send a WM_SETTINGCHANGE message after updating the user profile.
        /// </summary>
        const int SPIF_SENDWININICHANGE = 0x02;

        /// <summary>
        /// This wallpaper style enlarges/shrinks the image keeping the original aspect ratio to fit the screen.
        /// </summary>
        const int WALLPAPER_STYLE_FILL = 10;

        /// <summary>
        /// External call to user32.dll that can set a variety of system parameters, in this case we
        /// use it to set the desktop wallpaper.
        /// </summary>
        /// <param name="uiAction">Specifies the parameter we are setting, in this case SPI_SETDESKWALLPAPER</param>
        /// <param name="uiParam">Used by some uiAction parameters, in this case we always use 0</param>
        /// <param name="pvParam"></param>
        /// <param name="fWinIni"></param>
        /// <returns>When setting the desktop wallpaper, this always returns true unless there is an error.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uiAction, int uiParam, string pvParam, int fWinIni);

        /// <summary>
        /// Changes the current user's desktop wallpaper by replacing the old one and overwriting the registry.
        /// The wallpaper will be saved in the bmp format with no tiling and a "Fill" wallpaper style.
        /// </summary>
        /// <param name="uri">Uri to the new desktop wallpaper</param>
        public static void SetWallpaper(Uri uri)
        {
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            using (var image = DownloadImage(uri))
            {
                image.Write(tempPath, MagickFormat.Bmp);
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", WALLPAPER_STYLE_FILL.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        private static MagickImage DownloadImage(Uri uri)
        {
            using var stream = new System.Net.WebClient().OpenRead(uri.ToString());
            return new MagickImage(stream);
        }
    }
}
