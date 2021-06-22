using System;
using System.Collections.Generic;

namespace Library
{
    public class FirstPhase : IPhase
    {
        private List<AbstractVessel> vessels = new List<AbstractVessel>
        {
            new Battleship(),
            new Frigate(),
            new HeavyCruiser(),
            new LightCruiser(),
            new Puntoon(),
            new Submarine(),
        };
        private List<IItem> items = new List<IItem>
            {
                new AntiaircraftMissile(),
                new Armor(),
                new Hackers(),
                new Kong(),
                new SateliteLock()
            };
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            ItemsToString itemsName = new ItemsToString();
            VesselsToString vesselsName = new VesselsToString();
            VesselsAttackForms vesselsAttack = new VesselsAttackForms();
            ItemsValidators validator = new ItemsValidators();
            
            InputAddItem addItem = new InputAddItem();
            InputAddVessel addVessel = new InputAddVessel();

            // Posicionamiento de los barcos.
            int i = 0;
            bool agregado = false;
            while (i < 2)
            {
                agregado = false;
                while (!agregado)
                {
                    clientP.Print(vesselsName.NameOf(vessels[i]));
                    agregado = addVessel.AddVessel(this.vessels[i], player, clientP, clientR);
                    if (agregado)
                    {
                        clientP.Print(vesselsName.NameOf(vessels[i]) + " ha sido agregado correctamente.");
                    }
                    else
                    {
                        clientP.Print("El barco no ha sido agregado.");
                    }
                }
                i++;
            }
            clientP.Print(player.StringTable());

            // Distribucion de los items.
            for (i = 0; i < 3; i++)
            {
                Random random = new Random();
                int rnd = random.Next(0, this.items.Count);
                agregado = false;
                while (!agregado)
                {
                    clientP.Print(itemsName.NameOf(items[rnd]));



                    try
                    {
                        agregado = addItem.AddItem(this.items[rnd], player.GetVessels(), player, validator.ValidatorOf(this.items[rnd]), clientP, clientR);
                    }
                    catch (DeleteItemException)
                    {
                        clientP.Print("Item Eliminado.");
                        break;
                    }
                    catch (NeededEmptyVesselException)
                    {
                        clientP.Print("El item necesita un barco vacio.");
                    }
                    catch (NoEmptyPositionException)
                    {
                        clientP.Print("Posicion ocupada.");
                    }
                    catch (NoRepetitiveItemException)
                    {
                        clientP.Print("Solo puedes tener un item de este tipo por barco.");
                    }
                    catch (TooLongVesselException)
                    {
                        clientP.Print("Se necesita un barco mas grande.");
                    }
                    catch (WrongVesselException)
                    {
                        clientP.Print("Este item no puede ser agregado en este barco.");
                    }



                    if (agregado)
                    {
                        clientP.Print(itemsName.NameOf(items[rnd]) + " ha sido agregado correctamente.");
                    }
                    else
                    {
                        clientP.Print("El item no ha sido agregado.");
                    }
                }
            }
            clientP.Print(player.StringVessels());

            return new List<int> {};
        }
    }
}