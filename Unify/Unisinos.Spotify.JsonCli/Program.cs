using System;
using Unisinos.Spotify.Infra;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Unisinos.Spotify.JsonCli
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SpotifyContext())
            {
                db.Usuarios.Add(new Dominio.Usuario
                {
                    Nome = "Jefin"
                });

                db.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
