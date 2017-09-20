using System;

namespace HalloDelegates
{
    public delegate string MyDelegate(int zahl, double wert);

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate(MeineMethode);

            string result = del.Invoke(7, 8.9);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static string MeineMethode(int i, double d)
        {
            return (i + d).ToString();
        }
    }
}
