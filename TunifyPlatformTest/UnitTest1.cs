using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;   // Update with the actual namespace
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Repositories.Services;
using TunifyPlatform.Models; 

public class PlaylistServiceTests
{
    [Fact]
    public async Task GetSongsForPlaylist_ReturnsCorrectSongs()
    {
        // Arrange
        var playlistId = 1;
        var mockSongs = new List<Song>
        {
            new Song { Id = 1, Title = "Song 1", Genre = "Rock", Duration = new TimeSpan(0, 3, 45), playlistSongs = new List<PlaylistSongs>() },
            new Song { Id = 2, Title = "Song 2", Genre = "Pop", Duration = new TimeSpan(0, 4, 30), playlistSongs = new List<PlaylistSongs>() }
        };

        var mockPlaylists = new List<Playlist>
        {
            new Playlist { Id = playlistId, PlayList_Name = "My Playlist", playlistSongs = new List<PlaylistSongs>() }
        }.AsQueryable();

        var mockDbSet = new Mock<DbSet<Playlist>>();
        mockDbSet.As<IQueryable<Playlist>>().Setup(m => m.Provider).Returns(mockPlaylists.Provider);
        mockDbSet.As<IQueryable<Playlist>>().Setup(m => m.Expression).Returns(mockPlaylists.Expression);
        mockDbSet.As<IQueryable<Playlist>>().Setup(m => m.ElementType).Returns(mockPlaylists.ElementType);
        mockDbSet.As<IQueryable<Playlist>>().Setup(m => m.GetEnumerator()).Returns(mockPlaylists.GetEnumerator());

        var mockContext = new Mock<TunifyDbContext>();
        mockContext.Setup(c => c.playlist).Returns(mockDbSet.Object);

        var service = new PlayListSongsService(mockContext.Object);

        // Act
        var songs = await service.GetAllSongInList(playlistId);

        // Assert
        Assert.Equal(2, songs.Count);
        Assert.Contains(songs, s => s.Title == "Song 1");
        Assert.Contains(songs, s => s.Title == "Song 2");
    }
}
