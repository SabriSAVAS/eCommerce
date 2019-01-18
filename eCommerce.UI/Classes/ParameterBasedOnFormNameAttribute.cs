﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =true)]
    public class ParameterBasedOnFormNameAttribute : FilterAttribute, IActionFilter
    {
        private readonly string _name;
        private readonly string _actionParameterName;
        public ParameterBasedOnFormNameAttribute(string name, string actionParameterName)
        {
            this._name = name;
            this._actionParameterName = actionParameterName;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.ActionParameters[_actionParameterName] = filterContext.RequestContext.HttpContext.Request.Form.AllKeys.Any(x=>x.Equals(_name));
        }
    }
}