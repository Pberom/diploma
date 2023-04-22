using ElJournal.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    [Authorize, Log]
    public class StudentUserController : Controller
    {
        private ElJournalContext context = new ElJournalContext();

        public ElJournalContext GetContext()
        {
            return context;
        }

        public ActionResult ErrorPage() {
        return View();
        }
        // GET: Evaluation
        public async Task<ActionResult> Index(string searchString, ElJournalContext context1)
        {
            var searchSpace = from m in context1.UserStudent
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchSpace = searchSpace.Where(s => s.Email.Contains(searchString) || 
                s.NameS.Contains(searchString) || s.NameS.Contains(searchString) ||
                s.MiddleS.Contains(searchString) || s.SecondS.Contains(searchString));
            }

            return View(await searchSpace.ToListAsync());
        }

        // GET: Groups/UserStudent/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStudent groups = context.UserStudent.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Groups/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUserStudents,NameS,SecondS,MiddleS,Email,OtherEmail")] UserStudent groups)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.UserStudent.Add(groups);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(groups);
            }
           catch
            {
                return Redirect("~/StudentUser/ErrorPage");
            }
        }

        public ActionResult NewGroup()
        {
            return Redirect("~/Student/Index");
        }
        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UserStudent groups = context.UserStudent.Find(id);
                if (groups == null)
                {
                    return HttpNotFound();
                }
                return View(groups);
            }
            catch (Exception)
            {
                return Redirect("~/StudentUser/ErrorPage");
            }
          
        }

        // POST: Groups/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUserStudents,NameS,SecondS,MiddleS,Email,OtherEmail")] UserStudent groups)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(groups).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(groups);
            }
            catch (Exception)
            {
                return Redirect("~/StudentUser/ErrorPage");
            }
          
        }

        // GET: StudentUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStudent groups = context.UserStudent.Find(id);
            if (groups == null)
            {
                return HttpNotFound();
            }
            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserStudent groups = context.UserStudent.Find(id);
            context.UserStudent.Remove(groups);
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