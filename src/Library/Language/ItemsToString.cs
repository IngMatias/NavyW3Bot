using System.Collections.Generic;

namespace Library
{
    public class ItemsToString
    {
        public Dictionary<System.Type,string> ItemToString;
        public ItemsToString()
        {
            List<string> names = new List<string> 
            {
                "Lang-Misil Antiaereo",
                "Lang-Armadura",
                "Lang-Hackers",
                "Lang-Kong",
                "Lang-Bloqueo Satelital"
            };
            this.ItemToString = new Dictionary<System.Type, string> 
            {
                {new AntiaircraftMissile().GetType(), names[0]},
                {new Armor().GetType(), names[1]},
                {new Hackers().GetType(), names[2]},
                {new Kong().GetType(), names[3]},
                {new SateliteLock().GetType(), names[4]},
            };
        }
        public string NameOf(IItem item)
        {
            return this.ItemToString[item.GetType()];
        }
    }
}