namespace Library
{
    public class HackersAttackValidator : IAttackValidator
    {
        public HackersAttackValidator()
        {

        }
        public bool AvoidAttack(ITable table, AbstractAttacker attack)
        {
            return false;
        }
    }
}