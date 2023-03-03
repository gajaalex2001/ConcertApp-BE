using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConcertApp.API.Utility.CustomModelBinders
{
    public class CustomModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType == typeof(string) && context.BindingInfo.BindingSource != BindingSource.Body)
                return new StringTrimmerBinder();

            return null;
        }
    }
}
