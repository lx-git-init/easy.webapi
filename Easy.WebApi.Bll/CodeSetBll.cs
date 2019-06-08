using Easy.WebApi.IBll;
using Easy.WebApi.IDal;
using Easy.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.WebApi.Bll
{
    public class CodeSetBll : ICodeSetBll
    {
        private readonly ICodeSetDal _codeSetDal;

        public CodeSetBll(ICodeSetDal codeSetDal)
        {
            _codeSetDal = codeSetDal;
        }

        public async Task<EntityCodeSet> GetCodeSetById(int id)
        {
            return await _codeSetDal.GetCodeSetById(id);
        }

        public async Task<List<EntityCodeSet>> GetCodeSets(string[] notes)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertCodeSet(EntityCodeSet codeSet)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCodeSet(EntityCodeSet codeSet)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCodeSet(int id)
        {
            throw new NotImplementedException();
        }
    }
}