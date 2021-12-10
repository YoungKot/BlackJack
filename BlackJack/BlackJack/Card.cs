using BlackJack.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Card : ICard
    {
        public CardRank Face { get; set; }

        public CardSuit Suit { get; set; }

        public int Value { get; set; }

        public Card(CardRank face, CardSuit suit, int value)
        {
            this.Face = face;
            this.Suit = suit;
            this.Value = value;
        }

        public Card()
        {
        }

        public enum CardRank
        {
            Two, 
            Three, 
            Four, 
            Five, 
            Six, 
            Seven, 
            Eight, 
            Nine,
            Ten,
            Jack, 
            Queen, 
            King, 
            Ace
        }

        public enum CardSuit
        {
            Spades, 
            Diamonds, 
            Hearts, 
            Clubs
        }

        public int GetCardValue(CardRank key)
        {
            var values = new Dictionary<CardRank, int>(){
                {CardRank.Two, 2},
                {CardRank.Three, 3},
                {CardRank.Four, 4},
                {CardRank.Five, 5},
                {CardRank.Six, 6},
                {CardRank.Seven, 7},
                {CardRank.Eight, 8},
                {CardRank.Nine, 9},
                {CardRank.Ten, 10},
                {CardRank.Jack, 10},
                {CardRank.Queen, 10},
                {CardRank.King, 10},
                {CardRank.Ace, 1}
            };

            return values[key];

        }
    }
}
