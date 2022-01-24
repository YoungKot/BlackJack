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
    public class CardTests
    {
        private Mock<ICard> _card;

        public CardTests()
        {
            _card = new Mock<ICard>();
        }

        [TestMethod]
        public void CardValueShouldBeReturned()
        {
            //Arrange
            int actualResult;
            int expectedResult = 10;
            _card.Setup(c => c.GetCardValue(It.IsAny<CardRank>())).Returns(10);

            //Act and Assert
            actualResult = _card.Object.GetCardValue(CardRank.King);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
