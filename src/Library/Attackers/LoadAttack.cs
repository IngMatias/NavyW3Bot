// S - SRP: Esta clase tiene la responsabilidad de conocer como se atacan las cargas de profundidad.

// O - OCP: Utilizando AbstractAttacker podemos permitir tener un agregado de nuevos ataques 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L - LSP: LoadAttack puede ser intercambiado por cualquier otro Attackers y puede a su vez recibir los mismos
//     mensajes, sin embargo se comporta de distinta manera.

// I - ISP: No se utiliza.

// D - DIP: LoadAttack depende de una abstraccion por lo tanto cumple con DIP.

// Expert: No se utiliza.

// Polymorphism: No se utiliza.

// Creator: No se utiliza.

namespace Library
{
    public class LoadAttack : AbstractAttacker
    {
    }
}