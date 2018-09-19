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
using System.Xml.Serialization;
using System.Collections.Generic;

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
                WriteLine("3 - Gerar XML");
            }
            while(!int.TryParse(ReadLine(), out opt) || opt < 1 || opt > 3);

            switch(opt)
            {
                case 1:
                    Seed();
                    break;
                case 2:
                    GerarJson();
                    break;
                case 3:
                    GerarXML(GetContext());
                    break;
            }

            WriteLine(opt);

            Console.ReadKey();
        }

        static void GerarJson()
        {
            using(var context = GetContext())
            {
                var playlists = context.Playlists.Include(p => p.Criador);
            }
        }

        static void Seed()
        {
            AdicionarUsuarios();
            AdicionarMusicas();
            AdicionarPlaylists();

            WriteLine("Dados inseridos com sucesso");
            ReadKey();
        }

        static void GerarJSON(SpotifyContext db)
        {
            var fileWriter = new StreamWriter(File.Create("Albuns.json"));
            fileWriter.WriteLine(JsonConvert.SerializeObject(db.Albums.ToList()));
            fileWriter.Dispose();
            fileWriter = new StreamWriter(File.Create("Musicas.json"));
            fileWriter.WriteLine(JsonConvert.SerializeObject(db.Musicas.ToList()));
            fileWriter.Dispose();
            fileWriter = new StreamWriter(File.Create("Usuarios.json"));
            fileWriter.WriteLine(JsonConvert.SerializeObject(db.Usuarios.ToList()));
            fileWriter.Dispose();
        }

        static void GerarXML(SpotifyContext db)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Dominio.Usuario));
            TextWriter writer = new StreamWriter("Albuns.xml");
            foreach(Album a in db.Albums.ToList())
                ser.Serialize(writer, a);
            writer.Dispose();
            ser = new XmlSerializer(typeof(Dominio.Musica));
            writer = new StreamWriter("Musicas.xml");
            foreach (Musica a in db.Musicas.ToList())
                ser.Serialize(writer, a);
            writer.Dispose();
            ser = new XmlSerializer(typeof(Dominio.Usuario));
            writer = new StreamWriter("Usuarios.xml");
            foreach (Usuario a in db.Usuarios.ToList())
                ser.Serialize(writer, a);
            writer.Dispose();
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

        static void AdicionarMusicas()
        {
            using (var db = GetContext())
            {
                db.Albums.AddRange(new []
                {
                    new Album
                    {
                        Nome = "Is this it",
                        Musicas = new List<Musica>
                        {
                            new Musica { Nome = "Is this it", Duracao = 3.1 },
                            new Musica { Nome = "The modern age", Duracao = 2.54 },
                            new Musica { Nome = "Barely legal", Duracao = 2.5 },
                            new Musica { Nome = "Someday", Duracao = 5 },
                        }
                    },

                    new Album
                    {
                        Nome = "An awesome wave",
                        Musicas = new List<Musica>
                        {
                            new Musica { Nome = "Intro", Duracao = 7 },
                            new Musica { Nome = "Tesselate", Duracao = 5 },
                            new Musica { Nome = "Breezeblocks", Duracao = 4 },
                            new Musica { Nome = "Matilda", Duracao = 8 },
                        }
                    }
                });

                db.SaveChanges();
            }
        }

        static void AdicionarPlaylists()
        {
            using(var db = GetContext())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.Nome == "Jéferson");

                var musicas = db.Musicas
                    .Where(m => new [] { "Matilda", "Intro" }.Contains(m.Nome));

                var playlist = new Playlist { Nome = "Músicas Bacanas", Criador = usuario };

                var relacoes = musicas.Select(m => new PlaylistMusica { Musica = m, Playlist = playlist });
                
                db.Playlists.Add(playlist);
                db.PlaylistsMusicas.AddRange(relacoes);

                var giordano = db.Usuarios.FirstOrDefault(u => u.Nome == "Giordano");
                var musicasLongas = db.Musicas.Where(m => m.Duracao > 4);
                
                var listMusicasLongas = new Playlist { Nome = "Músicas Longas", Criador = giordano };
                var relacoes2 = musicasLongas.Select(m => new PlaylistMusica { Musica = m, Playlist = listMusicasLongas });

                db.Playlists.Add(listMusicasLongas);
                db.PlaylistsMusicas.AddRange(relacoes2);

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
