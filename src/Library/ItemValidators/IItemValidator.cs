
// S -  SRP: Esta interface tiene la responsabilidad de definir el tipo IItemValidator.

// O -  OCP: Implementando IItemValidator podemos permitir tener un agregado de nuevos items 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando nuevas clases.

// L -  LSP: Todas las clases que implementen esta interface son y deben ser subtipos.

// I -  ISP: No aplica.

// D -  DIP: El metodo IsAddable depende de abstracciones por lo tanto se cumple el patron.

//      Expert: No aplica.

//      Polymorphism: El metodo IsAddable es polimorfico.

//      Creator: Esta clase usa al patron ya que crea instancias de clases que se usan de manera cercana (Excepciones).

namespace Library
{
    public interface IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table);
    }
}