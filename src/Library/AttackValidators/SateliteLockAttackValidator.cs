namespace Library
{
    public class SateliteLockAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractTable table, AbstractAttacker attack)
        {
            if (attack is MissileAttack || attack is LoadAttack)
            {
                table.RandomAttack(attack);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}