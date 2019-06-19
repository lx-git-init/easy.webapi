using Microsoft.EntityFrameworkCore;

namespace Easy.WebApi.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<CodeSet> CodeSets { get; set; }
    }
}