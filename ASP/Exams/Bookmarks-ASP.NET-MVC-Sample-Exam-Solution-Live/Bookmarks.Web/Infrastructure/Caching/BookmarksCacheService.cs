using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookmarks.Web.Infrastructure.Caching
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using ViewModels;

    public class BookmarksCacheService : BaseCacheService, ICacheService
    {
        private readonly IBookmarksData data;

        public BookmarksCacheService(IBookmarksData data)
        {
            this.data = data;
        }

           

        public IList<BookmarkViewModel> Bookmarks
        {
            get
            {
                return this.Get<IList<BookmarkViewModel>>("Bookmarks", () =>
                {
                    return this.data.Bookmarks
                        .All()
                        .OrderByDescending(x => x.Votes.Sum(v => v.Value))
                        .Take(6)
                        .Project()
                        .To<BookmarkViewModel>()
                        .ToList();
                });
            }
        }
    }
}