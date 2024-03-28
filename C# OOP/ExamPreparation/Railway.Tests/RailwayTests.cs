namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class RailwayTests
    {
        private const string Name = "Central Station";
        private const string InvalidNameMessage = "Name cannot be null or empty!";
        private const string Train = "Sofia-Varna";
        private const string Train2 = "Varna-Sofia";
        private const string InvalidArrivalTrainMessage = $"There are other trains to arrive before {Train2}.";
        private const string ValidArrivalTrainMessage = $"{Train} is on the platform and will leave in 5 minutes.";

        private RailwayStation railwayStation;
        [SetUp]
        public void Setup()
        {
            railwayStation = new RailwayStation(Name);
        }

        [Test]
        public void Ctor_WithValidParameters_CreateNewIn()
        {
            RailwayStation railwayStation = new RailwayStation(Name);
            Assert.That(railwayStation, Is.Not.Null);
            Assert.That(railwayStation.Name, Is.EqualTo(Name));
            Assert.That(railwayStation.ArrivalTrains, Is.Not.Null);
            Assert.That(railwayStation.ArrivalTrains.Count , Is.EqualTo(0));
            Assert.That(railwayStation.DepartureTrains, Is.Not.Null);
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));
        }

        [TestCase(null)]
        [TestCase("   ")]
        public void Ctor_WithInvalidName_ThrowsException(string invalidName)
        {
            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => new RailwayStation(invalidName));

            Assert.That(ae.Message, Is.EqualTo(InvalidNameMessage));
        }

        [Test]
        public void NewArrivalOnBoard_ShouldWork()
        {
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            railwayStation.NewArrivalOnBoard(Train);
            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(Train, railwayStation.ArrivalTrains.Peek());
        }

        [Test]
        public void TrainHasArrived_WorksCorrectly()
        {
            railwayStation.NewArrivalOnBoard(Train);

            Assert.AreEqual(InvalidArrivalTrainMessage, railwayStation.TrainHasArrived(Train2));

            Assert.AreEqual(1, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);

            Assert.AreEqual(ValidArrivalTrainMessage, railwayStation.TrainHasArrived(Train));

            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void TrainHasLeft_WorksCorrectly()
        {
            railwayStation.NewArrivalOnBoard(Train);
            railwayStation.TrainHasArrived(Train);


            Assert.AreEqual(false, railwayStation.TrainHasLeft(Train2));

            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);

            Assert.AreEqual(true, railwayStation.TrainHasLeft(Train));

            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);

        }
    }
}