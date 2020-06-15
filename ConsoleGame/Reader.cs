using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ConsoleGame
{
    static class Reader
    {
        public static readonly HashSet<string> Commands = new HashSet<string>
        {
            "go to the west",
            "go to the north",
            "go to the south",
            "go to the east",
            "help",
            "me",
            "look around",
            "take %object name%",
            "throw %object name%",
            "show inventory",
            "show map",
            "exit"
        };

        public static string ReadName()
        {
            Console.WriteLine("# Type your name here: ");
            Console.Write("> ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("# Your name can't be emty.");
                ReadName();
            }
            else
            {
                Player.Name = name;
            }
            return $"# Ok! I'll call you {Player.Name}.";
        }

        public static string ReadCommand()
        {
            var command = Console.ReadLine().ToLower().TrimEnd();

            if (command.StartsWith("go"))
            {
                var words = command.Split(" ");
                var direction = words[^1];
                return Player.Go(direction);
            }
            else if (command.StartsWith("take"))
            {
                var objName = command.Split(" ")[^1];
                if (objName == "take")
                {
                    return "What do you want to take? Try again!";
                }
                else
                {
                    return Player.PutInInventory(objName);
                }
            }
            else if (command.StartsWith("throw"))
            {
                var objName = command.Split(" ")[^1];
                if (objName == "throw")
                {
                    return "What do you want to throw? Try again!";
                }
                else
                {
                    return Player.ThrowOutOfInventory(objName);
                }
            }
            else
            {
                return command switch
                {
                    "help" => Helper.GetHelpInfo(),
                    "me" => Player.About(),
                    "look around" => Player.Location.LookAround(),
                    "exit" => Helper.Exit(),
                    "show inventory" => Player.ShowInventory(),
                    "show map" => Player.ShowMap(),
                    _ => Helper.WrongInput()
                };
            }
        }

        public static string ReadID(string action, string msg)
        {
            Console.WriteLine($"# {msg}");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                return action switch
                {
                    "take" => Player.PutInInventory(id),
                    "throw" => Player.ThrowOutOfInventory(id),
                    _ => throw new ArgumentException()
                };
            }
            else
            {
                return ReReadID(action, msg);
            }
        }

        public static string ReReadID(string action, string msg)
        {
            Console.WriteLine("# Wrong ID! Type it again.");
            return ReadID(action, msg);
        }
    }
}
