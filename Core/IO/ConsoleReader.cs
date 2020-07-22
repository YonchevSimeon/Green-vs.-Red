namespace GreenVsRed.Core.IO
{
    using Interfaces;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}