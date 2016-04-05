using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Bookmark> bookmarks;

        public Category()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }
}
