using ChooseYourOwnAdventure.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChooseYourOwnAdventure.API.Filters
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is NotFoundException)
            {
                context.Result = new StatusCodeResult(404);
                return;
            }


            if (exception is ValidationException)
            {
                context.Result = new BadRequestObjectResult(exception.Message);
                return;
            }

            context.Result = new BadRequestObjectResult(string.Empty);

        }
    }
}
