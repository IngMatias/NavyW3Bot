// S - SRP: Esta clase tiene la responsabilidad de conocer como atacan los meteoritos.

// O - OCP: Utilizando AbstractAttacker podemos permitir tener un agregado de nuevos ataques 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L - LSP: MeteorAttack puede ser intercambiado por cualquier otro Attackers y puede a su vez recibir los mismos
//          mensajes, sin embargo se comporta de distinta manera.

// I - ISP: No es utilizado.

// D - DIP: MeteorAttack depende de una abstraccion por lo tanto cumple con DIP.

// Expert: No es utilizado.

// Polymorphism: No es utilizado.

// Creator: No es utilizado.

namespace Library
{
    public class MeteorAttack : AbstractAttacker
    {
    }
}