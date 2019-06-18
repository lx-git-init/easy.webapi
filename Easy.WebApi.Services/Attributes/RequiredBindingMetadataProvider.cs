using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Easy.WebApi.Services.Attributes
{
    public class RequiredBindingMetadataProvider : IBindingMetadataProvider
    {
        /// <summary>
        /// 改变RequiredAttribute的行为，强制它包含BindRequiredAttribute的行为
        /// </summary>
        /// <param name="context"></param>
        public void CreateBindingMetadata(BindingMetadataProviderContext context)
        {
            if (context.PropertyAttributes?.OfType<RequiredAttribute>().Any() ?? false)
            {
                context.BindingMetadata.IsBindingRequired = true;
            }
        }
    }
}