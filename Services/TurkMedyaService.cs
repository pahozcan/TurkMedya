using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TurkMedya.Models;

namespace TurkMedya.Services
{
    public class TurkMedyaService
    {
        private readonly HttpClient _httpClient;

        public TurkMedyaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Anasayfa> GetAnasayfaDataAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Anasayfa>("https://www.turkmedya.com.tr/anasayfa.json");
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("Error fetching Anasayfa data", ex);
            }
        }

        public async Task<DetayViewModel> GetNewsItemAsync(string itemId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://www.turkmedya.com.tr/detay.json");
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadFromJsonAsync<DetayResponse>();

                if (data != null && data.Data != null && data.Data.NewsDetail != null)
                {
                    var newsDetail = data.Data.NewsDetail;

                    if (newsDetail.ItemId == itemId)
                    {
                        return new DetayViewModel
                        {
                            Id = newsDetail.ItemId,
                            Title = newsDetail.Title,
                            BodyText = newsDetail.BodyText,
                            HasPhotoGallery = newsDetail.HasPhotoGallery,
                            HasVideo = newsDetail.HasVideo,
                            PublishDate = newsDetail.PublishDate,
                            FullPath = newsDetail.FullPath,
                            ImageUrl = newsDetail.ImageUrl,

                        };
                    }
                }

                return null;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error retrieving news item from API.", ex);
            }
        }




        public class DetayResponse
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public DetayData Data { get; set; }
        }

        public class DetayData
        {
            public NewsDetail NewsDetail { get; set; }
        }

        public class NewsDetail
        {
            public string ItemId { get; set; }
            public string Title { get; set; }
            public string BodyText { get; set; }
            public bool HasPhotoGallery { get; set; }
            public bool HasVideo { get; set; }
            public string PublishDate { get; set; }
            public string FullPath { get; set; }
            public string ImageUrl { get; set; }
            public Category Category { get; set; }
            public List<RelatedNewsItem> RelatedNews { get; set; }
        }

        public class Category
        {
            public string CategoryId { get; set; }
            public string Title { get; set; }
            public string Slug { get; set; }
            public string Color { get; set; }
        }

    }
}
