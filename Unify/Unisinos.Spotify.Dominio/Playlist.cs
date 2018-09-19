using System.Collections.Generic;

namespace Unisinos.Spotify.Dominio
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Nome { get; set; }     
        public Usuario Criador { get; set; }
    }
}