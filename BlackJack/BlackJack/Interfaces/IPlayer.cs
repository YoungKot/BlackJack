using System.Collections.Generic;

namespace BlackJack.Interfaces
{
    public interface IPlayer
    {
        List<Card> Cards { get; set; }
        int Score { get; set; }
        Card Card { get; set; }
        void DrawCard(IDeck deck);
        int GetScore();
        List<Card> GetCards();
        void SubtractScore();
    }
}
