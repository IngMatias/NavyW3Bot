namespace Library
{
    public interface IReader
    {
        public string Read();
        public string Read(IPrinter printer, object msg);
        public int ReadInt(int from, int until, IPrinter printer, object msg);
    }
}