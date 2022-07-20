namespace LostArkLogger
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.loggedPacketCountLabel = new System.Windows.Forms.Label();
            this.weblink = new System.Windows.Forms.LinkLabel();
            this.overlayEnabled = new System.Windows.Forms.CheckBox();
            this.logEnabled = new System.Windows.Forms.CheckBox();
            this.debugLog = new System.Windows.Forms.CheckBox();
            this.checkUpdate = new System.Windows.Forms.Button();
            this.sniffModeCheckbox = new System.Windows.Forms.CheckBox();
            this.regionSelector = new System.Windows.Forms.ComboBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.processButton = new System.Windows.Forms.Button();
            this.accessoryCount = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.necklaceCount = new System.Windows.Forms.Label();
            this.earringCount = new System.Windows.Forms.Label();
            this.ringCount = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.engraving1Choice = new System.Windows.Forms.ComboBox();
            this.engraving1Label = new System.Windows.Forms.Label();
            this.engraving1QuantityLabel = new System.Windows.Forms.Label();
            this.engraving1Quantity_1 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.engraving3Quantity_1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.engraving3Choice = new System.Windows.Forms.ComboBox();
            this.engraving4Quantity_1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.engraving4Choice = new System.Windows.Forms.ComboBox();
            this.engraving5Quantity_1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.engraving5Choice = new System.Windows.Forms.ComboBox();
            this.engraving6Quantity_1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.engraving6Choice = new System.Windows.Forms.ComboBox();
            this.engraving2Choice = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.maxCost = new System.Windows.Forms.TextBox();
            this.engraving6Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving5Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving4Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving3Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving1Quantity_2 = new System.Windows.Forms.TextBox();
            this.engraving6Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving5Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving4Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving3Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving2Quantity_3 = new System.Windows.Forms.TextBox();
            this.engraving1Quantity_3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loggedPacketCountLabel
            // 
            this.loggedPacketCountLabel.AutoSize = true;
            this.loggedPacketCountLabel.Location = new System.Drawing.Point(15, 12);
            this.loggedPacketCountLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.loggedPacketCountLabel.Name = "loggedPacketCountLabel";
            this.loggedPacketCountLabel.Size = new System.Drawing.Size(105, 15);
            this.loggedPacketCountLabel.TabIndex = 2;
            this.loggedPacketCountLabel.Text = "Logged Packets : 0";
            // 
            // weblink
            // 
            this.weblink.AutoSize = true;
            this.weblink.Location = new System.Drawing.Point(206, 12);
            this.weblink.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.weblink.Name = "weblink";
            this.weblink.Size = new System.Drawing.Size(67, 15);
            this.weblink.TabIndex = 4;
            this.weblink.TabStop = true;
            this.weblink.Text = "by shalzuth";
            this.weblink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.weblink_LinkClicked);
            // 
            // overlayEnabled
            // 
            this.overlayEnabled.AutoSize = true;
            this.overlayEnabled.Checked = true;
            this.overlayEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlayEnabled.Location = new System.Drawing.Point(16, 42);
            this.overlayEnabled.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.overlayEnabled.Name = "overlayEnabled";
            this.overlayEnabled.Size = new System.Drawing.Size(66, 19);
            this.overlayEnabled.TabIndex = 5;
            this.overlayEnabled.Text = "Overlay";
            this.overlayEnabled.UseVisualStyleBackColor = true;
            this.overlayEnabled.CheckedChanged += new System.EventHandler(this.overlayEnabled_CheckedChanged);
            // 
            // logEnabled
            // 
            this.logEnabled.AutoSize = true;
            this.logEnabled.Checked = true;
            this.logEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.logEnabled.Location = new System.Drawing.Point(16, 73);
            this.logEnabled.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.logEnabled.Name = "logEnabled";
            this.logEnabled.Size = new System.Drawing.Size(46, 19);
            this.logEnabled.TabIndex = 6;
            this.logEnabled.Text = "Log";
            this.logEnabled.UseVisualStyleBackColor = true;
            this.logEnabled.CheckedChanged += new System.EventHandler(this.logEnabled_CheckedChanged);
            // 
            // debugLog
            // 
            this.debugLog.AutoSize = true;
            this.debugLog.Location = new System.Drawing.Point(108, 42);
            this.debugLog.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.debugLog.Name = "debugLog";
            this.debugLog.Size = new System.Drawing.Size(61, 19);
            this.debugLog.TabIndex = 9;
            this.debugLog.Text = "Debug";
            this.debugLog.UseVisualStyleBackColor = true;
            this.debugLog.CheckedChanged += new System.EventHandler(this.debugLog_CheckedChanged);
            // 
            // checkUpdate
            // 
            this.checkUpdate.Location = new System.Drawing.Point(16, 101);
            this.checkUpdate.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.checkUpdate.Name = "checkUpdate";
            this.checkUpdate.Size = new System.Drawing.Size(91, 31);
            this.checkUpdate.TabIndex = 11;
            this.checkUpdate.Text = "Check Update";
            this.checkUpdate.UseVisualStyleBackColor = true;
            this.checkUpdate.Click += new System.EventHandler(this.checkUpdate_Click);
            // 
            // sniffModeCheckbox
            // 
            this.sniffModeCheckbox.AutoSize = true;
            this.sniffModeCheckbox.Location = new System.Drawing.Point(196, 42);
            this.sniffModeCheckbox.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.sniffModeCheckbox.Name = "sniffModeCheckbox";
            this.sniffModeCheckbox.Size = new System.Drawing.Size(78, 19);
            this.sniffModeCheckbox.TabIndex = 9;
            this.sniffModeCheckbox.Text = "Winpcap?";
            this.sniffModeCheckbox.UseVisualStyleBackColor = true;
            this.sniffModeCheckbox.CheckedChanged += new System.EventHandler(this.sniffModeCheckbox_CheckedChanged);
            // 
            // regionSelector
            // 
            this.regionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionSelector.FormattingEnabled = true;
            this.regionSelector.Location = new System.Drawing.Point(134, 67);
            this.regionSelector.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.regionSelector.Name = "regionSelector";
            this.regionSelector.Size = new System.Drawing.Size(140, 23);
            this.regionSelector.TabIndex = 12;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(312, 12);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(65, 23);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(312, 152);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(65, 23);
            this.processButton.TabIndex = 14;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // accessoryCount
            // 
            this.accessoryCount.AutoSize = true;
            this.accessoryCount.Location = new System.Drawing.Point(438, 16);
            this.accessoryCount.Name = "accessoryCount";
            this.accessoryCount.Size = new System.Drawing.Size(13, 15);
            this.accessoryCount.TabIndex = 15;
            this.accessoryCount.Text = "0";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(312, 40);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(65, 23);
            this.refreshButton.TabIndex = 16;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "N:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "E:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(385, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "R:";
            // 
            // necklaceCount
            // 
            this.necklaceCount.AutoSize = true;
            this.necklaceCount.Location = new System.Drawing.Point(409, 16);
            this.necklaceCount.Name = "necklaceCount";
            this.necklaceCount.Size = new System.Drawing.Size(12, 15);
            this.necklaceCount.TabIndex = 20;
            this.necklaceCount.Text = "-";
            // 
            // earringCount
            // 
            this.earringCount.AutoSize = true;
            this.earringCount.Location = new System.Drawing.Point(408, 31);
            this.earringCount.Name = "earringCount";
            this.earringCount.Size = new System.Drawing.Size(12, 15);
            this.earringCount.TabIndex = 21;
            this.earringCount.Text = "-";
            // 
            // ringCount
            // 
            this.ringCount.AutoSize = true;
            this.ringCount.Location = new System.Drawing.Point(408, 46);
            this.ringCount.Name = "ringCount";
            this.ringCount.Size = new System.Drawing.Size(12, 15);
            this.ringCount.TabIndex = 22;
            this.ringCount.Text = "-";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(312, 96);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(65, 23);
            this.saveButton.TabIndex = 23;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(312, 124);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(65, 23);
            this.loadButton.TabIndex = 24;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // engraving1Choice
            // 
            this.engraving1Choice.FormattingEnabled = true;
            this.engraving1Choice.Location = new System.Drawing.Point(480, 34);
            this.engraving1Choice.Name = "engraving1Choice";
            this.engraving1Choice.Size = new System.Drawing.Size(165, 23);
            this.engraving1Choice.TabIndex = 25;
            // 
            // engraving1Label
            // 
            this.engraving1Label.AutoSize = true;
            this.engraving1Label.Location = new System.Drawing.Point(480, 16);
            this.engraving1Label.Name = "engraving1Label";
            this.engraving1Label.Size = new System.Drawing.Size(69, 15);
            this.engraving1Label.TabIndex = 26;
            this.engraving1Label.Text = "Engraving 1";
            // 
            // engraving1QuantityLabel
            // 
            this.engraving1QuantityLabel.AutoSize = true;
            this.engraving1QuantityLabel.Location = new System.Drawing.Point(651, 16);
            this.engraving1QuantityLabel.Name = "engraving1QuantityLabel";
            this.engraving1QuantityLabel.Size = new System.Drawing.Size(51, 15);
            this.engraving1QuantityLabel.TabIndex = 27;
            this.engraving1QuantityLabel.Text = "Amount";
            // 
            // engraving1Quantity_1
            // 
            this.engraving1Quantity_1.Location = new System.Drawing.Point(651, 34);
            this.engraving1Quantity_1.Name = "engraving1Quantity_1";
            this.engraving1Quantity_1.Size = new System.Drawing.Size(100, 23);
            this.engraving1Quantity_1.TabIndex = 28;
            this.engraving1Quantity_1.Text = "0";
            this.engraving1Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving2Quantity_1
            // 
            this.engraving2Quantity_1.Location = new System.Drawing.Point(651, 85);
            this.engraving2Quantity_1.Name = "engraving2Quantity_1";
            this.engraving2Quantity_1.Size = new System.Drawing.Size(100, 23);
            this.engraving2Quantity_1.TabIndex = 32;
            this.engraving2Quantity_1.Text = "0";
            this.engraving2Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "Engraving 2";
            // 
            // engraving3Quantity_1
            // 
            this.engraving3Quantity_1.Location = new System.Drawing.Point(651, 136);
            this.engraving3Quantity_1.Name = "engraving3Quantity_1";
            this.engraving3Quantity_1.Size = new System.Drawing.Size(100, 23);
            this.engraving3Quantity_1.TabIndex = 36;
            this.engraving3Quantity_1.Text = "0";
            this.engraving3Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(480, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "Engraving 3";
            // 
            // engraving3Choice
            // 
            this.engraving3Choice.FormattingEnabled = true;
            this.engraving3Choice.Location = new System.Drawing.Point(480, 136);
            this.engraving3Choice.Name = "engraving3Choice";
            this.engraving3Choice.Size = new System.Drawing.Size(165, 23);
            this.engraving3Choice.TabIndex = 33;
            // 
            // engraving4Quantity_1
            // 
            this.engraving4Quantity_1.Location = new System.Drawing.Point(651, 187);
            this.engraving4Quantity_1.Name = "engraving4Quantity_1";
            this.engraving4Quantity_1.Size = new System.Drawing.Size(100, 23);
            this.engraving4Quantity_1.TabIndex = 40;
            this.engraving4Quantity_1.Text = "0";
            this.engraving4Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(651, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 39;
            this.label8.Text = "Amount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(480, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 38;
            this.label9.Text = "Engraving 4";
            // 
            // engraving4Choice
            // 
            this.engraving4Choice.FormattingEnabled = true;
            this.engraving4Choice.Location = new System.Drawing.Point(480, 187);
            this.engraving4Choice.Name = "engraving4Choice";
            this.engraving4Choice.Size = new System.Drawing.Size(165, 23);
            this.engraving4Choice.TabIndex = 37;
            // 
            // engraving5Quantity_1
            // 
            this.engraving5Quantity_1.Location = new System.Drawing.Point(651, 238);
            this.engraving5Quantity_1.Name = "engraving5Quantity_1";
            this.engraving5Quantity_1.Size = new System.Drawing.Size(100, 23);
            this.engraving5Quantity_1.TabIndex = 44;
            this.engraving5Quantity_1.Text = "0";
            this.engraving5Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(651, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 43;
            this.label10.Text = "Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(480, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 15);
            this.label11.TabIndex = 42;
            this.label11.Text = "Engraving 5";
            // 
            // engraving5Choice
            // 
            this.engraving5Choice.FormattingEnabled = true;
            this.engraving5Choice.Location = new System.Drawing.Point(480, 238);
            this.engraving5Choice.Name = "engraving5Choice";
            this.engraving5Choice.Size = new System.Drawing.Size(165, 23);
            this.engraving5Choice.TabIndex = 41;
            // 
            // engraving6Quantity_1
            // 
            this.engraving6Quantity_1.Location = new System.Drawing.Point(651, 289);
            this.engraving6Quantity_1.Name = "engraving6Quantity_1";
            this.engraving6Quantity_1.Size = new System.Drawing.Size(100, 23);
            this.engraving6Quantity_1.TabIndex = 48;
            this.engraving6Quantity_1.Text = "0";
            this.engraving6Quantity_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(651, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 15);
            this.label12.TabIndex = 47;
            this.label12.Text = "Amount";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(480, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 15);
            this.label13.TabIndex = 46;
            this.label13.Text = "Engraving 6";
            // 
            // engraving6Choice
            // 
            this.engraving6Choice.FormattingEnabled = true;
            this.engraving6Choice.Location = new System.Drawing.Point(480, 289);
            this.engraving6Choice.Name = "engraving6Choice";
            this.engraving6Choice.Size = new System.Drawing.Size(165, 23);
            this.engraving6Choice.TabIndex = 45;
            // 
            // engraving2Choice
            // 
            this.engraving2Choice.FormattingEnabled = true;
            this.engraving2Choice.Location = new System.Drawing.Point(480, 85);
            this.engraving2Choice.Name = "engraving2Choice";
            this.engraving2Choice.Size = new System.Drawing.Size(165, 23);
            this.engraving2Choice.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(321, 320);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 15);
            this.label14.TabIndex = 52;
            this.label14.Text = "Results";
            // 
            // maxCost
            // 
            this.maxCost.Location = new System.Drawing.Point(312, 181);
            this.maxCost.Name = "maxCost";
            this.maxCost.Size = new System.Drawing.Size(100, 23);
            this.maxCost.TabIndex = 53;
            this.maxCost.Text = "15001";
            // 
            // engraving6Quantity_2
            // 
            this.engraving6Quantity_2.Location = new System.Drawing.Point(757, 289);
            this.engraving6Quantity_2.Name = "engraving6Quantity_2";
            this.engraving6Quantity_2.Size = new System.Drawing.Size(100, 23);
            this.engraving6Quantity_2.TabIndex = 59;
            this.engraving6Quantity_2.Text = "0";
            this.engraving6Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving5Quantity_2
            // 
            this.engraving5Quantity_2.Location = new System.Drawing.Point(757, 238);
            this.engraving5Quantity_2.Name = "engraving5Quantity_2";
            this.engraving5Quantity_2.Size = new System.Drawing.Size(100, 23);
            this.engraving5Quantity_2.TabIndex = 58;
            this.engraving5Quantity_2.Text = "0";
            this.engraving5Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving4Quantity_2
            // 
            this.engraving4Quantity_2.Location = new System.Drawing.Point(757, 187);
            this.engraving4Quantity_2.Name = "engraving4Quantity_2";
            this.engraving4Quantity_2.Size = new System.Drawing.Size(100, 23);
            this.engraving4Quantity_2.TabIndex = 57;
            this.engraving4Quantity_2.Text = "0";
            this.engraving4Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving3Quantity_2
            // 
            this.engraving3Quantity_2.Location = new System.Drawing.Point(757, 136);
            this.engraving3Quantity_2.Name = "engraving3Quantity_2";
            this.engraving3Quantity_2.Size = new System.Drawing.Size(100, 23);
            this.engraving3Quantity_2.TabIndex = 56;
            this.engraving3Quantity_2.Text = "0";
            this.engraving3Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving2Quantity_2
            // 
            this.engraving2Quantity_2.Location = new System.Drawing.Point(757, 85);
            this.engraving2Quantity_2.Name = "engraving2Quantity_2";
            this.engraving2Quantity_2.Size = new System.Drawing.Size(100, 23);
            this.engraving2Quantity_2.TabIndex = 55;
            this.engraving2Quantity_2.Text = "0";
            this.engraving2Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving1Quantity_2
            // 
            this.engraving1Quantity_2.Location = new System.Drawing.Point(757, 34);
            this.engraving1Quantity_2.Name = "engraving1Quantity_2";
            this.engraving1Quantity_2.Size = new System.Drawing.Size(100, 23);
            this.engraving1Quantity_2.TabIndex = 54;
            this.engraving1Quantity_2.Text = "0";
            this.engraving1Quantity_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving6Quantity_3
            // 
            this.engraving6Quantity_3.Location = new System.Drawing.Point(863, 289);
            this.engraving6Quantity_3.Name = "engraving6Quantity_3";
            this.engraving6Quantity_3.Size = new System.Drawing.Size(100, 23);
            this.engraving6Quantity_3.TabIndex = 65;
            this.engraving6Quantity_3.Text = "0";
            this.engraving6Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving5Quantity_3
            // 
            this.engraving5Quantity_3.Location = new System.Drawing.Point(863, 238);
            this.engraving5Quantity_3.Name = "engraving5Quantity_3";
            this.engraving5Quantity_3.Size = new System.Drawing.Size(100, 23);
            this.engraving5Quantity_3.TabIndex = 64;
            this.engraving5Quantity_3.Text = "0";
            this.engraving5Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving4Quantity_3
            // 
            this.engraving4Quantity_3.Location = new System.Drawing.Point(863, 187);
            this.engraving4Quantity_3.Name = "engraving4Quantity_3";
            this.engraving4Quantity_3.Size = new System.Drawing.Size(100, 23);
            this.engraving4Quantity_3.TabIndex = 63;
            this.engraving4Quantity_3.Text = "0";
            this.engraving4Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving3Quantity_3
            // 
            this.engraving3Quantity_3.Location = new System.Drawing.Point(863, 136);
            this.engraving3Quantity_3.Name = "engraving3Quantity_3";
            this.engraving3Quantity_3.Size = new System.Drawing.Size(100, 23);
            this.engraving3Quantity_3.TabIndex = 62;
            this.engraving3Quantity_3.Text = "0";
            this.engraving3Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving2Quantity_3
            // 
            this.engraving2Quantity_3.Location = new System.Drawing.Point(863, 85);
            this.engraving2Quantity_3.Name = "engraving2Quantity_3";
            this.engraving2Quantity_3.Size = new System.Drawing.Size(100, 23);
            this.engraving2Quantity_3.TabIndex = 61;
            this.engraving2Quantity_3.Text = "0";
            this.engraving2Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // engraving1Quantity_3
            // 
            this.engraving1Quantity_3.Location = new System.Drawing.Point(863, 34);
            this.engraving1Quantity_3.Name = "engraving1Quantity_3";
            this.engraving1Quantity_3.Size = new System.Drawing.Size(100, 23);
            this.engraving1Quantity_3.TabIndex = 60;
            this.engraving1Quantity_3.Text = "0";
            this.engraving1Quantity_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 397);
            this.Controls.Add(this.engraving6Quantity_3);
            this.Controls.Add(this.engraving5Quantity_3);
            this.Controls.Add(this.engraving4Quantity_3);
            this.Controls.Add(this.engraving3Quantity_3);
            this.Controls.Add(this.engraving2Quantity_3);
            this.Controls.Add(this.engraving1Quantity_3);
            this.Controls.Add(this.engraving6Quantity_2);
            this.Controls.Add(this.engraving5Quantity_2);
            this.Controls.Add(this.engraving4Quantity_2);
            this.Controls.Add(this.engraving3Quantity_2);
            this.Controls.Add(this.engraving2Quantity_2);
            this.Controls.Add(this.engraving1Quantity_2);
            this.Controls.Add(this.maxCost);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.engraving2Choice);
            this.Controls.Add(this.engraving6Quantity_1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.engraving6Choice);
            this.Controls.Add(this.engraving5Quantity_1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.engraving5Choice);
            this.Controls.Add(this.engraving4Quantity_1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.engraving4Choice);
            this.Controls.Add(this.engraving3Quantity_1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.engraving3Choice);
            this.Controls.Add(this.engraving2Quantity_1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.engraving1Quantity_1);
            this.Controls.Add(this.engraving1QuantityLabel);
            this.Controls.Add(this.engraving1Label);
            this.Controls.Add(this.engraving1Choice);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ringCount);
            this.Controls.Add(this.earringCount);
            this.Controls.Add(this.necklaceCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.accessoryCount);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.regionSelector);
            this.Controls.Add(this.checkUpdate);
            this.Controls.Add(this.debugLog);
            this.Controls.Add(this.sniffModeCheckbox);
            this.Controls.Add(this.logEnabled);
            this.Controls.Add(this.overlayEnabled);
            this.Controls.Add(this.weblink);
            this.Controls.Add(this.loggedPacketCountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Lost Ark Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label loggedPacketCountLabel;
        private System.Windows.Forms.LinkLabel weblink;
        private System.Windows.Forms.CheckBox overlayEnabled;
        public System.Windows.Forms.CheckBox logEnabled;
        private System.Windows.Forms.CheckBox debugLog;
        private System.Windows.Forms.Button checkUpdate;
        private System.Windows.Forms.CheckBox sniffModeCheckbox;
        private System.Windows.Forms.ComboBox regionSelector;
        private Button clearButton;
        private Button processButton;
        private Label accessoryCount;
        private Button refreshButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label necklaceCount;
        private Label earringCount;
        private Label ringCount;
        private Button saveButton;
        private Button loadButton;
        private ComboBox engraving1Choice;
        private Label engraving1Label;
        private Label engraving1QuantityLabel;
        private TextBox engraving1Quantity_1;
        private TextBox engraving2Quantity_1;
        private Label label4;
        private Label label5;
        private TextBox engraving3Quantity_1;
        private Label label6;
        private Label label7;
        private ComboBox engraving3Choice;
        private TextBox engraving4Quantity_1;
        private Label label8;
        private Label label9;
        private ComboBox engraving4Choice;
        private TextBox engraving5Quantity_1;
        private Label label10;
        private Label label11;
        private ComboBox engraving5Choice;
        private TextBox engraving6Quantity_1;
        private Label label12;
        private Label label13;
        private ComboBox engraving6Choice;
        private ComboBox engraving2Choice;
        private Label label14;
        private TextBox maxCost;
        private TextBox engraving6Quantity_2;
        private TextBox engraving5Quantity_2;
        private TextBox engraving4Quantity_2;
        private TextBox engraving3Quantity_2;
        private TextBox engraving2Quantity_2;
        private TextBox engraving1Quantity_2;
        private TextBox engraving6Quantity_3;
        private TextBox engraving5Quantity_3;
        private TextBox engraving4Quantity_3;
        private TextBox engraving3Quantity_3;
        private TextBox engraving2Quantity_3;
        private TextBox engraving1Quantity_3;
    }
}
