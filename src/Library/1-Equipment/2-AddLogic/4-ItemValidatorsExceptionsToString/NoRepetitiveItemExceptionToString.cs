
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
    public class NoRepetitiveItemExceptionToString : AbstractItemValidatorsExceptionsToString
    {
        public NoRepetitiveItemExceptionToString()
        : base(new TooShortVesselExceptionToString())
        {
        }
        public override string ToString(ItemAddException exception, string lang)
        {
            if (exception is NoRepetitiveItemException)
            {
                return File.ReadAllLines(@"..\..\..\..\..\..\language\" + lang + @"\ItemExceptions.txt")[3];
            }
            else
            {
                return this.SendNext(exception,lang);
            }
        }
    }
}