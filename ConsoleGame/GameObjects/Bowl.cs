using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Bowl : GameObject
    {
        public Bowl()
        {
            Name = "Bowl";
            IsAlive = false;
            Description = "Old crumpled metal bowl.";
        }
    }
}
