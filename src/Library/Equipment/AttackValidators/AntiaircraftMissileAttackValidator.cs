
// S - SRP: Esta clase tiene la responsabilidad de validar si es posible colocar un item específico.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IAttackValidator pero no se
//      modifica el codigo existente para agregar un validador.

// L -  LSP: Esta clase es un subtipo de IAttackValidator.

// I -  ISP: No se utiliza.

// D -  DIP: Esta clase depende de AbstractAttackable y AbstractAttacker ambas son abstracciones 
//      por lo tanto cumple con DIP.

//      Expert: No es utilizado.

//      Polymorphism: El metodo AvoidAttack es polimorfico en todos los IAttackValidator.

//      Creator: No es utilizado.

namespace Library
{
    public class AntiaircraftMissileAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            return attack is MissileAttack;
        }
    }
}