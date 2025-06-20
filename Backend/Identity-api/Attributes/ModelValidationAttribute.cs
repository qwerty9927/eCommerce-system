using Identity_api.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Identity_api.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ModelValidationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;

        var errors = context.ModelState
            .Where(ms => ms.Value.Errors.Count > 0)
            .Select(ms => new
            {
                Field = ms.Key,
                Errors = ms.Value.Errors.Select(e => e.ErrorMessage).ToArray()
            });

        throw new UnprocessableException(error: errors);
    }
}