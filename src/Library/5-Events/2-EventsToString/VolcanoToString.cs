
// S -  SRP: Esta clase tiene como responsabilidad realizar un evento.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IEvent pero no se
//      modifica el codigo existente para agregar un evento.

// L -  LSP: Esta clase es un subtipo de IEvent.

// I -  ISP: No se utiliza.

// D -  DIP: Volcano depende de AbstractTable, una abstraccion, y LavaAttack que no es una.

//      Expert: No aplica.

//      Polymorphism: El metodo DoEvent es polimorfico a todos los IEvent.

//      Creator: Esta clase usa al patron para crear instancias de LavaAttack, ya que las usa de manera cercana.

using System.IO;

namespace Library
{
    public class VolcanoToString : AbstractIEventToString
    {
        public VolcanoToString()
        :base(new NullIEventToString())
        {
        }
        public override string ToString(IEvent catastrophe, string lang)
        {
            if (catastrophe is Volcano)
            {
                return File.ReadAllLines(@"..\..\..\..\language"+lang+@"\Events.txt")[3];
            }
            else
            {
                return this.SendNext(catastrophe, lang);
            }
        }
    }
}