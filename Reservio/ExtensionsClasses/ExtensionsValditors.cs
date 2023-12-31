using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Reservio.ExtensionsClasses
{
    public static class ExtensionsValditors
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
