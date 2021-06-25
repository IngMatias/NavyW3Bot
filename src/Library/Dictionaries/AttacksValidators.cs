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
        public AttacksValidators()
        {
            this._attackValidator = new Dictionary<System.Type, IAttackValidator>
            {
                {new AntiaircraftMissile().GetType(), new AntiaircraftMissileAttackValidator() },
                {new Armor().GetType(), new ArmorAttackValidator() },
                {new Hackers().GetType(), new HackersAttackValidator() },
                {new Kong().GetType(), new KongAttackValidator() },
                {new SateliteLock().GetType(), new SateliteLockAttackValidator() },
            };
        }
        public IAttackValidator ValidatorOf(IItem item)
        {
            return this._attackValidator[item.GetType()];
        }
    }
}