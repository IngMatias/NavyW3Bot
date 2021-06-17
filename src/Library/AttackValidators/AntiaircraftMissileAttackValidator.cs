namespace Library
{
    public class AntiaircraftMissileAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(ITable table, AbstractAttacker attack)
        {
            return attack is MissileAttack;
        }
    }
}