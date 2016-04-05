namespace Bookmarks.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using Bookmarks.Models;
    using Common.Mappings;

    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required!")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "The {0} should be between {2} {1}.")]
        public string Title { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required!")]
        [Url(ErrorMessage = "The {0} is invalid!")]
        public string Url { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The {0} is required!")]
        public int CategoryId { get; set; }

    }
}