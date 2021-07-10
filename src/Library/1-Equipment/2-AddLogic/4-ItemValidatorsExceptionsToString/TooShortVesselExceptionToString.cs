
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
    public class TooShortVesselExceptionToString : AbstractItemValidatorsExceptionsToString
    {
        public TooShortVesselExceptionToString()
        : base(new WrongVesselExceptionToString())
        {
        }
        public override string ToString(ItemAddException exception, string lang)
        {
            if (exception is TooShortVesselException)
            {
                return File.ReadAllLines(@"..\..\language\" + lang + @"\ItemExceptions.txt")[4];
            }
            else
            {
                return this.SendNext(exception,lang);
            }
        }
    }
}