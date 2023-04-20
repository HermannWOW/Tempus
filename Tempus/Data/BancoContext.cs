using Microsoft.EntityFrameworkCore;
using Tempus.Models;

namespace Tempus.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
            
        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
