using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DailyDesktopBackground.Models
{
    public class PhotoLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
        [JsonPropertyName("html")]
        public string Html { get; set; }
        [JsonPropertyName("download")]
        public string Download { get; set; }
        [JsonPropertyName("download_location")]
        public string DownloadLocation { get; set; }
    }
}
