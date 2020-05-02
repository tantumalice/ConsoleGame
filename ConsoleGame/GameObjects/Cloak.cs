using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Cloak : GameObject
    {
        public Properties.FabricColor Color { get; protected set; }
        public Cloak()
        {
            ID = idCounter++;
            Name = "Cloak";
            IsAlive = false;
            Color = RandomFiller.GetEnumValue<Properties.FabricColor>();
            Description = Color.ToString() + "old cloak.";
            Weight = 1.2f;
        }
    }
}
