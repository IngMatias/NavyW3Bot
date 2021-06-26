// S - SRP: Esta interfaz define la fase de Posisionamiento de Items.

// O - OCP: No se utiliza.
           
// L - LSP: Se cumple. Si se sustituye por IPhase su comportamiento es el mismo.

// I - ISP: Se cumple, utiliza todas las operaciones que define la interfaz, ninguna operacion esta de mas.

// D - DIP: Se rompe el principio cuando se depende de una clase de bajo nivel como ItemToString, ItemsValidators, InputAddItem.
//           Para que las tres ultimas cumplan con este principio, se deberian definir interfaces para que AttackPhase dependa de estas
//           interfaces y no de clases de bajo nivel.

// Expert: No se utiliza.

// Polymorphism: Se define el metodo Excecute.

// Creator: No se aplica.

using System;
using System.Collections.Generic;

namespace Library
{
    public class ItemPositioningPhase : IPhase
    {
        private ItemsToString _itemsName = new ItemsToString();
        private ItemsValidators _validator = new ItemsValidators();
        private InputAddItem _addItem = new InputAddItem();
        private List<IItem> _items = new List<IItem>
            {
                new AntiaircraftMissile(),
                new Armor(),
                new Hackers(),
                new Kong(),
                new SateliteLock()
            };
        private int _howManyItems = 5;
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            bool agregado;
            int i = 0;

            // Distribucion de los items.
            for (i = 0; i < this._howManyItems; i++)
            {
                Random random = new Random();
                int rnd = random.Next(0, this._items.Count);
                agregado = false;
                while (!agregado)
                {
                    clientP.Print(_itemsName.NameOf(this._items[rnd]));

                    try
                    {
                        agregado = _addItem.AddItem(this._items[rnd], player.GetVessels(), player, _validator.ValidatorOf(this._items[rnd]), clientP, clientR);
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
                    catch (TooShortVesselException)
                    {
                        clientP.Print("Se necesita un barco mas grande.");
                    }
                    catch (WrongVesselException)
                    {
                        clientP.Print("Este item no puede ser agregado en este barco.");
                    }
                    catch (BlockedVesselException)
                    {
                        clientP.Print("Este barco no puede añadir items porque esta bloqueado.");
                    }

                    if (agregado)
                    {
                        clientP.Print(_itemsName.NameOf(this._items[rnd]) + " ha sido agregado correctamente.");
                    }
                    else
                    {
                        clientP.Print("El item no ha sido agregado.");
                    }
                }
            }
            clientP.Print(player.StringVessels());

            return new List<int> { };
        }
    }
}