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
        // Vessels.
        private IItem _antiAircraft = new AntiaircraftMissile();
        private IItem _armor = new Armor();
        private IItem _hackers = new Hackers();
        private IItem _kong = new Kong();
        private IItem _sateliteLock = new SateliteLock();

        // Validators.
        private IItemValidator _antiAircraftValidator = new AntiaircraftMissileValidator();
        private IItemValidator _armorValidators = new ArmorValidator();
        private IItemValidator _hackersValidators = new HackersValidator();
        private IItemValidator _kongValidator = new KongValidator();
        private IItemValidator _sateliteLockValidator = new SateliteLockValidator();

        public ItemsValidators()
        {
            this._itemValidator = new Dictionary<System.Type, IItemValidator>
            {
                {_antiAircraft.GetType(), _antiAircraftValidator},
                {_armor.GetType(), _armorValidators },
                {_hackers.GetType(), _hackersValidators},
                {_kong.GetType(), _kongValidator},
                {_sateliteLock.GetType(), _sateliteLockValidator},
            };
        }
        public IItemValidator ValidatorOf(IItem item)
        {
            return this._itemValidator[item.GetType()];
        }
    }
}