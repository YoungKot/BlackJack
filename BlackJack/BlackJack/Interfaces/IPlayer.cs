using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Interfaces
{
    public interface IPlayer
    {
        public List<Card> Cards { get; set; }
        int Score { get; set; }
        Card Card { get; set; }
        void DrawCard(Deck deck);
        int GetScore();
        List<Card> GetCards();
        void SubtractScore();
    }
}
