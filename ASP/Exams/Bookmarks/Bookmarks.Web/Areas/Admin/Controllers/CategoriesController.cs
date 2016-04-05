
using AutoMapper;
using Bookmarks.Models;

namespace Bookmarks.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data;
    using Web.Controllers;
    using Kendo.Mvc.UI;
    using AutoMapper.QueryableExtensions;
    using ViewModels;
    using Kendo.Mvc.Extensions;

    public class CategoriesController : AdminController
    {
        public CategoriesController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = Data.Categories
                .All()
                .Project()
                .To<CategoryAdminViewModel>();

            return this.Json(data.ToDataSourceResult(request));
        }

        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.Data.Categories.Update(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Data.Categories.Remove(model.Id);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }


    }

}