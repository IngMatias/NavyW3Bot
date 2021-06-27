
// S -  SRP: Esta interfaz define la fase de Ataque.

// O -  OCP: Implementando IPhase podemos permitir el agregado de nuevas fases 
//      sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.
           
// L -  LSP: AttackPhase es un subtipo de IPhase.

// I -  ISP: No se usan todas las operaciones definidas en IPriner e IReader.

// D -  DIP: Se rompe el principio cuando se depende de clases de bajo nivel como InputTable, InputVessel e InputAttack.

//      Expert: No se utiliza.

//      Polymorphism: El metodo Excecute es polimorfico en todos los IPhase.

//      Creator: Se crean InputTable, InputVessel e InputAttack ya que se utilizan de manera cercana.

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