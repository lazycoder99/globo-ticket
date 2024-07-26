namespace GloboTicket.Web.Middleware
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Diagnostics;

    public class ValidationAttribute(ILogger<ValidationAttribute> logger) : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Code to run before the action executes
            logger.LogInformation("Action is executing.");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Code to run after the action executes
            logger.LogInformation("Action executed.");
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Code to run before the result executes
            logger.LogInformation("Result is executing.");
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            // Code to run after the result executes
            logger.LogInformation("Result executed.");
        }
    }

}
