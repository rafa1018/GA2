using GA2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GA2.Infraestructure.Data
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<User> USERS { get; set; }
        public DbSet<Rol> ROLES { get; set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
