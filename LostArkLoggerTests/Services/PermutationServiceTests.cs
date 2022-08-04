using AccessoryOptimizer.Models;
using AccessoryOptimizer.Services;
using static AccessoryOptimizer.Services.PermutationService;

namespace LostArkLoggerTests.Services
{
    internal class PermutationServiceTests
    {
        [Test]
        public void PermutationServiceTests_DataThatHasOneSuccessfulPermutation_AListThatContains1Permutation()
        {
            // arrange
            PSO.CurrentAccessories = GetSuccessfulPermutationTestData();
            var permutationService = new PermutationService
            {
                _necklaces = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Necklace).ToList(),
                _earrings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Earring).ToList(),
                _rings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Ring).ToList()
            };

            // act
            var successfulPermutations = permutationService.Process(new List<List<DesiredEngraving>>() { GetDesiredEngravings() }, 20000, filterWorryingEngraving: false, filterEngravingAtZero: false);

            // assert
            Assert.That((successfulPermutations.Count == 1));
        }

        [Test]
        public void PermutationServiceTests_DataThatHas8SuccessfulPermutation_AListThatContains8Permutations()
        {
            // arrange
            List<Accessory> accessories = GetSuccessfulPermutationTestData();
            
            for (int i = 0; i < 500; i++)
            {
                accessories.AddRange(GetTestData());
            }

            PSO.CurrentAccessories = accessories;
            var permutationService = new PermutationService
            {
                _necklaces = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Necklace).ToList(),
                _earrings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Earring).ToList(),
                _rings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Ring).ToList()
            };

            // act
            var successfulPermutations = permutationService.Process(new List<List<DesiredEngraving>>() { GetDesiredEngravings() }, 20000, filterWorryingEngraving: false, filterEngravingAtZero: false);

            // assert
            Assert.That(successfulPermutations.Count == 8);
        }

        [Test]
        public void PermutationServiceV2Tests_DataThatHas8SuccessfulPermutation_AListThatContains8Permutations()
        {
            // arrange
            List<Accessory> accessories = GetSuccessfulPermutationTestData();

            for (int i = 0; i < 20; i++)
            {
                accessories.AddRange(GetTestData());
            }

            // act
            var permutationService = new PermutationServiceV2();
            var successfulPermutations = permutationService.Process(
                accessories.Where(a => a.AccessoryType == AccessoryType.Necklace).ToList(),
                accessories.Where(a => a.AccessoryType == AccessoryType.Earring).ToList(),
                accessories.Where(a => a.AccessoryType == AccessoryType.Ring).ToList(),
                new List<List<DesiredEngraving>>() { GetDesiredEngravings() });

            // assert
            Assert.That(successfulPermutations.Count == 8);
        }

        private List<DesiredEngraving> GetDesiredEngravings()
        {
            return new()
            {
                new DesiredEngraving(5, EngravingType.Combat_Readiness),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(8, EngravingType.Barricade),
                new DesiredEngraving(15, EngravingType.Stabilized_Status),
                new DesiredEngraving(9, EngravingType.Spirit_Absorption)
            };
        }

        private static List<Accessory> GetSuccessfulPermutationTestData()
        {
            return new List<Accessory>()
            {
                new Accessory(AccessoryType.Necklace, AccessoryRank.Relic, new Random().Next(100),50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Combat_Readiness, 5),
                        new Engraving(EngravingType.Grudge, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Necklace, AccessoryRank.Relic, new Random().Next(100), 50, 5500,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Spirit_Absorption, 5),
                        new Engraving(EngravingType.Grudge, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Earring, AccessoryRank.Relic, new Random().Next(100),50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Barricade, 5),
                        new Engraving(EngravingType.Spirit_Absorption, 3),
                    },
                    new Engraving(EngravingType.Atk_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Earring, AccessoryRank.Relic, new Random().Next(100),50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Barricade, 3),
                    },
                    new Engraving(EngravingType.Move_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring, AccessoryRank.Relic, new Random().Next(100),50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Spirit_Absorption, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring, AccessoryRank.Relic, new Random().Next(100),50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Spirit_Absorption, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
            };
        }

        private int GetRandomAccessoryStatValue(AccessoryType accessoryType)
        {
            Random random = new Random();

            switch (accessoryType)
            {
                case AccessoryType.Ring:
                    return random.Next(161, 199);
                case AccessoryType.Earring:
                    return random.Next(241, 299);
                case AccessoryType.Necklace:
                    return random.Next(401, 499);
            }

            return 0;
        }

        private static List<Accessory> GetTestData()
        {
            return new List<Accessory>()
            {
                new Accessory(AccessoryType.Necklace, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Barricade, 5),
                        new Engraving(EngravingType.Adrenaline, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Necklace, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Adrenaline, 5),
                        new Engraving(EngravingType.Spirit_Absorption, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Earring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Spirit_Absorption, 5),
                        new Engraving(EngravingType.Barricade, 3),
                    },
                    new Engraving(EngravingType.Atk_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Earring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Grudge, 3),
                    },
                    new Engraving(EngravingType.Move_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Grudge, 5),
                        new Engraving(EngravingType.Spirit_Absorption, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Grudge, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Necklace, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Grudge, 5),
                        new Engraving(EngravingType.Adrenaline, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Necklace, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Grudge, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Earring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Adrenaline, 5),
                        new Engraving(EngravingType.Barricade, 3),
                    },
                    new Engraving(EngravingType.Atk_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Earring,AccessoryRank.Relic, 50, 50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Spirit_Absorption, 3),
                    },
                    new Engraving(EngravingType.Move_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Combat_Readiness, 5),
                        new Engraving(EngravingType.Spirit_Absorption, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring,AccessoryRank.Relic, 50, 50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Combat_Readiness, 5),
                        new Engraving(EngravingType.Stabilized_Status, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Necklace,AccessoryRank.Relic, 50, 50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Combat_Readiness, 5),
                        new Engraving(EngravingType.Barricade, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Necklace,AccessoryRank.Relic, 50, 50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Barricade, 5),
                        new Engraving(EngravingType.Grudge, 3),
                    },
                    new Engraving(EngravingType.Atk_Power_Reduction, -1),
                    new Stats(AccessoryType.Necklace, Stat_Type.Specialization, Stat_Type.Crit)),
                new Accessory(AccessoryType.Earring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Grudge, 5),
                        new Engraving(EngravingType.Combat_Readiness, 3),
                    },
                    new Engraving(EngravingType.Atk_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Earring,AccessoryRank.Relic, 50, 50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Stabilized_Status, 5),
                        new Engraving(EngravingType.Combat_Readiness, 3),
                    },
                    new Engraving(EngravingType.Move_Speed_Reduction, -1),
                    new Stats(AccessoryType.Earring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring,AccessoryRank.Relic, 50, 50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Spirit_Absorption, 5),
                        new Engraving(EngravingType.Combat_Readiness, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
                new Accessory(AccessoryType.Ring, AccessoryRank.Relic, 50,50, 100,
                    new List<Engraving>()
                    {
                        new Engraving(EngravingType.Combat_Readiness, 5),
                        new Engraving(EngravingType.Adrenaline, 3),
                    },
                    new Engraving(EngravingType.Defence_Reduction, -1),
                    new Stats(AccessoryType.Ring, Stat_Type.Specialization)),
            };
        }
    }
}
