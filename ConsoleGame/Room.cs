using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.GameObjects;

namespace ConsoleGame
{
    class Room
    {
        public List<GameObject> Items { get; protected set; }

        private readonly int initialItemsCapacity = 4;

        public string LookAround()
        {
            var sb = new StringBuilder();
            sb.AppendLine("In this room you see: ");
            foreach (var obj in Items)
            {
                sb.AppendLine(obj.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public void RemoveItem(GameObject item) => Items.Remove(item);

        public Room()
        {
            var rnd = new Random();
            var count = rnd.Next(1, initialItemsCapacity);
            Items = new List<GameObject>(count);
            for (int i = 0; i < count; ++i)
            {
                Items.Add(RandomFiller.GetGameObject());
            }
        }

        //TODO: Add item
    }
}
