
namespace Bookmarks.Web.Infrastructure
{
    using System.Collections.Generic;
    using ViewModels;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Common;
    using Data;

    public class MyCacheServise : BaseCacheService, ICacheService
    {
        private IBookmarksData data;

        public MyCacheServise(IBookmarksData data)
        {
            this.data = data;
        }

        public IList<BookmarkViewModel> Bookmars
        {
            get
            {
                return this.Get<IList<BookmarkViewModel>>("homePageBookmarks", () =>
                {
                    return this.data.Bookmarks
                        .All()
                        .OrderByDescending(x => x.Votes.Count())
                        .Take(GlobalConstants.HomePageNumberBookmarks)
                        .Project()
                        .To<BookmarkViewModel>()
                        .ToList();
                });
            }
        }
    }
}