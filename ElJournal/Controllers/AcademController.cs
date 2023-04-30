using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    public class AcademController : Controller
    {
        ElJournalContext context = new ElJournalContext();
        // GET: Academ
        public ActionResult Index()
        {
            return View(context.Academ);
        }

        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}