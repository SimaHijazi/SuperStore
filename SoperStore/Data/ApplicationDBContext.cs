using Microsoft.EntityFrameworkCore;
using SuperStore2.Models;
using SuperStore2.DOI;

namespace SoperStore2.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
        public DbSet<Signup> Signup { get; set; }
        public DbSet<Catagory> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
