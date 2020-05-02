using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    abstract class GameObject
    {
        public int ID { get; protected set; }
        public string Name { get; protected set; }

        public string Description { get; set; }

        public bool IsAlive { get; set; }

        public float Weight { get; protected set; }

        protected static int idCounter = 0;
        public override string ToString() => Name;
    }
}
