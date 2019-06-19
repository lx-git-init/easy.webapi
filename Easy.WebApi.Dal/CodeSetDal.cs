using Dapper;
using Easy.WebApi.IDal;
using Easy.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.WebApi.Dal
{
    public class CodeSetDal : ICodeSetDal
    {
        private readonly MyDbContext _dbContext;
        private readonly string _connStr;

        public CodeSetDal(IConfiguration configuration, MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _connStr = configuration["ConnectionStrings:default"];
        }

        /// <summary>
        /// 获取元素
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CodeSet> GetCodeSetById(int id)
        {
            using (IDbConnection conn = new SqlConnection(_connStr))
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                string sql = @"select * from codeset where id=@id";
                var query = await conn.QueryFirstOrDefaultAsync<CodeSet>(sql, new { id = id });
                sw.Stop();
                Console.WriteLine(">>>>dapper:" + sw.ElapsedMilliseconds + "<<<<");
                return query;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        public async Task<List<CodeSet>> GetCodeSets(string[] notes)
        {
            var codeSets = await _dbContext.CodeSets.Where(q => notes.Contains(q.Note)).ToListAsync();
            // var codeSets = await _dbContext.CodeSets.FromSql("select * from codeset where note='cs'").ToListAsync();
            return codeSets;
        }

        public Task<bool> InsertCodeSet(CodeSet codeSet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCodeSet(CodeSet codeSet)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCodeSet(int id)
        {
            throw new NotImplementedException();
        }
    }
}