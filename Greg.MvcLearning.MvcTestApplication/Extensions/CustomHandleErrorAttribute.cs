using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greg.MvcLearning.MvcTestApplication.Extensions
{
    public class CustomHandleErrorAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //
            //
            //  Add some specific logic...
            //
            //
            base.OnException(filterContext);
        }
    }
}