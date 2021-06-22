using System.Collections.Generic;

namespace Library
{
    public class Puntoon : AbstractVessel
    {
        public Puntoon()
        : base(1, 1)
        {

        }
        public string Name()
        {
            return "Puntoon";
        }
        public List<string> AttackForms()
        {
            return new List<string> { };
        }
    }
}