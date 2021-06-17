namespace Library
{
    public class KongAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractTable table, AbstractAttacker attack)
        {
            return attack is GodzillaAttack;
        }
    }
}