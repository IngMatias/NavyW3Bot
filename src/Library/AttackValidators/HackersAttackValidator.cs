namespace Library
{
    public class HackersAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractTable table, AbstractAttacker attack)
        {
            return false;
        }
    }
}