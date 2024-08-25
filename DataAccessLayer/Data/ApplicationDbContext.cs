using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextoptions):base(dbContextoptions)
        {
            
        }

        public DbSet<Record> Records { get; set; }
    }
}
