using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(a => a.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .ToList();
                context.Result = new BadRequestObjectResult(errors);
            }
            base.OnActionExecuting(context);
        }
    }
}