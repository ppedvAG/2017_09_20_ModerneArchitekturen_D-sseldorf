using System;

namespace TemplateMethod
{
    internal class Button : UiElement
    {
        protected override void ZeichneInhalt() => Console.WriteLine("Zeichne Button Inhalt.");
        protected override void ZeichneSchatten() => Console.WriteLine("Zeichne Button Schatten.");
    }
}
