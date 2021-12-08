using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Dealer
    {
        private List<Card> dealerCards = new List<Card>();
        public List<Card> DealerCards
        {
            get { return dealerCards; }
            set { dealerCards = value; }
        }

        public int DealerScore { get; set; } = 0;
        public Card DealerCard { get; set; }
        public void DrawCard(Deck deck)
        {
            DealerCard = deck.getCard();
            DealerCards.Add(DealerCard);
            DealerScore += DealerCard.Value;
        }

        public int getDealerScore()
        {
            return DealerScore;
        }

        public List<Card> getDealerCards()
        {
            return DealerCards;
        }

        public void SubtractScore()
        {
            if (DealerScore > 21)
            {
                DealerScore -= 10;
            }
        }
    }
}
