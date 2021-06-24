using System;
using System.Collections.Generic;

namespace Library
{
    public class AttackPhase : IPhase
    {
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {

            // Dependencias.
            InputTable tableOption = new InputTable();
            InputVessel vesselOption = new InputVessel();
            InputAttack attackWith = new InputAttack();

            // Mostrar los tableros de los enemigos y seleccionar uno.
            int tableToAttack = tableOption.TakeOptionTable(enemies.AsReadOnly(), clientP, clientR);

            // Mostrar los barcos disponibles y seleccionar uno.
            int vesselToAttack = vesselOption.TakeOptionVessel(player.GetVessels(), clientP, clientR);

            // Atacar con el barco.
            attackWith.AttackForm(player.GetVessels()[vesselToAttack]).Attack(player.GetVessels()[vesselToAttack], enemies[tableToAttack], clientP, clientR);

            return new List<int> { };
        }
    }
}