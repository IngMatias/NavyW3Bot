// S - SRP: Esta clase define el objeto Table con todos los metodos de las clases que hereda.

// O - OCP: Se cumple. Si se deseara añadir un comportamiento al tablero, se debería crear una nueva clase abtracta con el
//           comportamiento definido a esta nueva clase y hacer que AbstractVesselSaver lo herede.
//           Recordar que Table es una clase compuesta por:
//           AbstractVesselSaver -> AbstractField -> AbstractAttackable -> AbstractTable -> Table
//           AbstractVesselSaver es la última clase en la cadena, si esta clase hereda un comportamiento, todas las clases
//           que hereden a esta úlitma tambien habrán heredado el nuevo comportamiento, haciendo que se cumpla el principio.

// L - LSP: Se cumple. Cualquier objeto Table puede ser sustituido por el tipo AbstractTable sin tener ningun tipo de 
//           modificacion en su comportamiento.

// I - ISP: No se aplica.

// D - DIP: no se aplica.       

// Expert: No se aplica.

// Polymorphism: No se aplica.

// Creator: No se aplica.

namespace Library
{
    public class Table : AbstractTable
    {
        public Table()
        : base(14, 26)
        {
        }
    }
}