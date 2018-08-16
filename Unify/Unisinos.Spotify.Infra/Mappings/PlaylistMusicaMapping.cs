using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisinos.Spotify.Dominio;

namespace Unisinos.Spotify.Infra.Mappings
{
    public class PlaylistMusicaMapping: IEntityTypeConfiguration<PlaylistMusica>
    {
        public void Configure(EntityTypeBuilder<PlaylistMusica> builder)
        {
            builder.ToTable("PlaylistMusica");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Playlist).WithMany().IsRequired();

            builder.HasOne(p => p.Musica).WithMany().IsRequired();
        }
    }
}
