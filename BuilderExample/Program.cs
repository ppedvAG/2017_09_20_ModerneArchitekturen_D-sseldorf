using System;

namespace BuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var schrank = new Schrank.Builder(4)
                .MitOberfläche(Oberfläche.Gewachst)
                .MitMetallschienen()
                .MitKleiderstange()
                .MitEinlegeböden(3)
                .Konstruiere();

            var builder = new Schrank.Builder(2);

            // nächste Seite - einige Zeit später
            builder.MitOberfläche(Oberfläche.Lackiert);

            // nächste Seite - einige Zeit später
            builder.InFarbe(Farbe.Blau);

            // nächste Seite - einige Zeit später
            builder.MitEinlegeböden(0);

            // nächste Seite - einige Zeit später
            builder.MitMetallschienen();

            // bezahlen
            var bezahlterSchrank = builder.Konstruiere();
            Console.WriteLine(bezahlterSchrank.AnzahlBöden);
            Console.ReadKey();

            builder.MitEinlegeböden(Schrank.MaxBöden);
            Console.WriteLine(bezahlterSchrank.AnzahlBöden);


            Console.ReadKey();
        }
    }
}
