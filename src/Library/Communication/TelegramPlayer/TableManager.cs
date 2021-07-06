using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Library
{
    public class TableManager : AbstractPlayerStateManager
    {
        protected Table _table;

        public TableManager(long id, IPrinter clientP)
        :base(id, clientP)
        {
            this._table = new Table();
        }

        public bool AddVessel(int x, int y, AbstractVessel vessel,bool ori)
        {
            return this._table.AddVessel(x,y,vessel,ori);
        }

        public string Table
        {
            get
            {
                return this._table.StringTable();
            }
        }
        public ReadOnlyCollection<AbstractVessel> Vessels
        {
            get
            {
                return this._table.GetVessels();
            }
        }
    }
}