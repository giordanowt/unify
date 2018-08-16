using System.Collections.Generic;

namespace Unisinos.Spotify.Dominio
{
    public class PlaylistMusica
    {
        public int Id { get; set; }
        public List<Musica> Musica { get; set; }
        public List<Playlist> Playlist { get; set; }
    }
}