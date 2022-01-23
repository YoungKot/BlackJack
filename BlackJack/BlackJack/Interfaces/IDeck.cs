using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Interfaces
{
    public interface IDeck
    {
        int GetAceValue();
        List<Card> CreateDeck(int AceValue);
        List<Card> Shuffle();
        Card GetCard();
        List<Card> GetDeck();
    }
}
