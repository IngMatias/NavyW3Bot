
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
    public abstract class AbstractItemValidatorsExceptionsToString
    {
        private AbstractItemValidatorsExceptionsToString _next;
        public AbstractItemValidatorsExceptionsToString(AbstractItemValidatorsExceptionsToString next)
        {
            this._next = next;
        }
        public abstract string ToString(ItemAddException exception, string language);
        public string SendNext(ItemAddException exception, string language)
        {
            return this._next.ToString(exception, language);
        }
    }
}