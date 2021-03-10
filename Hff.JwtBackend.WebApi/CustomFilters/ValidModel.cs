using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.JwtBackend.WebApi.CustomFilters
{
    public class ValidModel:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var errors = context.ModelState.Values.Select(p => p.Errors.Select(i=>i.ErrorMessage)).FirstOrDefault();
            var errorString = "";
            foreach (var error in errors)
            {
                errorString = error + ",";
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(errorString);
            }
           
        }

    }
}
