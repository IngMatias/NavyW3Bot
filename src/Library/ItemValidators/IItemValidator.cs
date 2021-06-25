// S - SRP: Esta interface tiene la responsabilidad de validar si se puede agregar un item.

// O - OCP: Utilizando IItemValidator - podemos permitir tener un agregado de nuevos validadores 
//          sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L - LSP: Esta clase es un subtipo de IItemValidator

// I - ISP: 

// D - DIP: El metodo IsAddable depende de una clase abstracta por lo tanto cumple con DIP

// Expert: No se aplica.

// Polymorphism: El metodo IsAddable es polimorfico.

// Creator: No se aplica.


namespace Library
{
    public interface IItemValidator
    {
        public bool IsAddable(int position, AbstractItemSaver vesselToAdd, AbstractTable table);
    }
}