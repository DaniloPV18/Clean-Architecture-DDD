using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

StreamerDbContext streamerDbContext = new();
//QueryStreaming();
//await AddNewRecords();
//await QueryFilter();
//await QueryMethods();
//await TrackingAndNotTracking();
//await AddNewStreamerWithVideo();
//await AddNewActorWithVideo();
//await AddNewDirectorWithVideo();
//Console.WriteLine("Presione cualquier tecla para terminar el programa");
//Console.ReadKey();
//await MultipleEntitiesQuery();
//Streamer streamer = new()
//{
//    Nombre = "Amazon Prime",
//    Url = "https://www.amazonprime.com"
//};
//streamerDbContext!.Streamers!.Add(streamer);
//await streamerDbContext.SaveChangesAsync();
//var movies = new List<Video>
//{
//    new Video { Name="Mad Max",StreamerId=1},
//    new Video { Name="Crepusculo",StreamerId=streamer.Id},
//    new Video { Name="Batman",StreamerId=streamer.Id},
//    new Video { Name="Madagascar",StreamerId=streamer.Id}
//};
//await streamerDbContext!.AddRangeAsync(movies);
//await streamerDbContext!.SaveChangesAsync();
async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await streamerDbContext!.Videos!.Include(x => x.Actores).FirstOrDefaultAsync(q => q.Id == 1);
    //var actor = await streamerDbContext.Actor!.Select(q=> q.Nombre).ToListAsync();
    var videoWithDirector = await streamerDbContext!.Videos!
        .Where(q => q.Director != null)
        .Include(q => q.Director)
        .Select(q =>
            new
            {
                Director_Nombre_Completo = $"{q.Director.Nombre} {q.Director.Apellido}",
                Movie = q.Name
            }
        )
        .ToListAsync();
    foreach (var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre_Completo}");
    }
}
async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };
    await streamerDbContext.AddAsync(director);
    await streamerDbContext.SaveChangesAsync();
}
async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Alfonso",
        Apellido = "Vegas"
    };
    await streamerDbContext.AddAsync(actor);
    await streamerDbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1,
    };
    await streamerDbContext.AddAsync(videoActor);
    await streamerDbContext.SaveChangesAsync();
}
async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };
    var hungerGames = new Video
    {
        Name = "Hunger Games",
        Streamer = pantaya,
    };
    await streamerDbContext.AddAsync(hungerGames);
    await streamerDbContext.SaveChangesAsync();
}
async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await streamerDbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNotTracking = await streamerDbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);
    streamerWithTracking!.Nombre = "Netflix super";
    streamerWithNotTracking!.Nombre = "Amazon Plus";

    await streamerDbContext.SaveChangesAsync();
}
async Task QueryLinq()
{
    Console.WriteLine("Ingrese nombre streamer");
    var streamingName = Console.ReadLine();
    var streamers = await (from i in streamerDbContext.Streamers
                           where EF.Functions.Like(i.Nombre!, $"%{streamingName}%")
                           select i).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task QueryMethods()
{
    var streamer = streamerDbContext!.Streamers!;
    //ASUME SIEMPRE QUE VA A EXISTIR UN REGISTRO
    var firstAsync = await streamer.Where(y => y.Nombre.Contains("a")).FirstAsync();
    //DEVOLVER NULL O VALOR POR DEFECTO
    var firstOrDefaultAsync = await streamerDbContext!.Streamers!.Where(y => y.Nombre.Contains("a")).FirstOrDefaultAsync();
    var firstOrDefaultAsync_v2 = await streamerDbContext!.Streamers!.FirstOrDefaultAsync(y => y.Nombre.Contains("a"));
    //DEVUELVE ERROR CUANDO DEVUELVE UNA COLECCION, PREFERIBLE BUSCAR POR ID
    var singleAsync = await streamer.SingleAsync();
    //DEVUELVE NULO CUANDO DEVUELVE UNA COLECCION, PREFERIBLE BUSCAR POR ID
    var singleOrDefaultAsync = await streamer.SingleOrDefaultAsync();
    var resultado = await streamer.FindAsync(1);
}
async Task QueryFilter()
{
    Console.WriteLine("Ingrese nombre del streamer");
    var streamingName = Console.ReadLine();
    var streamers = await streamerDbContext!.Streamers!.Where(x => x.Nombre == streamingName).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
    //var streamerPartialResults = await streamerDbContext!.Streamers!.Where(x => x.Nombre.Contains(streamingName)).ToListAsync();
    var streamerPartialResults = await streamerDbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre, $"%{streamingName}%")).ToListAsync();
    foreach (var streamer in streamerPartialResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
void QueryStreaming()
{
    var streamers = streamerDbContext!.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}
async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://www.disney.com"
    };
    streamerDbContext!.Streamers!.Add(streamer);
    await streamerDbContext.SaveChangesAsync();
    var movies = new List<Video>
    {
        new Video { Name="La sirenita",StreamerId=streamer.Id},
        new Video { Name="101 Dalmatas",StreamerId=streamer.Id},
        new Video { Name="Cenicienta",StreamerId=streamer.Id},
        new Video { Name="Star Wars",StreamerId=streamer.Id}
    };
    await streamerDbContext!.AddRangeAsync(movies);
    await streamerDbContext!.SaveChangesAsync();
}