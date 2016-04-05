using System.Collections.Generic;
using Bookmarks.Web.ViewModels;

namespace Bookmarks.Web.Infrastructure
{
    public interface ICacheService
    {
        IList<BookmarkViewModel> Bookmars { get; }
    }
}