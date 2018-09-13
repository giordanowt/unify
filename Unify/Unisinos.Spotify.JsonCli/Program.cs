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

namespace Unisinos.Spotify.JsonCli
{
    class Program
    {
        static void Main(string[] args)
        {
            //AdicionarUsuarios();

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

                GerarJSON(db);

                GerarXML(db);

            }

            Console.ReadKey();
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

        static SpotifyContext GetContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SpotifyContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["UnifyDatabase"].ConnectionString);
            return new SpotifyContext(optionsBuilder.Options);
        }
    }
}
