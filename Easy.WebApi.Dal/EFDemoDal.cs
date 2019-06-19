using Easy.WebApi.IDal;
using Easy.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.Dal
{
    /// <summary>
    /// EF
    /// </summary>
    public class EFDemoDal : IEFDemoDal
    {
        private readonly MyDbContext _dbContext;

        public EFDemoDal(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<List<EntityDemo>> GetDemo()
        {
            //var demo = await MiniProfiler.Current.Inline(
            //    async () => await _dbContext.EntityDemos.ToListAsync(),
            //    "GetDemo");

            var demo = await _dbContext.EntityDemos.AsNoTracking().ToListAsync();
            return demo;
        }
    }
}