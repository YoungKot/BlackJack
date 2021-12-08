using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Player
    {
        private List<Card> playerCards = new List<Card>();
        public List<Card> PlayerCards
        {
            get { return playerCards; }
            set { playerCards = value; }
        }

        public int PlayerScore { get; set; } = 0;
        public Card PlayerCard { get; set; }
        public void DrawCard(Deck deck)
        {
            PlayerCard = deck.getCard();
            PlayerCards.Add(PlayerCard);
            PlayerScore += PlayerCard.Value;
        }

        public int getPlayerScore()
        {
            return PlayerScore;
        }

        public List<Card> getPlayerCards()
        {
            return PlayerCards;
        }

        public void SubtractScore()
        {
            if(PlayerScore > 21)
            {
                PlayerScore -= 10;
            }
        }
    }
}
