namespace Library
{
    public class ArmorAttackValidator : IAttackValidator
    {
        public bool AvoidAttack(AbstractAttackable table, AbstractAttacker attack)
        {
            return (attack is MissileAttack || attack is LoadAttack);
        }
    }
}