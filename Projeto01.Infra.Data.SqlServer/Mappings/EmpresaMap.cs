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
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            //nome da tabela
            builder.ToTable("EMPRESA");

            //chave primária
            builder.HasKey(e => e.Id);

            //campos
            builder.Property(e => e.Id)
                .HasColumnName("IDEMPRESA");

            builder.Property(e => e.NomeFantasia)
                .HasColumnName("NOMEFANTASIA")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.RazaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Cnpj)
                .HasColumnName("CNPJ")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
