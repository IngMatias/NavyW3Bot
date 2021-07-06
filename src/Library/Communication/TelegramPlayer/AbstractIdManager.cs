namespace Library
{
    public class AbstractIdManager
    {
        private long _id;
        public long Id 
        {
            get
            {
                return this._id;
            }
            set
            {
                if (this._id == 0)
                {
                    this._id = value;
                }
            }
        }
        public AbstractIdManager(long id)
        {
            this.Id = id;
        }
    }
}