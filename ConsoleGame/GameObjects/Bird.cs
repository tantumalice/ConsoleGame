using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Bird : GameObject
    {
        public Bird()
        {
            IsAlive = true;
            Name = "Bird";
            Description = "Little bird. Maybe sparrow or titmouse.";
        }
    }
}
