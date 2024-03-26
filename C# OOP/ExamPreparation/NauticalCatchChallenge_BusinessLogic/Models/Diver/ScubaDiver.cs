using System;

namespace NauticalCatchChallenge.Models.Diver
{
    public class ScubaDiver : Diver
    {
        private const int OxygenLevelConst = 540;
        private const double OxygenLevelModifier = 0.3;
        public ScubaDiver(string name) : base(name, OxygenLevelConst)
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
