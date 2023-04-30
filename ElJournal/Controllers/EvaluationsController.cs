using ElJournal.Filter;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ElJournal.Controllers
{
    [Authorize, Log]
    public class EvaluationsController : Controller
    {
        private ElJournalContext context = new ElJournalContext();
        public ActionResult Index()
        {
            var user = context.Evaluation.Include(u => u.Student.User).Include(u => u.CodeProfessorItem.Item).Include(u => u.Semestr);
            return View(user.ToList());
        }

        public ActionResult EmailRequest()
        {
            ViewBag.ListStudents = context.Students.Include(u => u.User);
            ViewBag.ListProfesserItem = context.ProfessorsItem.Include(u => u.Item);
            ViewBag.StudentId = new SelectList(context.Students.Include(u => u.User), "Id", "StudentId");
            ViewBag.CodeProfessorItemId = new SelectList(context.ProfessorsItem.Include(u => u.Item), "Id", "CodeProfessorItemId");          
           
            var user = context.Evaluation.Include(u => u.Student.User).Include(u => u.CodeProfessorItem.Item).Include(u => u.Student.Group);
            return View(user.ToList());
        }

        public ActionResult ProcessRequest()
        {
            return View(); 
        }

        public ActionResult ErrorPage()
        {
            return View();
        }


        // GET: Roles/Create
        public ActionResult Create()
        {
            ViewBag.SemestrId = new SelectList(context.Semestr, "IdSemestr", "NameSemesrt");

            ViewBag.StudentId = new SelectList(context.Students.Include(u => u.User), "Id", "StudentId");
            ViewBag.ListStudents = context.Students.Include(u => u.User);
            ViewBag.CodeProfessorItemId = new SelectList(context.ProfessorsItem.Include(u => u.Item), "Id", "CodeProfessorItemId");
            ViewBag.ListProfesserItem = context.ProfessorsItem.Include(u => u.Item);
            return View(new Evaluation());
        }

        // POST: Roles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Evaluation1,StudentId,CodeProfessorItemId,SemestrId")] Evaluation role)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Evaluation.Add(role);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ID = new SelectList(context.Students, "Id", "Id", role.Id);
                ViewBag.ID = new SelectList(context.ProfessorsItem, "Id", "Id", role.Id);
                return View(role);

            }
            catch (Exception)
            {
                return Redirect("~/Evaluations/ErrorPage");
            }
         
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation role = context.Evaluation.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(context.Students.Include(u => u.User), "Id", "StudentId");
            ViewBag.ListStudents = context.Students.Include(u => u.User);
            ViewBag.CodeProfessorItemId = new SelectList(context.ProfessorsItem.Include(u => u.Item), "Id", "CodeProfessorItemId");
            ViewBag.ListProfesserItem = context.ProfessorsItem.Include(u => u.Item);
            return View(role);
        }

        // POST: Roles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Evaluation1,DateEvalution,StudentId,CodeProfessorItemId,SemestrId")] Evaluation role)
        {
            if (ModelState.IsValid)
            {
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(context.Students, "Id", "Id", role.Id);
            ViewBag.ID = new SelectList(context.ProfessorsItem, "Id", "Id", role.Id);
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation role = context.Evaluation.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluation role = context.Evaluation.Find(id);
            context.Evaluation.Remove(role);
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