﻿using ASP_Blog.Models.Home;
using ASP_Blog.Models.Service;
using ASP_Blog.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        #region Index
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            IQueryable<News> source = websiteDB.News;
            List<News> news = await source.OrderByDescending(n => n.NewsDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            int newsCount = await source.CountAsync();

            List<ImageFile> images = await websiteDB.Images.ToListAsync();

            IndexViewModel model = new IndexViewModel()
            {
                News = news,
                Images = images,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(newsCount / (double)pageSize)
            };

            IQueryable<Guid> arr = websiteDB.Comments.Select(c => c.NewsId);
            ViewBag.Comments = arr;

            return View(model);
        }
        #endregion

        #region Просмотр комментариев
        [HttpGet]
        public async Task<IActionResult> ViewComments(Guid newsId, int pageNumber = 1)
        {
            News news = websiteDB.News.First(n => n.Id == newsId);

            int pageSize = 10;
            IQueryable<Comment> source = websiteDB.Comments.Where(c => c.NewsId == newsId);
            List<Comment> comments = await source.OrderByDescending(c => c.CommentDate).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            int commentsCount = await source.CountAsync();

            ViewCommentsViewModel model = new ViewCommentsViewModel()
            {
                News = news,
                Comments = comments,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(commentsCount / (double)pageSize)
            };

            return View(model);
        }
        #endregion

        #region Добавление комментария [GET]
        [HttpGet]
        public IActionResult AddComment(Guid newsId)
        {
            ViewBag.NewsId = newsId;
            return View();
        }
        #endregion

        #region Добавление комментария [POST]
        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment()
                {
                    Id = Guid.NewGuid(),
                    CommentBody = model.CommentBody,
                    CommentDate = DateTime.Now,
                    NewsId = model.TargetId,
                    UserName = User.Identity.Name
                };

                await websiteDB.Comments.AddAsync(comment);
                await websiteDB.SaveChangesAsync();

                return RedirectToAction("ViewComments", "Home", new { newsId = model.TargetId });
            }
            return View(model);
        }
        #endregion

        #region Список галерей
        public async Task<IActionResult> Galleries()
        {
            List<Gallery> galleries = await websiteDB.Galleries.OrderByDescending(g => g.GalleryDate).ToListAsync();
            return View(galleries);
        }
        #endregion

        #region Просмотр галереи
        public async Task<IActionResult> Gallery(Guid galleryId)
        {
            Gallery gallery = websiteDB.Galleries.First(g => g.Id == galleryId);

            List<ImageFile> images = await websiteDB.Images.Where(i => i.TargetId == galleryId).ToListAsync();

            GalleryViewModel model = new GalleryViewModel()
            {
                GalleryId = gallery.Id,
                GalleryTitle = gallery.GalleryTitle,
                GalleryDescription = gallery.GalleryDescription,
                Images = images
            };

            return View(model);
        }
        #endregion
    }
}
