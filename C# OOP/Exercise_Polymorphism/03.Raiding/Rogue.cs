namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int _roguePower = 80;
        public Rogue(string name) : base(name, _roguePower)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
