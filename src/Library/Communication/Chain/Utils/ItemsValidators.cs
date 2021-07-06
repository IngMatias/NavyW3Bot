
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
        private static Dictionary<System.Type, IItemValidator> _itemValidator;
        // Items.
        private IItem _antiAircraft = new AntiaircraftMissile();
        private IItem _armor = new Armor();
        private IItem _hackers = new Hackers();
        private IItem _kong = new Kong();
        private IItem _sateliteLock = new SateliteLock();

        // Vessels.
        private IItemValidator _antiaircraftValidator = new AntiaircraftMissileValidator();
        private IItemValidator _armorValidator = new ArmorValidator();
        private IItemValidator _hackersValidator = new HackersValidator();
        private IItemValidator _kongValidator = new KongValidator();
        private IItemValidator _sateliteLockValidator = new SateliteLockValidator();
        public ItemsValidators()
        {
            _itemValidator = new Dictionary<System.Type, IItemValidator>
            {
                {_antiAircraft.GetType(), _antiaircraftValidator},
                {_armor.GetType(), _armorValidator},
                {_hackers.GetType(), _hackersValidator},
                {_kong.GetType(), _kongValidator},
                {_sateliteLock.GetType(), _sateliteLockValidator},
            };
        }
        public static IItemValidator Of(IItem item)
        {
            return _itemValidator[item.GetType()];
        }
    }
}