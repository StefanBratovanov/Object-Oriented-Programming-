
namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmarks { get; set; }

    }
}