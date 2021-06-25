// S - SRP: Esta interface tiene la responsabilidad de definir el metodo AvoidAttack.

// O - OCP: 

// L - LSP: No se utiliza.

// I - ISP: No se utiliza.

// D - DIP: IAttackValidator depende de Table y AbstractAttacker, ambas clases abstractas por lo tanto cumple con DIP

// Expert: No se utiliza.

// Polymorphism: El metodo AvoidAttack es polimorfico en todos los IAttackValidator.

// Creator: No se utiliza.

namespace Library
{
    public interface IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack);
    }
}