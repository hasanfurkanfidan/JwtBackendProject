using Hff.JwtBackend.Business.Abstract;
using Hff.JwtBackend.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hff.JwtBackend.WebApi.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class, ITable, new()
    {
        private readonly IGenericService<TEntity> _genericService;
        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }
       
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(p => p.Key == "id").FirstOrDefault();
            var id = Convert.ToInt32(dictionary.Value.ToString());
            var entity = _genericService.GetByIdAsync(id).Result;
            if (entity==null)
            {
                context.Result = new NotFoundObjectResult($"There is no data for {id} ");
            }
        }
    }
}
