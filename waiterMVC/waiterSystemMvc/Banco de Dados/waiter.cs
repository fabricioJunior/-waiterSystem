using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace waiterSystemMvc.Banco_de_Dados
{
    public partial class waiter : DbContext
    {
        public waiter()
            : base("name=waiter")
        {
        }


        public virtual DbSet<Garcom> Garcom { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Garcom>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Garcom>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Garcom>()
            .Property(e => e.login)
            .IsUnicode(false);

            modelBuilder.Entity<Garcom>()
            .Property(e => e.senha)
            .IsUnicode(false);

            modelBuilder.Entity<Garcom>()
              .HasMany(e => e.Pedidos)
              .WithRequired(e => e.Garcom)
              .HasForeignKey(e => e.garcomId)
              .WillCascadeOnDelete(false);


            modelBuilder.Entity<Menu>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.Itens)
                .WithRequired(e => e.Menu)
                .HasForeignKey(e => e.idMenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.valor)
                .HasPrecision(14, 3);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Itens)
                .WithRequired(e => e.Pedido)
                .HasForeignKey(e => e.idPedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Itens>()
                .Property(e => e.valor)
                .HasPrecision(14, 3);
            
        }
    }
}
