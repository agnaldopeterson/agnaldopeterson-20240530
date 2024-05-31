using Microsoft.EntityFrameworkCore;
using rteCRUD.Models;
using System;

namespace rteCRUD.Data
{
    public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ColaboradorModel> Colaboradores { get; set; }
        public DbSet<UnidadeModel> Unidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder.Entity<UnidadeModel>()
               .HasIndex(u => u.Codigo)
               .IsUnique();

            modelBuilder.Entity<ColaboradorModel>()
                .HasOne(c => c.Unidade)
                .WithMany(u => u.Colaboradores)
                .HasForeignKey(c => c.UnidadeId);

            modelBuilder.Entity<ColaboradorModel>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Colaboradores)
                .HasForeignKey(c => c.UsuarioId);
        }
    }
}
