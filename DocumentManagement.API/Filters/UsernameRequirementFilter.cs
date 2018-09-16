using DocumentManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Net;

namespace DocumentManagement.API.Handlers
{
    public class UsernameRequirementFilter : ActionFilterAttribute
    {
        private readonly IUserService _userService;

        public UsernameRequirementFilter(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var username = context.HttpContext.Request.Headers.Keys.FirstOrDefault(k => k.Equals("username", StringComparison.InvariantCultureIgnoreCase));
            if (!string.IsNullOrWhiteSpace(username) && _userService.ValidateLogin(username))
                base.OnActionExecuting(context);
            else
                context.Result = new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
        }
    }
}
