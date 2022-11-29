using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace API_schedule.Filters 
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;

            var excObj = new { ExceptionMessage = $"В методе {actionName} возникло исключение: \n {exceptionMessage}" };

            context.Result = new JsonResult(excObj);
            context.HttpContext.Response.StatusCode = 500;

            context.ExceptionHandled = true;
        }

    }
}
