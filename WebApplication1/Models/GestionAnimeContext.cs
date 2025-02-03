using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class GestionAnimeContext : DbContext
{
    public GestionAnimeContext()
    {
    }

    public GestionAnimeContext(DbContextOptions<GestionAnimeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anime> Animes { get; set; }

    public virtual DbSet<Personaje> Personajes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TJK1E5N\\SQLEXPRESS;Database=gestionAnime;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>(entity =>
        {
            entity.HasKey(e => e.IdAnime).HasName("PK__animes__F69BDB2ADD0AC163");

            entity.ToTable("animes");

            entity.Property(e => e.IdAnime).HasColumnName("id_anime");
            entity.Property(e => e.Descripcion)
                .HasColumnType("ntext")
                .HasColumnName("descripcion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");
        });

        modelBuilder.Entity<Personaje>(entity =>
        {
            entity.HasKey(e => e.IdPersonaje).HasName("PK__personaj__81949F401E60E81B");

            entity.ToTable("personajes");

            entity.Property(e => e.IdPersonaje).HasColumnName("id_personaje");
            entity.Property(e => e.Descripcion)
                .HasColumnType("ntext")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdAnime).HasColumnName("id_anime");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(255)
                .HasColumnName("imagen_url");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdAnimeNavigation).WithMany(p => p.Personajes)
                .HasForeignKey(d => d.IdAnime)
                .HasConstraintName("FK__personaje__id_an__3D5E1FD2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04ADEEBD9008");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E61641D31F97B").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__usuarios__F3DBC572165B5704").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
