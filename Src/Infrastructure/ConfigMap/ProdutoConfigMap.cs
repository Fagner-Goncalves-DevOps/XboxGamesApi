using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ConfigMap
{
    public class ProdutoConfigMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(120);
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(185);
            //TODO: SQLite doesn't have support for decimal.
            builder.Property(p => p.Preco).HasColumnType("decimal(20,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(p => p.ProdutoGenero).WithMany().HasForeignKey(p => p.ProdutoGeneroId);
            builder.HasOne(p => p.ProdutoTipo).WithMany().HasForeignKey(p => p.ProdutoTipoId);
        }
    }
}
