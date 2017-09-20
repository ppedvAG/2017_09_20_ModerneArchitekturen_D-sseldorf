namespace CompositeExample
{
    public abstract class Aufgabe
    {
        public Aufgabe(string beschreibung) => Beschreibung = beschreibung;

        public string Beschreibung { get; set; }
        public abstract bool IstErledigt { get; }
        public abstract void Erledigen();
    }
}
