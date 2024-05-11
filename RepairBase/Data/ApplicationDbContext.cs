using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepairBase.Models;
namespace RepairBase.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Mb> Mb { get; set; }
        public DbSet<Parts> Parts { get; set; }
        public DbSet<Mb2Parts> Mb2Parts { get; set; }
        public DbSet<MbRepair> MbRepair { get; set; }
        public DbSet<File4MbRepair> File4MbRepair { get; set; }
    }
}
