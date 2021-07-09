
// S -  SRP: Esta clase define los metodos para la representacion (en strings) del tablero.

// O -  OCP: Se cumple. Si se deseara añadir una representacion basta con crear una nueva clase.

// L -  LSP: Se cumple. Cualquier objeto que herede esta clase es y debe ser un subtipo de esta.

// I -  ISP: No se aplica.

// D -  DIP: Esta clase depende solamente de abstracciones.

//      Expert: Esta clase no conoce la representacion del tablero, aun asi se encarga de su representacion. 

//      Polymorphism: No se aplica.

//      Creator: No se aplica.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Library
{
    public abstract class AbstractTable : AbstractAttackable
    {
        protected AbstractTable(int x, int y)
        : base(x, y)
        {
        }
    }
}