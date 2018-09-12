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

using static System.Console;

namespace Unisinos.Spotify.JsonCli
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt;
            do 
            {
                WriteLine("1 - Seed dos dados");
                WriteLine("2 - Gerar JSON");
            }
            while(!int.TryParse(ReadLine(), out opt) || opt < 1 || opt > 2);

            switch(opt)
            {
                case 1:
                    Seed();
                    break;
                case 2:
                    GerarJson();
                    break;
            }

            WriteLine(opt);

            Console.ReadKey();
        }

        static void GerarJson()
        {
            using(var context = GetContext())
            {
                var usuarios = context.Usuarios
                                      .Include(u => u.PlaylistsCriadas)
                                      .ThenInclude(p => p.PlaylistMusica)
                                      .ThenInclude(pm => pm.Musica)
                                      .ToList();

                                      
                 
            }
        }

        static void Seed()
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
