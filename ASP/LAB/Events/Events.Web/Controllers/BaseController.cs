


namespace Events.Web.Controllers
{
    using System.Web.Mvc;
    using Data;
    using Microsoft.AspNet.Identity;

    [ValidateInput(false)]
    public class BaseController : Controller
    {
        // GET: Base
        protected ApplicationDbContext db = new ApplicationDbContext();

        public bool isAdmin()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = (currentUserId != null && this.User.IsInRole("Administrator"));

            return isAdmin;
        }
    }
}