using System.Text.Json;
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;
public class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
       await DB.InitAsync("SearchDb", MongoClientSettings
        .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

       // create index for the items
       await DB.Index<Item>()
           .Key(x => x.Make, KeyType.Text)
           .Key(x => x.Model, KeyType.Text)
           .Key(x => x.Color, KeyType.Text)
           .CreateAsync();

        // check if we already have some other items in the DB
        var count = await DB.CountAsync<Item>();

        // removed the part where Mongo DB was populated by the json file

        using var scope = app.Services.CreateScope();

        var httpClient = scope.ServiceProvider.GetRequiredService<AuctionSvcHttpClient>();

        var items = await httpClient.GetItemForSearchDb();

        Console.WriteLine(items.Count + " returned from the auction service");

        if (items.Count > 0) await DB.SaveAsync(items);

    }
}
