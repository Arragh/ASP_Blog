using ASP_Blog.Models.Home;
using ASP_Blog.Models.Service;
using ASP_Blog.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Blog.Controllers
{
    public class HomeController : Controller
    {
        private WebsiteContext websiteDB;

        public HomeController(WebsiteContext websiteContext)
        {
            websiteDB = websiteContext;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            IQueryable<News> source = websiteDB.News;
            List<News> news = await source.OrderByDescending(n => n.NewsDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            int newsCount = await source.CountAsync();

            List<Image> images = await websiteDB.Images.ToListAsync();

            IndexViewModel model = new IndexViewModel()
            {
                News = news,
                Images = images,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(newsCount / (double)pageSize)
            };

            return View(model);
        }
    }
}
