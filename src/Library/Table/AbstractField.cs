﻿using System;
using System.Text;

namespace Library
{
    public abstract class AbstractField : AbstractVesselSaver
    {

        public enum Field
        {
            attackableWater,
            // Representa agua que puede ser atacada y no ha sido attacada.
            attackedWater,
            // Representa agua que ha sido atacada pero puede serlo nuevamente (ej. luego de un misil).
            unattackableWater,
            // Representa agua que no puede ser atacada (ej. luego de una carga).
            liveHiddenVessel,
            // Representa una parte de un barco vivo pero oculto.
            livedVessel,
            // Representa una parte de un barco vivo pero visible.
            deadVessel,
            // Representa una parte de un barco atacado. 
        }

        private Field[,] table;
        public AbstractField(int x, int y)
        : base()
        {
            this.table = new Field[x, y];
        }
        public int XLength()
        {
            return this.table.GetLength(0);
        }
        public int YLength()
        {
            return this.table.GetLength(1);
        }
        public Field At(int x, int y)
        {
            return this.table[x, y];
        }
        public void UpdateAt(int x, int y, Field data)
        {
            this.table[x, y] = data;
        }
        public bool IsEmpty()
        {
            for (int y = 0; y < this.YLength(); y++)
            {
                for (int x = 0; y < this.XLength(); x++)
                {
                    if (table[x, y] == Field.livedVessel ||
                        table[x, y] == Field.liveHiddenVessel)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsOrWasAVessel(int x, int y)
        {
            return table[x, y] == Field.liveHiddenVessel ||
                   table[x, y] == Field.livedVessel ||
                   table[x, y] == Field.deadVessel;
        }
        public bool IsAVessel(int x, int y)
        {
            return table[x, y] == Field.liveHiddenVessel ||
                   table[x, y] == Field.livedVessel;
        }
        public (int, int) GetLeftUp(int x, int y)
        {
            int xAux = x;
            int yAux = y;
            while (this.IsOrWasAVessel(xAux - 1, yAux))
            {
                xAux = xAux - 1;
            }
            while (this.IsOrWasAVessel(xAux, yAux - 1))
            {
                yAux = yAux - 1;
            }

            int up = xAux;
            int left = yAux;

            return (up, left);
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

            // Revisamos que el barco no se superponga con otro.
            for (int j = minY; j <= maxY; j++)
            {
                for (int i = minX; i <= maxX; i++)
                {
                    if (this.IsOrWasAVessel(i, j))
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
                    this.UpdateAt(x, j, Field.liveHiddenVessel);
                }
            }
            else
            {
                for (int i = x; i < x + vessel.Length(); i++)
                {
                    this.UpdateAt(i, y, Field.liveHiddenVessel);
                }
            }

            // Actualizo el diccionario. 
            this.AddVessel(x, y, vessel);
            return true;
        }

        public void RemoveVessel(int x, int y, Field data)
        {
            int xAux = x;
            int yAux = y;

            (int, int) aux = this.GetLeftUp(x, y);

            // Up y Left forman la posicion mas arriba y mas a la izquierda de un barco, 
            // lo que es nuestra clave en el diccionario.

            int up = aux.Item1;
            int left = aux.Item2;

            this.RemoveVessel((up, left));

            while (this.IsOrWasAVessel(xAux, y))
            {
                this.UpdateAt(xAux, yAux, data);
                xAux = xAux + 1;
            }
            xAux = up;
            yAux = left + 1;
            while (this.IsOrWasAVessel(x, yAux))
            {
                this.UpdateAt(xAux, yAux, data);
                yAux = yAux + 1;
            }
        }
    }
}