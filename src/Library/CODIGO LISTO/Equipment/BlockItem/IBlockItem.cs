
// S -  SRP: Esta clase tiene una responsabilidad, definir el tipo IBlockItem.

// O -  OCP: Esta clase es un ejemplo del uso de OCP, se implementa la interface IBlockItem 
// para agregar un item que bloquee los barcos.

// L -  LSP: Cualquier subtipo de IBlockItem se comporta de la misma forma.

// I -  ISP: No es utilizado el principio en esta clase.

// D -  DIP: Esta clase depende no depende de ninguna otra.

// Expert: Esta clase no conoce.

// Polymorphism: Esta clase no es polimorfica.

// Creator: No se utiliza.


namespace Library
{
    public interface IBlockItem
    {
    }
}