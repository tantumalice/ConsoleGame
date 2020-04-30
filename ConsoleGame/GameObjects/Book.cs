using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.GameObjects
{
    class Book : GameObject
    {
        public Book()
        {
            Name = "Book";
            IsAlive = false;
            Description = "Book with old yellow pages";
        }
    }
}
