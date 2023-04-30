using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    public class PracticeController : Controller
    {
        ElJournalContext ElJournalContext = new ElJournalContext();
        public ActionResult Index()
        {
            return View(ElJournalContext.Practice);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPractice,NumberPractice,NamePractice,DatePlacePractice,FioprepodPractic")] Practice groups)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ElJournalContext.Practice.Add(groups);
                    ElJournalContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(groups);
            }
            catch (Exception)
            {
                return Redirect("~/Practice/ErrorPage");
            }

        }
    }
}