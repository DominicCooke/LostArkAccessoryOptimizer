using AccessoryOptimizer.Models;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.Json;

namespace AccessoryOptimizer.Services
{
    public class PermutationService
    {
        public List<Accessory> _necklaces = new();
        public List<Accessory> _earrings = new();
        public List<Accessory> _rings = new();

        public void ClearAccessories()
        {
            PermutationServiceOptions.CurrentAccessories = new();
        }

        public void StoreAccessories()
        {
            string json = JsonSerializer.Serialize(PermutationServiceOptions.CurrentAccessories, new JsonSerializerOptions() { IncludeFields = true });
            File.WriteAllText(@"C:\Users\Dominic\Downloads\data.json", json);
        }

        public bool LoadAccessories()
        {
            string json = File.ReadAllText(@"C:\Users\Dominic\Downloads\data.json");
            if (string.IsNullOrEmpty(json))
            {
                return false;
            }
            else
            {
                PermutationServiceOptions.CurrentAccessories = JsonSerializer.Deserialize<List<Accessory>>(json);
                return PermutationServiceOptions.CurrentAccessories?.Count() > 0;
            }
        }

        public List<PermutationDisplay> Process(List<List<DesiredEngraving>> allDesiredEngravings, int maxPrice)
        {
            if (allDesiredEngravings.Count > 0)
            {
                var necks = _necklaces.Where(n => n.BuyNowPrice < maxPrice).ToList();
                var ears = _earrings.Where(n => n.BuyNowPrice < maxPrice).ToList();
                var rings = _rings.Where(n => n.BuyNowPrice < maxPrice).ToList();

                List<Permutation> permutationsThatMatchesDesiredEngravings = GetPermutations(necks, ears, rings, allDesiredEngravings);

                List<PermutationDisplay> permutationDisplays = permutationsThatMatchesDesiredEngravings.Select(p => new PermutationDisplay(p)).Where(e => !e.IsThereWorryingNegativeEngraving()).ToList();

                var cheap = permutationDisplays.Where(e => !e.IsThereWorryingNegativeEngraving()).OrderBy(e => e.Cost).Take(10).ToList();
                //PrintToTrace(cheap);

                var cheapYetGood1 = permutationDisplays.Where(pd => pd.AverageQuality > 80).OrderBy(e => e.Cost).Take(3).ToList();
                var cheapYetGood2 = permutationDisplays.Where(pd => pd.AverageQuality > 90).OrderBy(e => e.Cost).Take(3).ToList();
                var cheapYetGood3 = permutationDisplays.Where(pd => pd.AverageQuality > 90 && pd.NegativeSummary.LowestValue < 2).OrderBy(e => e.Cost).Take(3).ToList();
                var cheapYetGood4 = permutationDisplays.Where(pd => pd.AverageQuality > 80 && pd.NegativeSummary.LowestValue < 2).OrderBy(e => e.Cost).Take(3).ToList();
                PrintToTrace(cheapYetGood3);

                var averageCost = cheap.Sum(e => e.Cost) / 5;
                return permutationDisplays;

            }

            return new();
        }

        private void PrintToTrace(List<PermutationDisplay> permutations)
        {
            foreach (PermutationDisplay p in permutations)
            {
                Trace.WriteLine("\n");
                Trace.WriteLine($"Cost: {p.Cost} AverageQuality: {p.AverageQuality} Cost per Quality: {p.Cost / p.AverageQuality}");
                Trace.WriteLine("\n");
                var output = string.Format("{0, 30}{1,30}{2,30}{3,30}", $"-Atk: {p.NegativeSummary.AmountOfAtkPower}", $"-Spd: {p.NegativeSummary.AmountOfAtkSpeed}", $"-Mov: {p.NegativeSummary.AmountOfMoveSpeed}", $"-Def: {p.NegativeSummary.AmountOfDefenceReduction}");
                Trace.WriteLine(output);
                foreach (var a in p.GetAccessories())
                {

                    var output2 = string.Format("{0,-15}{1,30}{2,30}{3,30}{4,30}{5,30}", $"{a.AccessoryType} {a.Quality}", $"{a.Engravings[0].EngravingType} ({a.Engravings[0].EngravingValue})", $"{a.Engravings[1].EngravingType}({a.Engravings[1].EngravingValue})", $"{a.NegativeEngraving.EngravingType} ({a.NegativeEngraving.EngravingValue})", $"Bid: {a.MinimumBid}", $"Cost: {a.BuyNowPrice}");

                    Trace.WriteLine(output2);
                }
            }
        }

