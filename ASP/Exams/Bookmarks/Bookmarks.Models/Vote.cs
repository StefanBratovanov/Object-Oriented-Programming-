using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Models
{
    public class Vote
    {
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmarks { get; set; }
    }
}