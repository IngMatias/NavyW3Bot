namespace Library
{
    // S - SRP: Esta clase se encarga de la responsabilidad de conocer una posicion del tablero y
    // la posicion relativa del barco, en caso de que el ataque sea en un barco.

    // O - OCP: Se piensa la jerarquia AbstractAttacker - Attack para permitir el agregado de nuevas
    // formas de ataque sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Se habla de LSP en las subclases.

    // I - ISP: No se utilizan interfaces asi que se cumple ISP.

    // D - DIP: Se cumple DIP, porque solo se usan abstracciones.

    // Expert : En esta clase solo se conoce.

    // Polimorfismo : No se usa polimorfismo.

    // Creator : No se usa Creator.

    public abstract class AbstractAttacker
    {
        public int x {get; set;}
        public int y {get; set;}
        public int position {get; set;}
    }
}