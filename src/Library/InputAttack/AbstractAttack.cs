using System.Collections.Generic;

namespace Library
{
    public abstract class AbstractAttack
    {
        public abstract List<string> AttackForms();
        public int TakeOption(IPrinter clientP, IReader clientR)
        {
            int index = 0;
            foreach (string option in this.AttackForms())
            {
                if (index == 0)
                {
                    clientP.Print(option);
                }
                else
                {
                    clientP.Print(index + " " + option);
                }
            }

            return clientR.ReadInt(1, this.AttackForms().Count - 1, clientP, "Como desea atacar: ");
        }
        public (int,int) TakeAttack(AbstractTable table,IPrinter clientP, IReader clientR)
        {
            int x = clientR.ReadInt(1, table.XLength(), clientP, "En que posicion X desea atacar: ");
            int y = clientR.ReadInt(1, table.YLength(), clientP, "En que posicion Y desea atacar: ");
            return (x,y);
        }
        public abstract void Attack(AbstractVessel vessel, AbstractTable table, IPrinter clientP, IReader clientR);
    }
}