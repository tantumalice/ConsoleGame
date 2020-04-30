using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Stone : GameObject
    {
        public Stone()
        {
            Name = "Stone";
            Description = "Small gray stone. Ordinary crushed stone.";
            IsAlive = false;
        }
    }
}
