// S - SRP: Esta clase define los metodos necesarios para convertir la informacion del tablero a string.

// O - OCP: Se cumple. Si se deseara añadir un comportamiento al tablero, se debería crear una nueva clase abtracta con el
//           comportamiento definido a esta nueva clase y hacer que AbstractVesselSaver lo herede.
//           Recordar que Table es una clase compuesta por:
//           AbstractVesselSaver -> AbstractField -> AbstractAttackable -> AbstractTable -> Table
//           AbstractVesselSaver es la última clase en la cadena, si esta clase hereda un comportamiento, todas las clases
//           que hereden a esta úlitma tambien habrán heredado el nuevo comportamiento, haciendo que se cumpla el principio.

// L - LSP: Se cumple. Cualquier objeto Table puede ser sustituido por el tipo AbstractTable sin tener ningun tipo de 
//           modificacion en su comportamiento.

// I - ISP: No se aplica.

// D - DIP: No se aplica DIP ya que esta clase depende de clases de bajo nivel como lo son ItemToString y VesselToString. 
//           Para cumplir con este principio se deben hacer interfaces para cada una de estas clases. 
//           La implementacion ItemToString sería:
//                  IItemToString itemsName = new ItemToString();         

// Expert: No se aplica.

// Polymorphism: No se aplica.

// Creator: No se aplica.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Library
{
    public abstract class AbstractTable : AbstractAttackable
    {

        protected AbstractTable(int x, int y)
        : base(x, y)
        {

        }
        public string StringTable()
        {
            StringBuilder toReturn = new StringBuilder();
            for (int j = 0; j < this.YLength(); j++)
            {
                for (int i = 0; i < this.XLength(); i++)
                {
                    toReturn.Append((int)this.At(i, j));
                }
                toReturn.Append("\n");
            }
            return toReturn.ToString();
        }

        public string StringVessels()
        {
            // Dependencias.
            ItemsToString itemsName = new ItemsToString();
            VesselsToString vesselsName = new VesselsToString();

            StringBuilder toReturn = new StringBuilder();
            int vesselIndex = 1;
            int itemIndex = 1;

            foreach (AbstractVessel vessel in this.GetVessels())
            {
                toReturn.Append(vesselIndex +" "+ vesselsName.NameOf(vessel) + "\n");
                foreach (IItem item in vessel.Items)
                {
                    if (item != null)
                    {
                        toReturn.Append("    " + itemIndex + itemsName.NameOf(item) + "\n");
                    }
                    else
                    {
                        toReturn.Append("    " + itemIndex + "Vacio" + "\n");
                    }
                    itemIndex ++;
                }
                toReturn.Append("\n");
                vesselIndex ++;
            }
            return toReturn.ToString();
        }
    }
}