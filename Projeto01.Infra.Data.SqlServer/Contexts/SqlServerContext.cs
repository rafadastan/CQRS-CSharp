using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Contexts
{
    public class SqlServerContext : DbContext
    {
        //ctor + 2x[tab] -> construtor
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }

        //DbSet -> provedor para cada entidade (repositorio)
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        //sobrescrita de método (OVERRIDE)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent Mappings

            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());

            #endregion

            #region Indexes

            modelBuilder.Entity<Empresa>(entity => 
            {
                entity.HasIndex(e => e.Cnpj).IsUnique();
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {                
                entity.HasIndex(e => e.Cpf).IsUnique();
                entity.HasIndex(e => e.Matricula).IsUnique();
            });

            #endregion
        }
    }
}
