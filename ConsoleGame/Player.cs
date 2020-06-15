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

        private const float maxInventoryWeight = 5.0f;

        private static (int x, int y) coordinates;

        public static void SetGameField()
        {
            var rangeX = GameField.Field.GetLength(0);
            var rangeY = GameField.Field.GetLength(1);
            var x = RandomFiller.GetRandomInt(0, rangeX);
            var y = RandomFiller.GetRandomInt(0, rangeY);
            if (GameField.Field[x, y] != null)
            {
                coordinates = (x, y);
            }
            else
            {
                SetGameField();
            }
        }
        public static string Go(string direction)
        {
            bool success = false;
            switch (direction)
            {
                case "west":
                    int westX = coordinates.x - 1;
                    if (westX > 0 && GameField.Field[westX, coordinates.y] != null)
                    {
                        coordinates.x = westX;
                        success = true;

                    }
                    break;
                case "east":
                    int eastX = coordinates.x + 1;
                    if (eastX < GameField.Field.GetLength(0) && GameField.Field[eastX, coordinates.y] != null)
                    {
                        coordinates.x = eastX;
                        success = true;
                    }
                    break;
                case "north":
                    int northY = coordinates.y + 1;
                    if (northY < GameField.Field.GetLength(1) && GameField.Field[coordinates.x, northY] != null)
                    {
                        coordinates.y = northY;
                        success = true;
                    }
                    break;
                case "south":
                    int southY = coordinates.y - 1;
                    if (southY > 0 && GameField.Field[coordinates.x, southY] != null)
                    {
                        coordinates.y = southY;
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

        public static string ShowMap()
        {
            var sb = new StringBuilder();
            for (int j = GameField.Field.GetLength(1) - 1; j >= 0; --j) // Remember coordinates system!
            {
                for (int i = 0; i < GameField.Field.GetLength(0); ++i)
                {
                    if (i == coordinates.x && j == coordinates.y)
                    {
                        sb.Append("@ ");
                    }
                    else
                    {
                        sb.Append((GameField.Field[i, j] == null) ? "x " : "o ");
                    }
                }
                sb.Append("\n");
            }
            sb.Append("x - empty space, o - room, @ - you are here");
            return sb.ToString();
        }
        public static string ShowInventory()
        {
            if (inventory.Count == 0)
            {
                return "Your inventory is empty.";
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendLine("Your inventory: ");
                foreach (var obj in inventory)
                {
                    sb.AppendLine(obj.ToString());
                }
                return sb.ToString().TrimEnd();
            }
        }

        public static string PutInInventory(string name)
        {
            var buff = GameField.Field[coordinates.x, coordinates.y].Items.FindAll(obj => obj.Name.ToLower() == name.ToLower());
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
            var obj = GameField.Field[coordinates.x, coordinates.y].Items.Find(obj => obj.ID == id);
            return obj != null ? AddInInventory(obj) : Reader.ReReadID("take", "Type ID below.");
        }

        public static string ThrowOutOfInventory(string name)
        {
            var buff = inventory.FindAll(obj => obj.Name.ToLower() == name.ToLower());
            switch (buff.Count)
            {
                case 0:
                    return $"There is no {name} in your inventory!";
                case 1:
                    return RemoveFromInventory(buff[0]);
                default:
                    var sb = new StringBuilder();
                    sb.AppendLine($"There is more than one {name} in your inventory! Which one would you like to throw away? Type it's ID below.");
                    sb.Append("IDs: ");
                    foreach (var obj in buff)
                    {
                        sb.Append($"{obj.ID}  ");
                    }
                    return Reader.ReadID("throw", sb.ToString());
            };
        }

        public static string ThrowOutOfInventory(int id)
        {
            var obj = inventory.Find(obj => obj.ID == id);
            return obj != null ? RemoveFromInventory(obj) : Reader.ReReadID("throw", "Type ID below.");
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
                return $"You took the {obj}.";
            }
        }

        private static string RemoveFromInventory(GameObject obj)
        {
            inventory.Remove(obj);
            GameField.Field[coordinates.x, coordinates.y].AddItem(obj);
            currentInventoryWeight -= obj.Weight;
            return $"You threw the {obj}.";
        }
    }
}
