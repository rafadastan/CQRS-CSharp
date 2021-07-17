using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto01.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Infra.Data.SqlServer.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //nome da tabela
            builder.ToTable("FUNCIONARIO");

            //chave primária
            builder.HasKey(f => f.Id);

            //campos
            builder.Property(f => f.Id)
                .HasColumnName("IDFUNCIONARIO");

            builder.Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(f => f.Matricula)
                .HasColumnName("MATRICULA")
                .HasMaxLength(6)
                .IsRequired();

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("DATAADMISSAO")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(f => f.EmpresaId)
                .HasColumnName("IDEMPRESA")
                .IsRequired();

            #region Relacionamentos

            builder.HasOne(f => f.Empresa) //Funcionario TEM 1 Empresa
                .WithMany(e => e.Funcionarios) //Empresa TEM Muitos Funcionarios
                .HasForeignKey(f => f.EmpresaId); //Chave estrangeira (FOREGIN KEY)

            #endregion
        }
    }
}
