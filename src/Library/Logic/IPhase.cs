using System.Collections.Generic;

namespace Library
{
    public interface IPhase
    {
        public List<int> Execute(ITable player, List<ITable> enemies, IPrinter clientP, IReader clientR);
    }
}