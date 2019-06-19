using Easy.WebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.IDal
{
    public interface ICodeSetDal : IDependency
    {
        Task<CodeSet> GetCodeSetById(int id);

        Task<List<CodeSet>> GetCodeSets(string[] notes);

        Task<bool> InsertCodeSet(CodeSet codeSet);

        Task<bool> UpdateCodeSet(CodeSet codeSet);

        Task<bool> DeleteCodeSet(int id);
    }
}