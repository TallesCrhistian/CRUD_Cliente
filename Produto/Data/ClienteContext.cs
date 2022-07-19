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
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Endereco>(e => e.ClienteId);
        }
        public DbSet<Cliente> Cliente { get; set;}
        public DbSet<Endereco> Enderecos { get; set;}
       
      
    }
}
