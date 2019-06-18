using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Easy.WebApi.Services.Filters
{
    /// <summary>
    /// 方法验证处理
    /// </summary>
    public class ActionResultFilter : IActionFilter
    {
        private readonly IHostingEnvironment _env;

        public ActionResultFilter(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // throw new NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}