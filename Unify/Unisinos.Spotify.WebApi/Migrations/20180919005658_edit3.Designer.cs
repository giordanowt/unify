﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unisinos.Spotify.Infra;

namespace Unisinos.Spotify.WebApi.Migrations
{
    [DbContext(typeof(SpotifyContext))]
    [Migration("20180919005658_edit3")]
    partial class edit3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Unisinos.Spotify.Dominio.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Unisinos.Spotify.Dominio.Musica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumId");

                    b.Property<double>("Duracao");

                    b.Property<string>("Nome")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Musica");
                });

            modelBuilder.Entity("Unisinos.Spotify.Dominio.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CriadorId");

                    b.Property<string>("Nome")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.HasIndex("CriadorId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("Unisinos.Spotify.Dominio.PlaylistMusica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MusicaId");

                    b.Property<int?>("PlaylistId");

                    b.HasKey("Id");

                    b.HasIndex("MusicaId");

                    b.HasIndex("PlaylistId");

                    b.ToTable("PlaylistsMusicas");
                });

            modelBuilder.Entity("Unisinos.Spotify.Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(40);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Unisinos.Spotify.Dominio.Musica", b =>
                {
                    b.HasOne("Unisinos.Spotify.Dominio.Album")
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Unisinos.Spotify.Dominio.Playlist", b =>
                {
                    b.HasOne("Unisinos.Spotify.Dominio.Usuario", "Criador")
                        .WithMany()
                        .HasForeignKey("CriadorId");
                });

            modelBuilder.Entity("Unisinos.Spotify.Dominio.PlaylistMusica", b =>
                {
                    b.HasOne("Unisinos.Spotify.Dominio.Musica", "Musica")
                        .WithMany()
                        .HasForeignKey("MusicaId");

                    b.HasOne("Unisinos.Spotify.Dominio.Playlist", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistId");
                });
#pragma warning restore 612, 618
        }
    }
}
