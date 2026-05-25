using Microsoft.EntityFrameworkCore;
using Practical_20.Model.Entities;

namespace Practical_20.Model.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AppLog> AppLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, Name = "Bhautik", Department = "IT", Salary = 50000, Email = "bhautik@gmail.com" },
            new Employee { Id = 2, Name = "Shivang", Department = "HR", Salary = 45000, Email = "shivang@gmail.com" }
            );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
