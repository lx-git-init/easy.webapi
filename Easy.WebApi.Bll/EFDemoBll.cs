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
    public class EFDemoBll : IEFDemoBll
    {
        private readonly IEFDemoDal _efDemoDal;

        public EFDemoBll(IEFDemoDal efDemoDal)
        {
            _efDemoDal = efDemoDal;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<List<EntityDemo>> GetDemo()
        {
            return await _efDemoDal.GetDemo();
        }
    }
}