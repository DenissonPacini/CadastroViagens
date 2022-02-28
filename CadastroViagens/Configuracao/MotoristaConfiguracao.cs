using CadastroViagens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroViagens.Configuracao
{
    public class MotoristaConfiguracao
    {
        public void Configura(EntityTypeBuilder<Motorista> builder)
        {
            builder.HasKey(p => p.Id).HasName("Id");            

            builder.Property(p => p.Nome)
                .HasMaxLength(200)
                .HasColumnName("Nome")
                .HasColumnType("string")
                .IsRequired();

            builder.Property(p => p.UltimoNome)
                .HasMaxLength(200)
                .HasColumnName("UltimoNome")
                .HasColumnType("string")
                .IsRequired();

            builder.Property(P => P.CEP)
                .HasMaxLength(10)
                .HasColumnName("CEP")
                .HasColumnType("string");

            builder.Property(P => P.Logradouro)
                .HasMaxLength(200)
                .HasColumnName("Logradouro")
                .HasColumnType("string");

            builder.Property(P => P.Numero)
                .HasMaxLength(10)
                .HasColumnName("Numero")
                .HasColumnType("string");

            builder.Property(P => P.Complemento)
                .HasMaxLength(100)
                .HasColumnName("Complemento")
                .HasColumnType("string");

            builder.Property(P => P.Bairro)
                .HasMaxLength(100)
                .HasColumnName("Bairro")
                .HasColumnType("string");

            builder.Property(P => P.Localidade)
                .HasMaxLength(100)
                .HasColumnName("Localidade")
                .HasColumnType("string");

            builder.Property(P => P.Localidade)
                .HasMaxLength(10)
                .HasColumnName("UF")
                .HasColumnType("string");
        }
    }
}
