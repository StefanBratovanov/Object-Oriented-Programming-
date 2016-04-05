namespace Bookmarks.Web.InputModels
{
    using Bookmarks.Models;
    using Common.Mappings;

    public class CommentInputModel : IMapTo<Comment>
    {
        public string Content { get; set; }

        public string UserId { get; set; }

        public int BookmarkId { get; set; }
    }
}