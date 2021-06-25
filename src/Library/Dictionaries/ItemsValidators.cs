using System.Collections.Generic;

// S - SRP: Esta clase tiene la responsabilidad dado un item retornar su correspondiente validador.

// O - OCP: No cumple OCP, si se quiere agregar un nuevo item es necesario modificar el codigo sin embargo 
//          se nos ocurre que podemos aplicar Cadena de Responsabilidad para cumplir este patron.

// L - LSP: No aplica.

// I - ISP: No aplica.

// D - DIP: 

// Expert: Esta clase conoce el diccionario de items validos y como esta dispuesto, por ello tiene la responsabilidad 
//         validar de retornar el validador del mismo.

// Polymorphism: No es utilizado.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

namespace Library
{
    public class ItemsValidators
    {
        private Dictionary<System.Type, IItemValidator> _itemValidator;
        public ItemsValidators()
        {
            this._itemValidator = new Dictionary<System.Type, IItemValidator>
            {
                {new AntiaircraftMissile().GetType(), new AntiaircraftMissileValidator() },
                {new Armor().GetType(), new ArmorValidator() },
                {new Hackers().GetType(), new HackersValidator() },
                {new Kong().GetType(), new KongValidator() },
                {new SateliteLock().GetType(), new SateliteLockValidator() },
            };
        }
        public IItemValidator ValidatorOf(IItem item)
        {
            return this._itemValidator[item.GetType()];
        }
    }
}