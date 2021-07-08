using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class TableManager : AbstractPlayerStateManager
    {
        public Table _table;
        public TableManager(long id, IPrinter clientP)
        :base(id, clientP)
        {
            this._table = new Table();
        }
        public int XLength()
        {
            return this._table.XLength();
        }
        public int YLength()
        {
            return this._table.YLength();
        }
        public bool AddVessel(int x, int y, AbstractVessel vessel,bool ori)
        {
            return this._table.AddVessel(x,y,vessel,ori);
        }

        public string EmojiTable()
        {
            return this._table.EmojiTable();
        }
        public string EmojiEnemieTable()
        {
            return this._table.EmojiEnemiTable();
        }
        public ReadOnlyCollection<AbstractVessel> Vessels
        {
            get
            {
                return this._table.GetListOfVessels();
            }
        }
        public string VesselsEItemsString()
        {
            return this._table.StringVessels();
        }
    }
}