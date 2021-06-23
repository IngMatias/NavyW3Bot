namespace Library
{
    public abstract class AbstractKongCheck
    {
        public bool KongCheck( AbstractItemSaver vesselToAdd)
        {
            foreach( IItem item in vesselToAdd.Items)
            {
                if (item is Kong)
                {
                    return false;
                }
            }
            return true;
        }
    }
}