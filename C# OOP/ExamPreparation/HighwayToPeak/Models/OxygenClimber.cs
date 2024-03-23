namespace HighwayToPeak_.Models
{
    public class OxygenClimber : Climber
    {
        private const int oxigenClimberStamina = 10;
        public OxygenClimber(string name) : base(name, oxigenClimberStamina)
        {
            Name = name;
        }

        public override bool IsOxygenUsed => true;

        public override void Rest(int daysCount)
        {
            Stamina += daysCount;
        }
    }
}
