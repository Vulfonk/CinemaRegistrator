using System;
using System.Collections.Generic;
using CinemaDB.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB.Data;

public partial class DbCinemaContext : DbContext
{
    public DbCinemaContext()
    {
    }

    public DbCinemaContext(DbContextOptions<DbCinemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=new.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("countries");

            entity.HasIndex(e => e.Id, "IX_countries_ID").IsUnique();

            entity.HasIndex(e => e.Name, "IX_countries_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.ToTable("directors");

            entity.HasIndex(e => e.Id, "IX_directors_ID").IsUnique();

            entity.HasIndex(e => new { e.Name, e.DateBirth }, "IX_directors_name_date_birth").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateBirth).HasColumnName("date_birth");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("films");

            entity.HasIndex(e => e.Id, "IX_films_ID").IsUnique();

            entity.HasIndex(e => new { e.Name, e.Director, e.Year }, "IX_films_name_director_year").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Director).HasColumnName("director");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Genre1).HasColumnName("genre_1");
            entity.Property(e => e.Genre2).HasColumnName("genre_2");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DirectorNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.Director)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Genre1Navigation).WithMany(p => p.FilmGenre1Navigations)
                .HasForeignKey(d => d.Genre1)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Genre2Navigation).WithMany(p => p.FilmGenre2Navigations)
                .HasForeignKey(d => d.Genre2)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genres");

            entity.HasIndex(e => e.Id, "IX_genres_ID").IsUnique();

            entity.HasIndex(e => e.Name, "IX_genres_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.ToTable("halls");

            entity.HasIndex(e => e.Id, "IX_halls_ID").IsUnique();

            entity.HasIndex(e => e.Number, "IX_halls_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Number).HasColumnName("number");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("sessions");

            entity.HasIndex(e => e.Id, "IX_sessions_ID").IsUnique();

            entity.HasIndex(e => new { e.DateTime, e.Hall }, "IX_sessions_date_time_hall").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateTime).HasColumnName("date_time");
            entity.Property(e => e.Film).HasColumnName("film");
            entity.Property(e => e.Hall).HasColumnName("hall");

            entity.HasOne(d => d.FilmNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.Film)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.HallNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.Hall)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("ticket");

            entity.HasIndex(e => e.Id, "IX_ticket_ID").IsUnique();

            entity.HasIndex(e => new { e.Session, e.Place, e.Row }, "IX_ticket_session_place_row").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateTimePurchase).HasColumnName("date_time_purchase");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Row).HasColumnName("row");
            entity.Property(e => e.Session).HasColumnName("session");

            entity.HasOne(d => d.SessionNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.Session)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
