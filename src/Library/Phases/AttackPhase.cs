using System;
using System.Collections.Generic;

namespace Library
{
    public class AttackPhase : IPhase
    {
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            InputType inputType = new InputType();
            VesselsToString vesselsName = new VesselsToString();
            VesselsAttackForms vesselsAttack = new VesselsAttackForms();
            List<AbstractVessel> playerVessels = new List<AbstractVessel>();

            // primero tengo que mostrar los tableros de los enemigos y enumerarlos
            int i = 1;
            foreach(AbstractTable enemie in enemies)
            {
                clientP.Print("Tablero "+ i + 1  + "\n" + enemie.ToString());
                i++;
            }
            
            clientR.ReadInt(1,enemies.Count,clientP,"A que tablero desea atacar?:");

            int e = 0;
            foreach(AbstractVessel vessel in player.GetVessels())
            {
                playerVessels.Add(vessel);
                clientP.Print("Dispone de " + vesselsName.NameOf(vessel) + ". Presione "+ e + 1 + " para seleccionarlo.");
                e++;
            }

            int idOfAttackerVessel = clientR.ReadInt(1,enemies.Count,clientP,"Con que enbarcación desea atacar?:");
            int idOfAtackedTable = clientR.ReadInt(1,enemies.Count,clientP,"A que tablero desea atacar?:");

            AbstractVessel attackerVessel = playerVessels[idOfAttackerVessel - 1];
            AbstractTable attackedTable = enemies[idOfAtackedTable - 1];

            inputType.AttackFormsOf(attackerVessel).Attack(attackerVessel,attackedTable,clientP,clientR);


            return new List<int> {};
        }
    }
}