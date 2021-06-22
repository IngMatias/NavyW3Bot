namespace Library
{
    public class AntiaircraftMissileAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            return attack is MissileAttack;
        }
    }
}