using System;
using System.Text;

namespace Library
{
    public abstract class AbstractField : AbstractVesselSaver
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
        public AbstractField(int x, int y)
        : base()
        {
            this.table = new int[x, y];
        }
        public int XLength()
        {
            return this.table.GetLength(0);
        }
        public int YLength()
        {
            return this.table.GetLength(1);
        }
        public int At(int x, int y)
        {
            return this.table[x, y];
        }
        public void UpdateAt(int x, int y, int data)
        {
            this.table[x, y] = data;
        }
        public bool IsAVessel(int x, int y)
        {
            return this.At(x, y) == 1;
        }
        public bool IsOrWasSomething(int x, int y)
        {
            return true;
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
                    this.UpdateAt(x, j, 1);
                }
            }
            else
            {
                for (int i = x; i < x + vessel.Length(); i++)
                {
                    this.UpdateAt(i, y, 1);
                }
            }
            // Actualizo el diccionario. 
            this.AddVessel(x, y, vessel);
            return true;
        }
        public void AttackAt(int x, int y, AbstractAttacker attack)
        {
            if (this.IsAVessel(x, y))
            {
                int xAux = x;
                int yAux = y;
                while (this.IsOrWasSomething(xAux - 1, y))
                {
                    xAux = xAux - 1;
                }
                while (this.IsOrWasSomething(x, yAux - 1))
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
                        this.UpdateAt(x, y, -1);
                    }
                    else
                    {
                        this.UpdateAt(x, y, -3);
                    }
                }
                else
                {
                    // Aca hay algo pero no se pudo atacar.
                    this.UpdateAt(x, y, -5);
                }

            }
            else
            {
                this.UpdateAt(x, y, -2);
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
            // Up y Left forman la posicion mas arriba y mas a la izquierda de un barco, lo que es nuestra clave en el diccionario
            int up = xAux;
            int left = yAux;

            this.RemoveVessel((up, left));

            while (this.IsAVessel(xAux, y))
            {
                this.UpdateAt(xAux, yAux, -3);
                xAux = xAux + 1;
            }
            xAux = up;
            yAux = left + 1;
            while (this.IsAVessel(x, yAux))
            {
                this.UpdateAt(xAux, yAux, -3);
                yAux = yAux + 1;
            }
        }
    }
}