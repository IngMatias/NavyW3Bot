using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Library
{
    public class Table
    {
        private  int[,] table;
        private Dictionary<(int,int), AbstractVessels> vessels;
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
        // -2 Inatacable 
        // -1 Ruinas 
        // 0 - Agua
        // +1- Barco 
        // +2- Submarino 
        
        public bool IsAVassel(int x,int y)
        {
            return table[x,y] == 1;  
        }
        public bool IsASubmarine(int x,int y)
        {
            return table[x,y] == 2;  
        }
        public bool IsEmpty()
        {
            for (int y=0 ; y < this.YLength(); y++)
            {
                for (int x=0 ; y < this.XLength(); x++)
                {
                    if (table[x,y] > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // false - Horizontal
        // true - Vertical 
        public void AddVessel(int x, int y, AbstractVessels vessel, bool orientation)
        {
            
        }
        public void AddVessel(int x, int y, Submarine vessel, bool orientation)
        {

        }
        public void MissileAt(int x, int y)
        {

        }
        public void LoadAt(int x, int y)
        {
            
        }
        public void RemoveVessel(int x, int y)
        {
            
        }
        public string StringTable()
        {
            return "";
        }

        
    }
}
