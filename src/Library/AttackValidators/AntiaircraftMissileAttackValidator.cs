namespace Library
{
    public class AntiaircraftMissileAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractTable table, AbstractAttacker attack)
        {
            return attack is MissileAttack;
        }
    }
}