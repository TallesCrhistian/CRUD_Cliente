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
     
        public DbSet<Cliente> Cliente { get; set;}
       
      
    }
}
