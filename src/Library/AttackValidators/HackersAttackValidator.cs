namespace Library
{
    public class HackersAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(ITable table, AbstractAttacker attack)
        {
            return false;
        }
    }
}