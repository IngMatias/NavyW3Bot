// S - SRP: Esta clase tiene la responsabilidad de definir un tipo de embaracion.

// O - OCP: No se aplica.

// L - LSP: Esta tipo puede ser sustituido por el tipo AbstractVessel.

// I - ISP: No es utilizado el principio en esta clase ya que no se implementa ninguna interfaz.

// D - DIP: Esta clase cumple con el principio ya que depende solo de clases de alto nivel (clases abstractas).

// Expert: Esta clase es respon¿sable de saber las espesificaciones de la embarcacion, tales como sus dimenciones y el tipo de ataque que realiza.

// Polymorphism: No se utiliza.

// Creator: No se utiliza.

using System.Collections.Generic;

namespace Library
{
    public class Puntoon : AbstractVessel
    {
        public Puntoon()
        : base(1, 1)
        {

        }
    }
}