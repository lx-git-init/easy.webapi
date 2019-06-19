using Easy.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.IDal
{
    /// <summary>
    /// Dapper
    /// </summary>
    public interface IDapperDemoDal : IDependency
    {
        Task<List<EntityDemo>> GetDemo();
    }
}