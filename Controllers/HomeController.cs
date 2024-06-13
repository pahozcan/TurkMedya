using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TurkMedya.Models;
using TurkMedya.Services;

namespace TurkMedya.Controllers
{
    public class HomeController : Controller
    {
        private readonly TurkMedyaService _turkMedyaService;
        private const int PageSize = 5;

        public HomeController(TurkMedyaService turkMedyaService)
        {
            _turkMedyaService = turkMedyaService;
        }

        public async Task<IActionResult> Index(int page = 1, string category = null, string keyword = null)
        {
            var anasayfaData = await _turkMedyaService.GetAnasayfaDataAsync();
            if (anasayfaData == null)
            {
                return View("Error");
            }

            var filteredData = FilterData(anasayfaData.Data, category, keyword);

            var totalItems = filteredData.Sum(d => d.ItemList.Count);
            var totalPages = (int)Math.Ceiling((double)totalItems / PageSize);
            var startIndex = (page - 1) * PageSize;

            var pagedData = filteredData
                .SelectMany(d => d.ItemList)
                .Skip(startIndex)
                .Take(PageSize)
                .ToList();

            var paginatedModel = new AnasayfaViewModel
            {
                Data = pagedData.Select(item => new DataItem { ItemList = new List<Item> { item } }).ToList(),
                CurrentPage = page,
                PageSize = PageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                ErrorCode = anasayfaData.ErrorCode,
                ErrorMessage = anasayfaData.ErrorMessage
            };

            var categoryTitles = GetCategoryTitles(anasayfaData.Data);
            ViewBag.CategoryTitles = categoryTitles;

            return View(paginatedModel);
        }

        private List<DataItem> FilterData(List<DataItem> data, string category, string keyword)
        {
            bool isCategoryProvided = !string.IsNullOrEmpty(category) && category != "All Categories";
            bool isKeywordProvided = !string.IsNullOrEmpty(keyword);

            if (isCategoryProvided)
            {
                data = data.Where(d => d.ItemList.Any(item =>
                    item.Category != null && item.Category.Title.Equals(category, StringComparison.OrdinalIgnoreCase)
                )).ToList();
            }

            if (isKeywordProvided)
            {
                string normalizedKeyword = keyword.Trim();
                foreach (var dataItem in data)
                {
                    dataItem.ItemList = dataItem.ItemList.Where(item =>
                        item.Title.Contains(normalizedKeyword, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
                }

                data = data.Where(d => d.ItemList.Any()).ToList();
            }

            return data;
        }

        private List<string> GetCategoryTitles(List<DataItem> data)
        {
            return data.SelectMany(d => d.ItemList)
                       .Select(item => item.Category.Title)
                       .Distinct()
                       .ToList();
        }

        public async Task<IActionResult> Detay(string itemId)
        {
            var newsItem = await _turkMedyaService.GetNewsItemAsync(itemId);

            if (newsItem == null)
            {
                return NotFound();
            }

            return View(newsItem);
        }
    }
}
