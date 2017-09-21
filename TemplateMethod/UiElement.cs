using System;
using System.Collections.Generic;

namespace TemplateMethod
{
    internal abstract class UiElement
    {
        public List<UiElement> Children { get; } = new List<UiElement>();

        // Die Template Method
        public void Zeichnen()      // darf nicht virtual oder abstract sein!!
        {
            // Der Algorithmus
            // 1. Rahmen Zeichnen
            // 2. Inhalt Zeichnen
            // 3. Unterelemente Zeichnen

            ZeichneRahmen();
            ZeichneSchatten();
            ZeichneInhalt();
            ZeichneUnterelemente();
        }

        // 1. kann überschrieben werden
        protected virtual void ZeichneRahmen()
        {
            Console.WriteLine("Zeichne default Rahmen.");
        }

        // 2. muss überschrieben werden
        protected abstract void ZeichneInhalt();

        // 3. kann nicht überschrieben werden.
        private void ZeichneUnterelemente()
        {
            Children.ForEach(e => e.Zeichnen());
        }

        // 4. Hook
        protected virtual void ZeichneSchatten() { /* absichtlich leer */ }
    }
}
