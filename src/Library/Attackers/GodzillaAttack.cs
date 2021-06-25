// S - SRP: Esta clase tiene la responsabilidad de conocer como ataca Godzilla.

// O - OCP: Utilizando AbstractAttacker podemos permitir tener un agregado de nuevos ataques 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L - LSP: GodzillaAttack puede ser intercambiado por cualquier otro Attackers y puede a su vez recibir los mismos
//          mensajes, sin embargo se comporta de distinta manera.

// I - ISP: No se utiliza.

// D - DIP: GodzillaAttack depende solo de una abstraccion por lo tanto cumple con DIP.

// Expert: No se utiliza.

// Polymorphism: No se utiliza..

// Creator: No se utiliza.

namespace Library
{
    public class GodzillaAttack : AbstractAttacker
    {
    }
}