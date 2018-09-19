using System.Collections.Generic;
using System.Xml.Serialization;

namespace Unisinos.Spotify.Dominio
{
    public class PlaylistMusica
    {
        public int Id { get; set; }
        public Musica Musica { get; set; }

        [XmlIgnore]
        public Playlist Playlist { get; set; }
    }
}