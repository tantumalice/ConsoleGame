﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGame.GameObjects;

namespace ConsoleGame
{
    class Room
    {
        public List<GameObject> Items { get; protected set; }

        private const int initialItemsCapacity = 4;

        public string LookAround()
        {
            if (Items.Count > 0)
            {
                var sb = new StringBuilder();
                sb.AppendLine("In this room you see: ");
                foreach (var obj in Items)
                {
                    sb.AppendLine(obj.ToString());
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "The room is empty.";
            }
        }

        public void RemoveItem(GameObject item) => Items.Remove(item);

        public void AddItem(GameObject item) => Items.Add(item);

        public Room()
        {
            var count = RandomFiller.GetRandomInt(1, initialItemsCapacity);
            Items = new List<GameObject>(count);
            for (int i = 0; i < count; ++i)
            {
                Items.Add(RandomFiller.GetGameObject());
            }
        }
    }
}
