using System;
using System.Collections.Generic;
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
            "exit"
        };

        public static string ReadName()
        {
            Console.Write("Type your name here: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Your name can't be emty.");
                ReadName();
            }
            else
            {
                Player.Name = name;
            }
            return $"Ok! I'll call you {Player.Name}.";
        }

        public static string ReadCommand()
        {
            var command = Console.ReadLine().ToLower();
            if (!Commands.Contains(command))
            {
                return Helper.WrongInput();
            }
            else
            {
                if(command.StartsWith("go"))
                {
                    var words = command.Split(" ");
                    var direction = words[words.Length - 1];
                    return Player.Go(direction);
                }
                else
                {
                    return command switch
                    {
                        "help" => Helper.GetHelpInfo(),
                        "me" => Player.About(),
                        "look around" => Player.Location.LookAround(),
                        "exit" => Helper.Exit(),
                        _ => Helper.WrongInput()
                    };
                }
            }
        }
    }
}
