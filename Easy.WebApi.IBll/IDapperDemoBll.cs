using Easy.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.IBll
{
    /// <summary>
    /// Dapper
    /// </summary>
    public interface IDapperDemoBll : IDependency
    {
        Task<List<EntityDemo>> GetDemo();
    }
}