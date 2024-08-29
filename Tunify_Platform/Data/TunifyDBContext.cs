using Microsoft.EntityFrameworkCore;
using Tunify_Platform;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Tunify_Platform.Data
{
        public class TunifyDBContext : IdentityDbContext<ApplicationUser>    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public TunifyDBContext(DbContextOptions<TunifyDBContext> options) : base(options){} 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region PlaylistSong configuration
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => ps.PlaylistSongID);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlists)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistID);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Songs)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongID);
            #endregion

            #region Subscription configuration
            modelBuilder.Entity<Subscription>()
                .HasMany(s => s.Users)
                .WithOne(u => u.Subscription)
                .HasForeignKey(u => u.SubscriptionID);

            modelBuilder.Entity<Subscription>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);
            #endregion

            #region User configuration
            modelBuilder.Entity<User>()
                .HasMany(u => u.Playlists)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserID);
            #endregion

            #region Artist configuration
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithOne(al => al.Artist)
                .HasForeignKey(al => al.ArtistID);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistID);
            #endregion

            #region Album configuration
            modelBuilder.Entity<Album>()
                .HasMany(al => al.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Song configuration
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Seed initial data
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Username = "user1", Email = "user1@example.com", JoinDate = DateTime.Now, SubscriptionID = 1 },
                new User { UserID = 2, Username = "user2", Email = "user2@example.com", JoinDate = DateTime.Now, SubscriptionID = 1 }
            );

            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionID = 1, SubscriptionType = "Basic", Price = 9.99m },
                new Subscription { SubscriptionID = 2, SubscriptionType = "Premium", Price = 19.99m }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { SongID = 1, Title = "Song 1", ArtistID = 1, AlbumID = 1, Duration = new TimeSpan(0, 3, 45), Genre = "Pop" },
                new Song { SongID = 2, Title = "Song 2", ArtistID = 1, AlbumID = 1, Duration = new TimeSpan(0, 4, 20), Genre = "Rock" }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistID = 1, Name = "Artist 1", Bio = "Bio of Artist 1" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumID = 1, AlbumName = "Album 1", ReleaseDate = DateTime.Now, ArtistID = 1 }
            );

            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistID = 1, UserID = 1, PlaylistName = "Playlist 1", CreatedDate = DateTime.Now },
                new Playlist { PlaylistID = 2, UserID = 2, PlaylistName = "Playlist 2", CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<PlaylistSong>().HasData(
                new PlaylistSong { PlaylistSongID = 1, PlaylistID = 1, SongID = 1 },
                new PlaylistSong { PlaylistSongID = 2, PlaylistID = 1, SongID = 2 },
                new PlaylistSong { PlaylistSongID = 3, PlaylistID = 2, SongID = 1 }
            );
            #endregion
        }
    }
}