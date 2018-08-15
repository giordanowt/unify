using System.Collections.Generic;

namespace Unisinos.Spotify.Dominio
{
    public class PlaylistMusica
    {
        public int id { get; set; }
        public List<Musica> Musica { get; set; }
        public List<Playlist> Playlist { get; set; }
    }
}