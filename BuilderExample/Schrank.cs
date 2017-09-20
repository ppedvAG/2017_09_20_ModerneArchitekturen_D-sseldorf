using System;

namespace BuilderExample
{
    internal class Schrank
    {
        public const byte MinTüren = 2;
        public const byte MaxTüren = 7;
        public const byte MinBöden = 0;
        public const byte MaxBöden = 6;

        private Schrank(byte anzahlTüren) => AnzahlTüren = anzahlTüren;

        public byte AnzahlTüren { get; private set; }
        public Oberfläche Oberfläche { get; private set; }
        public Farbe Farbe { get; private set; }
        public bool Metallschienen { get; private set; }
        public byte AnzahlBöden { get; private set; }
        public bool Kleiderstange { get; private set; }

        public class Builder
        {
            private readonly Schrank _schrank;

            public Builder(byte anzahlTüren)
            {
                if (anzahlTüren < MinTüren || anzahlTüren > MaxTüren)
                    throw new ArgumentException($"Die Anzahl der Türen muss zwischen {MinTüren} und {MaxTüren} liegen.");

                _schrank = new Schrank(anzahlTüren)
                {
                    Oberfläche = Oberfläche.Lackiert,
                    Farbe = Farbe.Weiß,
                    AnzahlBöden = 2,
                    Kleiderstange = false,
                    Metallschienen = false
                };
            }

            public Builder MitOberfläche(Oberfläche oberfläche)
            {
                if (oberfläche != Oberfläche.Lackiert && _schrank.Farbe != Farbe.KeineFarbe)
                    _schrank.Farbe = Farbe.KeineFarbe;

                _schrank.Oberfläche = oberfläche;

                return this;
            }

            public Builder InFarbe(Farbe farbe)
            {
                if (_schrank.Oberfläche != Oberfläche.Lackiert && farbe != Farbe.KeineFarbe)
                    throw new ArgumentException($"Eine Farbe kann nur bei Oberfläche Lackiert gesetzt werden.");

                _schrank.Farbe = farbe;

                return this;
            }

            public Builder MitEinlegeböden(byte anzahl)
            {
                if (anzahl < MinBöden || anzahl > MaxBöden)
                    throw new ArgumentException($"Die Anzahl der Böden muss zwischen {MinBöden} und {MaxBöden} liegen.");

                _schrank.AnzahlBöden = anzahl;

                return this;
            }

            public Builder MitKleiderstange() => MitKleiderstange(true);
            public Builder MitKleiderstange(bool kleiderstange)
            {
                _schrank.Kleiderstange = kleiderstange;
                return this;
            }

            public Builder MitMetallschienen() => MitMetallschienen(true);
            public Builder MitMetallschienen(bool metallschienen)
            {
                _schrank.Metallschienen = metallschienen;
                return this;
            }

            public Schrank Konstruiere() => (Schrank)_schrank.MemberwiseClone();
        }
    }
}
