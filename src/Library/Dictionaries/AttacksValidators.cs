
// S -  SRP: Esta clase tiene la responsabilidad dado un ataque retornar su correspondiente validador.

// O -  OCP: No cumple OCP, si se quiere agregar un nuevo ataque es necesario modificar el codigo sin embargo 
//      una posible solucion podria ser aplicando el patron Cadena de Responsabilidad para cumplir OCP.

// L -  LSP: No se hallan relaciones de subtipo relacionadas con esta clase.

// I -  ISP: No se usan las operaciones de la interface IAttackValidator.

// D -  DIP: Esta clase depende solamente de abstracciones.

//      Expert: Esta clase conoce el diccionario de validadores de ataques, por ello tiene la responsabilidad 
//      de retornar el validador del mismo.

//      Polymorphism: No es utilizado.

//      Creator: Esta clase usa el patron ya que guarda instancias de IItem e IAttackValidator.

using System.Collections.Generic;

namespace Library
{
    public class AttacksValidators
    {
        private Dictionary<System.Type, IAttackValidator> _attackValidator;
        // Items.
        private IItem _antiAircraft = new AntiaircraftMissile();
        private IItem _armor = new Armor();
        private IItem _hackers = new Hackers();
        private IItem _kong = new Kong();
        private IItem _sateliteLock = new SateliteLock();

        // Validators.
        private IAttackValidator _antiaircraftAttackValidator = new AntiaircraftMissileAttackValidator();
        private IAttackValidator _armorAttackValidator = new ArmorAttackValidator();
        private IAttackValidator _hackersAttackValidator = new HackersAttackValidator();
        private IAttackValidator _kongAttackValidator = new KongAttackValidator();
        private IAttackValidator _sateliteLockAttackValidator = new SateliteLockAttackValidator();

        public AttacksValidators()
        {
            this._attackValidator = new Dictionary<System.Type, IAttackValidator>
            {
                {_antiAircraft.GetType(), _antiaircraftAttackValidator},
                {_armor.GetType(), _armorAttackValidator },
                {_hackers.GetType(), _hackersAttackValidator},
                {_kong.GetType(), _kongAttackValidator},
                {_sateliteLock.GetType(), _sateliteLockAttackValidator},
            };
        }
        public IAttackValidator ValidatorOf(IItem item)
        {
            return this._attackValidator[item.GetType()];
        }
    }
}