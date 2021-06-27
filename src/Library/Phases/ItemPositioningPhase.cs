
// S -  SRP: Esta clase define la fase de distribucion de items.

// O -  OCP: Implementando IPhase podemos permitir el agregado de nuevas fases 
//      sin la necesidad de alterar el codigo, sino mas bien simplemente agregando una nueva clase.

// L -  LSP: ItemPositioningPhase es un subtipo de IPhase.

// I -  ISP: No se usan todas las operaciones definidas en IPriner e IReader.

// D -  DIP: No se depende solo de abstracciones.

//      Expert: Esta clase conoce los items por lo tanto se encarga de asignarlos.

//      Polymorphism: El metodo Excecute es polimorfico en todos los IPhase.

//      Creator: Se crean ItemsToString, ItemsValidators, InputAddItem porque se usan de manera cercana.

using System;
using System.Collections.Generic;

namespace Library
{
    public class ItemPositioningPhase : IPhase
    {
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

            ItemsToString _itemsName = new ItemsToString();
            ItemsValidators _validator = new ItemsValidators();
            InputAddItem _addItem = new InputAddItem();

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