using Microsoft.EntityFrameworkCore;
using NetMVCCRUD.Models.Domain;

namespace NetMVCCRUD.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
