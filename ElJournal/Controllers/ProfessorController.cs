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
    public class ProfessorController : Controller
    {
        // GET: Professor
        private ElJournalContext context = new ElJournalContext();
        public async Task<ActionResult> Index(string searchString, ElJournalContext context1)
        {
            var searchSpace = from m in context1.Professor
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchSpace = searchSpace.Where(s => s.F.Contains(searchString) || s.I.Contains(searchString));
            }
            return View(await searchSpace.ToListAsync());
        }

        public ActionResult NewProfItems()
        {
            return Redirect("~/ProfItems/Index");
        }

        // GET: Evaluation/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
           
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        // POST: NameItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,F,I,O")] Professor nameItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Professor.Add(nameItem);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(nameItem);
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
        
        }

        // GET: NameItem/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Professor nameItem = context.Professor.Find(id);
                if (nameItem == null)
                {
                    return HttpNotFound();
                }
                return View(nameItem);
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage"); 
            }
           
        }

        // POST: NameItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,F,I,O")] Professor nameItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(nameItem).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(nameItem);
            }
            catch (Exception)
            {
                return Redirect("~/Professor/ErrorPage");
            }
        }

        // GET: NameItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor nameItem = context.Professor.Find(id);
            if (nameItem == null)
            {
                return HttpNotFound();
            }
            return View(nameItem);
        }

        // POST: Evaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor nameItem = context.Professor.Find(id);
            context.Professor.Remove(nameItem);
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