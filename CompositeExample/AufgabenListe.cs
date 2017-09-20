using System;
using System.Collections.Generic;

namespace CompositeExample
{
    public class AufgabenListe : Aufgabe
    {
        private readonly List<Aufgabe> _aufgaben = new List<Aufgabe>();

        public AufgabenListe(string beschreibung) 
            : base(beschreibung)
        { }

        public override bool IstErledigt => _aufgaben.TrueForAll(a => a.IstErledigt);

        public override void Erledigen()
        {
            if(!IstErledigt)
            {
                Console.WriteLine($"{Beschreibung} wird erledigt.");
                _aufgaben.ForEach(a => a.Erledigen());
            }
        }

        public void Hinzufügen(Aufgabe aufgabe) => _aufgaben.Add(aufgabe);
    }
}
