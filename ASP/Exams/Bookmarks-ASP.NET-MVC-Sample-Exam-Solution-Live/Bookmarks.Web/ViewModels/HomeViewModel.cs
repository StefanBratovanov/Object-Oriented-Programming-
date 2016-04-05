using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookmarks.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<BookmarkViewModel> Bookmarks { get; set; }
    }
}