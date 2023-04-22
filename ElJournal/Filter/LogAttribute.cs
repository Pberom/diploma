using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElJournal.Filter
{
    public class LogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;

            Visitor visitor = new Visitor()
            {
                Ip = request.ServerVariables["HTTP_X_FORWARD_FOR"] ?? request.UserHostAddress,
                Url = request.RawUrl,
                Date = DateTime.Now,
                Email = request.UserHostName
            };

            using (ElJournalContext context = new ElJournalContext())
            {
                context.Visitor.Add(visitor);
                context.SaveChanges();
            }
            base.OnActionExecuted(filterContext);
        }
    }
}