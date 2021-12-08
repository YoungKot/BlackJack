using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BlackJack.Card;

namespace BlackJack
{
    public class Deck
    {
        public List<Card> deck;
        public int deckSize;
        public Card card = new Card();
        Random rng = new Random();
        Card newCard;
        public List<Card> shuffleddeck;
        public Deck()
        {
            deckSize = 52;
            deck = new List<Card>(deckSize);
        }

        public List<Card> createDeck(int AceValue)
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
                        newCard = new Card((CardRank)i, (CardSuit)j, card.getCardValue((CardRank)i));
                    }
                    deck.Add(newCard);
                }
            }
            return deck;
        }

        public List<Card> Shuffle()
        {
            shuffleddeck = deck.OrderBy(a => rng.Next()).ToList();
            return shuffleddeck;
        }

        public Card getCard()
        {
            int index = rng.Next(0, shuffleddeck.Count - 1);
            var card = shuffleddeck[index];
            shuffleddeck.RemoveAt(index);
            return card;
        }
    }
}
