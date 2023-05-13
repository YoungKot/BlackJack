using static BlackJack.Card;

namespace BlackJack.Interfaces
{
    public interface ICard
    {
        CardRank Face { get; set; }

        CardSuit Suit { get; set; }

        int Value { get; set; }

        int GetCardValue(CardRank key);
    }
}
