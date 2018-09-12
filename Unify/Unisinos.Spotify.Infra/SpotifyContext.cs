using Microsoft.EntityFrameworkCore;
using Unisinos.Spotify.Dominio;
using Unisinos.Spotify.Infra.Mappings;
using System.Configuration;

namespace Unisinos.Spotify.Infra
{
    public class SpotifyContext : DbContext
    {
        public SpotifyContext() : base() { }

        public SpotifyContext(DbContextOptions options) : base(options) { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaylistMapping());
            modelBuilder.ApplyConfiguration(new MusicaMapping());
            modelBuilder.ApplyConfiguration(new AlbumMapping());
            modelBuilder.ApplyConfiguration(new MusicaMapping());                   
            modelBuilder.ApplyConfiguration(new PlaylistMusicaMapping());        
            modelBuilder.ApplyConfiguration(new UsuarioMapping());   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["UnifyDatabase"].ConnectionString);
        }
    }
}