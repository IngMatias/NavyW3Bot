using System.Collections.Generic;

namespace Library
{
    public interface IPhase
    {
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR);
    }
}