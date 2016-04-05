
namespace Bookmarks.Web.InputModels
{
    using Common;
    using Common.Mappings;
    using System.ComponentModel.DataAnnotations;
    using Bookmarks.Models;

    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.ReqiredValidationMessage)]
        [StringLength(200, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.ReqiredValidationMessage)]
        [StringLength(200, ErrorMessage = GlobalConstants.StringLengthValidationMessage)]
        [Url(ErrorMessage = "The {0} is invalid!")]
        public string URL { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

    }
}