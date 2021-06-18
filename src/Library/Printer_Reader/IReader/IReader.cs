namespace Library
{
    public interface IReader
    {
        public string Read();
        public string Read(IPrinter printer, string msg);
        public int ReadInt(int from, int until, IPrinter printer, string msg);
    }
}