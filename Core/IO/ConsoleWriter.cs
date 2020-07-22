namespace GreenVsRed.Core.IO
{
    using Interfaces;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}