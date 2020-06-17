using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DailyDesktopBackground.Models
{
    public class UnsplashPhoto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("urls")]
        public PhotoUrls Urls { get; set; }
        [JsonPropertyName("links")]
        public PhotoLinks Links { get; set; }
    }
}
