namespace Library
{
    public interface IAttackValidator
    {
        public bool AvoidAttack(ITable table, AbstractAttacker attack);
    }
}