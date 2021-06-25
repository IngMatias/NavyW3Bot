// S - SRP: Esta clase tiene la responsabilidad de situar un punto de ataque.

// O - OCP: Esta clase cumple con el principio, ya que si se quiere agregar una nueva forma de ataque basta con
//          heredar esta clase.

// L - LSP: Cualquier clase que herede de AbstractAttacker es y debe ser un subtipo.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio ya que no depende de otra clase.

// Expert: No se utiliza.

// Polymorphism: No se utiliza.

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