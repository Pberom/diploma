using ElJournal.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    [Authorize, Log]
    public class GroupController : Controller
    {
        private ElJournalContext context = new ElJournalContext();
        // GET: Evaluation
        public async Task<ActionResult> Index(string searchString, ElJournalContext context1)
        {
            var movies = from m in context1.Group
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.NameGroup.Contains(searchString) || s.CodeGroup.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        // POST: Groups/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodeGroup,NameGroup")] Group groups)
        {
            try
            {
                if ((groups.CodeGroup != null) && (groups.NameGroup != null))
                {
                    if (ModelState.IsValid)
                    {
                        context.Group.Add(groups);
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else return View(groups);
                }
                else return Redirect("~/Professor/ErrorPage");
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");

            }

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
                Group groups = context.Group.Find(id);
                if (groups == null)
                {
                    return HttpNotFound();
                }
                return View(groups);
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
          
        }

        // POST: Groups/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodeGroup,NameGroup")] Group groups)
        {
            try
            {
                if ((groups.CodeGroup != null) && (groups.NameGroup != null))
                {
                    if (ModelState.IsValid)
                    {
                        context.Entry(groups).State = EntityState.Modified;
                        context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(groups);
                }
                return Redirect("~/Professor/ErrorPage");
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
          
        }



        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group groups = context.Group.Find(id);
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
            Group groups = context.Group.Find(id);
            context.Group.Remove(groups);
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