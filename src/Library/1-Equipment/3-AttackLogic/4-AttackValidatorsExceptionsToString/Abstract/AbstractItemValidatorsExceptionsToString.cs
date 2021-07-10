
// S -  SRP: Tiene la responsabilidad declarar un error.

// O -  OCP: Basta con heredar Exception para implementar un error.

// L -  LSP: Todas las excepciones se comportan de igual manera.

// I -  ISP: No aplica.

// D -  DIP: No aplica.

//      Expert: No aplica.

//      Polymorphism: No aplica.

//      Creator: No aplica.

using System;

namespace Library
{
    public abstract class AbstractAttackValidatorsExceptionsToString
    {
        private AbstractAttackValidatorsExceptionsToString _next;
        public AbstractAttackValidatorsExceptionsToString(AbstractAttackValidatorsExceptionsToString next)
        {
            this._next = next;
        }
        public abstract string ToString(AttackException exception, string language);
        public string SendNext(AttackException exception, string language)
        {
            return this._next.ToString(exception, language);
        }
    }
}