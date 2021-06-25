// S - SRP: Esta clase tiene la responsabilidad de validar si es posible colocar el item Armor.

// O - OCP: Utilizando IAttackValidator podemos permitir tener un agregado de nuevos validadores 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L - LSP: Esta clase es un subtipo de IAttackValidator.

// I - ISP: No se utiliza.

// D - DIP: ArmorAttackValidator depende de AbstractAttackable y AbstractAttacker ambas son abstracciones 
//          por lo tanto cumple con DIP.

// Expert: No es utilizado.

// Polymorphism: El metodo AvoidAttack es polimorfico en todos los IAttackValidator.

// Creator: No es utilizado.

namespace Library
{
    public class ArmorAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            return (attack is MissileAttack || attack is LoadAttack);
        }
    }
}