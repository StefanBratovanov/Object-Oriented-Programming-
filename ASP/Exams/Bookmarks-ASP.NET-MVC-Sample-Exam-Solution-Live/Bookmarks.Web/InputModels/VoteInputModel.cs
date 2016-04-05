namespace Bookmarks.Web.InputModels
{
    using Bookmarks.Models;
    using Common.Mappings;

    public class VoteInputModel : IMapTo<Vote>
    {
        public string UserId { get; set; }

        public int BookmarkId { get; set; }
    }
}