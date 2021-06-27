
// S -  SRP: Esta clase define la fase de distribucion de barcos.

// O -  OCP: Implementando IPhase podemos permitir el agregado de nuevas fases 
//      sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L -  LSP: VasselsPositioningPhase es un subtipo de IPhase.

// I -  ISP: No se usan todas las operaciones definidas en IPriner e IReader.

// D -  DIP: No se depende solo de abstracciones.

//      Expert: Esta clase conoce los items por lo tanto se encarga de asignarlos.

//      Polymorphism: El metodo Excecute es polimorfico en todos los IPhase.

//      Creator: Se crean VesselsToString e InputAddVessel porque se usan de manera cercana.

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
            // Dependencias.
            VesselsToString _vesselsName = new VesselsToString();
            InputAddVessel _addVessel = new InputAddVessel();

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