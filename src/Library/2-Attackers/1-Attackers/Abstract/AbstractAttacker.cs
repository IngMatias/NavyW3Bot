
// S -  SRP: Esta clase tiene una sola responsabilidad: situar un punto de ataque.

// O -  OCP: Esta clase cumple con el principio, ya que si se quiere agregar una nueva forma 
// de ataque basta con heredar esta clase.

// L -  LSP: Esta clase cumple con el principio, cualquier clase que herede de 
// AbstractAttacker es un subtipo.

// I -  ISP: No es utilizado el principio en esta clase ya que no se utiliza ninguna interfaz.

// D -  DIP: Esta clase cumple con el principio ya que no depende de ninguna otra clase.

// Expert: Esta clase solo conoce.

// Polymorphism: Esta clase no es polimorfica.

// Creator: No se utiliza.

namespace Library
{
    public abstract class AbstractAttacker
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Position { get; set; }
    }
}