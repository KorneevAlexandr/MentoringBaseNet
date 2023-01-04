using FileCabinet.Console.ConsoleComponents;
using FileCabinet.Repositories;
using FileCabinet.Repositories.FileRepositories;
using FileCabinet.Services;
using FileCabinet.StorageConfiguration;
using Microsoft.Extensions.DependencyInjection;

namespace FileCabinet.Console
{
    public static class DependencyInjection
    {
        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(FileRepository<>));
            serviceCollection.AddScoped(typeof(IDocumentService<>), typeof(DocumentService<>));
            serviceCollection.AddScoped(typeof(IIsbnDocumentService<>), typeof(IsbnDocumentService<>));

            serviceCollection.AddSingleton<IFileStorageConfiguration>(new FileStorageConfiguration("C:\\Users\\Aliaksandr_Karneyeu\\source\\FileCabinet\\Data\\"));

            serviceCollection.AddScoped<IMenu, Menu>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
