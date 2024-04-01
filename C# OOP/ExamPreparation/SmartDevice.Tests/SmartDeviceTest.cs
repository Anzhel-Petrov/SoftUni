namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class SmartDeviceTest
    {
        private int memoryCapacity = 128;
        private Device device;
        [SetUp]
        public void Setup()
        {
            device = new Device(memoryCapacity);
        }

        [Test]
        public void Ctor_CreateInstance_WorksCorrectly()
        {
            Assert.That(device, Is.Not.Null);
            Assert.That(device.Applications, Is.Not.Null);
            Assert.AreEqual(device.MemoryCapacity, memoryCapacity);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
            Assert.AreEqual(device.Photos, 0);
            Assert.AreEqual(device.Applications.Count, 0);
        }

        [Test]
        public void TakePhoto_ReturnsTrue()
        {
            Assert.That(device.TakePhoto(10), Is.True);
            Assert.AreEqual(device.AvailableMemory, 118);
            Assert.AreEqual(device.Photos, 1);
        }

        [Test]
        public void TakePhoto_ReturnsFalse()
        {
            Assert.That(device.TakePhoto(150), Is.False);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
            Assert.AreEqual(device.Photos, 0);
        }

        [Test]
        public void InstallApp_WorksCorrectly()
        {
            Assert.That(device.InstallApp("Test", 10), Is.EqualTo("Test is installed successfully. Run application?"));
            Assert.AreEqual(device.AvailableMemory, 118);
            Assert.AreEqual(device.Applications.Count, 1);
            Assert.That(device.Applications.Contains("Test"));
            //Assert.IsTrue(device.Applications.Contains("Test"));
        }

        [Test]
        public void InstallApp_ThrowsException()
        {
            InvalidOperationException ae = Assert.Throws<InvalidOperationException>(
                () => device.InstallApp("Test", 150));

            Assert.That(ae.Message, Is.EqualTo("Not enough available memory to install the app."));

            //Assert.Throws<InvalidOperationException>(() => device.InstallApp("Test", 150));

        }

        [Test]
        public void FormatDevice_WorksCorrectly()
        {
            device.InstallApp("Test", 10);
            device.TakePhoto(10);
            device.FormatDevice();

            Assert.AreEqual(device.MemoryCapacity, memoryCapacity);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
            Assert.AreEqual(device.Photos, 0);
            Assert.AreEqual(device.Applications.Count, 0);
        }

        [Test]
        public void GetDeviceStatus_ShoulsReturnCorrectFormat()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyFirstApp", 500);
            device.InstallApp("MySecondApp", 300);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - photoSize - 500 - 300} MB");
            stringBuilder.AppendLine($"Photos Count: 1");
            stringBuilder.AppendLine($"Applications Installed: MyFirstApp, MySecondApp");

            string result = stringBuilder.ToString().TrimEnd();
            string status = device.GetDeviceStatus();

            Assert.AreEqual(result, status);
        }
    }
}