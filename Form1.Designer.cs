namespace Crk_Topping_Scanner
{
    partial class Form1
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
            this.numStat3 = new System.Windows.Forms.NumericUpDown();
            this.numStat1 = new System.Windows.Forms.NumericUpDown();
            this.btnAddTopping = new System.Windows.Forms.Button();
            this.drpStatType1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.drpStatType3 = new System.Windows.Forms.ComboBox();
            this.tbxStat3 = new System.Windows.Forms.Panel();
            this.drpStatType2 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numStat2 = new System.Windows.Forms.NumericUpDown();
            this.drpToppingType = new System.Windows.Forms.ComboBox();
            this.drpResonantType = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numStat3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStat1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tbxStat3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStat2)).BeginInit();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numStat3
            // 
            this.numStat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numStat3.DecimalPlaces = 1;
            this.numStat3.Dock = System.Windows.Forms.DockStyle.Right;
            this.numStat3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numStat3.Location = new System.Drawing.Point(121, 0);
            this.numStat3.Margin = new System.Windows.Forms.Padding(0);
            this.numStat3.Name = "numStat3";
            this.numStat3.Size = new System.Drawing.Size(102, 22);
            this.numStat3.TabIndex = 7;
            // 
            // numStat1
            // 
            this.numStat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numStat1.DecimalPlaces = 1;
            this.numStat1.Dock = System.Windows.Forms.DockStyle.Right;
            this.numStat1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numStat1.Location = new System.Drawing.Point(121, 0);
            this.numStat1.Margin = new System.Windows.Forms.Padding(0);
            this.numStat1.Name = "numStat1";
            this.numStat1.Size = new System.Drawing.Size(102, 22);
            this.numStat1.TabIndex = 6;
            // 
            // btnAddTopping
            // 
            this.btnAddTopping.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddTopping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTopping.Location = new System.Drawing.Point(4, 460);
            this.btnAddTopping.Name = "btnAddTopping";
            this.btnAddTopping.Size = new System.Drawing.Size(223, 38);
            this.btnAddTopping.TabIndex = 11;
            this.btnAddTopping.Text = "Add topping";
            this.btnAddTopping.UseVisualStyleBackColor = true;
            // 
            // drpStatType1
            // 
            this.drpStatType1.BackColor = System.Drawing.SystemColors.Window;
            this.drpStatType1.Dock = System.Windows.Forms.DockStyle.Left;
            this.drpStatType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpStatType1.FormattingEnabled = true;
            this.drpStatType1.Items.AddRange(new object[] {
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
            this.drpStatType1.Location = new System.Drawing.Point(0, 0);
            this.drpStatType1.Name = "drpStatType1";
            this.drpStatType1.Size = new System.Drawing.Size(118, 24);
            this.drpStatType1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.drpStatType1);
            this.panel3.Controls.Add(this.numStat1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 26);
            this.panel3.TabIndex = 10;
            // 
            // drpStatType3
            // 
            this.drpStatType3.Dock = System.Windows.Forms.DockStyle.Left;
            this.drpStatType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpStatType3.FormattingEnabled = true;
            this.drpStatType3.Items.AddRange(new object[] {
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
            this.drpStatType3.Location = new System.Drawing.Point(0, 0);
            this.drpStatType3.Name = "drpStatType3";
            this.drpStatType3.Size = new System.Drawing.Size(118, 24);
            this.drpStatType3.TabIndex = 6;
            // 
            // tbxStat3
            // 
            this.tbxStat3.Controls.Add(this.numStat3);
            this.tbxStat3.Controls.Add(this.drpStatType3);
            this.tbxStat3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxStat3.Location = new System.Drawing.Point(4, 427);
            this.tbxStat3.Name = "tbxStat3";
            this.tbxStat3.Size = new System.Drawing.Size(223, 26);
            this.tbxStat3.TabIndex = 9;
            // 
            // drpStatType2
            // 
            this.drpStatType2.Dock = System.Windows.Forms.DockStyle.Left;
            this.drpStatType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpStatType2.FormattingEnabled = true;
            this.drpStatType2.Items.AddRange(new object[] {
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
            this.drpStatType2.Location = new System.Drawing.Point(0, 0);
            this.drpStatType2.Name = "drpStatType2";
            this.drpStatType2.Size = new System.Drawing.Size(118, 24);
            this.drpStatType2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numStat2);
            this.panel4.Controls.Add(this.drpStatType2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 313);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(223, 26);
            this.panel4.TabIndex = 8;
            // 
            // numStat2
            // 
            this.numStat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numStat2.DecimalPlaces = 1;
            this.numStat2.Dock = System.Windows.Forms.DockStyle.Right;
            this.numStat2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numStat2.Location = new System.Drawing.Point(121, 0);
            this.numStat2.Margin = new System.Windows.Forms.Padding(0);
            this.numStat2.Name = "numStat2";
            this.numStat2.Size = new System.Drawing.Size(102, 22);
            this.numStat2.TabIndex = 7;
            // 
            // drpToppingType
            // 
            this.drpToppingType.Dock = System.Windows.Forms.DockStyle.Right;
            this.drpToppingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpToppingType.FormattingEnabled = true;
            this.drpToppingType.Items.AddRange(new object[] {
            "Raspberry",
            "Walnut",
            "Peanut",
            "Caramel",
            "Apple Jelly",
            "Chocolate",
            "Almond",
            "Hazelnut",
            "Candy",
            "Kiwi"});
            this.drpToppingType.Location = new System.Drawing.Point(138, 0);
            this.drpToppingType.Margin = new System.Windows.Forms.Padding(0);
            this.drpToppingType.Name = "drpToppingType";
            this.drpToppingType.Size = new System.Drawing.Size(85, 24);
            this.drpToppingType.TabIndex = 7;
            // 
            // drpResonantType
            // 
            this.drpResonantType.Dock = System.Windows.Forms.DockStyle.Left;
            this.drpResonantType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpResonantType.FormattingEnabled = true;
            this.drpResonantType.Items.AddRange(new object[] {
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
            this.drpResonantType.Location = new System.Drawing.Point(0, 0);
            this.drpResonantType.Name = "drpResonantType";
            this.drpResonantType.Size = new System.Drawing.Size(137, 24);
            this.drpResonantType.TabIndex = 7;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.drpToppingType);
            this.panel6.Controls.Add(this.drpResonantType);
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
            this.tableLayoutPanel2.Controls.Add(this.btnAddTopping, 0, 8);
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
            // btnRead
            // 
            this.btnRead.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRead.Location = new System.Drawing.Point(139, 4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(128, 40);
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScreenshot.Location = new System.Drawing.Point(4, 4);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(128, 40);
            this.btnScreenshot.TabIndex = 6;
            this.btnScreenshot.Text = "Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnRead, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnExport, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnScreenshot, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 454);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 48);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnExport
            // 
            this.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExport.Location = new System.Drawing.Point(274, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(129, 40);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 502);
            this.panel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 502);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numStat3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStat1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tbxStat3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numStat2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numStat3;
        private System.Windows.Forms.NumericUpDown numStat1;
        private System.Windows.Forms.Button btnAddTopping;
        private System.Windows.Forms.ComboBox drpStatType1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox drpStatType3;
        private System.Windows.Forms.Panel tbxStat3;
        private System.Windows.Forms.ComboBox drpStatType2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numStat2;
        private System.Windows.Forms.ComboBox drpToppingType;
        private System.Windows.Forms.ComboBox drpResonantType;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panel1;
    }
}

