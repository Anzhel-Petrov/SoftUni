namespace NauticalCatchChallenge.Models.Fish
{
    public class DeepSeaFish : Fish
    {
        private const int TimeToCatchConst = 180;
        public DeepSeaFish(string name, double points) : base(name, points, TimeToCatchConst)
        {
        }
    }
}
