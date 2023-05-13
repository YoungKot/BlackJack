using BlackJack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static BlackJack.Card;

namespace BlackJack
{
    public class Deck : IDeck
    {
        private readonly List<Card> deck;
        private const int deckSize = 52;
        private readonly ICard _card;
        private Card newCard;
        private List<Card> shuffleddeck;
        private readonly Random random = new Random();
        private readonly List<int> aceValues = new List<int> { 1, 11 };

        public Deck(ICard card)
        {
            _card = card;
            deck = new List<Card>(deckSize);
            CreateDeck(GetAceValue());
            Shuffle();
        }

        public int GetAceValue()
        {
            var AceValue = aceValues.OrderBy(a => random.Next()).ToList().First();
            return AceValue;
        }

        public List<Card> CreateDeck(int AceValue)
        {
            for(int i = 0; i < Enum.GetNames(typeof(CardRank)).Length; i++)
            {
                for(int j = 0; j < Enum.GetNames(typeof(CardSuit)).Length; j++)
                {
                    if (i == 12 && AceValue == 1)
                    {
                        newCard = new Card((CardRank)i, (CardSuit)j, AceValue);
                    }

                    else if (i == 12 && AceValue == 11)
                    {
                        newCard = new Card((CardRank)i, (CardSuit)j, AceValue);
                    }

                    else
                    {
                        newCard = new Card((CardRank)i, (CardSuit)j, _card.GetCardValue((CardRank)i));
                    }
                    deck.Add(newCard);
                }
            }
            return deck;
        }

        public List<Card> Shuffle()
        {
            shuffleddeck = deck.OrderBy(a => random.Next()).ToList();
            return shuffleddeck;
        }

        public Card GetCard()
        {
            int index = random.Next(0, shuffleddeck.Count - 1);
            var card = shuffleddeck[index];
            shuffleddeck.RemoveAt(index);
            return card;
        }

        public List<Card> GetDeck()
        {
            return shuffleddeck;
        }
    }
}
