
namespace Empires.IO
{
    using System;
    using Empires.Contracts;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();
            return input;
        }
    }
}