        private bool DoesPermutationMatchDesiredEngravings(List<DesiredEngraving> desiredEngravings, Permutation permutation)
        {
            bool anyMissing = false;

            foreach (DesiredEngraving desiredEngraving in desiredEngravings)
            {
                if (permutation.GetEngravingAmount(desiredEngraving.EngravingType) >= desiredEngraving.Amount)
                {
                    continue;
                }
                else
                {
                    anyMissing = true;
                    break;
                }
            }

            return anyMissing;
        }

        private List<Permutation> GetPermutations(List<Accessory> necklaces, List<Accessory> earrings, List<Accessory> rings, List<List<DesiredEngraving>> allDesiredEngravings)
        {
            ConcurrentBag<Permutation> permutationsThatMatchesDesiredEngravings = new();
            if (necklaces.Count > 0)
            {
                List<(Accessory, Accessory)> earringCombinations = GetEarringCombinations(earrings);
                List<(Accessory, Accessory)> ringCombinations = GetRingCombinations(rings);

                var desiredEngravingAmounts = allDesiredEngravings.Select(dee => dee.Sum(de => de.Amount)).ToList();

                var rangePartitioner = Partitioner.Create(0, earringCombinations.Count, 250);
                var overall = Stopwatch.StartNew();

                Parallel.ForEach(rangePartitioner, (earringRange, loopState) =>
                {
                    var stopwatch = Stopwatch.StartNew();

                    for (int i = earringRange.Item1; i < earringRange.Item2; i++)
                    {
                        (Accessory, Accessory) eC = earringCombinations[i];

                        foreach (var rC in ringCombinations)
                        {
                            var areAnyEngravingsSatisfied = desiredEngravingAmounts.Any(dea => dea - GetCurrentEngravingValueTotal(eC.Item1, eC.Item2, rC.Item1, rC.Item2) <= 8);

                            if (!IsThereAWorryingNegativeEngraving(eC.Item1, eC.Item2, rC.Item1, rC.Item2) && areAnyEngravingsSatisfied)
                            {
                                foreach (var necklace in necklaces)
                                {
                                    Permutation permutation = new Permutation(eC.Item1, eC.Item2, rC.Item1, rC.Item2, necklace);

                                    foreach (var desiredEngravings in allDesiredEngravings)
                                    {
                                        if (!DoesPermutationMatchDesiredEngravings(desiredEngravings, permutation))
                                        {
                                            permutationsThatMatchesDesiredEngravings.Add(permutation);
                                        }
                                    }
                                }
                            }
                        };
                        Trace.WriteLine($"Finishing a cominbation run took: {stopwatch.Elapsed}");
                        stopwatch.Stop();
                    }
                });
                Trace.WriteLine($"It took this long in total: {overall.Elapsed}");
                overall.Stop();
            }

            return permutationsThatMatchesDesiredEngravings.ToList();
        }

        private int GetCurrentEngravingValueTotal(Accessory earring1, Accessory earring2, Accessory ring1, Accessory ring2)
        {
            return earring1.Engravings.Sum(e => e.EngravingValue)
                            + earring2.Engravings.Sum(e => e.EngravingValue)
                            + ring1.Engravings.Sum(e => e.EngravingValue)
                            + ring2.Engravings.Sum(e => e.EngravingValue);
        }

        private bool IsThereAWorryingNegativeEngraving(Accessory earring1, Accessory earring2, Accessory ring1, Accessory ring2)
        {
            List<Accessory> accessories = new List<Accessory>() { earring1, earring2, ring1, ring2 };

            NegativeSummary negativeSummary = new NegativeSummary(accessories);
            return negativeSummary.IsThereWorryingNegativeEngraving();
        }


        private List<(Accessory, Accessory)> GetEarringCombinations(List<Accessory> earrings)
        {
            List<(Guid, Guid)> idCombinations = new();
            List<(Accessory, Accessory)> earringCombinations = new();

            foreach (var (earring, k) in earrings.Select((value, k) => (value, k)))
            {
                for (int p = k; p < earrings.Count; p++)
                {
                    Accessory nextEarring = earrings[p];
                    if (idCombinations.Any(i => (i.Item1 == earring.Id && i.Item2 == nextEarring.Id) || (i.Item2 == earring.Id && i.Item1 == nextEarring.Id)) || earring.Id == nextEarring.Id)
                    {
                        continue;
                    }
                    else
                    {
                        earringCombinations.Add((earring, nextEarring));

                        var totalEngravingValueCurrent = earring.Engravings.Sum(e => e.EngravingValue) + nextEarring.Engravings.Sum(e => e.EngravingValue);

                        if (!AreAccessoriesAreOverNegativeCap(earring, nextEarring) && totalEngravingValueCurrent >= 12)
                        {
                            idCombinations.Add((earring.Id, nextEarring.Id));
                        }
                    }

                }
            }

            return earringCombinations;
        }

