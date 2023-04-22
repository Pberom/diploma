using ElJournal.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    [Authorize, Log]
    public class NameItemController : Controller
    {
            // GET: NameItem
            private ElJournalContext context = new ElJournalContext();
            public ActionResult Index()
            {
                return View(context.NameItem.ToList());
            }
            
                 // GET: Evaluation/Create
            public ActionResult Create()
            {
                return View();
            }


            // POST: NameItem/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id,NameItem1")] NameItem nameItem)
            {
            try
            {
                if (ModelState.IsValid)
                {
                    context.NameItem.Add(nameItem);
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

        public ActionResult ErrorPage()
        {
            return View();
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
                NameItem nameItem = context.NameItem.Find(id);
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
            public ActionResult Edit([Bind(Include = "Id,NameItem1")] NameItem nameItem)
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
                NameItem nameItem = context.NameItem.Find(id);
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
                NameItem nameItem = context.NameItem.Find(id);
                context.NameItem.Remove(nameItem);
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