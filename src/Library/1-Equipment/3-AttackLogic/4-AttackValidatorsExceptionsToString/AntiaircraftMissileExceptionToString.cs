
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
    public class AntiaircraftMissileExceptionToString : AbstractAttackValidatorsExceptionsToString
    {
        public AntiaircraftMissileExceptionToString()
        :base(new ArmorAttackExceptionToString())
        {
        }
        public override string ToString(AttackException exception, string lang)
        {
            if (exception is AntiaircraftMissileException)
            {
                return File.ReadAllLines(@"..\..\..\..\..\language\"+lang+@"\AttackExceptions.txt")[0];
            }
            else 
            {
                return this.SendNext(exception, lang);
            }
        }
    }
}