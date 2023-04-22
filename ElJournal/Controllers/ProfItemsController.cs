using ElJournal.Filter;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    [Authorize, Log]
    public class ProfItemsController : Controller
    {
        private ElJournalContext context = new ElJournalContext();
        // GET: ProfItems
        public ActionResult Index()
        {
            var user = context.ProfessorsItem.Include(u => u.Professor).Include(u => u.Item);
            return View(user.ToList());
        }

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ProfessorsItem user = context.ProfessorsItem.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        public ActionResult Create()
        {
            ViewBag.ProfessorId = new SelectList(context.Professor, "Id", "F");
            ViewBag.ItemId = new SelectList(context.NameItem, "Id", "NameItem1");
            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProfessorId,ItemId")] ProfessorsItem user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.ProfessorsItem.Add(user);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ProfessorId = new SelectList(context.Professor, "Id", "F", user.ProfessorId);
                ViewBag.ItemId = new SelectList(context.NameItem, "Id", "NameItem1", user.ItemId);
                return View(user);
            }
            catch (System.Exception)
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
                ProfessorsItem user = context.ProfessorsItem.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ProfessorId = new SelectList(context.Professor, "Id", "F", user.ProfessorId);
                ViewBag.ItemId = new SelectList(context.NameItem, "Id", "NameItem1", user.ItemId);
                return View(user);
            }
            catch (System.Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
          
        }

        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProfessorId,ItemId")] ProfessorsItem user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ProfessorId = new SelectList(context.Professor, "Id", "F", user.ProfessorId);
                ViewBag.ItemId = new SelectList(context.NameItem, "Id", "NameItem1", user.ItemId);
                return View(user);
            }
            catch (System.Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
          
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorsItem user = context.ProfessorsItem.Find(id);
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
            ProfessorsItem user = context.ProfessorsItem.Find(id);
            context.ProfessorsItem.Remove(user);
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