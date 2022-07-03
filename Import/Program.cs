using Contract;
using Contract.Dtos;
using Contract.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Import
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ConfigureServices();

                //if (args.Length == 0)
                //{
                //    Log.Logger.Information("There is no file to process...");
                //    return;
                //}

                string fullPath = @"C:\Users\aaziz\Downloads\software engineer coding assessment\software engineer\coding\feed-products\capterra.yaml";// args[0].ToString();
                
                EnumExtension fileExtension = GetFileExtension(fullPath);

                if (fileExtension == EnumExtension.Unknown)
                {
                    Log.Logger.Information("File could not be found or its format is not supported");
                    return;
                }
                Log.Logger.Information("Reading file content....");

                var fileContent = ReadFileContent(fullPath);
                ImportData importData = new();
                switch (fileExtension)
                {

                    case EnumExtension.Json:

                        IList<JsonProductDto> json = importData.ImportJson(fileContent);

                        if (json is null)
                        {
                            Log.Logger.Information($"File {fullPath} could not be deserialized.");
                            return;
                        }

                        var flatten = json.SelectMany(o => o.Categories
                                .Select(p => new
                                {
                                    Category = p,
                                    o.Title,
                                    o.Twitter
                                }));

                        foreach (var item in flatten)
                        {
                            Console.WriteLine($"importing: name: {item.Title}; Categories: {item.Category}; Twitter: {item.Twitter}");
                        }
                        break;

                    case EnumExtension.Yaml:
                        
                        IList<YamlProductDto> yaml = importData.ImportJaml(fileContent);
                        if (yaml is null)
                        {
                            Log.Logger.Information($"File {fullPath} could not be deserialized.");
                            return;
                        }

                        foreach (YamlProductDto item in yaml)
                        {
                            Console.WriteLine($"importing: name: {item.Name}; Categories: {item.Tags}; Twitter: {item.Twitter}");
                        }
                        break;

                    default:

                        Log.Logger.Information($"File {fullPath} format is not supported");
                        break;
                }


            }
            catch (Exception exception)
            {

                Log.Logger.Fatal(exception, "Error while importing products");
                throw;
            }

        }
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", 
                                    optional: false, 
                                    reloadOnChange: true);
        }
        private static void ConfigureServices()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            //setting log with serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger.Information("Startup Application");

            //setting dependency injection and app settings
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IImportData, ImportData>();
                })
                .UseSerilog()
                .Build();

            ActivatorUtilities.CreateInstance<ImportData>(host.Services);
        }
        private static string ReadFileContent(string fileFullPath)
        {
            using StreamReader stream = new($"{fileFullPath}");
            return stream.ReadToEnd();
        }
        static EnumExtension GetFileExtension(string fileName)
        {
            string ex = Path.GetExtension(fileName).ToLower();
            return ex switch
            {
                ".json" => EnumExtension.Json,
                ".yaml" => EnumExtension.Yaml,
                _ => EnumExtension.Unknown,
            };
        }
        enum EnumExtension
        {
            Json,
            Yaml,
            Unknown
        }
    }
}
