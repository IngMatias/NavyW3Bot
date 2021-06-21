using System;
using System.Collections.Generic;

namespace Library
{
    public class FirstPhase : IPhase
    {
        private List<string> vesselsName = new List<string>
            {
                "Battleship",
                "Frigate",
                "HeavyCruiser",
                "LightCruiser",
                "Puntoon",
                "Submarine"
            };
        private List<AbstractVessel> vessels = new List<AbstractVessel>
            {
                new Battleship(),
                new Frigate(),
                new HeavyCruiser(),
                new LightCruiser(),
                new Puntoon(),
                new Submarine(),
            };
        private List<string> itemsName = new List<string> 
            {
                "AntiaircraftMissile",
                "Armor",
                "Hackers",
                "Kong",
                "SateliteLock",
            };
        private List<IItem> items = new List<IItem>
            {
                new AntiaircraftMissile(),
                new Armor(),
                new Hackers(),
                new Kong(),
                new SateliteLock()
            };
        private List<IItemValidator> itemValidators = new List<IItemValidator>
            {
                new AntiaircraftMissileValidator(),
                new ArmorValidator(),
                new HackersValidator(),
                new KongValidator(),
                new SateliteLockValidator()
            };
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {

            // Posicionamiento de los barcos.
            InputAddVessel addVessel = new InputAddVessel();
            int i = 0;
            bool agregado = false;
            while (i < this.vessels.Count)
            {
                agregado = false;
                while (!agregado)
                {
                    clientP.Print(vesselsName[i]);
                    agregado = addVessel.AddVessel(this.vessels[i], player, clientP, clientR);
                    if (agregado)
                    {
                        clientP.Print(vesselsName[i] + " ha sido agregado correctamente.");
                    }
                    else
                    {
                        clientP.Print("El barco no ha sido agregado.");
                    }
                }
                i++;
            }

            // Distribucion de los items.
            InputAddItem addItem = new InputAddItem();
            for (i = 0; i<this.items.Count; i++)
            {
                Random random= new Random();
                int rnd = random.Next(0,this.items.Count);
                agregado = false;
                while (!agregado)
                {
                    clientP.Print(itemsName[rnd]);
                    agregado = addItem.AddItem(this.items[rnd],player.GetVessels(),player,this.itemValidators[rnd],clientP,clientR);
                    if (agregado)
                    {
                        clientP.Print(itemsName[i] + " ha sido agregado correctamente.");
                    }
                    else
                    {
                        clientP.Print("El item no ha sido agregado.");
                    }
                }
            }

            return new List<int>();
        }
    }
}