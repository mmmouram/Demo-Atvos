using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Config
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderClient> OrderClients { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderObservation> OrderObservations { get; set; }
        public DbSet<OrderBlock> OrderBlocks { get; set; }
        public DbSet<OrderInvoice> OrderInvoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional entity configuration can be placed here if necessary
        }
    }
}
