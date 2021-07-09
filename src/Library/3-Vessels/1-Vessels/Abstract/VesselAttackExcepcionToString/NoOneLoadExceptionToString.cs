
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
    public class NoOneLoadExceptionToString : AbstractVesselAttackExceptionToString
    {
        public NoOneLoadExceptionToString()
        :base(new NoOneMissileExceptionToString())
        {
        }
        public override string ToString(VesselAttackException exception, string lang)
        {
            if (exception is NoOneLoadException)
            {
                return File.ReadAllLines(@"..\..\..\..\..\language"+lang+@"\VesselsAttackException.txt")[0];
            }
            else
            {
                return this.SendNext(exception, lang);
            }
        }
    }
}