using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Book : GameObject
    {
        public Book()
        {
            ID = idCounter++;
            Name = "Book";
            IsAlive = false;
            Description = "Book with old yellow pages";
        }
    }
}
