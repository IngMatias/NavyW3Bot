namespace Library
{
    public interface IReader
    {
        public string Read();
        public string Read(IPrinter printer, string msg);
    }
}