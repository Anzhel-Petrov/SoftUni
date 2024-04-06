using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class InfluencerRepositoryTests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase("Alex", 2000)]
        [TestCase("Ivan", 2200)]
        public void CtorInfluencer_CreatesValidInstance(string userName, int followers)
        {
            Influencer influencer = new(userName, followers);
            Assert.That(influencer, Is.Not.Null);
            Assert.AreEqual(followers, influencer.Followers);
            Assert.AreEqual(userName, influencer.Username);
        }

        [Test]
        public void CtorInfluencerRepository_CreatesValidInstance()
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();
            Assert.That(influencerRepository, Is.Not.Null);
            Assert.That(influencerRepository.Influencers, Is.Not.Null);
            Assert.AreEqual(0, influencerRepository.Influencers.Count);
        }

        [TestCase("Alex", 2000)]
        [TestCase("Ivan", 2200)]
        public void RegisterInfluencer_RegistersInfluencer(string userName, int followers)
        {
            Influencer influencer = new(userName, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();

            string actualResult = influencerRepository.RegisterInfluencer(influencer);
            string expectedResult = $"Successfully added influencer {userName} with {followers}";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(1, influencerRepository.Influencers.Count);
        }

        [TestCase(null)]
        public void RegisterInfluencer_FailsWithNullUserName_Fails(Influencer influencer)
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();

            ArgumentNullException ae = Assert.Throws<ArgumentNullException>(
                () => influencerRepository.RegisterInfluencer(influencer));

            Assert.That(ae.Message, Is.EqualTo("Influencer is null (Parameter 'influencer')"));
        }

        [TestCase("Alex", 2000)]
        [TestCase("Ivan", 2200)]
        public void RegisterInfluencer_InfluencerExists_Fails(string userName, int followers)
        {
            Influencer influencer = new(userName, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            InvalidOperationException ae = Assert.Throws<InvalidOperationException>(
                () => influencerRepository.RegisterInfluencer(influencer));

            Assert.That(ae.Message, Is.EqualTo($"Influencer with username {userName} already exists"));
        }

        [TestCase("Alex", 2000)]
        [TestCase("Ivan", 2200)]
        public void RemoveInfluencer_RemovesSuccess(string userName, int followers)
        {
            Influencer influencer = new(userName, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            Assert.AreEqual(1, influencerRepository.Influencers.Count);
            Assert.That(influencerRepository.RemoveInfluencer(userName), Is.True);
            Assert.AreEqual(0, influencerRepository.Influencers.Count);
        }

        [TestCase(null)]
        public void RemoveInfluencer_ThrowsNullArgumentException(string userName)
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();

            ArgumentNullException ae = Assert.Throws<ArgumentNullException>(
                () => influencerRepository.RemoveInfluencer(userName));

            Assert.That(ae.Message, Is.EqualTo("Username cannot be null (Parameter 'username')"));
        }

        [TestCase("Alex")]
        public void RemoveInfluencer_DoesNotExist_Fails(string userName)
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();

            Assert.That(influencerRepository.RemoveInfluencer(userName), Is.False);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ReturnsCorrectResult()
        {
            Influencer influencerTop = new("Pavel", 1056);
            Influencer influencer = new("Alex", 765);
            Influencer influencer2 = new("Ivan", 234);
            Influencer influencer3 = new("Peter", 935);
            Influencer influencer4 = new("Stefan", 856);
            
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);
            influencerRepository.RegisterInfluencer(influencer2);
            influencerRepository.RegisterInfluencer(influencer3);
            influencerRepository.RegisterInfluencer(influencer4);
            influencerRepository.RegisterInfluencer(influencerTop);

            Assert.That(influencerRepository.GetInfluencerWithMostFollowers(), Is.EqualTo(influencerTop));
        }

        [TestCase("Alex", 2000)]
        public void GetInfluencer_ReturnsCorrect(string userName, int followers)
        {
            Influencer influencer = new(userName, followers);
            InfluencerRepository influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);

            Assert.That(influencerRepository.GetInfluencer(userName), Is.EqualTo(influencer));
        }

        [TestCase("Alex")]
        public void GetInfluencer_ReturnsNull(string userName)
        {
            InfluencerRepository influencerRepository = new InfluencerRepository();

            Assert.That(influencerRepository.GetInfluencer(userName), Is.Null);
        }
    }
}