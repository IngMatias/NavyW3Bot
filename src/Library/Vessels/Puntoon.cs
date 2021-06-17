using System.Collections.Generic;

namespace Library
{
    public class Puntoon : AbstractVessel
    {
        public Puntoon()
        : base(1, 1)
        {
            
        }

        public override void Attack0(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            throw new System.NotImplementedException();
        }

        public override void Attack1(AbstractTable table, IPrinter clientP, IReader clientR)
        {
            throw new System.NotImplementedException();
        }

        public override List<string> AttackForms()
        {
            return new List<string>();
        }
    }
}