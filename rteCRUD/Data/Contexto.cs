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
    }
}
