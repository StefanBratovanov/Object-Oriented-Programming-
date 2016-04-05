namespace Bookmarks.Web.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Mappings;
    using Bookmarks.Models;

    public class CategoryKendoViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Length!")]
        public string Name { get; set; }
    }
}