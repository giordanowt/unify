using System.Collections.Generic;

namespace Unisinos.Spotify.Dominio
{
    public class Album
    {
        public int Id { get; set; }

        public List<Musica> Musicas { get; private set; }

        public string Nome { get; private set; }

    }
}