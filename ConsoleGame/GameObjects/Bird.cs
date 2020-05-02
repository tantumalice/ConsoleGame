﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Bird : GameObject
    {
        public Bird()
        {
            ID = idCounter++;
            IsAlive = true;
            Name = "Bird";
            Description = "Little bird. Maybe sparrow or titmouse.";
            Weight = 0.05f;
        }
    }
}
