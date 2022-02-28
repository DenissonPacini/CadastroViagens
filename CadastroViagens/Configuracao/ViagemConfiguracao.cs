using CadastroViagens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroViagens.Configuracao
{
    public class ViagemConfiguracao
    {
        public void Configura(EntityTypeBuilder<Viagem> builder)
        {

            builder.ToTable("Viagem");
            builder.HasKey(p => p.Id).HasName("Id");

            builder.Property(p => p.DataHoraViagem)
                .HasMaxLength(200)
                .HasColumnName("DataHoraViagem")
                .HasColumnType("string")
                .IsRequired();

            builder.Property(p => p.LocalEntrega)
                    .HasMaxLength(100)
                    .HasColumnName("LocalEntrega")
                    .HasColumnType("string")
                    .IsRequired();

            builder.Property(P => P.LocalSaida)
                    .HasMaxLength(100)
                    .HasColumnName("LocalSaida")
                    .HasColumnType("string");

            builder.Property(P => P.TotalKmEntreCidade)
                    .HasMaxLength(100)
                    .HasColumnName("TotalKmEntreCidade")
                    .HasColumnType("string");

            builder.Property(P => P.IdMotorista)
                    .HasColumnName("IdMotorista")
                    .HasColumnType("int");

        }
    }
}
