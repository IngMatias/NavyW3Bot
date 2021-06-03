using System.Collections.Generic;

namespace Library
{
    public class Table
    {
        private  bool[,] table;
        private Dictionary<(int,int), GeneralVessels> vessels;
        public bool IsAVassel(int x,int y)
        {
            return true;
        }
        public bool IsEmpty()
        {
            return true;
        }
        public void AddVessel(int x, int y, GeneralVessels vessel, bool orientation)
        {

        }
        public void DeleteVessel(int x, int y)
        {
            
        }
    }
}
