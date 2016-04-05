using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookmarks.Web.Areas.Admin.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Bookmarks.Models;
    using Data;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using ViewModels;
    using Web.Controllers;

    public class CategoriesController : AdministrationController
    {
        public CategoriesController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var categories = this.Data.Categories
                .All()
                .Project()
                .To<CategoryKendoViewModel>();
            return this.Json(categories.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, CategoryKendoViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] {model}.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, CategoryKendoViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.Data.Categories.All().FirstOrDefault(x => x.Id == model.Id);
                if (category != null)
                {
                    category.Name = model.Name;
                }

                this.Data.Categories.Update(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest]DataSourceRequest request, CategoryKendoViewModel model)
        {
            this.Data.Categories.Delete(model.Id);
            this.Data.SaveChanges();

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}