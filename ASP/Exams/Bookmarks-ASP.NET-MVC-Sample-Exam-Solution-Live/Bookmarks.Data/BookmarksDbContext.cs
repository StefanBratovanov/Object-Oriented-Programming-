namespace Bookmarks.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    using Migrations;

    public class BookmarksDbContext : IdentityDbContext<ApplicationUser>, IBookmarksDbContext
    {
        public BookmarksDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksDbContext, Configuration>());
        }

        public static BookmarksDbContext Create()
        {
            return new BookmarksDbContext();
        }


        public IDbSet<Bookmark> Bookmarks { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Vote> Votes { get; set; }
    }
}
