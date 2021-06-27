
// S -  SRP: Esta clase tiene una responsabilidad estructural.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se hereda la clase AbstractAttacker pero no se
//      modifica el codigo existente para agregar una forma de ataque.

// L -  LSP: Este Attack puede ser intercambiado por cualquier otro Attack, puede recibir los mismos 
//      mensajes.

// I -  ISP: No es utilizado el principio en esta clase ya que no se utiliza ninguna interfaz.

// D -  DIP: Este Attack depende solo de una abstraccion por lo tanto cumple con DIP.

//      Expert: No se utiliza.

//      Polymorphism: No se utiliza..

//      Creator: No se utiliza.

namespace Library
{
    public class HurricaneAttack : AbstractAttacker
    {
    }
}