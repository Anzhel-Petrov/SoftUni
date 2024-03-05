namespace _04.WildFarm
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }
        void ProduceSound();
        void Feed(IFood food);
    }
}
