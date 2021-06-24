using System;
using System.Collections.Generic;

namespace Library
{
    public class VasselsPositioningPhase : IPhase
    {

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
            VesselsToString vesselsName = new VesselsToString();
            VesselsAttackForms vesselsAttack = new VesselsAttackForms();
            InputAddVessel addVessel = new InputAddVessel();

            // Posicionamiento de los barcos.
            int i = 0;
            bool agregado = false;

            while (i < this._vessels.Count)
            {
                agregado = false;
                while (!agregado)
                {
                    clientP.Print(vesselsName.NameOf(this._vessels[i]));
                    agregado = addVessel.AddVessel(this._vessels[i], player, clientP, clientR);
                    if (agregado)
                    {
                        clientP.Print(vesselsName.NameOf(this._vessels[i]) + " ha sido agregado correctamente.");
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