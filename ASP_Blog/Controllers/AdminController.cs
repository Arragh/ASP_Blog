using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASP_Blog.Models.Home;
using ASP_Blog.Models.Service;
using ASP_Blog.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Blog.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        WebsiteContext websiteDB;
        IWebHostEnvironment _appEnvironment;

        public AdminController(WebsiteContext webContext, IWebHostEnvironment appEnvironment)
        {
            websiteDB = webContext;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Добавление новости [GET]
        [HttpGet]
        public IActionResult AddNews()
        {
            return View();
        }
        #endregion

        #region Добавление новости [POST]
        [HttpPost]
        public async Task<IActionResult> AddNews(AddNewsViewModel model, IFormFileCollection uploads)
        {
            // Проверяем размер каждого изображения
            foreach (var image in uploads)
            {
                if (image.Length > 2097152)
                {
                    ModelState.AddModelError("Image", "Размер изображения должен быть не более 2МБ.");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                News news = new News()
                {
                    Id = Guid.NewGuid(),
                    NewsTitle = model.NewsTitle,
                    NewsBody = model.NewsBody,
                    NewsDate = DateTime.Now,
                    UserName = User.Identity.Name
                };

                // Создаем список изображений
                List<Image> images = new List<Image>();
                foreach (var uploadedImage in uploads)
                {
                    // Присваиваем загружаемому файлу уникальное имя на основе Guid
                    string imageName = Guid.NewGuid() + "_" + uploadedImage.FileName;
                    // Путь сохранения файла
                    string path = "/files/" + imageName;
                    // сохраняем файл в папку files в каталоге wwwroot
                    using (FileStream file = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedImage.CopyToAsync(file);
                    }
                    // Создаем объект класса Image со всеми параметрами
                    Image image = new Image { Id = Guid.NewGuid(), ImageName = imageName, ImagePath = path, TargetId = news.Id };
                    // Добавляем объект класса Image в ранее созданный список images
                    images.Add(image);
                }
                // Сохраняем новые объекты в БД
                await websiteDB.Images.AddRangeAsync(images);
                await websiteDB.News.AddAsync(news);
                await websiteDB.SaveChangesAsync();

                return RedirectToAction("Index", "Admin");
            }

            // Редирект на случай невалидности модели
            return View(model);
        }
        #endregion

        [HttpGet]
        public IActionResult AddGallery()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGallery(AddGalleryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Gallery gallery = new Gallery()
                {
                    Id = Guid.NewGuid(),
                    GalleryTitle = model.GalleryTitle,
                    GalleryDescription = model.GalleryDescription,
                    GalleryDate = DateTime.Now
                };

                await websiteDB.Galleries.AddAsync(gallery);
                await websiteDB.SaveChangesAsync();

                return RedirectToAction("Gallery", "Home", new { galleryId = gallery.Id });
            }
            return View(model);
        }
    }
}
