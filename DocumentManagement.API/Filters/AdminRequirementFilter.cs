using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;

namespace DocumentManagement.API.Handlers
{
    public class AdminRequirementFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var admin = context.HttpContext.Request.Headers.Keys.FirstOrDefault(k => k.Equals("admin", StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(admin) && admin.Equals("1"))
                base.OnActionExecuting(context);
            else
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
        }
    }
}