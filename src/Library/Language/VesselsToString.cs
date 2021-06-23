using System.Collections.Generic;

namespace Library
{
    public class VesselsToString
    {
        private Dictionary<System.Type,string> _vesselToString;
        public VesselsToString()
        {
            List<string> names = new List<string> 
            {
                "Lang-Acorazado",
                "Lang-Fragata",
                "Lang-Crucero Pesado",
                "Lang-Crucero Ligero",
                "Lang-Ponton",
                "Lang-Submarino"
            };
            this._vesselToString = new Dictionary<System.Type, string> 
            {
                {new Battleship().GetType(), names[0]},
                {new Frigate().GetType(), names[1]},
                {new HeavyCruiser().GetType(), names[2]},
                {new LightCruiser().GetType(), names[3]},
                {new Puntoon().GetType(), names[4]},
                {new Submarine().GetType(), names[5]},
            };
        }
        public string NameOf(AbstractVessel vessel)
        {
            return this._vesselToString[vessel.GetType()];
        }
    }
}