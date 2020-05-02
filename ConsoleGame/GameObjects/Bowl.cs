using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Bowl : GameObject
    {
        public Bowl()
        {
            ID = idCounter++;
            Name = "Bowl";
            IsAlive = false;
            Description = "Old crumpled metal bowl.";
        }
    }
}
