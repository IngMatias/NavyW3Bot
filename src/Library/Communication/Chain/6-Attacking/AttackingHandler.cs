
using System;
using System.Collections.Generic;

namespace Library
{
    public class AttackingHandler : AbstractHandler
    {
        public AttackingHandler()
        : base(new ShowEnemiesHandler())
        {
        }
        public override void DoCommand(string command, AbstractPlayer player)
        {
            // attack barco x y missil/load receptor
            if (command.StartsWith("attack ") && player.IsAttacking() && command.Split(" ").Length == 6)
            {
                if (Rooms.Instance.IsPlaying(player))
                {
                    if (Rooms.Instance.IsPlayingWith(player, command.Split(" ")[5]))
                    {
                        string[] commArg = command.Split(" ");

                        int vesselInt = StringToInt.Convert(1, player.Vessels.Count, command.Split(" ")[1], player, "El barco") - 1;
                        int x = StringToInt.Convert(1, player.XLength(), command.Split(" ")[2], player, "La primera coordenada") - 1;
                        int y = StringToInt.Convert(1, player.YLength(), command.Split(" ")[3], player, "La segunda coordenada") - 1;

                        int form = 0;
                        if (vesselInt != -2)
                        {
                            VesselsAttackForms aux = new VesselsAttackForms();
                            form = StringToInt.Convert(1, 2, command.Split(" ")[4], player, "La forma de ataque") - 1;
                        }

                        if (x != -2 && y != -2 && vesselInt != -2)
                        {
                            try
                            {
                                if (form == 0)
                                {
                                    Rooms.Instance.AttackByPlayingWithMissile(player, commArg[5], vesselInt, x, y);
                                }
                                else
                                {
                                    Rooms.Instance.AttackByPlayingWithLoad(player, commArg[5], vesselInt, x, y);
                                }
                                Rooms.Instance.SendAllByPlaying(player, player.Name + " ha atacado a " + commArg[5]);
                                Rooms.Instance.ShowTableOf(player, commArg[5]);
                                Rooms.Instance.NextAttackByPlaying(player);
                            }
                            catch(NotImplementedException)
                            {
                                player.SendMessage("Ese barco no puede atacar de esa forma");
                            }
                        }
                    }
                    else
                    {
                        player.SendMessage(command.Split(" ")[5] + " no esta jugando contigo");
                    }
                }
                else
                {
                    player.SendMessage("No es tu turno de atacar.");
                }
            }
            else
            {
                this.SendNext(command, player);
            }
        }
    }
}
