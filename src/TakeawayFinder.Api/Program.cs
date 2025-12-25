using TakeawayFinder.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () =>
{
    string data = await JustEatApi.GetData();
    
    return Results.Content(data, "application/json");
});

app.Run();