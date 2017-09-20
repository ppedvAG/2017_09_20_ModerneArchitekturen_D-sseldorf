using System;

namespace SingeltonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = Configuration.Instance;
            config.Load();

            Configuration.Instance.Load();
        }
    }
}
