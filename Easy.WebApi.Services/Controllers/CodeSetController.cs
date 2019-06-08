using Easy.WebApi.IBll;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easy.WebApi.Services.Controllers
{
    [ApiController]
    [Route("api/code_set/")]
    public class CodeSetController : ControllerBase
    {
        private readonly ICodeSetBll _codeSetBll;

        public CodeSetController(ICodeSetBll codeSetBll)
        {
            _codeSetBll = codeSetBll;
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
    }
}