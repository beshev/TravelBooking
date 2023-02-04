﻿namespace TravelBooking.Web.Infrastructure.Attributes
{
    using System;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using TravelBooking.Web.Infrastructure.Extensions;

    public class SetTempDataErrorsAttribute : ActionFilterAttribute
    {
        private readonly string key;

        public SetTempDataErrorsAttribute(string key)
        {
            this.key = key;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var controller = context.Controller as Controller;
            controller.TempData[this.key] = string.Join(Environment.NewLine, controller.ModelState.GetModelStateErrors());
        }
    }
}
