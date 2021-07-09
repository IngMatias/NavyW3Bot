
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
    public class ArmorAttackExceptionToString : AbstractAttackValidatorsExceptionsToString
    {
        public ArmorAttackExceptionToString()
        : base(new KongAttackExceptionToString())
        {
        }
        public override string ToString(AttackException exception, string lang)
        {
            if (exception is ArmorAttackException)
            {
                return File.ReadAllLines(@"..\..\..\..\..\language\" + lang + @"\AttackExceptions.txt")[1];
            }
            else
            {
                return this.SendNext(exception, lang);
            }
        }
    }
}