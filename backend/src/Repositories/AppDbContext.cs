using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuração da entidade Empresa
            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cnpj)
                      .HasMaxLength(14)
                      .IsRequired()
                      .HasColumnType("VARCHAR(14)");
                entity.Property(e => e.IsMei)
                      .IsRequired();
            });
        }
    }
}
