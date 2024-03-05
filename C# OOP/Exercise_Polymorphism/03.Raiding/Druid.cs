namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private const int _druidPower = 80;
        public Druid(string name) : base(name, _druidPower)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} healed for {base.Power}";
        }
    }
}
