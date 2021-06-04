using System;
using System.Collections.Generic;

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
        public bool IsAVassel(int x,int y)
        {
            return true;
        }
        public bool IsEmpty()
        {
            return true;
        }
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
