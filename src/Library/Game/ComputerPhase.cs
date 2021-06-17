using System.Collections.Generic;

namespace Library
{
    public class ComputerPhase : IPhase
    {
        public List<int> Execute(AbstractTable player, List<AbstractTable> enemies, IPrinter clientP, IReader clientR)
        {
            return new List<int>();
        }
    }
}