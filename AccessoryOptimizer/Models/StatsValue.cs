using System.Text.Json.Serialization;

namespace AccessoryOptimizer.Models
{
    public class StatsValue
    {
        [JsonPropertyName("critValue")]
        public int CritValue { get; set; } = 0;

        [JsonPropertyName("specValue")]
        public int SpecValue { get; set; } = 0;

        [JsonPropertyName("swiftValue")]
        public int SwiftValue { get; set; } = 0;

        [JsonConstructor]
        public StatsValue(int critValue, int specValue, int swiftValue)
        {
            CritValue = critValue;
            SpecValue = specValue;
            SwiftValue = swiftValue;
        }

        public StatsValue(Stats stats)
        {
            AddValue(stats.StatType1, stats.Stat1Quantity);

            if (stats.StatType2 != null)
            {
                AddValue((Stat_Type)stats.StatType2, (int)stats.Stat2Quantity);
            }

            void AddValue(Stat_Type statType, int statQuantity)
            {
                switch (statType)
                {
                    case Stat_Type.Specialization:
                        SpecValue = statQuantity + CritValue;
                        break;
                    case Stat_Type.Swiftness:
                        SwiftValue = statQuantity + CritValue;
                        break;
                    case Stat_Type.Crit:
                        CritValue = statQuantity + CritValue;
                        break;
                }
            }
        }
    }
}
