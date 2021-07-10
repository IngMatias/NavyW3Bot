
// S -  SRP: Esta clase tiene como responsabilidad realizar un evento.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IEvent pero no se
//      modifica el codigo existente para agregar un evento.

// L -  LSP: Esta clase es un subtipo de IEvent.

// I -  ISP: No se utiliza.

// D -  DIP: MeteorShower depende de AbstractTable, una abstraccion, y MeteorAttack que no es una.

//      Expert: Esta clase conoce la cantidad de meteoros que debe lanzar, por lo tanto se encarga de lanzarlos.

//      Polymorphism: El metodo DoEvent es polimorfico a todos los IEvent.

//      Creator: Esta clase usa al patron para crear instancias de MeteorAttack, ya que las usa de manera cercana.

using System.IO;

namespace Library
{
    public class MeteorShowerToString : AbstractIEventToString
    {
        public MeteorShowerToString()
        :base(new VolcanoToString())
        {
        }
        public override string ToString(IEvent catastrophe, string lang)
        {
            if (catastrophe is MeteorShower)
            {
                return File.ReadAllLines(@"..\..\..\..\language"+lang+@"\Events.txt")[2];
            }
            else
            {
                return this.SendNext(catastrophe, lang);
            }
        }
    }
}