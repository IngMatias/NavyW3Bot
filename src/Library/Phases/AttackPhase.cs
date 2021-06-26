// S - SRP: Esta interfaz define la fase de Ataque.

// O - OCP: No se utiliza.
           
// L - LSP: Se cumple. Si se sustituye por IPhase su comportamiento es el mismo.

// I - ISP: Se cumple, utiliza todas las operaciones que define la interfaz, ninguna operacion esta de mas.

// D - DIP: Se rompe el principio cuando se depende de una clase de bajo nivel como random, InputTable, InputVessel y InputAttack.
//           Para que las tres ultimas cumplan con este principio, se deberian definir interfaces para que AttackPhase dependa de estas
//           interfaces y no de clases de bajo nivel.

// Expert: No se utiliza.

// Polymorphism: Se define el metodo Excecute.

// Creator: No se aplica.

using System;
using System.Collections.Generic;

namespace Library
{
    public class AttackPhase : IPhase
    {
        // Dependencias.
            private InputTable _tableOption = new InputTable();
            private InputVessel _vesselOption = new InputVessel();
            private InputAttack _attackWith = new InputAttack();

        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            // Mostrar los tableros de los enemigos y seleccionar uno.
            int tableToAttack = _tableOption.TakeOptionTable(enemies.AsReadOnly(), clientP, clientR);

            // Mostrar los barcos disponibles y seleccionar uno.
            int vesselToAttack = _vesselOption.TakeOptionVessel(player.GetVessels(), clientP, clientR);

            // Atacar con el barco.
            _attackWith.AttackForm(player.GetVessels()[vesselToAttack]).Attack(player.GetVessels()[vesselToAttack], enemies[tableToAttack], clientP, clientR);

            return new List<int> { };
        }
    }
}