using System.Collections.Generic;

namespace Library
{
    public class ComputerPhase : IPhase
    {
        public ComputerPhase()
        {

        }

        public List<int> Execute(ITable player, List<ITable> enemies, IPrinter clientP, IReader clientR)
        {
            return new List<int>();
        }
    }
}