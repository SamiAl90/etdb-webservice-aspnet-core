using ETDB.API.WebService.Misc.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ETDB.API.WebService.Misc.Filters
{
    public class RessourceNotFoundExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is RessourceNotFoundException))
            {
                return;
            }

            context.Result = new NotFoundObjectResult(context.Exception.Message);
            context.ExceptionHandled = true;
        }
    }
}
