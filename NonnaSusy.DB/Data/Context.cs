using Microsoft.EntityFrameworkCore;
using NonnaSusy.DB.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NonnaSusy.DB.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<PrecioProductoPorCliente> PreciosProductoPorCliente { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Renglon> Renglones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de relaciones y restricciones
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasMany(c => c.Telefonos)
                    .WithOne(t => t.Cliente)
                    .HasForeignKey(t => t.ClienteID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(c => c.NombreCliente)
                                .HasMaxLength(60)
                                .IsRequired();

                entity.Property(c => c.Direccion)
                                .HasMaxLength(200)
                                .IsRequired();

                entity.HasIndex(c => c.NombreCliente).IsUnique();
                entity.HasIndex(c => c.Direccion).IsUnique();
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasOne(p => p.Cliente)
                    .WithMany()
                    .HasForeignKey(p => p.ClienteID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(p => p.FechaPedido)
                                .IsRequired();
                entity.Property(p => p.ClienteID)
                                .IsRequired();

                entity.HasIndex(p => p.FechaPedido);
                entity.HasIndex(p => p.ClienteID);
            });

            modelBuilder.Entity<PrecioProductoPorCliente>(entity =>
            {
                entity.Property(p => p.Precio)
                                .IsRequired();
                entity.Property(p => p.ClienteID)
                                .IsRequired();

                entity.HasIndex(p => p.ClienteID);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(p => p.NombreProducto)
                                .HasMaxLength(100)
                                .IsRequired();


                entity.HasIndex(p => p.NombreProducto).IsUnique();


            });

            modelBuilder.Entity<Renglon>(entity =>
            {
                entity.HasOne(r => r.Pedido)
                    .WithMany(p => p.Renglones)
                    .HasForeignKey(r => r.PedidoID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.Producto)
                .WithMany()
                .HasForeignKey(r => r.ProductoID)
                .OnDelete(DeleteBehavior.NoAction);

                entity.Property(r => r.Cantidad)
                                .IsRequired();

                entity.HasIndex(r => new { r.PedidoID, r.ProductoID })
                                .IsUnique();
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.HasOne(t => t.Cliente)
                    .WithMany(c => c.Telefonos)
                    .HasForeignKey(t => t.ClienteID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(t => t.NumeroTelefono)
                                .HasMaxLength(30)
                                .IsRequired();
            });
        }
    }
}
