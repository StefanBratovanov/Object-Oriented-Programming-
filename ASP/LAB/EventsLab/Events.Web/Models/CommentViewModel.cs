
namespace Events.Web.Models
{

    using System.Linq;
    using Data;
    using System;
    using System.Linq.Expressions;

    public class CommentViewModel
    {
        public string Text { get; set; }

        public string Author { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> ViewModel
        {
            get
            {
                return e => new CommentViewModel()
                {
                    Text = e.Text,
                    Author = e.Author.FullName,
                };
            }
        }
    }
}