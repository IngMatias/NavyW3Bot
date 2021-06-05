namespace Library
{
    public class Puntoon : AbstractVessels
    {
        public Puntoon()
        :base()
        {
            this.state = new int[1];
            this.InitState(1);
        }
    }
}