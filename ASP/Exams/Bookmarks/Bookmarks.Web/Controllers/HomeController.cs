

namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Common;
    using ViewModels;
    using System.Web.Mvc;
    using Data;
    using Infrastructure;

    public class HomeController : BaseController
    {
        private ICacheService cacheService;

        public HomeController(IBookmarksData data, ICacheService cacheService)
            : base(data)
        {
            this.cacheService = cacheService;
        }

        public ActionResult Index()
        {
            var bookmarks = this.cacheService.Bookmars;

            //var bookmarks = this.Data.Bookmarks
            //    .All()
            //    .OrderByDescending(x => x.Votes.Count())
            //    .Take(GlobalConstants.HomePageNumberBookmarks)
            //    .Project()
            //    .To<BookmarkViewModel>();

            return View(bookmarks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}