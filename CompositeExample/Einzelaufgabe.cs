using System;

namespace CompositeExample
{
    public class Einzelaufgabe : Aufgabe
    {
        public Einzelaufgabe(string beschreibung) 
            : base(beschreibung)
        { }

        private bool _istErledigt;
        public override bool IstErledigt => _istErledigt;

        public override void Erledigen()
        {
            if(!IstErledigt)
            {
                // nur für die Doku - im Program
                Console.WriteLine($"\t{Beschreibung} wird erledgit.");
                _istErledigt = true;
            }
        }
    }
}
