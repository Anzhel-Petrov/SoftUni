using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak_.Models
{
    public class NaturalClimber : Climber
    {
        private const int naturalClimberStamina = 6;
        public NaturalClimber(string name) : base(name, naturalClimberStamina)
        {
            Name = name;
        }

        public override bool IsOxygenUsed => true;

        public override void Rest(int daysCount)
        {
            Stamina += daysCount * 2;
        }
    }
}
