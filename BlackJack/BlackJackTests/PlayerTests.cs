using BlackJack;
using BlackJack.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using static BlackJack.Card;

namespace BlackJackTests
{
    [TestClass]
    public class PlayerTests
    {
        private Mock<IPlayer> _player;
        private Mock<IDeck> _deck;
        private List<Card> cards;

        public PlayerTests()
        {
            _player = new Mock<IPlayer>();
            _deck = new Mock<IDeck>();
            cards = new List<Card>() { new Card((CardRank)1, (CardSuit)0, 10), new Card((CardRank)2, (CardSuit)1, 4) };
        }

        [TestMethod]
        public void VerfyDrawCardMethodIsExecuted()
        {
            //Arrange
            _player.Object.DrawCard(_deck.Object);
            _player.Verify(p => p.DrawCard(It.IsAny<IDeck>()), Times.Once);
        }

        [TestMethod]
        public void VerifySubtractScoreMethodIsExecuted()
        {
            //Arrange
            _player.Object.GetScore();
            _player.Verify(p => p.GetScore(), Times.Once);
        }

        [TestMethod]
        public void ScoreShouldBeReturned()
        {
            //Arrange
            int actualResult;
            int expectedResult = 10;
            _player.Setup(p => p.GetScore()).Returns(10);

            //Act and Assert
            actualResult = _player.Object.GetScore();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CardListShouldBeReturned()
        {
            //Arrange
            int actualResult;
            int expectedResult = 2;
            _player.Setup(p => p.GetCards()).Returns(cards);

            //Act and Assert
            actualResult = _player.Object.GetCards().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