        private List<(Accessory, Accessory)> GetRingCombinations(List<Accessory> rings)
        {
            List<(Guid, Guid)> idCombinations = new();
            List<(Accessory, Accessory)> ringCombinations = new();

            foreach (var (ring, k) in rings.Select((value, k) => (value, k)))
            {
                for (int p = k; p < rings.Count; p++)
                {
                    Accessory nextRing = rings[p];
                    if (idCombinations.Any(i => (i.Item1 == ring.Id && i.Item2 == nextRing.Id) || (i.Item2 == ring.Id && i.Item1 == nextRing.Id)) || ring.Id == nextRing.Id)
                    {
                        continue;
                    }
                    else
                    {
                        ringCombinations.Add((ring, nextRing));

                        var totalEngravingValueCurrent = ring.Engravings.Sum(e => e.EngravingValue) + nextRing.Engravings.Sum(e => e.EngravingValue);

                        if (!AreAccessoriesAreOverNegativeCap(ring, nextRing) && totalEngravingValueCurrent >= 12)
                        {
                            idCombinations.Add((ring.Id, nextRing.Id));
                        }
                    }
                }
            }

            return ringCombinations;
        }

        private bool AreAccessoriesAreOverNegativeCap(Accessory accessory1, Accessory accessory2)
        {
            var negativeSummary = new NegativeSummary(new List<Accessory>() { accessory1, accessory2 });

            return negativeSummary.IsThereWorryingNegativeEngraving();
        }

        public static class PermutationServiceOptions
        {
            public static Stat_Type DesiredStatType1 = Stat_Type.Specialization;
            public static Stat_Type DesiredStatType2 = Stat_Type.Crit;

            public static List<Accessory> CurrentAccessories = new();

            public static Dictionary<UInt32, string> EngravingList = new Dictionary<UInt32, string>()
            {
                [107] = "Disrespect",
                [109] = "Spirit Absorption",
                [110] = "Ether Predator",
                [111] = "Stabilized Status",
                [118] = "Grudge",
                [121] = "Super Charge",
                [123] = "Strong Will",
                [125] = "Mayhem",
                [127] = "Esoteric Skill Enhancement",
                [129] = "Enhanced Weapon",
                [130] = "Firepower Enhancement",
                [134] = "Drops of Ether",
                [140] = "Crisis Evasion",
                [141] = "Keen Blunt Weapon",
                [142] = "Vital Point Hit",
                [167] = "Max MP Increase",
                [168] = "MP Efficiency Increase",
                [188] = "Berserker's Technique",
                [189] = "First Intention",
                [190] = "Ultimate Skill: Taijutsu",
                [191] = "Shock Training",
                [192] = "Pistoleer",
                [193] = "Barrage Enhancement",
                [194] = "True Courage",
                [195] = "Desperate Salvation",
                [202] = "Master of Escape",
                [224] = "Combat Readiness",
                [225] = "Lone Knight",
                [235] = "Fortitude",
                [236] = "Crushing Fist",
                [237] = "Shield Piercing",
                [238] = "Master's Tenacity",
                [239] = "Divine Protection",
                [240] = "Heavy Armor",
                [241] = "Explosive Expert",
                [242] = "Enhanced Shield",
                [243] = "Necromancy",
                [244] = "Preemptive Strike",
                [245] = "Broken Bone",
                [246] = "Lightning Fury",
                [247] = "Cursed Doll",
                [248] = "Contender",
                [249] = "Ambush Master",
                [251] = "Magick Stream",
                [253] = "Barricade",
                [254] = "Raid Captain",
                [255] = "Awakening",
                [256] = "Energy Overflow",
                [257] = "Robust Spirit",
                [258] = "Loyal Companion",
                [259] = "Death Strike",
                [276] = "Pinnacle",
                [277] = "Control",
                [278] = "Remaining Energy",
                [279] = "Surge",
                [280] = "Perfect Suppression",
                [281] = "Demonic Impulse",
                [282] = "Judgment",
                [283] = "Blessed Aura",
                [288] = "Master Brawler",
                [289] = "Peacemaker",
                [290] = "Time to Hunt",
                [291] = "Deathblow",
                [292] = "Esoteric Flurry",
                [293] = "Igniter",
                [294] = "Reflux",
                [295] = "Increases Mass",
                [296] = "Propulsion",
                [297] = "Hit Master",
                [298] = "Sight Focus",
                [299] = "Adrenaline",
                [300] = "All-Out Attack",
                [301] = "Expert",
                [302] = "Emergency Rescue",
                [303] = "Precise Dagger",
                [803] = "Move Speed Reduction",
                [802] = "Atk. Speed Reduction",
                [801] = "Defense Reduction",
                [800] = "Atk. Power Reduction"
            };
        }
    }
}

