using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DailyDesktopBackground.Models
{
    public class PhotoUrls
    {
        [JsonPropertyName("raw")]
        public string Raw { get; set; }
        [JsonPropertyName("full")]
        public string Full { get; set; }
        [JsonPropertyName("regular")]
        public string Regular { get; set; }
        [JsonPropertyName("small")]
        public string Small { get; set; }
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }
    }
}
