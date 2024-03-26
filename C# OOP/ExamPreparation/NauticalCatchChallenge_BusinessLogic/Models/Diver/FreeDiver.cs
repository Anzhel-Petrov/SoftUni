using System;

namespace NauticalCatchChallenge.Models.Diver
{
    public class FreeDiver : Diver
    {
        private const int OxygenLevelConst = 120;
        private const double OxygenLevelModifier = 0.6;
        public FreeDiver(string name) : base(name, OxygenLevelConst)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            base.OxygenLevel -= (int)Math.Round(TimeToCatch * OxygenLevelModifier, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            base.OxygenLevel = OxygenLevelConst;
        }
    }
}
