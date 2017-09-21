using DecoratorExample.Caching;
using DecoratorExample.Core;
using DecoratorExample.Data;
using DecoratorExample.Logging;
using System;
using System.Collections.Generic;

namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            var cache = new Cache();

            var repository = new Repository();
            var loggingRepository = new LoggingRepository(repository, logger);
            var cachingRepository = new CachingRepository(loggingRepository, cache, cachtime: 20);
            var vm = new ViewModel(cachingRepository);

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

        public IEnumerable<string> Customers { get; set; }

        // Dependency Inversion
        public ViewModel(IRepository repository) => _repository = repository;

        public void Initialize()
        {
            Customers = _repository.GetAllCustomers();
        }
    }
}
