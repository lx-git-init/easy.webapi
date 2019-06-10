using Easy.WebApi.IBll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace Easy.WebApi.Services.Controllers
{
    [ApiController]
    [Route("api/code_set/")]
    public class CodeSetController : ControllerBase
    {
        private readonly ICodeSetBll _codeSetBll;
        private readonly IStringLocalizer<CodeSetController> _localizer;

        public CodeSetController(ICodeSetBll codeSetBll, IStringLocalizer<CodeSetController> localizer)
        {
            _codeSetBll = codeSetBll;
            _localizer = localizer;
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("detail")]
        public async Task<IActionResult> GetCodeSetById(int id)
        {
            var result = await _codeSetBll.GetCodeSetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("hello")]
        public string Hello()
        {
            return _localizer["About Title"];
        }
    }
}