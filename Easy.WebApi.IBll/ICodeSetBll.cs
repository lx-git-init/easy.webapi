using Easy.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.IBll
{
    public interface ICodeSetBll : IDependency
    {
        Task<EntityCodeSet> GetCodeSetById(int id);

        Task<List<EntityCodeSet>> GetCodeSets(string[] notes);

        Task<bool> InsertCodeSet(EntityCodeSet codeSet);

        Task<bool> UpdateCodeSet(EntityCodeSet codeSet);

        Task<bool> DeleteCodeSet(int id);
    }
}