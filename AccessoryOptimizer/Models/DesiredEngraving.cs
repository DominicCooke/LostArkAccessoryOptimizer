namespace AccessoryOptimizer.Models
{
    public class DesiredEngraving
    {
        public int Amount;
        public EngravingType EngravingType;

        public DesiredEngraving(int amount, EngravingType engravingType)
        {
            Amount = amount;
            EngravingType = engravingType;
        }
    }
}
