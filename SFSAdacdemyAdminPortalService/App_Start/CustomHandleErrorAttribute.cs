using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace SFSAdacdemyAdminPortalService
{
    public class CustomHandleErrorAttribute : ExceptionFilterAttribute
    {
        ErrorLogging logging = new ErrorLogging();
        public override void OnException(HttpActionExecutedContext context)
        {
            //base.OnException(actionExecutedContext);

            if(context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }

        private void ESLogging(HttpActionExecutedContext filterContext)
        {
            string user = string.Empty;
            var controllerName = filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionContext.ActionDescriptor.ActionName;

            logging.LogData(filterContext.Exception.ToString(), user, controllerName, actionName, "ERROR");
        }

        private void Log4NetLogging(HttpActionExecutedContext filterContext)
        {
            //log the error using log4net

            LogInstance.Error(filterContext.Exception.Message, filterContext.Exception);
        }
    }
}