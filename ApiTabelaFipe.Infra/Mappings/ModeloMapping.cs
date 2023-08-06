﻿using ApiTabelaFipe.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTabelaFipe.Infra.Mappings
{
    public class ModeloMapping : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("MODELO");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn();
        }
    }
}
