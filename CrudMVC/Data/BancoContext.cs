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
        public DbSet<VendaModel> Venda { get; set; }

        public DbSet<ItemVendaModel> ItemVenda { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento Venda -> Itens
            modelBuilder.Entity<VendaModel>()
                .HasMany(v => v.ItensVenda)
                .WithOne(i => i.Venda)
                .HasForeignKey(i => i.VendaId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
