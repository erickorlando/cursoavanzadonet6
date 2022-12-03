using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GalaxyApp.AccesoDatos
{
    public class InstitutoDbContext : IdentityDbContext<GalaxyUser>
    {
        public InstitutoDbContext(DbContextOptions<InstitutoDbContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InstitutoDbContext).Assembly);
        }
    }
}