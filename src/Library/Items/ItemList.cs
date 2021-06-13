using System;
using System.Collections.Generic;

    // S - SRP: Esta clase se encarga de la responsabilidad de conocer todos los items del juego y
    // elegir aleatoriamente uno de ellos, esta funcion se piensa para no alterar el resto del codigo
    // al momento de agregar nuevos items.
    // Si se es estricto hay dos razones de cambio, si se desea agregar un nuevo item y si se desea 
    // cambiar el metodo de eleccion entre ellos. No creemos que sea necesario romper esta unión, para
    // continuar respetando los otros patrones.

    // O - OCP: Se piensa la jerarquia ItemList - IItem - Item para permitir el agregado de nuevos
    // items sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.

    // L - LSP: No se encuentra una aplicacion del principio LSP.
    
    // I - ISP: ItemList no respeta ISP, no hace uso de las operaciones de IItem.

    // D - DIP: ItemList depende de IItem, que es una abstraccion, se cumple DIP.

namespace Library
{
    public class ItemList
    {
        private List<IItem> items = new List<IItem> {
                                                        new AntiaircraftMissile(),
                                                        new Armor(),
                                                        new Hackers(),
                                                        new Kong(),
                                                        new SateliteLock(),
                                                    };
        public IItem RandomItem()
        {
            Random rnd = new Random();
            return this.items[rnd.Next(0,this.items.Count)];
        }
    }
}