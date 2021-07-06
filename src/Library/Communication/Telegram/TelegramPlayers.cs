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
        public AbstractPlayer GetPlayer(long id)
        {
            try
            {
                Console.WriteLine("Se consulta: " + id);
                return this._actualPlaying[id];
            } 
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Se agrega: " + id);
                AbstractPlayer playerToAdd = new Player(id, new ClientTelegramPrinter());
                this._actualPlaying.Add(id, playerToAdd);
            }
            return this._actualPlaying[id];
        }
    }
}