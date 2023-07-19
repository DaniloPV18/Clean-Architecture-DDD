using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation("Inserción nuevos records a la base de datos {context}", typeof(StreamerDbContext).Name);
            }
        }
        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer{ CreatedBy = "danilo", Nombre = "HBO", Url="http://www.hbo.com"},
                new Streamer{ CreatedBy = "danilo", Nombre = "LinuxStream", Url="http://www.ls.com"},
                new Streamer{ CreatedBy = "danilo", Nombre = "MarvelMovies", Url="http://www.mm.com"}
            };
        }
    }
}
