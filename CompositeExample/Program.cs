using System;

namespace CompositeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var aufgaben = new AufgabenListe("Alles was so anfällt.");

            var patterns = new AufgabenListe("Patterns lernen! :D");
            patterns.Hinzufügen(new Einzelaufgabe("Composite"));
            patterns.Hinzufügen(new Einzelaufgabe("Builder"));
            patterns.Hinzufügen(new Einzelaufgabe("MVVM"));

            var urlaub = new AufgabenListe("Koffer packen");
            urlaub.Hinzufügen(new Einzelaufgabe("Duschgel"));
            urlaub.Hinzufügen(new Einzelaufgabe("Handtuch"));
            urlaub.Hinzufügen(new Einzelaufgabe("Badehose"));

            aufgaben.Hinzufügen(patterns);
            aufgaben.Hinzufügen(urlaub);

            urlaub.Erledigen();

            aufgaben.Erledigen();

            Console.ReadKey();
        }
    }
}
