namespace Bookmarks.Data
{
    using System.Data.Entity;
    using Models;

    public interface IBookmarksDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Bookmark> Bookmarks { get; }

        IDbSet<Comment> Comments { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Vote> Votes { get; }

        int SaveChanges();
    }
}
