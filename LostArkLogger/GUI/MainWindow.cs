using AccessoryOptimizer.Models;
using AccessoryOptimizer.Services;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using static AccessoryOptimizer.Services.PermutationService;

namespace LostArkLogger
{
    public partial class MainWindow : Form, INotifyPropertyChanged
    {
        private PermutationService _permutationService;

        Parser sniffer;
        Overlay overlay;
        private int _packetCount;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string PacketCount
        {
            get { return "Logged Packets: " + _packetCount; }
        }

        public MainWindow()
        {
            InitializeComponent();
            //versionLabel.Text = "v" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            Oodle.Init();
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            sniffer = new Parser();
            sniffer.onPacketTotalCount += (int totalPacketCount) =>
            {
                _packetCount = totalPacketCount;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PacketCount)));
            };
            loggedPacketCountLabel.Text = "Logged Packets : 0";
            loggedPacketCountLabel.DataBindings.Add("Text", this, nameof(PacketCount));
            //sniffModeCheckbox.Checked = Properties.Settings.Default.Npcap;
            overlay = new Overlay();
            overlay.AddSniffer(sniffer);
            // overlay.Show();

            _permutationService = new PermutationService();
            InitializeOptions();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _permutationService.ClearAccessories();
            UpdateCountText();
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            var allDesiredEngravings = GetDesiredEngravings();

            PSO.DesiredStatType1 = Enum.Parse<Stat_Type>(desiredStatType1.SelectedItem.ToString());
            PSO.DesiredStatType2 = Enum.Parse<Stat_Type>(desiredStatType2.SelectedItem.ToString());

            _permutationService._necklaces = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Necklace).ToList();
            _permutationService._earrings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Earring).ToList();
            _permutationService._rings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Ring).ToList();

            var permutations = _permutationService.Process(allDesiredEngravings, int.Parse(maxCost.Text), reuse_checkBox.Checked);

            cheapest_Textbox.Text = GetStringOutputOfResults(permutations
                .OrderBy(p => p.Cost)
                .Take(5)
                .ToList());

            cheapest500HighStat1_textBox.Text = GetStringOutputOfResults(permutations
                .OrderBy(p => p.Cost)
                .Take(500)
                .OrderBy(p => PSO.DesiredStatType1 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType1 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue))
                .Reverse()
                .Take(5)
                .ToList());

            cheapest500HighStat2_textBox.Text = GetStringOutputOfResults(permutations
                .OrderBy(p => p.Cost)
                .Take(500)
                .OrderBy(p => PSO.DesiredStatType2 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType2 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue))
                .Reverse()
                .Take(5)
                .ToList());

            cheapest80Q_textBox.Text = GetStringOutputOfResults(permutations
                .Where(p => p.AverageQuality >= 80)
                .Take(5)
                .ToList());

            cheapest90Q_textBox.Text = GetStringOutputOfResults(permutations
                .Where(p => p.AverageQuality >= 90)
                .Take(5)
                .ToList());

            cheapest95Q_textBox.Text = GetStringOutputOfResults(permutations
                .Where(p => p.AverageQuality >= 95)
                .Take(5)
                .ToList());

            cheapestWithRelicNeck_textBox.Text = GetStringOutputOfResults(permutations
                .Where(p => p.Necklace.AccessoryRank == AccessoryRank.Relic)
                .OrderBy(p => p.Cost)
                .Take(5)
                .ToList());


            highestStat1_textBox.Text = GetStringOutputOfResults(permutations
                .OrderBy(p => PSO.DesiredStatType1 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType1 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue))
                .Reverse()
                .Take(5)
                .ToList());

            highestStat2_textBox.Text = GetStringOutputOfResults(permutations
                .OrderBy(p => PSO.DesiredStatType2 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType2 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue))
                .Reverse()
                .Take(5)
                .ToList());
        }

        private void InitializeOptions()
        {
            engraving1Choice.DataSource = GetChoices<EngravingType>();
            engraving2Choice.DataSource = GetChoices<EngravingType>();
            engraving3Choice.DataSource = GetChoices<EngravingType>();
            engraving4Choice.DataSource = GetChoices<EngravingType>();
            engraving5Choice.DataSource = GetChoices<EngravingType>();
            engraving6Choice.DataSource = GetChoices<EngravingType>();

            desiredStatType1.DataSource = GetChoices<Stat_Type>();
            desiredStatType2.DataSource = GetChoices<Stat_Type>();


        }

        #region Shadowhunter
        /*
        private List<DesiredEngraving> GetDesiredEngravingsManual1()
        {
            return new()
            {
                new DesiredEngraving(3, EngravingType.Demonic_Impulse),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(15, EngravingType.Hit_Master),
                new DesiredEngraving(8, EngravingType.Adrenaline),
                new DesiredEngraving(9, EngravingType.Keen_Blunt_Weapon)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual2()
        {
            return new()
            {
                new DesiredEngraving(3, EngravingType.Demonic_Impulse),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(15, EngravingType.Hit_Master),
                new DesiredEngraving(9, EngravingType.Adrenaline),
                new DesiredEngraving(8, EngravingType.Keen_Blunt_Weapon)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual3()
        {
            return new()
            {
                new DesiredEngraving(3, EngravingType.Demonic_Impulse),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(9, EngravingType.Hit_Master),
                new DesiredEngraving(15, EngravingType.Adrenaline),
                new DesiredEngraving(8, EngravingType.Keen_Blunt_Weapon)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual4()
        {
            return new()
            {
               new DesiredEngraving(3, EngravingType.Demonic_Impulse),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(8, EngravingType.Hit_Master),
                new DesiredEngraving(15, EngravingType.Adrenaline),
                new DesiredEngraving(9, EngravingType.Keen_Blunt_Weapon)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual5()
        {
            return new()
            {
                new DesiredEngraving(3, EngravingType.Demonic_Impulse),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(9, EngravingType.Hit_Master),
                new DesiredEngraving(8, EngravingType.Adrenaline),
                new DesiredEngraving(15, EngravingType.Keen_Blunt_Weapon)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual6()
        {
            return new()
            {
                new DesiredEngraving(3, EngravingType.Demonic_Impulse),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(8, EngravingType.Hit_Master),
                new DesiredEngraving(9, EngravingType.Adrenaline),
                new DesiredEngraving(15, EngravingType.Keen_Blunt_Weapon)
            };
        }
        */
        #endregion

        #region Glavier
        /*
         private List<DesiredEngraving> GetDesiredEngravingsManual1()
         {
             return new()
             {
                 new DesiredEngraving(6, EngravingType.Pinnacle),
                 new DesiredEngraving(3, EngravingType.Grudge),
                 new DesiredEngraving(9, EngravingType.Increases_Mass),
                 new DesiredEngraving(15, EngravingType.Keen_Blunt_Weapon),
                 new DesiredEngraving(3, EngravingType.Raid_Captain),

             };
         }
        */
        #endregion

        #region Sorceress
        /*
        private List<DesiredEngraving> GetDesiredEngravingsManual1()
        {
            return new()
            {
                new DesiredEngraving(6, EngravingType.Igniter),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(15, EngravingType.All_Out_Attack),
                new DesiredEngraving(9, EngravingType.Hit_Master),
                new DesiredEngraving(3, EngravingType.Adrenaline)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual2()
        {
            return new()
            {
                new DesiredEngraving(6, EngravingType.Igniter),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(9, EngravingType.All_Out_Attack),
                new DesiredEngraving(15, EngravingType.Hit_Master),
                new DesiredEngraving(3, EngravingType.Adrenaline)
            };
        }
        */
        #endregion

        #region Gunlancer
        /*
        private List<DesiredEngraving> GetDesiredEngravingsManual1()
        {
            return new()
            {
                new DesiredEngraving(5, EngravingType.Combat_Readiness),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(15, EngravingType.Barricade),
                new DesiredEngraving(9, EngravingType.Stabilized_Status),
                new DesiredEngraving(3, EngravingType.Spirit_Absorption)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual2()
        {
            return new()
            {
                new DesiredEngraving(5, EngravingType.Combat_Readiness),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(15, EngravingType.Barricade),
                new DesiredEngraving(3, EngravingType.Stabilized_Status),
                new DesiredEngraving(9, EngravingType.Spirit_Absorption)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual3()
        {
            return new()
            {
                new DesiredEngraving(5, EngravingType.Combat_Readiness),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(9, EngravingType.Barricade),
                new DesiredEngraving(15, EngravingType.Stabilized_Status),
                new DesiredEngraving(3, EngravingType.Spirit_Absorption)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual4()
        {
            return new()
            {
                new DesiredEngraving(5, EngravingType.Combat_Readiness),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(3, EngravingType.Barricade),
                new DesiredEngraving(15, EngravingType.Stabilized_Status),
                new DesiredEngraving(9, EngravingType.Spirit_Absorption)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual5()
        {
            return new()
            {
                new DesiredEngraving(5, EngravingType.Combat_Readiness),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(9, EngravingType.Barricade),
                new DesiredEngraving(3, EngravingType.Stabilized_Status),
                new DesiredEngraving(15, EngravingType.Spirit_Absorption)
            };
        }

        private List<DesiredEngraving> GetDesiredEngravingsManual6()
        {
            return new()
            {
                new DesiredEngraving(5, EngravingType.Combat_Readiness),
                new DesiredEngraving(3, EngravingType.Grudge),
                new DesiredEngraving(3, EngravingType.Barricade),
                new DesiredEngraving(9, EngravingType.Stabilized_Status),
                new DesiredEngraving(15, EngravingType.Spirit_Absorption)
            };
        }
        */
        #endregion


        private string[] GetChoices<T>()
        {
            string[] choices = new[] { string.Empty };
            choices = choices.Concat(Enum.GetNames(typeof(T))).ToArray();
            return choices;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateCountText();
        }

        private void UpdateCountText()
        {
            accessoryCount.Text = PSO.CurrentAccessories.Count.ToString();
            earringCount.Text = PSO.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Earring).Count().ToString();
            ringCount.Text = PSO.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Ring).Count().ToString();
            necklaceCount.Text = PSO.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Necklace).Count().ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            _permutationService.StoreAccessories();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            _permutationService.LoadAccessories();
            UpdateCountText();
        }

        private List<List<DesiredEngraving>> GetDesiredEngravings()
        {
            List<List<DesiredEngraving>> overallDesiredEngravings = new();

            for (int i = 1; i < 7; i++)
            {
                string firstEngravingQuantity = Controls[$"engraving1Quantity_{i}"].Text;

                if (!string.IsNullOrEmpty(firstEngravingQuantity) && firstEngravingQuantity != "0")
                {
                    overallDesiredEngravings.Add(GetDesiredEngraving(i));
                }
            }

            return overallDesiredEngravings;
        }

        private List<DesiredEngraving> GetDesiredEngraving(int columnIndex)
        {
            List<DesiredEngraving> desiredEngravings = new();

            for (int i = 1; i < 7; i++)
            {
                AddEngravingIfSet(desiredEngravings, Controls[$"engraving{i}Choice"] as ComboBox, Controls[$"engraving{i}Quantity_{columnIndex}"] as TextBox);
            }

            return desiredEngravings;
        }

        private string GetStringOutputOfResults(List<PermutationDisplay> permutations)
        {
            StringBuilder overallString = new();

            foreach (PermutationDisplay p in permutations)
            {
                overallString.AppendLine("\n");
                overallString.AppendLine($"Cost: {p.Cost} AverageQuality: {p.AverageQuality} Cost per Quality: {p.Cost / p.AverageQuality}");
                overallString.AppendLine("\n");

                var output = string.Format("{0, 30}{1,30}{2,30}{3,30}", $"-Atk: {p.NegativeSummary.AmountOfAtkPower}", $"-Spd: {p.NegativeSummary.AmountOfAtkSpeed}", $"-Mov: {p.NegativeSummary.AmountOfMoveSpeed}", $"-Def: {p.NegativeSummary.AmountOfDefenceReduction}");
                overallString.AppendLine(output);
                foreach (var a in p.GetAccessories())
                {

                    var output2 = string.Format("{0,-15}{1,30}{2,30}{3,30}{4,30}{5,30}", $"{a.AccessoryType} {a.Quality}", $"{a.Engravings[0].EngravingType} ({a.Engravings[0].EngravingValue})", $"{a.Engravings[1].EngravingType}({a.Engravings[1].EngravingValue})", $"{a.NegativeEngraving.EngravingType} ({a.NegativeEngraving.EngravingValue})", $"Bid: {a.MinimumBid}", $"Cost: {a.BuyNowPrice}");
                    overallString.AppendLine(output2);
                }
            }

            return overallString.ToString();
        }

        private static void AddEngravingIfSet(List<DesiredEngraving> desiredEngravings, ComboBox choiceComboBox, TextBox quantityTextBox)
        {
            if (!string.IsNullOrEmpty(choiceComboBox.Text))
            {
                if (!string.IsNullOrEmpty(quantityTextBox.Text) && quantityTextBox.Text != "0")
                {
                    desiredEngravings.Add(new DesiredEngraving(int.Parse(quantityTextBox.Text), Enum.Parse<EngravingType>(choiceComboBox.Text)));
                }
            }
        }

        private void saveLastEngravingsButton_Click(object sender, EventArgs e)
        {
            List<List<DesiredEngraving>> allDesiredEngravings = GetDesiredEngravings();

            string json = JsonSerializer.Serialize(allDesiredEngravings, new JsonSerializerOptions() { IncludeFields = true });
            File.WriteAllText(@".\savedEngravings.json", json);
        }

        private void loadLastEngravingsButton_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText(@".\savedEngravings.json");
            if (string.IsNullOrEmpty(json))
            {
                return;
            }
            else
            {
                List<List<DesiredEngraving>> allDesiredEngravings = JsonSerializer.Deserialize<List<List<DesiredEngraving>>>(json);

                foreach (var (desiredEngravings, k) in allDesiredEngravings.Select((value, k) => (value, k)))
                {
                    foreach (var (desiredEngraving, j) in desiredEngravings.Select((value, j) => (value, j)))
                    {
                        ComboBox comboBox = ((ComboBox)Controls[$"engraving{j + 1}Choice"]);
                        comboBox.SelectedIndex = comboBox.FindString(desiredEngraving.EngravingType.ToString());
                        Controls[$"engraving{j + 1}Quantity_{k + 1}"].Text = desiredEngraving.Amount.ToString();
                    }
                }

            }
        }
    }
}
