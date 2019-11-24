using BancoTalentos.CandidatoService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.DataAccess.EntityMap
{
    public class CandidatoMap : IEntityTypeConfiguration<Contato>
    {
        void IEntityTypeConfiguration<Contato>.Configure(EntityTypeBuilder<Contato> builder)
        {
            builder
               .HasOne(b => b.Cidade)
               .WithOne(r => r.Contato)
               .HasForeignKey<Contato>("CidadeId");
        }
    }
}
