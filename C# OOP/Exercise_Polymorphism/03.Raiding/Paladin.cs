namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private const int _paladinPower = 100;

        public Paladin(string name) : base(name, _paladinPower)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} healed for {base.Power}";
        }
    }
}
