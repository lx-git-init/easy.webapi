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

        public async Task<CodeSet> GetCodeSetById(int id)
        {
            return await _codeSetDal.GetCodeSetById(id);
        }

        public async Task<List<CodeSet>> GetCodeSets(string[] notes)
        {
            return await _codeSetDal.GetCodeSets(notes);
        }

        public async Task<bool> InsertCodeSet(CodeSet codeSet)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCodeSet(CodeSet codeSet)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCodeSet(int id)
        {
            throw new NotImplementedException();
        }
    }
}