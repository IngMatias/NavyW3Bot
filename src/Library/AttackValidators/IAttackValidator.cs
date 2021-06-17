namespace Library
{
    public interface IAttackValidator
    {
        public bool AvoidAttack(AbstractTable table, AbstractAttacker attack);
    }
}