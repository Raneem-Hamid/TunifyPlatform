using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Repositories.Services;
using TunifyPlatform.Data;
using TunifyPlatform.Repositories.Interfaces;
using TunifyPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.Options;
using Microsoft.OpenApi.Models;

namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // DbContext Configuration
            builder.Services.AddDbContext<TunifyDbContext>(options =>
                options.UseSqlServer(ConnectionString));

            // Identity Configuration
            builder.Services.AddIdentity<Account, IdentityRole>()
                .AddEntityFrameworkStores<TunifyDbContext>()
                .AddDefaultTokenProviders();

            // Service Registrations
            builder.Services.AddControllers();
            builder.Services.AddTransient<IUser, UserService>();
            builder.Services.AddTransient<IArtist, ArtistService>();
            builder.Services.AddTransient<IPlayList, PlayListService>();
            builder.Services.AddTransient<ISong, SongService>();
            builder.Services.AddScoped<IAccount, IdentityAccountService>();
            builder.Services.AddScoped<JwtTokenService>();

            // Swagger Configuration
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
            });

            //Jwt Authentecation
            builder.Services.AddAuthentication(options =>
            {

                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
            });
        

            var app = builder.Build();

            // Middleware Configuration
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.MapControllers();

            // Swagger Middleware
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "musicAPI"; // Set as needed
            });

            // Default Route
            app.MapGet("/", () => "Hello World!");

            // Run the application
            app.Run();
        }
    }
}
