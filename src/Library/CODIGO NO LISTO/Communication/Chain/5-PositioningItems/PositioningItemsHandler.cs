using System;
using System.Collections.Generic;

namespace Library
{
    public class PositioningItemsHandler : AbstractHandler
    {
        public PositioningItemsHandler()
        : base(new ShowItemsHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            if (command.StartsWith("add") && player.IsPositioningItem() && command.Split(" ").Length == 3)
            {
                int vesselInt = StringToInt.Convert(1, player.Vessels.Count, command.Split(" ")[1], player, "El barco") - 1;
                int position = -2;

                if (vesselInt != -2)
                {
                    position = StringToInt.Convert(1, player.Vessels[vesselInt].Length(), command.Split(" ")[2], player, "La posicion del barco") - 1;
                }

                if (vesselInt != -2 && position != -2)
                {
                    try
                    {
                        player.AddItem(position, Item.Instance.Next(player), player.Vessels[vesselInt]);
                        Item.Instance.RemoveItem(player);
                        player.SendMessage("Se ha agregado el item correctamente");

                        ItemsToString itemsToString = new ItemsToString();
                        player.SendMessage("Siguiente item: "+ itemsToString.ToString(Item.Instance.Next(player)));
                    }
                    catch (Exception)
                    {
                        Item.Instance.RemoveItem(player);
                    }

                    if (player.CountItems() >= 4)
                    {
                        player.NextState();
                    }
                }
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}