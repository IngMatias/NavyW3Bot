// S - SRP: Esta clase se encarga de la responsabilidad de validar si es posible colocar el item Hackers.

// O - OCP: Utilizando IAttackValidator - podemos permitir tener un agregado de nuevos validadores 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L - LSP: Esta clase es un subtipo de IAttackValidator.

// I - ISP: No se utiliza.

// D - DIP: SateliteLockAttackValidator depende de AbstractAttackable y AbstractAttacker ambas son abstracciones 
//          por lo tanto cumple con DIP.

// Expert: No se utiliza.

// Polymorphism: El metodo AvoidAttack es polimorfico en todos los IAttackValidator.

// Creator: No es utilizado.

namespace Library
{
    public class SateliteLockAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            if (attack is MissileAttack || attack is LoadAttack)
            {
                table.RandomAttack(attack);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}