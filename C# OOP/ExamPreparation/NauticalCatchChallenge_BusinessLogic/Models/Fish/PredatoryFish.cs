namespace NauticalCatchChallenge.Models.Fish
{
    public class PredatoryFish : Fish
    {
        private const int TimeToCatchConst = 60;
        public PredatoryFish(string name, double points) : base(name, points, TimeToCatchConst)
        {
        }
    }
}
