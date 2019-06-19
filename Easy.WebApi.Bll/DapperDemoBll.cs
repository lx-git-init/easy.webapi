using Easy.WebApi.IBll;
using Easy.WebApi.IDal;
using Easy.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.Bll
{
    /// <summary>
    ///
    /// </summary>
    public class DapperDemoBll : IDapperDemoBll
    {
        private readonly IDapperDemoDal _dapperDemoDal;

        public DapperDemoBll(IDapperDemoDal dapperDemoDal)
        {
            _dapperDemoDal = dapperDemoDal;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<List<EntityDemo>> GetDemo()
        {
            return await _dapperDemoDal.GetDemo();
        }
    }
}