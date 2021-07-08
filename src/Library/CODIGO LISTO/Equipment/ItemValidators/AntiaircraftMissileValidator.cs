
// S -  SRP: Esta clase tiene la responsabilidad de validar si se puede agregar un item especifico.

// O -  OCP: Implementando IItemValidator podemos permitir tener un agregado de nuevos items 
// sin la necesidad de alterar el codigo, sino mas bien simplemente agregando nuevas clases.

// L -  LSP: Esta clase es un subtipo de IItemValidator.

// I -  ISP: No aplica.

// D -  DIP: El metodo IsAddable depende de abstracciones por lo tanto se cumple el patron.

// Expert: No aplica.

// Polymorphism: El metodo IsAddable es polimorfico.

// Creator: Esta clase usa al patron ya que crea instancias de clases que se usan de manera cercana (Excepciones).

namespace Library
{
    public class AntiaircraftMissileValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            foreach (IItem item in vesselToAdd.Items)
            {
                if (item is AntiaircraftMissile)
                {
                    throw new NoRepetitiveItemException();
                }
            }
            if (vesselToAdd.Items[position] != null)
            {
                throw new NoEmptyPositionException();
            }
            return true;
        }
    }
}
