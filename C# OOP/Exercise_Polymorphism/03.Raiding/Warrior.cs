namespace _03.Raiding
{
    internal class Warrior : BaseHero
    {
        private const int _warriorPower = 100;
        public Warrior(string name) : base(name, _warriorPower)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
