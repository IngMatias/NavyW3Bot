
// S -  SRP: Tiene la responsabilidad declarar un error.

// O -  OCP: Basta con heredar Exception para implementar un error.

// L -  LSP: Todas las excepciones se comportan de igual manera.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: No aplica.

//      Polymorphism: No aplica.

//      Creator: No aplica.

using System;
using System.IO;

namespace Library
{
    public class NeededEmptyVesselExceptionToString : AbstractItemValidatorsExceptionsToString
    {
        public NeededEmptyVesselExceptionToString()
        :base(new NoEmptyPositionExceptionToString())
        {
        }
        public override string ToString(ItemAddException exception, string lang)
        {
            if (exception is NeededEmptyVesselException)
            {
                return File.ReadAllLines(@"\..\..\language\"+lang+@"\ItemExceptions.txt")[1];
            }
            else 
            {
                return this.SendNext(exception, lang);
            }
        }
    }
}