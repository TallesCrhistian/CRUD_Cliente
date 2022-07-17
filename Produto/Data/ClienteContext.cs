using Microsoft.EntityFrameworkCore;
using Produto.Models;

namespace Produto.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) :
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>()
           .Property<string>("ClienteForeignKey");

            modelBuilder.Entity<Endereco>()
           .HasOne(e => e.Cliente)
           .WithMany(c => c.Enderecos)
           .HasForeignKey("ClienteForeignKey");
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
    }
}
