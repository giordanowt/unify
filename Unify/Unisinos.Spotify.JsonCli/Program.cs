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
            while(!int.TryParse(ReadLine(), out opt) || opt < 1 || opt > 2);

            switch(opt)
            {
                case 1:
                    Seed();
                    break;
                case 2:
                    GerarJson();
                    break;
                case 3:
                    GerarXML();
                    break;
            }

            WriteLine(opt);

            Console.ReadKey();
        }

        static void GerarJson()
        {
            using(var context = GetContext())
            {
                var usuarios = context.Playlists;

                                      
                 
            }
        }

        static void Seed()
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

        static void GerarJSON()
        {
            using (var db = GetContext())
            {
                var aaa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Albuns.json");
                var fileWriter = new StreamWriter(File.Create(aaa));
                fileWriter.WriteLine(JsonConvert.SerializeObject(db.Albums.ToList()));
                fileWriter.Dispose();
                fileWriter = new StreamWriter(File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas.json")));
                fileWriter.WriteLine(JsonConvert.SerializeObject(db.Musicas.ToList()));
                fileWriter.Dispose();
                fileWriter = new StreamWriter(File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usuarios.json")));
                fileWriter.WriteLine(JsonConvert.SerializeObject(db.Usuarios.ToList()));
                fileWriter.Dispose();
            }
        }

        static void GerarXML()
        {
            using (var db = GetContext())
            {
                XmlSerializer ser = new XmlSerializer(typeof(Dominio.Usuario));
                TextWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Albuns.xml"));
                foreach (Album a in db.Albums.ToList())
                    ser.Serialize(writer, a);
                writer.Dispose();
                ser = new XmlSerializer(typeof(Dominio.Musica));
                writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Musicas.xml"));
                foreach (Musica a in db.Musicas.ToList())
                    ser.Serialize(writer, a);
                writer.Dispose();
                ser = new XmlSerializer(typeof(Dominio.Usuario));
                writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Usuarios.xml"));
                foreach (Usuario a in db.Usuarios.ToList())
                    ser.Serialize(writer, a);
                writer.Dispose();
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
