using CrudMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CrudMVC.Data
{
    public class BancoContext  : DbContext 
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) {
          
            
        }
        public DbSet<ProdutoModel> Produto { get; set; }
    }
}
