using System.Collections.Generic;

namespace Unisinos.Spotify.Dominio
{
    public class PlaylistMusica
    {
        public int Id { get; set; }
        public Musica Musica { get; set; }
        public Playlist Playlist { get; set; }
    }
}