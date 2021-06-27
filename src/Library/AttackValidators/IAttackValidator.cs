
// S -  SRP: Esta interface tiene la responsabilidad de definir el tipo IAttackValidator.

// O -  OCP: Esta clase cumple con el principio, ya que si se quiere agregar una nueva forma de ataque basta con
//      heredar esta clase para implementar su validador.

// L -  LSP: Cualquier clase que implemente IAttackValidator es y debe ser un subtipo.

// I -  ISP: No se utiliza.

// D -  DIP: El metodo definido en esta interface depende solamente de abstracciones.

//      Expert: No es utilizado.

//      Polymorphism: El metodo AvoidAttack es polimorfico en todos los IAttackValidator.

//      Creator: No es utilizado.

namespace Library
{
    public interface IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack);
    }
}