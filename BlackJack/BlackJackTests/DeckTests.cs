using BlackJack;
using BlackJack.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;
using static BlackJack.Card;

namespace BlackJackTests
{
    [TestClass]
    public class DeckTests
    {
        private Mock<IDeck> _deck;
        private List<Card> deck;

        public DeckTests()
        {   
            _deck = new Mock<IDeck>();
            deck = new List<Card>() { new Card((CardRank)1, (CardSuit)0, 10), new Card((CardRank)2, (CardSuit)1, 4) };
        }

        [TestMethod]
        public void DeckShouldBeCreated()
        {
            //Arrange
            int actualResult;
            int aceValue = 1;
            int expectedResult = 2;
            _deck.Setup(d => d.CreateDeck(It.IsAny<int>())).Returns(deck);

            //Act and Assert
            actualResult = _deck.Object.CreateDeck(aceValue).Count;
            Assert.AreEqual(expectedResult, actualResult);     
        }

        [TestMethod]
        public void AceValueShouldBeReturned()
        {
            //Arrange
            int actualResult;
            int aceValue = 11;
            int expectedResult = 11;
            _deck.Setup(d => d.GetAceValue()).Returns(aceValue);

            //Act and Assert
            actualResult = _deck.Object.GetAceValue();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeckShouldBeShuffled()
        {
            //Arrange
            List<Card> actualResult;
            var expectedResult = new Card((CardRank)2, (CardSuit)1, 4);
            _deck.Setup(d => d.Shuffle()).Returns(deck.OrderBy(i => i.Value).ToList());

            //Act and Assert
            actualResult = _deck.Object.Shuffle();
            Assert.AreEqual(expectedResult.Value, actualResult.First().Value);
        }

        [TestMethod]
        public void CardShouldBeReturned()
        {
            //Arrange
            Card actualResult;
            var expectedResult = new Card((CardRank)2, (CardSuit)1, 4);
            _deck.Setup(d => d.GetCard()).Returns(deck.Last());

            //Act and Assert
            actualResult = _deck.Object.GetCard();
            Assert.AreEqual(expectedResult.Value, actualResult.Value);
        }

        [TestMethod]
        public void DeckShouldBeReturned()
        {
            //Arrange
            List<Card> actualResult;
            var expectedResult = 2;
            _deck.Setup(d => d.GetDeck()).Returns(deck);

            //Act and Assert
            actualResult = _deck.Object.GetDeck();
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}
