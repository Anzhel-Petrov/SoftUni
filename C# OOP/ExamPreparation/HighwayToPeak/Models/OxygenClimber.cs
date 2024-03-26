namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int oxigenClimberStamina = 10;
        public OxygenClimber(string name) : base(name, oxigenClimberStamina)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount;
        }
    }
}
