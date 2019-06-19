using Microsoft.EntityFrameworkCore;

namespace Easy.WebApi.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<EntityCodeSet> EntityCodeSets { get; set; }
    }
}