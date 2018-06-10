namespace Homework8.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Homework8.Model;

    public partial class ArtistContext : DbContext
    {
        public ArtistContext()
            : base("name=ArtistContext")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Artwork> Artworks { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Artworks)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Artwork>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.Artwork)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Classifications)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);
        }
    }
}
