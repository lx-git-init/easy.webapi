using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Easy.WebApi.Services.Filters
{
    /// <summary>
    /// 接口错误信息处理
    /// </summary>
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;

        public ApiExceptionFilter(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            // throw new NotImplementedException();
        }
    }
}