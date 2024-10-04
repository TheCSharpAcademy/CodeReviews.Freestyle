using WebScraper;
using Utilities;
using Data.Controller;
using Data.Service;
using Data.Repository;
using Data;


var scraper = new SeleniumWebScraper();

Logger.Log("[lime]Starting Football Match Predictor...[/]");

await scraper.DownloadExcelFile();
Logger.Log("[lime]Excel file downloaded and processed successfully.[/]");

var context = new FootballContext();
IMatchDataRepository matchDataRepository= new MatchDataRepository(context);
IDataSeeder dataSeeder = new DataSeeder(matchDataRepository);
IExcelToDatabaseOperation dataController = new ExcelToDatabaseOperation(dataSeeder, matchDataRepository);
await dataController.RunOperation();
// var builder = Host.CreateApplicationBuilder(args);

// ConfigureServices(builder.Services, builder.Configuration);

// var host = builder.Build();

// void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
// {
//     services.AddSingleton<IWebScraper, SeleniumWebScraper>();
// }