using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisinos.Spotify.Dominio;

namespace Unisinos.Spotify.Infra.Mappings
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("Musica");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasMaxLength(40);
            builder.Property(p => p.Duracao);
        }
    }
}
