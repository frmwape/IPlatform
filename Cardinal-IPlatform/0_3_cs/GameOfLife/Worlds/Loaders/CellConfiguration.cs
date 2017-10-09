namespace GameOfLife.Worlds.Loaders
{
    public class CellConfiguration
    {
        public CellConfiguration(bool alive)
        {
            Alive = alive;
        }

        public bool Alive { get; private set; }

        public override string ToString() => string.Format("I am {0}", Alive ? "alive" : "dead");
        
    }
}