using WebScraper;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


var scraper = new SeleniumWebScraper();

Console.WriteLine("Starting Football Match Predictor...");

await scraper.DownloadExcelFile();
Console.WriteLine("Excel file downloaded and processed successfully.");

// var builder = Host.CreateApplicationBuilder(args);

// ConfigureServices(builder.Services, builder.Configuration);

// var host = builder.Build();

// void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
// {
//     services.AddSingleton<IWebScraper, SeleniumWebScraper>();
// }