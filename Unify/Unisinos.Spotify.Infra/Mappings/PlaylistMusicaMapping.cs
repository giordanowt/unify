using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unisinos.Spotify.Dominio;

namespace Unisinos.Spotify.Infra.Mappings
{
    public class PlaylistMusicaMapping: IEntityTypeConfiguration<PlaylistMusica>
    {
        public void Configure(EntityTypeBuilder<PlaylistMusica> builder)
        {
            builder.ToTable("PlaylistsMusicas");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Playlist);

            builder.HasOne(p => p.Musica);
        }
    }
}
