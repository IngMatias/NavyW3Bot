using System;
using System.Collections.Generic;

namespace Library
{
    public class PlayerPhase : IPhase
    {
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            InputVessel vesselSelect = new InputVessel();
            int selectedVessel = vesselSelect.TakeOptionVessel(player.GetVessels(),clientP,clientR);
            Console.WriteLine(player.GetVessels()[selectedVessel]);
/*
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