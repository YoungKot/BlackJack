using BlackJack.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Player : IPlayer
    {
        private List<Card> cards = new List<Card>();
        public List<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }
        public int Score { get; set; } = 0;
        public Card Card { get; set; }
        public void DrawCard(Deck deck)
        {
            Card = deck.GetCard();
            Cards.Add(Card);
            Score += Card.Value;
        }

        public int GetScore()
        {
            return Score;
        }

        public List<Card> GetCards()
        {
            return Cards;
        }

        public void SubtractScore()
        {
            if(Score > 21)
            {
                Score -= 10;
            }
        }
    }
}
