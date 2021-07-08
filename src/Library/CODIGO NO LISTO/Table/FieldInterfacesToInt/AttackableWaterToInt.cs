namespace Library
{
    public class AttackableWaterToInt : AbstractFieldInterfaceToInt
    {
        public AttackableWaterToInt()
        :base(new AttackedWaterToInt())
        {
        }

        public override int Convert(IField field)
        {
            if (field is IAttackableWater)
            {
                return 0;
            }
            else
            {
                return this.SendNext(field);
            }
        }
    }
}