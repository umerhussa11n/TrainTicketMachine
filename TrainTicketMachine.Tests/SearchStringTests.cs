using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainTicketMachine.Interfaces;

namespace TrainTicketMachine.Tests
{
    [TestClass]
    public class SearchStringTests
    {
        Mock<ISearchString> mockSearchString;
        public SearchStringTests()
        {
            SetUp();
        }

        public void SetUp()
        {
            mockSearchString = new Mock<ISearchString>();
        }

        [TestMethod]
        public void SearchString_Validate_AssignNumbers_NotValidInput()
        {
            mockSearchString.Setup(x => x.Value).Returns("12345678");
            var searchString = new SearchString("12345678");

            searchString.Validate();

            Assert.IsFalse(searchString.IsValid);
        }

        [TestMethod]
        public void SearchString_Validate_AssignNumbersAndLetters_NotValidInput()
        {
            mockSearchString.Setup(x => x.Value).Returns("asdasdad12345678");
            var searchString = new SearchString("asdasd12345678");
            searchString.Validate();

            Assert.IsFalse(searchString.IsValid);
        }

        [TestMethod]
        public void SearchString_Validate_AssignLetters_ValidInput()
        {
            mockSearchString.Setup(x => x.Value).Returns("asdasdad");
            var searchString = new SearchString("asdasdad");
            searchString.Validate();

            Assert.IsTrue(searchString.IsValid);
        }

        [TestMethod]
        public void SearchString_Validate_AssignNull_Returns_InputIsNotValid()
        {
            mockSearchString.Setup(x => x.Value).Returns(string.Empty);
            var searchString = new SearchString(null);
            searchString.Validate();

            Assert.AreEqual(searchString.Error, searchString.Error);
        }
    }
}
