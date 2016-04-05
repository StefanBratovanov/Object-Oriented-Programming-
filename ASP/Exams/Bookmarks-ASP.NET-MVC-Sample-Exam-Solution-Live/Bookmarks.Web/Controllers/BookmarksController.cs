using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmarks.Web.Controllers
{
    using System.Data.Entity;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Bookmarks.Models;
    using Data;
    using InputModels;
    using Microsoft.AspNet.Identity;
    using PagedList;
    using ViewModels;

    [Authorize]
    public class BookmarksController : BaseController
    {
        private const int DefaultPageSize = 6;
        private const int DefaultPageNumber = 1;

        public BookmarksController(IBookmarksData data) : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var bookmarks = this.Data.Bookmarks
                .All()
                .OrderBy(x => x.Title)
                .Project()
                .To<BookmarkViewModel>()
                .ToPagedList(page ?? DefaultPageNumber, DefaultPageSize);

            return this.View(bookmarks);
        }

        public ActionResult Details(int id)
        {
            var bookmark = this.Data.Bookmarks
                .All()
                .Where(x => x.Id == id)
                .Project()
                .To<BookmarkDetailsViewModel>()
                .FirstOrDefault();

            if (bookmark != null)
            {
                return this.View(bookmark);
            }

            // TODO: Add error
            return this.RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            this.LoadCategories();
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarkInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var bookmark = Mapper.Map<Bookmark>(model);
                this.Data.Bookmarks.Add(bookmark);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = bookmark.Id });
            }

            this.LoadCategories();
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.UserId = this.User.Identity.GetUserId();
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentViewModel = this.Data.Comments
                    .All()
                    .Where(x => x.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentViewModel);
            }

            return this.Json(this.ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(VoteInputModel model)
        {
            if (this.Data.Votes.All().Any(x => x.BookmarkId == model.BookmarkId && x.UserId == model.UserId))
            {
                this.ModelState.AddModelError(string.Empty, "The user has already vote for this bookmark.");
            }

            if (model != null && this.ModelState.IsValid)
            {
                var vote = Mapper.Map<Vote>(model);
                vote.Value = 1;

                this.Data.Votes.Add(vote);
                this.Data.SaveChanges();

                var votesCount = this.Data.Votes
                    .All()
                    .Where(x => x.BookmarkId == model.BookmarkId)
                    .Sum(x => x.Value);
                return this.Content(votesCount.ToString());
            }

            return this.Json(this.ModelState, JsonRequestBehavior.AllowGet);
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = this.Data.Categories
                .All()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                });
        }
    }
}