using Microsoft.EntityFrameworkCore;
using Interbank.Entity;

namespace Interbank.Context
{
    public class TransaccionContext : DbContext
    {
        public TransaccionContext(DbContextOptions<TransaccionContext> options) : base(options)
        {

        }
        public DbSet<Transaccion> Transaccions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaccion>()
                .Property(x => x.Monto)
                .HasColumnType("decimal(18,2)"); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
