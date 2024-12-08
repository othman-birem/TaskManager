using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TaskManager.Server.Modules.Binders
{
    public class StringToGuidBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.FieldName).FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                //bindingContext.ModelState.TryAddModelError(bindingContext.FieldName, "Id cannot be null or empty.");
                bindingContext.Result = ModelBindingResult.Success(Guid.NewGuid());
                return Task.CompletedTask;
            }

            if (Guid.TryParse(value, out var guid))
            {
                bindingContext.Result = ModelBindingResult.Success(guid);
            }
            else
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.FieldName, "Invalid GUID format.");
            }

            return Task.CompletedTask;
        }
    }
}
