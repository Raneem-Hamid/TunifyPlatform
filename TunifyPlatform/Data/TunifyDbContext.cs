using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Models;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Data
{
    public class TunifyDbContext : IdentityDbContext<Account>
    {
        public TunifyDbContext ( DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> user { get; set; }

        public DbSet<Subscription> supscribtion { get; set; }

        public DbSet<Playlist> playlist { get; set; }

        public DbSet<Song> song { get; set; }

        public DbSet<Album> album { get; set; }

        public DbSet<Artist> artist { get; set; }

        public DbSet<PlaylistSongs> playlistSongs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlaylistSongs>().HasKey(pk => new { pk.Playlist_ID, pk.Song_ID });

            modelBuilder.Entity<PlaylistSongs>()
               .HasOne(s => s.Song)
               .WithMany(pls => pls.playlistSongs)
            .HasForeignKey(s => s.Song_ID);

            modelBuilder.Entity<PlaylistSongs>()
                .HasOne(p => p.Playlist)
                .WithMany(pls => pls.playlistSongs)
                .HasForeignKey(P => P.Playlist_ID);

            modelBuilder.Entity<Song>()
              .HasOne(a => a.artist)
              .WithMany(s => s.song)
           .HasForeignKey(s => s.Artist_ID);


            // Seed data for Subscriptions
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { Id = 1, Type = "Free", price = "0" },
                new Subscription { Id = 2, Type = "Premium", price = "9.99m" },
                new Subscription { Id = 3, Type = "Family", price = "14.99m" }
            );

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "user1", Email = "user1@example.com", Join_Date = DateTime.Now, Subscription_ID = 1 },
                new User { Id = 2, UserName = "user2", Email = "user2@example.com", Join_Date = DateTime.Now, Subscription_ID = 2 },
                new User { Id = 3, UserName = "user3", Email = "user3@example.com", Join_Date = DateTime.Now, Subscription_ID = 3 }
            );

            // Seed data for Artists
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Id = 1, Name = "Artist 1", Bio = "Bio for Artist 1" },
                new Artist { Id = 2, Name = "Artist 2", Bio = "Bio for Artist 2" },
                new Artist { Id = 3, Name = "Artist 3", Bio = "Bio for Artist 3" }
            );

            // Seed data for Albums
            modelBuilder.Entity<Album>().HasData(
                new Album { Id = 1, Album_Name = "Album 1", Release_Date = new DateTime(2020, 1, 1), Artist_ID = 1 },
                new Album { Id = 2, Album_Name = "Album 2", Release_Date = new DateTime(2021, 5, 1), Artist_ID = 2 },
                new Album { Id = 3, Album_Name = "Album 3", Release_Date = new DateTime(2022, 9, 1), Artist_ID = 3 }
            );

            // Seed data for Songs
            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Title = "Song 1", Artist_ID = 1, Album_ID = 1, Duration = new TimeSpan(0, 3, 45), Genre = "Pop" },
                new Song { Id = 2, Title = "Song 2", Artist_ID = 2, Album_ID = 2, Duration = new TimeSpan(0, 3, 45), Genre = "Rock" },
                new Song { Id = 3, Title = "Song 3", Artist_ID = 3, Album_ID = 3, Duration = new TimeSpan(0, 3, 45), Genre = "Jazz" }
            );

            // Seed data for Playlists
            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { Id = 1, User_ID = 1, PlayList_Name = "Playlist 1", Created_Date = DateTime.Now },
                new Playlist { Id = 2, User_ID = 2, PlayList_Name = "Playlist 2", Created_Date = DateTime.Now },
                new Playlist { Id = 3, User_ID = 3, PlayList_Name = "Playlist 3", Created_Date = DateTime.Now }
            );

            // Seed data for PlaylistSongs (join table)
            modelBuilder.Entity<PlaylistSongs>().HasData(
                new PlaylistSongs { Playlist_ID = 1, Song_ID = 1 },
                new PlaylistSongs { Playlist_ID = 2, Song_ID = 2 },
                new PlaylistSongs { Playlist_ID = 3, Song_ID = 3 }
            );

            SeedRoles(modelBuilder, "Admin", new[] { "ManageUsers", "ManagePlaylists" });
            SeedRoles(modelBuilder, "User", new[] { "ViewPlaylists", "AddSongs" });

        }


        private void SeedRoles(ModelBuilder modelBuilder , string roleName , params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName,
                Name = roleName.ToLower(),
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            //foreach (var permission in permissions)
            //{
            //    var roleClaim = new IdentityRoleClaim<string>
            //    {
                   
            //        RoleId = role.Id,
            //        ClaimType = "Permission",
            //        ClaimValue = permission
            //    };

            //    modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaim);
            //}
        }
    }
}
