namespace Library
{
    public class KongAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(ITable table, AbstractAttacker attack)
        {
            return attack is GodzillaAttack;
        }
    }
}