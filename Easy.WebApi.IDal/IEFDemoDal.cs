using Easy.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.IDal
{
    /// <summary>
    /// EF
    /// </summary>
    public interface IEFDemoDal : IDependency
    {
        Task<List<EntityDemo>> GetDemo();
    }
}