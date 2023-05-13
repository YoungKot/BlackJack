using BlackJack;
using BlackJack.Interfaces;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackTests
{
    [TestClass]
    public class PlayerTests
    {
        private readonly Mock<IPlayer> _player;
        private readonly Mock<IDeck> _deck;
        private readonly IList<Card> cards;

        public PlayerTests()
        {
            _player = new Mock<IPlayer>();
            _deck = new Mock<IDeck>();
            cards = A.CollectionOfFake<Card>(10);
        }

        [TestMethod]
        public void VerfyDrawCardMethodIsExecuted()
        {
            //Arrange
            _player.Object.DrawCard(_deck.Object);
            _player.Verify(player => player.DrawCard(It.IsAny<IDeck>()), Moq.Times.Once);
        }

        [TestMethod]
        public void VerifySubtractScoreMethodIsExecuted()
        {
            //Arrange
            _player.Object.GetScore();
            _player.Verify(player => player.GetScore(), Moq.Times.Once);
        }

        [TestMethod]
        public void ScoreShouldBeReturned()
        {
            //Arrange
            int actualResult;
            int expectedResult = 10;
            _player.Setup(player => player.GetScore()).Returns(10);

            //Act and Assert
            actualResult = _player.Object.GetScore();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CardListShouldBeReturned()
        {
            //Arrange
            int actualResult;
            int expectedResult = 10;
            _player.Setup(player => player.GetCards()).Returns(cards.ToList());

            //Act and Assert
            actualResult = _player.Object.GetCards().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
