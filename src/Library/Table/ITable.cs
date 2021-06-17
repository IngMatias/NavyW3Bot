using System.Collections.ObjectModel;

namespace Library
{
    public interface ITable
    {
        public int XLength();
        public int YLength();
        public void Update(int x, int y, int data);
        public ReadOnlyCollection<AbstractVessel> GetVessels();
        public bool IsAVessel(int x, int y);
        public bool IsSomething(int x, int y);
        public bool IsEmpty();
        public bool AddVessel(int x, int y, AbstractVessel vessel, bool orientation);
        public void AttackAt(int x, int y, AbstractAttacker attack);
        public void RandomAttack(AbstractAttacker attack);
        public void RemoveVessel(int x, int y);
        public string StringTable();
    }
}