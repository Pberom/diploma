using ElJournal.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    [MyAuth]
    public class HomeController : Controller
    {
     
        ElJournalContext context = new ElJournalContext();
        public ActionResult Index()
        {
            var role = new List<AspNetRoles>();
            using (ElJournalContext db = new ElJournalContext())
            {
                role = db.AspNetRoles.ToList();
            }
            return View(role.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Log()
        {
            foreach (var role in context.AspNetRoles)
            {
                //if (role.RoleId == 1)
                //{
                var visitors = new List<Visitor>();
                using (ElJournalContext db = new ElJournalContext())
                {
                    visitors = db.Visitor.ToList();
                }
                return View(visitors.ToList());
                //}
                //else
                //    return Redirect("~/ErrorPage");
                //}
                //return Redirect("~/ErrorPage");
            }
            return Redirect("~/ErrorPage");
        }

        public ActionResult DeleteAll()
        {
            context.Visitor.RemoveRange(context.Visitor);
            context.SaveChanges();
            return Redirect("~/Home");
        }
    }
}