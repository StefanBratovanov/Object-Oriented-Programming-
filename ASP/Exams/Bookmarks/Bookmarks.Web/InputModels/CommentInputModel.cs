
namespace Bookmarks.Web.InputModels
{
    using Common.Mappings;
    using Bookmarks.Models;

    public class CommentInputModel : IMapTo<Comment>
    {
        public int BookmarkId { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }
    }
}