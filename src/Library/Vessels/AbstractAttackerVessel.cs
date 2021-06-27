
// S - SRP: Esta clase tiene la responsabilidad de definir los metodos necesarios para que un barco pueda atacar.

// O -  OCP: No se aplica, para agregar una forma diferente de atacar hay que modificar este codigo.

// L -  LSP: Cualquier clase que herede esta debe ser y es un subtipo de esta clase.

// I -  ISP: No se aplica.

// D -  DIP: Esta clase solo depende de abstracciones.

//      Expert: No se aplica.

//      Polymorphism: No se aplica.

//      Creator: No se utiliza.

using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractAttackerVessel : AbstractStateManager
    {
        public AbstractAttackerVessel(int size, int health)
        : base(size, health)
        {
        }
        public virtual void LaunchMissile(AbstractTable table, int x, int y)
        {
            throw new NotImplementedException();
        }
        public virtual void ThrowLoad(AbstractTable table, int x, int y)
        {
            throw new NotImplementedException();
        }
        public virtual void LaunchMissile(AbstractTable table, int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }
    }
}