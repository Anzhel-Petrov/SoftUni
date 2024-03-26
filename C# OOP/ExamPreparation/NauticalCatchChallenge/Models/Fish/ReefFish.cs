namespace NauticalCatchChallenge.Models.Fish
{
    public class ReefFish : Fish
    {
        private const int TimeToCatchConst = 30;
        public ReefFish(string name, double points) : base(name, points, TimeToCatchConst)
        {
        }
    }
}
