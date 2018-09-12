using System;
using System.Linq;
using Unisinos.Spotify.Infra;
using System.IO;
using Microsoft.Extensions.Configuration;
using Unisinos.Spotify.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Unisinos.Spotify.JsonCli
{
    class Program
    {
        static void Main(string[] args)
        {
            AdicionarUsuarios();

            using(var db = GetContext())
            {
                var usuario = db.Usuarios.First();

                var musica = new Musica
                {
                    Nome = "Darude Sandstorm",
                    Duracao = 3.4
                };

                var playlist = new Playlist
                {
                    Nome = "Músicas Bacanas",
                    Criador = usuario
                };

                db.Musicas.Add(musica);
                db.Playlists.Add(playlist);

                db.SaveChanges();
            }

            Console.ReadKey();
        }

        static void AdicionarUsuarios()
        {
            using(var db = GetContext())
            {
                db.Usuarios.AddRange(new[]
                {
                    new Usuario { Nome = "Jéferson" },
                    new Usuario { Nome = "Giordano" },
                    new Usuario { Nome = "Joaquim" },
                    new Usuario { Nome = "Mário" },
                    new Usuario { Nome = "Alex" }
                });

                db.SaveChanges();
            }
        }

        static SpotifyContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SpotifyContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["UnifyDatabase"].ConnectionString);
            return new SpotifyContext(optionsBuilder.Options);
        }
    }
}
