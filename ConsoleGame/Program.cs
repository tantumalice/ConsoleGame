using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsOver = false;
            Console.WriteLine(Reader.ReadName());
            Console.WriteLine($"Hello, {Player.Name}! Let's start the game! Type \"Help\" to see commands.");
            while (!IsOver)
            {
                var msg = Reader.ReadCommand();
                Console.WriteLine(msg);
            }
        }
    }
}
