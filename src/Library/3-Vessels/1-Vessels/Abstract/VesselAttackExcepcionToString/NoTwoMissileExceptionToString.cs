
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
    public class NoTwoMissileExceptionToString : AbstractVesselAttackExceptionToString
    {
        public NoTwoMissileExceptionToString()
        :base(new NullVesselAttackExceptionToString())
        {
        }
        public override string ToString(VesselAttackException exception, string lang)
        {
            if (exception is NoTwoMissileException)
            {
                return File.ReadAllLines(@"..\..\..\..\..\language"+lang+@"\VesselsAttackException.txt")[2];
            }
            else
            {
                return this.SendNext(exception, lang);
            }
        }
    }
}