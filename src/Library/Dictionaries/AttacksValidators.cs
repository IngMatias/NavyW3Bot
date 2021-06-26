using System.Collections.Generic;

// S - SRP: Esta clase tiene la responsabilidad dado un ataque retornar su correspondiente validador.

// O - OCP: No cumple OCP, si se quiere agregar un nuevo ataque es necesario modificar el codigo sin embargo 
//          se nos ocurre que podemos aplicar Cadena de Responsabilidad para cumplir este patron.

// L - LSP: No aplica.

// I - ISP: No aplica.

// D - DIP: 

// Expert: Esta clase conoce el diccionario de ataques validos y como esta dispuesto, por ello tiene la responsabilidad 
//         validar de retornar el validador del mismo.

// Polymorphism: No es utilizado.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

namespace Library
{
    public class AttacksValidators
    {
        private Dictionary<System.Type, IAttackValidator> _attackValidator;

        // Vessels.
        private IItem _antiAircraft = new AntiaircraftMissile();
        private IItem _armor = new Armor();
        private IItem _hackers = new Hackers();
        private IItem _kong = new Kong();
        private IItem _sateliteLock = new SateliteLock();

        // AttackValidators.
        private IAttackValidator _antiAircraftValidator = new AntiaircraftMissileAttackValidator();
        private IAttackValidator _armorValidators = new ArmorAttackValidator();
        private IAttackValidator _hackersValidators = new HackersAttackValidator();
        private IAttackValidator _kongValidator = new KongAttackValidator();
        private IAttackValidator _sateliteLock = new SateliteLockAttackValidator();


        public AttacksValidators()
        {
            this._attackValidator = new Dictionary<System.Type, IAttackValidator>
            {
                {_antiAircraft.GetType(), _antiAircraftValidator},
                {_armor.GetType(), _armorValidators },
                {_hackers.GetType(), _hackersValidators},
                {_kong.GetType(), _kongValidator},
                {_sateliteLock.GetType(), _sateliteLock},
            };
        }
        public IAttackValidator ValidatorOf(IItem item)
        {
            return this._attackValidator[item.GetType()];
        }
    }
}