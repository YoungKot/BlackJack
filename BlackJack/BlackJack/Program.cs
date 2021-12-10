using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    class Program
    {
        private static protected Game game = new Game();
        static void Main(string[] args)
        {
            game.PlayGame();
        }
    }
}
