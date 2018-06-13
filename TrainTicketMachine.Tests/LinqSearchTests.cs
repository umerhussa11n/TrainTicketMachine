using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainTicketMachine.Interfaces;

namespace TrainTicketMachine.Tests
{
    [TestClass]
    public class LinqSearchTests
    {
        public List<string> AllStations { get; set; }
        public bool ValidateString { get; set; }
        public LinqSearchTests()
        {
            Setup();
        }

        private void Setup()
        {
            AllStations = new List<string>() { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" };
            ValidateString = true;
        }
        [TestMethod]
        public void LinqSearch_ReturnStationAndValidCharacters_CallWithoutPerformingSearch_ThrowsInvalidOperationException()
        {
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("DART");

            var searchStation = new LinqSearch(stationListStub.Object, searchStringStub.Object);
            Assert.ThrowsException<InvalidOperationException>(() => searchStation.ReturnStationAndValidCharacters());

        }

        [TestMethod]
        public void LinqSearch_UserInputsDART_Dartford_And_Dartmouth_Is_Returned()
        {
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("DART");

            var linqSearch = new LinqSearch(stationListStub.Object, searchStringStub.Object);
            linqSearch.Search();
            var result = linqSearch.ReturnStationAndValidCharacters();

            var expectedStations = new List<string> { "DARTFORD", "DARTMOUTH" };
            CollectionAssert.AreEqual(result.Item1, expectedStations);
        }

        [TestMethod]
        public void LinqSearch_UserInputDART_DartfortAndDartmouthFound()
        {
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("DART");

            var searchStation = new TrainTicketMachine.LinqSearch(stationListStub.Object, searchStringStub.Object);
            searchStation.Search();
            var result = searchStation.ReturnStationAndValidCharacters();

            var expectedStations = new List<string> { "DARTFORD", "DARTMOUTH" };
            CollectionAssert.AreEqual(result.Item1, expectedStations);
        }

        [TestMethod]
        public void LinqSearch_UserInputDART_F_And_M_Are_Returned_As_Valid_Characters()
        {
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("DART");

            var searchStation = new TrainTicketMachine.LinqSearch(stationListStub.Object, searchStringStub.Object);
            searchStation.Search();
            var result = searchStation.ReturnStationAndValidCharacters();

            var expectedValidCharacters = "F,M";
            Assert.AreEqual(result.Item2, expectedValidCharacters);
        }

        [TestMethod]
        public void LinqSearch_UserInputLiverpool_Liverpool_And_Liverpool_Lime_Street_Found()
        {
            AllStations = new List<string>() { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("LIVERPOOL");

            var searchStation = new TrainTicketMachine.LinqSearch(stationListStub.Object, searchStringStub.Object);
            searchStation.Search();
            var result = searchStation.ReturnStationAndValidCharacters();

            var expectedStations = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET" };
            CollectionAssert.AreEqual(result.Item1, expectedStations);
        }

        [TestMethod]
        public void LinqSearch_UserInputLiverpool_Space_Is_Returned_As_Next_Valid_Character()
        {
            AllStations = new List<string>() { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("LIVERPOOL");

            var searchStation = new TrainTicketMachine.LinqSearch(stationListStub.Object, searchStringStub.Object);
            searchStation.Search();
            var result = searchStation.ReturnStationAndValidCharacters();

            Assert.AreEqual(result.Item2, " ");
        }

        [TestMethod]
        public void LinqSearch_UserInputsKINGSCROSS_NoStationIsReturned()
        {
            AllStations = new List<string>() { "EUSTON", "LONDON BRIDGE", "VICTORIA" };
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("KINGSCROSS");

            var searchStation = new TrainTicketMachine.LinqSearch(stationListStub.Object, searchStringStub.Object);
            searchStation.Search();
            var result = searchStation.ReturnStationAndValidCharacters();

            var expectedStations = new List<string> { };
            CollectionAssert.AreEqual(result.Item1, expectedStations);
        }

        [TestMethod]
        public void LinqSearch_UserInputsKINGSCROSS_NoNextValidCharacterIsReturned()
        {
            AllStations = new List<string>() { "EUSTON", "LONDON BRIDGE", "VICTORIA" };
            Mock<IStationReader> stationListStub = new Mock<IStationReader>();
            stationListStub.Setup(s => s.Read()).Returns(AllStations);
            stationListStub.Setup(s => s.AllStations).Returns(AllStations);

            Mock<ISearchString> searchStringStub = new Mock<ISearchString>();
            searchStringStub.Setup(x => x.Validate()).Returns(true);
            searchStringStub.SetupGet(x => x.IsValid).Returns(true);
            searchStringStub.SetupGet(x => x.Value).Returns("KINGSCROSS");

            var searchStation = new TrainTicketMachine.LinqSearch(stationListStub.Object, searchStringStub.Object);
            searchStation.Search();
            var result = searchStation.ReturnStationAndValidCharacters();

            var validCharacters = string.Empty;
            Assert.AreEqual(result.Item2, validCharacters);
        }
    }
}
