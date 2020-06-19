using System;
using System.Collections.Generic;
namespace ConsoleGame
{
    static class Reader
    {
        public static readonly Dictionary<string, Func<string, string>> Interactions = new Dictionary<string, Func<string, string>>()
        {
            {"take", new Func<string, string>(command => ProcessTaking(command))},
            {"throw", new Func<string, string>(command => ProcessThrowing(command))}
        };

        public static readonly Dictionary<string, Func<string>> SimpleCommands = new Dictionary<string, Func<string>>()
        {
            {"help", new Func<string>(() => Helper.GetHelpInfo())},
            {"me", new Func<string>(() => Player.About())},
            {"look around", new Func<string>(() => Player.Location.LookAround())},
            {"show inventory", new Func<string>(() => Player.ShowInventory())},
            {"show map", new Func<string>(() => Player.ShowMap())},
            {"exit", new Func<string>(() => Helper.Exit())},
            {"go to the west", new Func<string>(() => Player.Go("west"))},
            {"go to the north", new Func<string>(() => Player.Go("north"))},
            {"go to the south", new Func<string>(() => Player.Go("south"))},
            {"go to the east", new Func<string>(() => Player.Go("east"))}
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

            if (SimpleCommands.TryGetValue(command, out var action))
            {
                return action.Invoke();
            }
            else
            {
                if (Interactions.TryGetValue(command.Split(" ")[0], out var interaction))
                {
                    return interaction.Invoke(command);
                }
                else
                {
                    return Helper.WrongInput();
                }
            }
        }

        public static string ProcessTaking(string command)
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

        public static string ProcessThrowing(string command)
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
