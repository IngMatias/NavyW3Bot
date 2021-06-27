
// S -  SRP: Esta clase tiene la responsabilidad dado un item retornar el objeto para validar si es agregable.

// O -  OCP: No cumple OCP, si se quiere agregar un nuevo item es necesario modificar el codigo sin embargo 
//      una posible solucion podria ser aplicando el patron Cadena de Responsabilidad para cumplir OCP.

// L -  LSP: No se hallan relaciones de subtipo relacionadas con esta clase.

// I -  ISP: No se usan las operaciones de la interface IItemValidator.

// D -  DIP: Esta clase depende solamente de abstracciones.

//      Expert: Esta clase conoce el diccionario de validadores de items, por ello tiene la responsabilidad 
//      de retornar el validador del mismo.

//      Polymorphism: No es utilizado.

//      Creator: Esta clase usa el patron ya que guarda instancias de IItem e IItemValidator.

using System.Collections.Generic;

namespace Library
{
    public class ItemsValidators
    {
        private Dictionary<System.Type, IItemValidator> _itemValidator;
        public ItemsValidators()
        {
            this._itemValidator = new Dictionary<System.Type, IItemValidator>
            {
                {new AntiaircraftMissile().GetType(), new AntiaircraftMissileValidator()},
                {new Armor().GetType(), new ArmorValidator()},
                {new Hackers().GetType(), new HackersValidator()},
                {new Kong().GetType(), new KongValidator()},
                {new SateliteLock().GetType(), new SateliteLockValidator()},
            };
        }
        public IItemValidator ValidatorOf(IItem item)
        {
            return this._itemValidator[item.GetType()];
        }
    }
}