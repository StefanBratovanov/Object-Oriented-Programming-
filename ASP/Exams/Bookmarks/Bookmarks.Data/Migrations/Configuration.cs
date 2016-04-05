namespace Bookmarks.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Bookmarks.Data.BookmarksDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "Bookmarks.Data.ApplicationDbContext";
        }

        protected override void Seed(Bookmarks.Data.BookmarksDbContext context)
        {
            
        }
    }
}
