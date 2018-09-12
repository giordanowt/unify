using System;
using System.Linq;
using Unisinos.Spotify.Infra;
using System.IO;
using Microsoft.Extensions.Configuration;
using Unisinos.Spotify.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq;
using Newtonsoft.Json;

namespace Unisinos.Spotify.JsonCli
{
    class Program
    {
        static void Main(string[] args)
        {
            AdicionarUsuarios();

            using(var db = GetContext())
            {
                /*
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

                db.SaveChanges();*/
                
                var fileWriter = new StreamWriter(File.Create("Albuns.json"));
                fileWriter.WriteLine(JsonConvert.SerializeObject(db.Albums.ToList()));
                fileWriter.Dispose();
                fileWriter = new StreamWriter(File.Create("Musica.json"));
                fileWriter.WriteLine(JsonConvert.SerializeObject(db.Musicas.ToList()));
                fileWriter.Dispose();
                fileWriter = new StreamWriter(File.Create("Usuarios.json"));
                fileWriter.WriteLine(JsonConvert.SerializeObject(db.Usuarios.ToList()));
                fileWriter.Dispose();
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
