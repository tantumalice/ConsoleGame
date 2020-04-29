using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.GameObjects;

namespace ConsoleGame
{
    static class Player
    {
        public static string Name { get; set; } = "Stranger";

        public static string Description = "You are here to explore the Rooms.";

        public static Room Location
        {
            get
            {
                return GameField.Field[coordinates.x, coordinates.y];
            }
        }

        private static List<GameObject> inventory = new List<GameObject>(inventoryCapacity);

        private static readonly int inventoryCapacity = 8;

        private static (int x, int y) coordinates;

        private static (int rangeX, int rangeY) field;

        public static void SetGameField(Room[,] gameField)
        {
            Random rnd = new Random();
            var rangeX = gameField.GetLength(0);
            var rangeY = gameField.GetLength(1);
            coordinates = (rnd.Next(rangeX), rnd.Next(rangeY));
            field = (rangeX, rangeY);
        }
        public static string Go(string direction)
        {
            bool success = false;
            switch (direction)
            {
                case "west":
                    if (coordinates.x - 1 > 0)
                    {
                        coordinates.x--;
                        success = true;
                    }
                    break;
                case "east":
                    if (coordinates.x + 1 < field.rangeX)
                    {
                        coordinates.x++;
                        success = true;
                    }
                    break;
                case "north":
                    if (coordinates.y + 1 < field.rangeY)
                    {
                        coordinates.y++;
                        success = true;
                    }
                    break;
                case "south":
                    if (coordinates.y - 1 > 0)
                    {
                        coordinates.y--;
                        success = true;
                    }
                    break;
                default:
                    return "Wrong direction.";
            }
            return success ? "You have entered the next room." : "There is no door here.";
        }

        public static string About()
        {
            var sb = new StringBuilder();
            sb.AppendLine("About you:");
            sb.Append("Your name is ").AppendLine(Name);
            sb.AppendLine(Description);
            //sb.AppendLine($"You are at {coordinates.x}, {coordinates.y}");
            return sb.ToString();
        }
        public static string ShowInventory()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Your inventory: ");
            foreach (var obj in inventory)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString();
        }

        public static string PutInInventory(GameObject obj)
        {
            if (obj.IsAlive)
            {
                return "You can't take alive object!";
            }
            else if (inventory.Count == inventoryCapacity)
            {
                return "You can't carry more things! Something needs to be thrown away.";
            }
            else
            {
                inventory.Add(obj);
                return "You took " + obj.ToString();
            }
        }

        //TODO: выбросить объект
    }
}
