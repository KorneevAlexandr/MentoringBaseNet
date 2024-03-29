﻿using FileCabinet.Caching;
using FileCabinet.Console.ConsoleComponents;
using FileCabinet.Console.ConsoleComponents.DocumentComponents;
using FileCabinet.Console.ConsoleComponents.DocumentFormatters;
using FileCabinet.Domain;
using FileCabinet.Repositories;
using FileCabinet.Repositories.FileRepositories;
using FileCabinet.Services;
using FileCabinet.StorageConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileCabinet.Console
{
    public static class DependencyInjection
    {
        private const string StoragePathSectionName = "StoragePath";
        private const string CachingOptionsSectionName = "CachingOptions";

        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            var configuration = GetConfiguration();

            serviceCollection.AddSingleton<IFileStorageConfiguration>(new FileStorageConfiguration(configuration.GetValue<string>(StoragePathSectionName)));

            serviceCollection.AddMemoryCache();

            serviceCollection.Configure<CachingOptions>(configuration.GetSection(CachingOptionsSectionName));

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(FileRepository<>));
            serviceCollection.AddScoped(typeof(IDocumentService<>), typeof(DocumentService<>));
            serviceCollection.AddScoped(typeof(IIsbnDocumentService<>), typeof(IsbnDocumentService<>));

            serviceCollection.AddScoped<IMenu, Menu>();

            serviceCollection.AddScoped(typeof(IDocumentComponent<>), typeof(DocumentComponent<>));
            serviceCollection.AddScoped(typeof(IIsbnDocumentComponent<>), typeof(IsbnDocumentComponent<>));
            serviceCollection.AddScoped<IDocumentFormatter<Book>, BookFormatter>();
            serviceCollection.AddScoped<IDocumentFormatter<LocalBook>, LocalBookFormatter>();
            serviceCollection.AddScoped<IDocumentFormatter<Patent>, PatentFormatter>();
            serviceCollection.AddScoped<IDocumentFormatter<Magazine>, MagazineFormatter>();

            return serviceCollection.BuildServiceProvider();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            return builder.Build();
        }
    }
}
