using System;
using System.Collections.Generic;

namespace Library
{
    public class TelegramPlayers
    {
        private Dictionary<long, AbstractPlayer> _actualPlaying;
        private static TelegramPlayers _instance;
        public static TelegramPlayers Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TelegramPlayers();
                }
                return _instance;
            }
        }
        private TelegramPlayers()
        {
            this._actualPlaying = new Dictionary<long, AbstractPlayer> ();
        }
        public AbstractPlayer GetPlayer(string name, long id)
        {
            try
            {
                AbstractPlayer toReturn = this._actualPlaying[id];
                if (toReturn.Name != name)
                {
                    toReturn.Name = name;
                }
                Console.WriteLine("Se consulta "+ name);
                return toReturn;
            } 
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Se agrego un player: " + name);
                AbstractPlayer playerToAdd = new Player(name, id, new ClientTelegramPrinter());
                this._actualPlaying.Add(id, playerToAdd);
            }
            return this._actualPlaying[id];
        }
    }
}