using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Repositories.Services;
using TunifyPlatform.Data;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(option => option.UseSqlServer(ConnectionString));
            builder.Services.AddControllers();
            builder.Services.AddTransient<IUser, UserService>();
            builder.Services.AddTransient<IArtist, ArtistService>();
            builder.Services.AddTransient<IPlayList, PlayListService>();
            builder.Services.AddTransient<ISong, SongService>();

            var app = builder.Build();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
