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
        public static Room Location => GameField.Field[coordinates.x, coordinates.y];

        private static readonly List<GameObject> inventory = new List<GameObject>();

        private static float currentInventoryWeight = 0;

        private static readonly float maxInventoryWeight = 5;

        private static (int x, int y) coordinates;

        public static void SetGameField()
        {
            Random rnd = new Random();
            var rangeX = GameField.Field.GetLength(0);
            var rangeY = GameField.Field.GetLength(1);
            coordinates = (rnd.Next(rangeX), rnd.Next(rangeY));
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
                    if (coordinates.x + 1 < GameField.Field.GetLength(0))
                    {
                        coordinates.x++;
                        success = true;
                    }
                    break;
                case "north":
                    if (coordinates.y + 1 < GameField.Field.GetLength(1))
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
            return sb.ToString().TrimEnd();
        }
        public static string ShowInventory()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Your inventory: ");
            foreach (var obj in inventory)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public static string PutInInventory(string name)
        {
            var buff = GameField.Field[coordinates.x, coordinates.y].Items
                                                                    .FindAll
                                                                     (
                                                                      delegate (GameObject obj)
                                                                      {
                                                                          return obj.Name.ToLower() == name.ToLower();
                                                                      }
                                                                     );
            switch (buff.Count)
            {
                case 0:
                    return $"There is no {name} in this room!";
                case 1:
                    return AddInInventory(buff[0]);
                default:
                    if (buff[0].IsAlive)
                    {
                        return "You can't take alive object!";
                    }
                    else
                    {
                        var sb = new StringBuilder();
                        sb.AppendLine($"There is more than one {name} in this room! Which one would you like to take? Type it's ID below.");
                        sb.Append("IDs: ");
                        foreach (var obj in buff)
                        {
                            sb.Append($"{obj.ID}  ");
                        }
                        return Reader.ReadID("take", sb.ToString());
                    }
            };
        }

        public static string PutInInventory(int id)
        {
            var obj = GameField.Field[coordinates.x, coordinates.y].Items
                                                                   .Find
                                                                    (
                                                                     delegate (GameObject obj)
                                                                     {
                                                                         return obj.ID == id;
                                                                     }
                                                                    );
            if (obj != null)
            {
                return AddInInventory(obj);
            }
            else
            {
                return Reader.ReReadID("take", "Type ID below.");
            }
        }

        private static string AddInInventory(GameObject obj)
        {
            if (obj.IsAlive)
            {
                return "You can't take alive object!";
            }
            else if (currentInventoryWeight + obj.Weight > maxInventoryWeight)
            {
                return "You can't carry more things! Something needs to be thrown away.";
            }
            else
            {
                inventory.Add(obj);
                GameField.Field[coordinates.x, coordinates.y].RemoveItem(obj);
                currentInventoryWeight += obj.Weight;
                return "You took the " + obj.ToString();
            }
        }

        //TODO: выбросить объект
    }
}
