using System;
using System.Collections.Generic;

namespace Library
{
    public class PlayerPhase : IPhase
    {
        public int TakeOption(List<string> otions)
        {
            return 0;
        }
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
/*          // Muestra los barcos en pantalla, y el jugador elije con cual atacar.
            int option = 1;
            foreach (AbstractVessel vessel in player.GetVessels())
            {
                clientP.Print(option);
                foreach (string attack in vessel.AttackForms())
                {
                    clientP.Print("  " + attack);
                }
                option++;
            }
            int vesselOption = Int32.Parse(clientR.Read()) - 1;

            // Elige la forma de ataque.
            option = 0;
            foreach (string attackForm in player.GetVessels()[vesselOption].AttackForms())
            {
                clientP.Print(option + "  " + attackForm);
                option++;
            }
            int attackOption = Int32.Parse(clientR.Read()) - 1;

            // Muestra los tableros enemigos, y el jugador elije con cual atacar.
            option = 1;
            foreach (AbstractTable table in enemies)
            {
                clientP.Print("Table " + option);
                option++;
            }
            int tableAttacked = Int32.Parse(clientR.Read()) - 1;

            // player.GetVessels()[vesselOption].Attack0(enemies[tableAttacked], clientP, clientR);
*/
            return new List<int> { };
        }
    }
}