using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisinos.Spotify.Dominio;

namespace Unisinos.Spotify.Infra.Mappings
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Album");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasMaxLength(20);

            builder.HasMany(p => p.Musicas).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
