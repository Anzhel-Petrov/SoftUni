namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class TelevisionTests
    {
        private TelevisionDevice? _televisionDevice;
        private const string Brand = "Grundig";
        private const double Price = 1999.99;
        private const int ScreenWidth = 115; 
        private const int ScreenHeight = 70;
        private const string SwitchOnMessage = "Cahnnel {0} - Volume {1} - Sound {2}";
        private const string InvalidKey = "Invalid key!";

        [SetUp]
        public void Setup()
        {
            _televisionDevice = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeight);
        }

        [Test]
        public void CtorWIthValidArguments_WorksCorrectly()
        {
            Assert.That(_televisionDevice, Is.Not.Null);
            Assert.That(_televisionDevice.Brand, Is.EqualTo(Brand));
            Assert.That(_televisionDevice.Price, Is.EqualTo(Price));
            Assert.That(_televisionDevice.ScreenWidth, Is.EqualTo(ScreenWidth));
            Assert.That(_televisionDevice.ScreenHeigth, Is.EqualTo(ScreenHeight));

            Assert.That(_televisionDevice.CurrentChannel, Is.EqualTo(0));
            Assert.That(_televisionDevice.Volume, Is.EqualTo(13));
            Assert.That(_televisionDevice.IsMuted, Is.EqualTo(false));
        }

        [Test]
        public void MuteDevice_WorksCorrectly()
        {
            bool result;

            result = _televisionDevice.MuteDevice();
            Assert.That(_televisionDevice.IsMuted, Is.EqualTo(true));
            Assert.That(result, Is.EqualTo(true));

            result = _televisionDevice.MuteDevice();
            Assert.That(_televisionDevice.IsMuted, Is.EqualTo(false));
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void SwitchOn_WorksCorrectly()
        {
            Assert.AreEqual(string.Format(SwitchOnMessage, _televisionDevice.CurrentChannel, _televisionDevice.Volume, "On"), _televisionDevice.SwitchOn());
            _televisionDevice.MuteDevice();
            Assert.AreEqual(string.Format(SwitchOnMessage, _televisionDevice.CurrentChannel, _televisionDevice.Volume, "Off"), _televisionDevice.SwitchOn());
        }

        [Test]
        public void ChangeChannel_WorksCorrectly()
        {
            _televisionDevice.ChangeChannel(5);
            Assert.AreEqual(5, _televisionDevice.CurrentChannel);

            ArgumentException ae = Assert.Throws<ArgumentException>(
                () => _televisionDevice.ChangeChannel(-10));

            Assert.That(ae.Message, Is.EqualTo(InvalidKey));
        }

        [TestCase("UP", 10, 23)]
        [TestCase("DOWN", 10, 3)]
        public void VolumeChange_WorksCorrectly(string direction, int units, int currentVolume)
        {
            Assert.AreEqual($"Volume: {currentVolume}", _televisionDevice.VolumeChange(direction, units));
        }

        [TestCase("UP", 100, 100)]
        [TestCase("DOWN", 100, 0)]
        public void VolumeChange_ResetsVolumeCorrectly(string direction, int units, int currentVolume)
        {
            Assert.AreEqual($"Volume: {currentVolume}", _televisionDevice.VolumeChange(direction, units));
        }

        [TestCase("InvalidDirection", 100)]
        public void VolumeChange_InvalidDirection_ShouldNotChangeVolume(string direction, int units)
        {
            Assert.AreEqual($"Volume: {_televisionDevice.Volume}", _televisionDevice.VolumeChange(direction, units));
        }

        [Test]
        public void ToString_OutputsCorrectly()
        {
            Assert.AreEqual($"TV Device: {_televisionDevice.Brand}, Screen Resolution: {_televisionDevice.ScreenWidth}x{_televisionDevice.ScreenHeigth}, Price {_televisionDevice.Price}$",
                _televisionDevice.ToString());
        }
    }
}