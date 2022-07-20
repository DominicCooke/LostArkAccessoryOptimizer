using System.ComponentModel;
using System.Net;

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
            regionSelector.DataSource = Enum.GetValues(typeof(Region));
            regionSelector.SelectedIndex = (int)Properties.Settings.Default.Region;
            regionSelector.SelectedIndexChanged += new EventHandler(regionSelector_SelectedIndexChanged);
            loggedPacketCountLabel.Text = "Logged Packets : 0";
            loggedPacketCountLabel.DataBindings.Add("Text", this, nameof(PacketCount));
            //sniffModeCheckbox.Checked = Properties.Settings.Default.Npcap;
            // overlay = new Overlay();
            // overlay.AddSniffer(sniffer);
            // overlay.Show();

            _permutationService = new PermutationService();
            InitializeOptions();
        }

        private void weblink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/shalzuth/LostArkLogger");
        }

        private void overlayEnabled_CheckedChanged(object sender, EventArgs e)
        {
            overlay.Visible = overlayEnabled.Checked;
        }

        private void logEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Logger.enableLogging = logEnabled.Checked;
        }

        private void debugLog_CheckedChanged(object sender, EventArgs e)
        {
            Logger.debugLog = debugLog.Checked;
        }

        private void checkUpdate_Click(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers["User-Agent"] = "LostArkLogger";
                var json = wc.DownloadString(@"https://api.github.com/repos/shalzuth/LostArkLogger/releases/latest");
                var version = json.Substring(json.IndexOf("tag_name") + 11);
                version = version.Substring(0, version.IndexOf("\""));
                if (version == System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString()) MessageBox.Show("Current version is up to date : " + version, "Version Info");
                else
                {
                    var exeUrl = json.Substring(json.IndexOf("browser_download_url") + 23);
                    exeUrl = exeUrl.Substring(0, exeUrl.IndexOf("\""));
                    var curFileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
                    if (File.Exists(curFileName + ".old")) File.Delete(curFileName + ".old");
                    File.Move(curFileName, curFileName + ".old"); // need to delete this old breadcrumb elegantly. maybe on app start. not going to solve right now.
                    wc.DownloadFile(exeUrl, curFileName);
                    System.Diagnostics.Process.Start(curFileName);
                    Environment.Exit(0);
                }
            }
        }

        private void sniffModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.sniffModeCheckbox.Enabled = false;
            this.sniffer.use_npcap = sniffModeCheckbox.Checked;
            this.sniffer.InstallListener();
            // This will unset the checkbox if it fails to initialize
            this.sniffModeCheckbox.Checked = this.sniffer.use_npcap;
            this.sniffModeCheckbox.Enabled = true;
            Properties.Settings.Default.Npcap = sniffModeCheckbox.Checked;
            Properties.Settings.Default.Save();
        }

        private void regionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Region = (Region)Enum.Parse(typeof(Region), regionSelector.Text);
            Properties.Settings.Default.Save();
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.FriendlyName);
            Environment.Exit(0);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _permutationService.ClearAccessories();
            UpdateCountText();
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            var allDesiredEngravings = new List<List<DesiredEngraving>>()
            {
                GetDesiredEngravingsManual1(),
                GetDesiredEngravingsManual2(),
                GetDesiredEngravingsManual3(),
                GetDesiredEngravingsManual4(),
                GetDesiredEngravingsManual5(),
                GetDesiredEngravingsManual6(),
            };

            _permutationService._necklaces = PermutationServiceOptions.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Necklace).ToList();
            _permutationService._earrings = PermutationServiceOptions.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Earring).ToList();
            _permutationService._rings = PermutationServiceOptions.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Ring).ToList();

            _permutationService.Process(allDesiredEngravings, int.Parse(maxCost.Text));
        }

        private void InitializeOptions()
        {
            engraving1Choice.DataSource = GetChoices();
            engraving2Choice.DataSource = GetChoices();
            engraving3Choice.DataSource = GetChoices();
            engraving4Choice.DataSource = GetChoices();
            engraving5Choice.DataSource = GetChoices();
            engraving6Choice.DataSource = GetChoices();
        }

        #region Sorceress
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


        private string[] GetChoices()
        {
            string[] choices = new[] { string.Empty };
            choices = choices.Concat(Enum.GetNames(typeof(EngravingType))).ToArray();
            return choices;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateCountText();
        }

        private void UpdateCountText()
        {
            accessoryCount.Text = PermutationServiceOptions.CurrentAccessories.Count.ToString();
            earringCount.Text = PermutationServiceOptions.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Earring).Count().ToString();
            ringCount.Text = PermutationServiceOptions.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Ring).Count().ToString();
            necklaceCount.Text = PermutationServiceOptions.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Necklace).Count().ToString();
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

        private List<DesiredEngraving> GetDesiredEngravings()
        {
            List<DesiredEngraving> desiredEngravings = new();
            AddEngravingIfSet(desiredEngravings, engraving1Choice, engraving1Quantity_1);
            AddEngravingIfSet(desiredEngravings, engraving2Choice, engraving2Quantity_1);
            AddEngravingIfSet(desiredEngravings, engraving3Choice, engraving3Quantity_1);
            AddEngravingIfSet(desiredEngravings, engraving4Choice, engraving4Quantity_1);
            AddEngravingIfSet(desiredEngravings, engraving5Choice, engraving5Quantity_1);
            AddEngravingIfSet(desiredEngravings, engraving6Choice, engraving6Quantity_1);

            return desiredEngravings;
        }

        private void AddEngravingIfSet(List<DesiredEngraving> desiredEngravings, ComboBox choiceComboBox, TextBox quantityTextBox)
        {
            if (!string.IsNullOrEmpty(choiceComboBox.Text))
            {
                desiredEngravings.Add(new DesiredEngraving(int.Parse(quantityTextBox.Text), Enum.Parse<EngravingType>(choiceComboBox.Text)));
            }
        }
    }
}
