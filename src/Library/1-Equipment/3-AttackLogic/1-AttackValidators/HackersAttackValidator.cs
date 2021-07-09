
// S - SRP: Esta clase tiene la responsabilidad de validar si es posible evitar un ataque específico.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IAttackValidator pero no se
// modifica el codigo existente para agregar una nueva forma de evitar un ataque.

// L -  LSP: Esta clase es un subtipo de IAttackValidator.

// I -  ISP: No se utiliza.

// D -  DIP: Esta clase depende de AbstractAttackable y AbstractAttacker ambas son abstracciones 
// por lo tanto cumple con DIP.

// Expert: No es utilizado.

// Polymorphism: El metodo AvoidAttack es polimorfico en todos los IAttackValidator.

// Creator: No aplica a interfaces.

namespace Library
{
    public class HackersAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            return false;
        }
    }
}