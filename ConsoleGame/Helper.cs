using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    static class Helper
    {
        public static string GetHelpInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine("List of commands:");
            foreach (var command in Reader.SimpleCommands)
            {
                sb.AppendLine(command.Key);
            }
            foreach (var command in Reader.Interactions)
            {
                sb.Append(command.Key).AppendLine(" %object name%");
            }
            return sb.ToString().TrimEnd();
        }

        public static string WrongInput()
        {
            return "Wrong command! Type \"Help\" for help.";
        }

        public static string Exit()
        {
            Environment.Exit(0);
            return "Sayonara!";
        }
    }
}
