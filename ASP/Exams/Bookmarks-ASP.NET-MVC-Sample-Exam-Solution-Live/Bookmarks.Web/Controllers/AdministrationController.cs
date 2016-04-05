namespace Bookmarks.Web.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Data;

    [Authorize(Roles = GlobalConstants.RoleAdministration)]
    public abstract class AdministrationController : BaseController
    {
        protected AdministrationController(IBookmarksData data) : base(data)
        {
        }
    }
}