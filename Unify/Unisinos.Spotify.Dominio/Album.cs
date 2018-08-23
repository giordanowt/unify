using System.Collections.Generic;

namespace Unisinos.Spotify.Dominio
{
    public class Album
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public List<Musica> Musicas { get; private set; }

    }
}