namespace Library
{
    // S - SRP: Esta clase no se encarga de ninguna responsabilidad.

    // O - OCP: Se piensa la jerarquia AbstractAttacker - Attack para permitir el agregado de nuevas
    // formas de ataque sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Esta clase puede ser intercambiado por cualquier otra forma de ataque y puede recibir los mismos
    // mensajes, se comporta de la misma manera, pero no genera los mismos efectos en el juego, naturalmente.

    // I - ISP: Se cumple ya que esta clase no contiene comportamiento.

    // D - DIP: Se cumple DIP, porque no se usan abstracciones.
    
    public class GodzillaAttack : AbstractAttacker
    {

    }
}