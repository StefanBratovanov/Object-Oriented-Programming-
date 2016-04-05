
namespace Empires.IO
{
    using System;
    using Empires.Contracts;

    public class ConsoleWriter : IOutputWriter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
