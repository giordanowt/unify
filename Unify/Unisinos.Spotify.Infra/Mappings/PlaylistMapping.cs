using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisinos.Spotify.Dominio;

namespace Unisinos.Spotify.Infra.Mappings
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("Playlists");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).HasMaxLength(40);

            
        }
    }
}
