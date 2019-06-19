using Easy.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.IBll
{
    /// <summary>
    /// EF
    /// </summary>
    public interface IEFDemoBll : IDependency
    {
        Task<List<EntityDemo>> GetDemo();
    }
}