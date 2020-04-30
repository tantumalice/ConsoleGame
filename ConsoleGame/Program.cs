using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player.SetGameField(GameField.Field);
            Console.WriteLine(Reader.ReadName());
            Console.WriteLine($"# Hello, {Player.Name}! Let's start the game! Type \"Help\" to see commands.");
            while (true)
            {
                Console.Write("> ");
                var msg = Reader.ReadCommand();
                Console.WriteLine($"# {msg.Replace("\n", "\n# ")}");
            }
        }
    }
}
