using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame
{
    abstract class GameObject
    {
        public string Name { get; private set; }

        public string Description { get; set; }

        public bool IsAlive { get; set; }

        public override string ToString() => Name;
    }
}
