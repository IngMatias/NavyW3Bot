// S - SRP: Esta interfaz define la fase de Posisionamiento de Barcos.

// O - OCP: No se utiliza.
           
// L - LSP: Se cumple. Si se sustituye por IPhase su comportamiento es el mismo.

// I - ISP: Se cumple, utiliza todas las operaciones que define la interfaz, ninguna operacion esta de mas.

// D - DIP: Se rompe el principio cuando se depende de una clase de bajo nivel como VesselsToString, InputAddVessel.
//           Para que se cumpla con este principio, se deberian definir interfaces para que AttackPhase dependa de estas
//           interfaces y no de clases de bajo nivel.

// Expert: No se utiliza.

// Polymorphism: Se define el metodo Excecute.

// Creator: No se aplica.

using System;
using System.Collections.Generic;

namespace Library
{
    public class VasselsPositioningPhase : IPhase
    {
        private VesselsToString _vesselsName = new VesselsToString();
        private InputAddVessel _addVessel = new InputAddVessel();

        private List<AbstractVessel> _vessels = new List<AbstractVessel>
        {
            new Battleship(),
            new Frigate(),
            new HeavyCruiser(),
            new LightCruiser(),
            new Puntoon(),
            new Submarine(),
        };
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            // Posicionamiento de los barcos.
            int i = 0;
            bool agregado = false;

            while (i < this._vessels.Count)
            {
                agregado = false;
                while (!agregado)
                {
                    clientP.Print(_vesselsName.NameOf(this._vessels[i]));
                    agregado = _addVessel.AddVessel(this._vessels[i], player, clientP, clientR);
                    if (agregado)
                    {
                        clientP.Print(_vesselsName.NameOf(this._vessels[i]) + " ha sido agregado correctamente.");
                    }
                    else
                    {
                        clientP.Print("El barco no ha sido agregado.");
                    }
                }
                i++;
            }
            clientP.Print(player.StringTable());

            return new List<int> { };
        }
    }
}