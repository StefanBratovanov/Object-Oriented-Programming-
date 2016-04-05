using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmarks.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Infrastructure.Caching;
    using ViewModels;

    public class HomeController : BaseController
    {
        private const int HomePageBookmarksNumber = 6;
        private ICacheService cacheService;

        public HomeController(IBookmarksData data, ICacheService cacheService)
            : base(data)
        {
            this.cacheService = cacheService;
        }

        public ActionResult Index()
        {
            var bookmarks = this.cacheService.Bookmarks;

            var homeViewModel = new HomeViewModel()
            {
                Bookmarks = bookmarks
            };

            return this.View(homeViewModel);
        }
    }
}