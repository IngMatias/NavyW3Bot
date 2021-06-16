
    // S - SRP: Esta interface se encarga de la responsabilidad de definir un tipo Item.
    // En el caso de querer agregar un nuevo item solo hace falta implementar esta interface y
    // agregar dicha clase a la ItemList.
    
    // O - OCP: Se piensa la jerarquia ItemList - IItem - Item para permitir el agregado de nuevos
    // items sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: Todos los subtipos de IItem deben implementar el metodo IsAddable, lo que hace que puedan
    // reibir el mensaje correspondiente en cualquier caso, aunque se comporten de manera distinta.
    // Se debe revisar cuidadosamente los efectos colaterales.

    // I - ISP: No se encuentra una aplicacion del principio ISP.
    
    // D - DIP: IItem depende de Table, que no es una abstraccion, no se cumple DIP.

namespace Library
{
    public interface IItem
    {
        public bool IsAddable(ITable table, AbstractVessels vasselToAdd);
        public bool ReceiveAttack(ITable table, AbstractAttacker attack);
    }
}