using Microsoft.EntityFrameworkCore;
using Unisinos.Spotify.Dominio;
using Unisinos.Spotify.Infra.Mappings;

namespace Unisinos.Spotify.Infra
{
    public class SpotifyContext : DbContext
    {
        public SpotifyContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Musica> Musicas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumMapping());
            modelBuilder.ApplyConfiguration(new MusicaMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());        
        }

    }
}