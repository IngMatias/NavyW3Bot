
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
    public class WrongVesselExceptionToString : AbstractItemValidatorsExceptionsToString
    {
        public WrongVesselExceptionToString()
        : base(new NullExceptionToString())
        {
        }
        public override string ToString(ItemAddException exception, string lang)
        {
            if (exception is WrongVesselException)
            {
                return File.ReadAllLines(@"..\..\..\..\..\..\language\" + lang + @"\ItemExceptions.txt")[5];
            }
            else
            {
                return this.SendNext(exception,lang);
            }
        }
    }
}