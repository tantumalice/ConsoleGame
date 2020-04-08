using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    static class Player
    {
        public static string Name { get; private set; }

        private static List<GameObject> inventory = new List<GameObject>(inventoryCapacity);

        private static readonly int inventoryCapacity = 10;

        private static (int x, int y) currentLocation;

        private static (int rangeX, int rangeY) field;

        public static void SetGameField(int rangeX, int rangeY)
        {
            Random rnd = new Random();
            currentLocation = (rnd.Next(0, rangeX), rnd.Next(0, rangeY));
            field = (rangeX, rangeY);
        }
        public static string Go(string direction)
        {
            bool success = false;
            switch (direction)
            {
                case "запад":
                    if (currentLocation.x - 1 > 0)
                    {
                        currentLocation.x--;
                        success = true;
                    }
                    break;
                case "восток":
                    if (currentLocation.x + 1 < field.rangeX)
                    {
                        currentLocation.x++;
                        success = true;
                    }
                    break;
                case "север":
                    if (currentLocation.x + 1 < field.rangeY)
                    {
                        currentLocation.y++;
                        success = true;
                    }
                    break;
                case "юг":
                    if (currentLocation.y - 1 < 0)
                    {
                        currentLocation.y--;
                        success = true;
                    }
                    break;
                default:
                    return "Неверное направление.";
            }
            return success ? "Вы прошли в другую комнату." : "Здесь нет двери.";
        }
        public static string ShowInventory()
        {
            var sb = new StringBuilder();
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
                return "Вы не можете взять живой объект!";
            }
            else if (inventory.Count == inventoryCapacity)
            {
                return "Вы не можете нести больше. Нужно что-то выбросить!";
            }
            else
            {
                inventory.Add(obj);
                return "Вы взяли " + obj.ToString();
            }
        }

        //TODO: выбросить объект
    }
}
