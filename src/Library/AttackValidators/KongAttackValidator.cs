namespace Library
{
    public class KongAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            return attack is GodzillaAttack;
        }
    }
}