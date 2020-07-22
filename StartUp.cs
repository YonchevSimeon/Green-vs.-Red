namespace GreenVsRed
{
    using Core;
    using Core.Interfaces;
    using Core.IO;
    using Core.IO.Interfaces;

    public class Program
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IRunnable engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
