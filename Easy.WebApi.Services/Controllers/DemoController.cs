using Easy.WebApi.IBll;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easy.WebApi.Services.Controllers
{
    [ApiController]
    [Route("api/demo/")]
    public class DemoController : ControllerBase
    {
        private readonly IDapperDemoBll _dapperDemoBll;
        private readonly IEFDemoBll _efDemoBll;

        public DemoController(
            IDapperDemoBll dapperDemoBll,
            IEFDemoBll efDemoBll)
        {
            _dapperDemoBll = dapperDemoBll;
            _efDemoBll = efDemoBll;
        }

        /// <summary>
        /// 实例1
        /// </summary>
        /// <returns></returns>
        [HttpGet("1")]
        public async Task<IActionResult> GetDemo_one()
        {
            var result = await _dapperDemoBll.GetDemo();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// 实例2
        /// </summary>
        /// <returns></returns>
        [HttpGet("2")]
        public async Task<IActionResult> GetDemo_two()
        {
            var result = await _efDemoBll.GetDemo();
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}