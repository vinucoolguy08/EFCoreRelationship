using EFCoreRelationship.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationship.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Role).HasDefaultValue("Player");
        }
    }
}
