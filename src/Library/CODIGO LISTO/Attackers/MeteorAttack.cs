
// S -  SRP: Esta clase tiene una responsabilidad estructural.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se hereda la clase AbstractAttacker 
// pero no se modifica el codigo existente para agregar una forma de ataque.

// L -  LSP: Este Attack puede ser intercambiado por cualquier otro Attack, puede recibir 
// los mismos mensajes.

// I -  ISP: No es utilizado el principio en esta clase ya que no se utiliza ninguna interfaz.

// D -  DIP: Esta clase depende solo de una abstraccion por lo tanto cumple con DIP.

// Expert: Esta clase no conoce.

// Polymorphism: Esta clase no es polimorfica.

// Creator: No se utiliza.

namespace Library
{
    public class MeteorAttack : AbstractAttacker
    {
    }
}