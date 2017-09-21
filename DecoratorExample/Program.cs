using DecoratorExample.Caching;
using DecoratorExample.Core;
using DecoratorExample.Data;
using DecoratorExample.Logging;
using StructureMap;
using System;
using System.Collections.Generic;

namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var logger = new ConsoleLogger();
            //var cache = new Cache();
            //var repository = new Repository();
            //var loggingRepository = new LoggingRepository(repository, logger);
            //var cachingRepository = new CachingRepository(loggingRepository, cache, cachtime: 20);
            //var vm = new ViewModel(cachingRepository);

            //IRepository repository = new Repository();
            //repository = new LoggingRepository(repository, logger);
            //repository = new CachingRepository(repository, cache, cachtime: 20);
            //var vm = new ViewModel(repository);

            var container = new Container(c =>
            {
                c.For<ILogger>().Use<ConsoleLogger>().Singleton();
                c.For<ICache>().Use<SimpleCache>().Singleton();

                c.For<IRepository>().Use<Repository>();
                c.For<IRepository>().DecorateAllWith<LoggingRepository>();
                c.For<IRepository>().DecorateAllWith<CachingRepository>().Ctor<int>().Is(10);
            });

            var vm = container.GetInstance<ViewModel>();

            do
            {
                vm.Initialize();

                // fancy Presentation durch XAML Code
                foreach (var c in vm.Customers)
                    Console.WriteLine(c);
                Console.WriteLine();
            }
            while (Console.ReadKey().Key != ConsoleKey.Q);
        }
    }

    internal class ViewModel
    {
        private readonly IRepository _repository;
        private readonly IContainer _container;

        public IEnumerable<string> Customers { get; set; }

        // Dependency Inversion
        public ViewModel(IRepository repository) => _repository = repository;

        public void Initialize() => Customers = _repository.GetAllCustomers();
    }
}
