
// S -  SRP: Esta clase tiene la responsabilidad de validar si se puede agregar el item Kong.

// O -  OCP: Implementando IItemValidator podemos permitir tener un agregado de nuevos items 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando nuevas clases.

// L -  LSP: Esta clase es un subtipo de IItemValidator.

// I -  ISP: No aplica.

// D -  DIP: El metodo IsAddable depende de abstracciones por lo tanto se cumple el patron.

//      Expert: No aplica.

//      Polymorphism: El metodo IsAddable es polimorfico.

//      Creator: Esta clase usa al patron ya que crea instancias de clases que se usan de manera cercana (Excepciones).

namespace Library
{
    public class KongValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            if (vesselToAdd.CountItem() != 0)
            {
                throw new NeededEmptyVesselException();
            }
            if (vesselToAdd.Length() < 4)
            {
                throw new TooShortVesselException();
            }
            return true;
        }
    }
}