using NUnit.Framework;
using System.Xml.Linq;
using NUnit.Framework.Constraints;

namespace VendingRetail.Tests
{
    public class VendingRetails
    {
        private int waterCapcity = 100;
        private int buttonsCount = 3;
        private CoffeeMat coffeeMat;

        [SetUp]
        public void Setup()
        {
            coffeeMat = new CoffeeMat(waterCapcity, buttonsCount);
        }

        [Test]
        public void Ctor_CreatesInstance_Correct()
        {
            Assert.That(coffeeMat, Is.Not.Null);
            Assert.AreEqual(coffeeMat.WaterCapacity, waterCapcity);
            Assert.AreEqual(coffeeMat.ButtonsCount, buttonsCount);
            Assert.AreEqual(coffeeMat.Income, 0);
        }

        [Test]
        public void FillWaterTank_FillsCorrectly()
        {
            string actualResult = coffeeMat.FillWaterTank();
            string expectedResult = $"Water tank is filled with {waterCapcity}ml";
            ;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FillWaterTank_TankFull()
        {
            coffeeMat.FillWaterTank();

            string actualResult = coffeeMat.FillWaterTank();
            string expectedResult = "Water tank is already full!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddDrink_AddsDrinkWorks()
        {
            Assert.That(coffeeMat.AddDrink("Espresso", 1.25), Is.True);
            Assert.That(coffeeMat.AddDrink("Americano", 1.75), Is.True);
            Assert.That(coffeeMat.AddDrink("Latte", 2.25), Is.True);
        }

        [Test]
        public void AddDrink_NoCapacity()
        {
            Assert.That(coffeeMat.AddDrink("Espresso", 1.25), Is.True);
            Assert.That(coffeeMat.AddDrink("Americano", 1.75), Is.True);
            Assert.That(coffeeMat.AddDrink("Latte", 2.25), Is.True);
            Assert.That(coffeeMat.AddDrink("Hot Chocolate", 0.85), Is.False);
            Assert.That(coffeeMat.AddDrink("Milk", 1), Is.False);
        }

        [TestCase("Espresso", 1.25)]
        [TestCase("Milk", 1.00)]
        public void BuyDrink_CanBuyDrink(string drinkName, double price)
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 5);
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink(drinkName, price);
            Assert.AreEqual($"Your bill is {price:f2}$", coffeeMat.BuyDrink(drinkName));
        }

        [Test]
        public void BuyDrink_NotEnoughWaterInTank()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 5);
            coffeeMat.AddDrink("Espresso", 1.25);
            Assert.AreEqual("CoffeeMat is out of water!", coffeeMat.BuyDrink("Espresso"));
        }

        [TestCase("Espresso")]
        [TestCase("Milk")]
        public void BuyDrink_NoSuchDrink(string drinkName)
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 5);
            coffeeMat.FillWaterTank();
            Assert.AreEqual($"{drinkName} is not available!", coffeeMat.BuyDrink(drinkName));
        }

        [Test]
        public void Income_ResetsIncome()
        {
            CoffeeMat coffeeMat = new CoffeeMat(2000, 5);
            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Espresso", 2.50);

            coffeeMat.BuyDrink("Espresso");


            double expectedIncome = 2.50;
            double actualIncome = coffeeMat.Income;

            Assert.AreEqual(expectedIncome, actualIncome);

            coffeeMat.CollectIncome();

            Assert.AreEqual(coffeeMat.Income, 0);
        }

        [Test]
        public void CheckWaterConsuming()
        {
            CoffeeMat coffeeMat = new CoffeeMat(170, 6);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.AddDrink("Capuccino", 1.50);
            coffeeMat.AddDrink("Latte", 1.00);
            coffeeMat.AddDrink("Hot Chocolate", 1.60);
            coffeeMat.AddDrink("Milk", 0.90);
            coffeeMat.AddDrink("Tea", 0.60);
            coffeeMat.AddDrink("Hot Water", 0.30);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Coffee");
            string actualResult = coffeeMat.BuyDrink("Hot Chocolate");

            string expectedResult = "CoffeeMat is out of water!";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}