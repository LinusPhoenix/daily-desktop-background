using DailyDesktopBackground.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DailyDesktopBackground.Helper
{
    public class UnsplashApiClient
    {
        private const string DESKTOP_BACKGROUND_ENDPOINT = @"https://api.unsplash.com/photos/random?query=desktop%20background&orientation=landscape";

        private readonly HttpClient _client;

        private string AccessKey { get; set; }

        public UnsplashApiClient(string accessKey)
        {
            AccessKey = accessKey;
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization", $"Client-ID {AccessKey}");
        }

        /// <summary>
        /// Searches for a random "desktop background" image with landscape orientation.
        /// </summary>
        public async Task<UnsplashPhoto> GetRandomDesktopBackground()
        {
            var response = await _client.GetAsync(DESKTOP_BACKGROUND_ENDPOINT);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UnsplashPhoto>(jsonString);
        }

        /// <summary>
        /// When downloading a photo from Unsplash, clients are expected to call the download endpoint for tracking purposes.
        /// This method sends a GET request to that endpoint for the given photo asynchronously but returns immediately
        /// since we do not care about the result.
        /// </summary>
        public void CallDownloadTrackingEndpoint(UnsplashPhoto photo)
        {
            var endpointUrl = photo.Links.DownloadLocation;
            _client.GetAsync(endpointUrl);
        }
    }
}
