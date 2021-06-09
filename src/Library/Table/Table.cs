using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

    // S - SRP: Esta interface se encarga de la responsabilidad de manejar el tablero.
    // Si se es estricto hay mas de dos razones de cambio, si se desea cambiar el tamaño
    // del tablero, agregar una nueva representacion en el mismo o cambiar el modo de agregado
    // de barcos, por ejemplo permitiendo agregarse en el borde.
    // Sin embargo no creemos que sea necesario romper esta unión.

    // O - OCP: No se encuentra una aplicacion del principio OCP.

    // L - LSP: No se encuentra una aplicacion del principio LSP.
    
    // I - ISP: Table no respeta ISP, no hace uso de todas las operaciones de AbstractVessels.

    // D - DIP: Table depende solo de abstracciones, se cumple DIP.

    // Expert : Esta clase conoce el tablero, por lo tanto tiene todo lo relacionado con su Consulta y Tratamiento.
    // Ademas conoce el lugar donde se hallan los barcos, por lo que tambien es responsable de realizar los ataques si corrsponde.

    // Polimorfismo : No se usa polimorfismo.

    // Creator : Se usa Creator en la creacion de la matriz table y el diccionario vessels.

namespace Library
{
    public class Table
    {

        // La clase Table contiene una Matriz donde se guardan 
        // enteros que se interpretan de la siguiente manera.
        // En el futuro podria implementarse un enumerado.
        // +1 Barco.
        //  0 Agua.
        // -1 Ruinas despues de un misil.
        // -2 Ruinas despues de una carga. 
        // -3 Ruinas despues de un evento.

        private int[,] table;
        private Dictionary<(int, int), AbstractVessels> vessels;
        public Table()
        {
            this.table = new int[14,26];
            this.vessels = new Dictionary<(int, int), AbstractVessels>();
        }
        public int XLength()
        {
            return this.table.GetLength(0);
        }
        public int YLength()
        {
            return this.table.GetLength(1);
        }
        public ReadOnlyCollection<AbstractVessels> GetVessels()
        {
            return this.vessels.Values.ToList<AbstractVessels>().AsReadOnly();
        }
        public bool IsAVassel(int x, int y)
        {
            return table[x, y] == 1;
        }
        public bool IsEmpty()
        {
            for (int y = 0; y < this.YLength(); y++)
            {
                for (int x = 0; y < this.XLength(); x++)
                {
                    if (table[x, y] > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool AddVessel(int x, int y, AbstractVessels vessel, bool orientation)
        {
            // La orientacion se interpreta de la siguiente manera.
            // true - Vertical 
            // false - Horizontal
            int minX = x - 1;
            int minY = y - 1;
            int maxX;
            int maxY;
            if (orientation)
            {
                maxX = x + 1;
                maxY = y + vessel.Length();
            }
            else
            {
                maxX = x + vessel.Length();
                maxY = y + 1;
            }
            // Revisamos que el barco tenga el espacio suficiente en el tablero.
            // No se permiten barcos contra el borde.
            if (!(0 <= minX && maxX < this.XLength() && 0 <= minY && maxY < this.YLength()))
            {
                return false;
            }
            // Revisamos que el barco no se superponga con otro, ni con un submarino.
            for (int j = minY; j <= maxY; j++)
            {
                for (int i = minX; i <= maxX; i++)
                {
                    if (this.IsAVassel(i, j))
                    {
                        return false;
                    }

                }
            }
            // Colocamos el barco.
            if (orientation)
            {
                for (int j = y; j < y + vessel.Length(); j++)
                {
                    this.table[x, j] = 1;
                }
            }
            else
            {
                for (int i = x; i < x + vessel.Length(); i++)
                {
                    this.table[i, y] = 1;
                }
            }
            // Actualizo el diccionario. 
            this.vessels.Add((x,y), vessel);
            return true;
        }
        public void AttackAt(int x, int y, AbstractAttacker attack)
        {

        }
        public void RandomAttack(AbstractAttacker attack)
        {
            Random random = new Random();
            int randomX = random.Next(0, this.XLength());
            int randomY = random.Next(0, this.YLength());
            this.AttackAt(randomX, randomY, attack);
        }
        public void RemoveVessel(int x, int y)
        {
            
        }
        public string StringTable()
        {
            StringBuilder toReturn = new StringBuilder();
            for (int j = 0;j<this.YLength(); j++)
            {
                for (int i=0;i<this.XLength();i++)
                {
                    toReturn.Append(this.table[i,j]);
                }
                toReturn.Append("\n");
            }
            return toReturn.ToString();
        }
    }
}