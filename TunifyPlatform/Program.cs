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

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });
            

            var app = builder.Build();
            app.MapControllers();

            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
);


            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "musicAPI";
            });

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
