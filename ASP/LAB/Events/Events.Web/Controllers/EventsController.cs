


using System;
using System.Linq;
using Events.Web.Extensions;

namespace Events.Web.Controllers
{
    using System.Web.Mvc;
    using Events.Web.Models;
    using Events.Data;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class EventsController : BaseController
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var e = new Event
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = model.Title,
                    StatrDateTime = model.StatrDateTime,
                    Duration = model.Duration,
                    Description = model.Description,
                    Location = model.Location,
                    IsPublic = model.IsPublic
                };

                this.db.Events.Add(e);
                this.db.SaveChanges();
                this.AddNotification("Event crated.", NotificationType.INFO);

                return this.RedirectToAction("My");
            }

            return View();
        }


        public ActionResult My()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var events = this.db.Events
                .Where(e => e.AuthorId == currentUserId)
                .OrderBy(e => e.StatrDateTime)
                .Select(EventViewModel.ViewModel);

            var upcommingE = events.Where(e => e.StatrDateTime > DateTime.Now);
            var pastE = events.Where(e => e.StatrDateTime <= DateTime.Now);

            return View(new UpcomingPassedEventsViewModel()
            {
                UpcomingEvents = upcommingE,
                PassedEvents = pastE
            });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var eventToEdit = this.LoadEvent(id);
            if (eventToEdit == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }

            //var model = EventInputModel.CreateFromEvent(eventToEdit);

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventInputModel model)
        {
            var eventToEdit = this.LoadEvent(id);
            if (eventToEdit == null)
            {
                this.AddNotification("Cannot edit event #" + id, NotificationType.ERROR);
                return this.RedirectToAction("My");
            }

            if (model != null && this.ModelState.IsValid)
            {
                eventToEdit.Title = model.Title;
                eventToEdit.StatrDateTime = model.StatrDateTime;
                eventToEdit.Duration = model.Duration;
                eventToEdit.Description = model.Description;
                eventToEdit.Location = model.Location;
                eventToEdit.IsPublic = model.IsPublic;

                this.db.SaveChanges();
                this.AddNotification("Even edited", NotificationType.INFO);
                return this.RedirectToAction("My");
            }

            return this.View(model);
        }

        private Event LoadEvent(int id)
        {
            var currUserId = this.User.Identity.GetUserId();
            var isAdmin = this.isAdmin();
            var eventToEdit = this.db.Events
                .Where(e => e.Id == id)
                .FirstOrDefault(e => e.AuthorId == currUserId || isAdmin);

            return eventToEdit;
        }
    }
}