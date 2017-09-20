using System;

namespace SingeltonExample
{
    internal class Configuration : IDisposable
    {
        private static Configuration _instance;

        public static Configuration Instance => _instance ?? (_instance = new Configuration());

        private Configuration()
        { }

        public void Load() => Console.WriteLine("Laden...");

        public void Dispose() => throw new NotImplementedException();
    }
}
