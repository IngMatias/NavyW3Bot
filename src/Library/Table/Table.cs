using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Library
{
    public class Table : ITable
    {

        // La clase Table contiene una Matriz donde se guardan 
        // enteros que se interpretan de la siguiente manera.
        // En el futuro podria implementarse un enumerado.
        // +1 Barco: hay un barco.
        //  0 Agua: no hay barco.
        // -1 Ruinas despues de un misil (pueden ser atacables).
        // -2 Ruinas sin barco (no pueden ser atacables).
        // -3 Ruina con barco (no pueden ser atacables).
        // -4 Hay algo (puede ser atacado)

        private int[,] table;
        private Dictionary<(int, int), AbstractVessel> vessels;
        public Table()
        {
            this.table = new int[14, 26];
            this.vessels = new Dictionary<(int, int), AbstractVessel>();
        }
        public int XLength()
        {
            return this.table.GetLength(0);
        }
        public int YLength()
        {
            return this.table.GetLength(1);
        }
        public void Update(int x, int y, int data)
        {
            this.table[x, y] = data;
        }

        public ReadOnlyCollection<AbstractVessel> GetVessels()
        {
            return this.vessels.Values.ToList<AbstractVessel>().AsReadOnly();
        }
        public bool IsAVessel(int x, int y)
        {
            return table[x, y] == 1;
        }
        public bool IsSomething(int x, int y)
        {
            return table[x, y] != 0;
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
        public bool AddVessel(int x, int y, AbstractVessel vessel, bool orientation)
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
                    if (this.IsAVessel(i, j))
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
                    this.Update(x, j, 1);
                }
            }
            else
            {
                for (int i = x; i < x + vessel.Length(); i++)
                {
                    this.Update(i, y, 1);
                }
            }
            // Actualizo el diccionario. 
            this.vessels.Add((x, y), vessel);
            return true;
        }
        public void AttackAt(int x, int y, AbstractAttacker attack)
        {
            if (this.IsAVessel(x, y))
            {
                int xAux = x;
                int yAux = y;
                while (this.IsSomething(xAux - 1, y))
                {
                    xAux = xAux - 1;
                }
                while (this.IsSomething(x, yAux - 1))
                {
                    yAux = yAux - 1;
                }

                int up = xAux;
                int left = yAux;

                if (y == yAux)
                {
                    // Actualizo la Posicion relativa al barco en attack.
                    attack.Position = x - xAux;
                }
                else
                {
                    // Actualizo la Posicion relativa al barco en attack.
                    attack.Position = y - yAux;
                }

                // bool successfully = this.vessels[(xAux, yAux)].ReceiveAttack(this, attack);
                bool successfully = true;

                if (successfully)
                {
                    if (attack is MissileAttack)
                    {
                        this.Update(x, y, -1);
                    }
                    else
                    {
                        this.Update(x, y, -3);
                    }
                }
                else
                {
                    // Aca hay algo pero no se pudo atacar.
                    this.Update(x, y, -5);
                }

            }
            else
            {
                this.Update(x, y, -2);
            }
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
            int xAux = x;
            int yAux = y;
            while (this.IsAVessel(xAux - 1, y))
            {
                xAux = xAux - 1;
            }
            while (this.IsAVessel(x, yAux - 1))
            {
                yAux = yAux - 1;
            }
            // Up y Left forman la posicion mas arriba y mas a la izquierda de un barco; lo que es nuestra clave en el diccionario
            int up = xAux;
            int left = yAux;

            this.vessels.Remove((up, left));

            while (this.IsAVessel(xAux, y))
            {
                this.Update(xAux, yAux, -3);
                xAux = xAux + 1;
            }
            xAux = up;
            yAux = left + 1;
            while (this.IsAVessel(x, yAux))
            {
                this.Update(xAux, yAux, -3);
                yAux = yAux + 1;
            }
        }

        public string StringTable()
        {
            StringBuilder toReturn = new StringBuilder();
            for (int j = 0; j < this.YLength(); j++)
            {
                for (int i = 0; i < this.XLength(); i++)
                {
                    toReturn.Append(this.table[i, j]);
                }
                toReturn.Append("\n");
            }
            return toReturn.ToString();
        }
    }
}