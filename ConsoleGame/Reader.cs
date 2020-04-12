using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    static class Reader
    {
        public static readonly HashSet<string> Commands = new HashSet<string>
        {
            "Go to the West",
            "Go to the North",
            "Go to the South",
            "Go to the East",
            "Help",
            "Me",
            "Look around",
            "Exit"
        };

        public static string ReadName()
        {
            Console.Write("Type your name here: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
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
            var command = Console.ReadLine();
            if (!Commands.Contains(command))
            {
                return Helper.WrongInput();
            }
            else
            {
                if(command.StartsWith("Go"))
                {
                    var words = command.Split(" ");
                    var direction = words[words.Length - 1];
                    return Player.Go(direction);
                }
                else
                {
                    return command switch
                    {
                        "Help" => Helper.GetHelpInfo(),
                        "Me" => Player.About(),
                        "Look around" => Player.Location.LookAround(),
                        "Exit" => Helper.Exit(),
                        _ => Helper.WrongInput()
                    };
                }
            }
        }
    }
}
