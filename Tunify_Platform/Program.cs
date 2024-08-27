using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<TunifyDBContext>(optionsX => optionsX.UseSqlServer(ConnectionString));

            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();
            builder.Services.AddScoped<ISong, SongService>();

            var app = builder.Build();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}