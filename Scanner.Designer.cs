namespace Crk_Topping_Scanner
{
    partial class Scanner
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
            this.stat3 = new System.Windows.Forms.NumericUpDown();
            this.stat1 = new System.Windows.Forms.NumericUpDown();
            this.addToppingButton = new System.Windows.Forms.Button();
            this.statType1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statType3 = new System.Windows.Forms.ComboBox();
            this.tbxStat3 = new System.Windows.Forms.Panel();
            this.statType2 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.stat2 = new System.Windows.Forms.NumericUpDown();
            this.toppingType = new System.Windows.Forms.ComboBox();
            this.resonantType = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.readButton = new System.Windows.Forms.Button();
            this.screenshotButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exportButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.scannedList = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stat1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tbxStat3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stat2)).BeginInit();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stat3
            // 
            this.stat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stat3.DecimalPlaces = 1;
            this.stat3.Dock = System.Windows.Forms.DockStyle.Right;
            this.stat3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.stat3.Location = new System.Drawing.Point(121, 0);
            this.stat3.Margin = new System.Windows.Forms.Padding(0);
            this.stat3.Name = "stat3";
            this.stat3.Size = new System.Drawing.Size(102, 22);
            this.stat3.TabIndex = 7;
            // 
            // stat1
            // 
            this.stat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stat1.DecimalPlaces = 1;
            this.stat1.Dock = System.Windows.Forms.DockStyle.Right;
            this.stat1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.stat1.Location = new System.Drawing.Point(121, 0);
            this.stat1.Margin = new System.Windows.Forms.Padding(0);
            this.stat1.Name = "stat1";
            this.stat1.Size = new System.Drawing.Size(102, 22);
            this.stat1.TabIndex = 6;
            // 
            // addToppingButton
            // 
            this.addToppingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addToppingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addToppingButton.Location = new System.Drawing.Point(4, 460);
            this.addToppingButton.Name = "addToppingButton";
            this.addToppingButton.Size = new System.Drawing.Size(223, 38);
            this.addToppingButton.TabIndex = 11;
            this.addToppingButton.Text = "Add topping";
            this.addToppingButton.UseVisualStyleBackColor = true;
            this.addToppingButton.Click += new System.EventHandler(this.btnAddTopping_Click);
            // 
            // statType1
            // 
            this.statType1.BackColor = System.Drawing.SystemColors.Window;
            this.statType1.Dock = System.Windows.Forms.DockStyle.Left;
            this.statType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statType1.FormattingEnabled = true;
            this.statType1.Items.AddRange(new object[] {
            "Amplify Buff",
            "ATK SPD",
            "ATK%",
            "Cooldown",
            "CRIT Resist",
            "CRIT%",
            "Debuff Resist",
            "DEF%",
            "DMG Resist",
            "HP%"});
            this.statType1.Location = new System.Drawing.Point(0, 0);
            this.statType1.Name = "statType1";
            this.statType1.Size = new System.Drawing.Size(118, 24);
            this.statType1.TabIndex = 6;
            this.statType1.SelectedIndexChanged += new System.EventHandler(this.statType1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.statType1);
            this.panel3.Controls.Add(this.stat1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 26);
            this.panel3.TabIndex = 10;
            // 
            // statType3
            // 
            this.statType3.Dock = System.Windows.Forms.DockStyle.Left;
            this.statType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statType3.FormattingEnabled = true;
            this.statType3.Items.AddRange(new object[] {
            "Amplify Buff",
            "ATK SPD",
            "ATK%",
            "Cooldown",
            "CRIT Resist",
            "CRIT%",
            "Debuff Resist",
            "DEF%",
            "DMG Resist",
            "HP%"});
            this.statType3.Location = new System.Drawing.Point(0, 0);
            this.statType3.Name = "statType3";
            this.statType3.Size = new System.Drawing.Size(118, 24);
            this.statType3.TabIndex = 6;
            // 
            // tbxStat3
            // 
            this.tbxStat3.Controls.Add(this.stat3);
            this.tbxStat3.Controls.Add(this.statType3);
            this.tbxStat3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxStat3.Location = new System.Drawing.Point(4, 427);
            this.tbxStat3.Name = "tbxStat3";
            this.tbxStat3.Size = new System.Drawing.Size(223, 26);
            this.tbxStat3.TabIndex = 9;
            // 
            // statType2
            // 
            this.statType2.Dock = System.Windows.Forms.DockStyle.Left;
            this.statType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statType2.FormattingEnabled = true;
            this.statType2.Items.AddRange(new object[] {
            "Amplify Buff",
            "ATK SPD",
            "ATK%",
            "Cooldown",
            "CRIT Resist",
            "CRIT%",
            "Debuff Resist",
            "DEF%",
            "DMG Resist",
            "HP%"});
            this.statType2.Location = new System.Drawing.Point(0, 0);
            this.statType2.Name = "statType2";
            this.statType2.Size = new System.Drawing.Size(118, 24);
            this.statType2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.stat2);
            this.panel4.Controls.Add(this.statType2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 313);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(223, 26);
            this.panel4.TabIndex = 8;
            // 
            // stat2
            // 
            this.stat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stat2.DecimalPlaces = 1;
            this.stat2.Dock = System.Windows.Forms.DockStyle.Right;
            this.stat2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.stat2.Location = new System.Drawing.Point(121, 0);
            this.stat2.Margin = new System.Windows.Forms.Padding(0);
            this.stat2.Name = "stat2";
            this.stat2.Size = new System.Drawing.Size(102, 22);
            this.stat2.TabIndex = 7;
            // 
            // toppingType
            // 
            this.toppingType.Dock = System.Windows.Forms.DockStyle.Right;
            this.toppingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toppingType.FormattingEnabled = true;
            this.toppingType.Items.AddRange(new object[] {
            "Caramel",
            "Almond",
            "Raspberry",
            "Chocolate",
            "Apple Jelly",
            "Walnut",
            "Peanut",
            "Hazelnut",
            "Candy",
            "Kiwi"});
            this.toppingType.Location = new System.Drawing.Point(138, 0);
            this.toppingType.Margin = new System.Windows.Forms.Padding(0);
            this.toppingType.Name = "toppingType";
            this.toppingType.Size = new System.Drawing.Size(85, 24);
            this.toppingType.TabIndex = 7;
            // 
            // resonantType
            // 
            this.resonantType.Dock = System.Windows.Forms.DockStyle.Left;
            this.resonantType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resonantType.FormattingEnabled = true;
            this.resonantType.Items.AddRange(new object[] {
            "Not Resonant",
            "Moonkissed",
            "Triple Cone Cup Trio",
            "Dragonic",
            "Tropical Rock",
            "Sea Salt",
            "Radiant Cheese",
            "Frosted Crystal",
            "Life-sprouting",
            "Destructive",
            "Fragrant",
            "Iris Gem",
            "Deceitful",
            "Truthful",
            "Sacred Vow",
            "Flaming",
            "Indolent",
            "Passionate",
            "Fuzzy Wuzzy",
            "Seafarer",
            "Destined",
            "Silent",
            "Blooming"});
            this.resonantType.Location = new System.Drawing.Point(0, 0);
            this.resonantType.Name = "resonantType";
            this.resonantType.Size = new System.Drawing.Size(137, 24);
            this.resonantType.TabIndex = 7;
            this.resonantType.SelectedIndexChanged += new System.EventHandler(this.drpResonantType_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.toppingType);
            this.panel6.Controls.Add(this.resonantType);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 85);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(223, 26);
            this.panel6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(4, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 80);
            this.label7.TabIndex = 6;
            this.label7.Text = "Stat 3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(4, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 80);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stat 2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(4, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 80);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stat 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 80);
            this.label1.TabIndex = 0;
            this.label1.Text = "Topping Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.addToppingButton, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbxStat3, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(231, 502);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(407, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 502);
            this.panel2.TabIndex = 10;
            // 
            // readButton
            // 
            this.readButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.readButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.readButton.Location = new System.Drawing.Point(139, 4);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(128, 40);
            this.readButton.TabIndex = 5;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            // 
            // screenshotButton
            // 
            this.screenshotButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.screenshotButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenshotButton.Location = new System.Drawing.Point(4, 4);
            this.screenshotButton.Name = "screenshotButton";
            this.screenshotButton.Size = new System.Drawing.Size(128, 40);
            this.screenshotButton.TabIndex = 6;
            this.screenshotButton.Text = "Screenshot";
            this.screenshotButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.readButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.exportButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.screenshotButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 454);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 48);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // exportButton
            // 
            this.exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportButton.Location = new System.Drawing.Point(274, 4);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(129, 40);
            this.exportButton.TabIndex = 4;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.scannedList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 502);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // scannedList
            // 
            this.scannedList.AutoSize = true;
            this.scannedList.Location = new System.Drawing.Point(17, 33);
            this.scannedList.Name = "scannedList";
            this.scannedList.Size = new System.Drawing.Size(40, 16);
            this.scannedList.TabIndex = 7;
            this.scannedList.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Scanned Toppings";
            // 
            // Scanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 502);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Scanner";
            this.Text = "Topping Scanner";
            this.Load += new System.EventHandler(this.Scanner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stat1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tbxStat3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stat2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown stat3;
        private System.Windows.Forms.NumericUpDown stat1;
        private System.Windows.Forms.Button addToppingButton;
        private System.Windows.Forms.ComboBox statType1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox statType3;
        private System.Windows.Forms.Panel tbxStat3;
        private System.Windows.Forms.ComboBox statType2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown stat2;
        private System.Windows.Forms.ComboBox toppingType;
        private System.Windows.Forms.ComboBox resonantType;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button screenshotButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label scannedList;
        private System.Windows.Forms.Label label2;
    }
}

