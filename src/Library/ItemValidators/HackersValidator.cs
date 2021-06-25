// S - SRP: Esta clase tiene la responsabilidad de validar si se puede agregar el item Hackers.

// O - OCP: Utilizando IItemValidator - podemos permitir tener un agregado de nuevos validadores 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L - LSP: Esta clase es un subtipo de IItemValidator

// I - ISP: 

// D - DIP: El metodo IsAddable depende de una clase abstracta por lo tanto cumple con DIP

// Expert: 

// Polymorphism: El metodo IsAddable es polimorfico.

// Creator: Esta clase usa al patron ya que crea instancias de clases cercanas.

namespace Library
{
    public class HackersValidator : IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table)
        {
            if (!(vesselToAdd is Puntoon))
            {
                throw new WrongVesselException();
            }
            if (vesselToAdd.Items[position] != null)
            {
                throw new NoEmptyPositionException();
            }
            return true;
        }
    }
}