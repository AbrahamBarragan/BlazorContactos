using BlazorContactos.Server.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlazorContactos.Server.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediosContacto>()
            .HasOne(p => p.Contacto)
            .WithMany(b => b.Medios);
        }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<MediosContacto> Medios { get; set; }
    }
}