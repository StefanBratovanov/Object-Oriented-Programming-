using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookmarks.Web.Infrastructure.Caching
{
    using Areas.Admin.ViewModels;
    using ViewModels;

    public interface ICacheService
    {
        IList<BookmarkViewModel> Bookmarks { get; } 
    }
}