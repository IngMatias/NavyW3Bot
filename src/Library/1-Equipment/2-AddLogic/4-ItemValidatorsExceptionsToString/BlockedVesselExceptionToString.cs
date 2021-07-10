
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
    public class BlockedVesselExceptionToString : AbstractItemValidatorsExceptionsToString
    {
        public BlockedVesselExceptionToString()
        :base(new NeededEmptyVesselExceptionToString())
        {
        }
        public override string ToString(ItemAddException exception, string lang)
        {
            if (exception is BlockedVesselException)
            {
                return File.ReadAllLines(@"..\..\language\"+lang+@"\ItemExceptions.txt")[0];
            }
            else 
            {
                return this.SendNext(exception, lang);
            }
        }
    }
}