using BlackJack;
using BlackJack.Interfaces;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace BlackJackTests
{
    [TestClass]
    public class DeckTests
    {
        private readonly Mock<IDeck> _deck;
        private readonly IList<Card> deck;

        public DeckTests()
        {   
            _deck = new Mock<IDeck>();
            deck = A.CollectionOfFake<Card>(10);
        }

        [TestMethod]
        public void DeckShouldBeCreated()
        {
            //Arrange
            int actualResult;
            int aceValue = 1;
            int expectedResult = 10;
            _deck.Setup(deck => deck.CreateDeck(It.IsAny<int>())).Returns(deck.ToList());

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
            _deck.Setup(deck => deck.GetAceValue()).Returns(aceValue);

            //Act and Assert
            actualResult = _deck.Object.GetAceValue();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeckShouldBeShuffled()
        {
            //Arrange
            List<Card> actualResult;
            var expectedResult = A.Fake<ICard>();
            _deck.Setup(deck => deck.Shuffle()).Returns(deck.OrderBy(i => i.Value).ToList());

            //Act and Assert
            actualResult = _deck.Object.Shuffle();
            Assert.AreEqual(expectedResult.Value, actualResult.Last().Value);
        }

        [TestMethod]
        public void CardShouldBeReturned()
        {
            //Arrange
            Card actualResult;
            var expectedResult = A.Fake<ICard>();
            _deck.Setup(deck => deck.GetCard()).Returns(deck.Last());

            //Act and Assert
            actualResult = _deck.Object.GetCard();
            Assert.AreEqual(expectedResult.Value, actualResult.Value);
        }

        [TestMethod]
        public void DeckShouldBeReturned()
        {
            //Arrange
            List<Card> actualResult;
            var expectedResult = 10;
            _deck.Setup(deck => deck.GetDeck()).Returns(deck.ToList());

            //Act and Assert
            actualResult = _deck.Object.GetDeck();
            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}
