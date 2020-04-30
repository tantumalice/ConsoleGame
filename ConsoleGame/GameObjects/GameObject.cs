using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    abstract class GameObject
    {
        public string Name { get; protected set; }

        public string Description { get; set; }

        public bool IsAlive { get; set; }

        public override string ToString() => Name;
    }
}
