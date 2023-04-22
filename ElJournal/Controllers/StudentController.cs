using ElJournal.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    [Authorize, Log]
    public class StudentController : Controller
    {
        private ElJournalContext context = new ElJournalContext();
        // GET: Student
        public async Task<ActionResult> Index(string searchString, ElJournalContext context1)
        {
            var user = context.Students.Include(u => u.User).Include(u => u.Group).ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.Group.CodeGroup.Contains(searchString) || s.User.Email.Contains(searchString)).ToList();
                ViewBag.UserId = context.Students.Include(u => u.User).Include(u => u.Group);
                ViewBag.GroupId = context.Students.Include(u => u.User).Include(u => u.Group);
                return View(user.ToList());
            }
            else return View(user.ToList());
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        public ActionResult NewStudent()
        {
            return Redirect("~/StudentUser/Index");
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(context.UserStudent, "IdUserStudents", "Email");
            ViewBag.GroupId = new SelectList(context.Group, "Id", "CodeGroup");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,GroupId")] Students user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Students.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.UserId = new SelectList(context.UserStudent, "IdUserStudents", "Email", user.UserId);
                ViewBag.GroupId = new SelectList(context.Group, "Id", "CodeGroup", user.GroupId);
                return View(user);
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
          

         
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Students user = context.Students.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.UserId = new SelectList(context.AspNetUsers, "Id", "Email", user.UserId);
                ViewBag.GroupId = new SelectList(context.Group, "Id", "CodeGroup", user.GroupId);
                return View(user);
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,GroupId")] Students user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.UserId = new SelectList(context.AspNetUsers, "Id", "Email", user.UserId);
                ViewBag.GroupId = new SelectList(context.Group, "Id", "CodeGroup", user.GroupId);
                return View(user);
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
           
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students user = context.Students.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students user = context.Students.Find(id);
            context.Students.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}