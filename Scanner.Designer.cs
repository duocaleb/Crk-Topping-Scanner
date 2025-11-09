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
            stat3 = new System.Windows.Forms.NumericUpDown();
            stat1 = new System.Windows.Forms.NumericUpDown();
            addToppingButton = new System.Windows.Forms.Button();
            statType1 = new System.Windows.Forms.ComboBox();
            panel3 = new System.Windows.Forms.Panel();
            statType3 = new System.Windows.Forms.ComboBox();
            tbxStat3 = new System.Windows.Forms.Panel();
            statType2 = new System.Windows.Forms.ComboBox();
            panel4 = new System.Windows.Forms.Panel();
            stat2 = new System.Windows.Forms.NumericUpDown();
            toppingType = new System.Windows.Forms.ComboBox();
            resonantType = new System.Windows.Forms.ComboBox();
            panel6 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            readButton = new System.Windows.Forms.Button();
            screenshotButton = new System.Windows.Forms.Button();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            exportButton = new System.Windows.Forms.Button();
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            scannedList = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)stat3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stat1).BeginInit();
            panel3.SuspendLayout();
            tbxStat3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stat2).BeginInit();
            panel6.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // stat3
            // 
            stat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            stat3.DecimalPlaces = 1;
            stat3.Dock = System.Windows.Forms.DockStyle.Right;
            stat3.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            stat3.Location = new System.Drawing.Point(137, 0);
            stat3.Margin = new System.Windows.Forms.Padding(0);
            stat3.Name = "stat3";
            stat3.Size = new System.Drawing.Size(115, 29);
            stat3.TabIndex = 7;
            // 
            // stat1
            // 
            stat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            stat1.DecimalPlaces = 1;
            stat1.Dock = System.Windows.Forms.DockStyle.Right;
            stat1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            stat1.Location = new System.Drawing.Point(137, 0);
            stat1.Margin = new System.Windows.Forms.Padding(0);
            stat1.Name = "stat1";
            stat1.Size = new System.Drawing.Size(115, 29);
            stat1.TabIndex = 6;
            // 
            // addToppingButton
            // 
            addToppingButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            addToppingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            addToppingButton.Location = new System.Drawing.Point(4, 601);
            addToppingButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            addToppingButton.Name = "addToppingButton";
            addToppingButton.Size = new System.Drawing.Size(252, 53);
            addToppingButton.TabIndex = 11;
            addToppingButton.Text = "Add topping";
            addToppingButton.UseVisualStyleBackColor = true;
            addToppingButton.Click += btnAddTopping_Click;
            // 
            // statType1
            // 
            statType1.BackColor = System.Drawing.SystemColors.Window;
            statType1.Dock = System.Windows.Forms.DockStyle.Left;
            statType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            statType1.FormattingEnabled = true;
            statType1.Items.AddRange(new object[] { "Amplify Buff", "ATK SPD", "ATK%", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist", "HP%" });
            statType1.Location = new System.Drawing.Point(0, 0);
            statType1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            statType1.Name = "statType1";
            statType1.Size = new System.Drawing.Size(132, 29);
            statType1.TabIndex = 6;
            statType1.SelectedIndexChanged += statType1_SelectedIndexChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(statType1);
            panel3.Controls.Add(stat1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(4, 260);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(252, 34);
            panel3.TabIndex = 10;
            // 
            // statType3
            // 
            statType3.Dock = System.Windows.Forms.DockStyle.Left;
            statType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            statType3.FormattingEnabled = true;
            statType3.Items.AddRange(new object[] { "Amplify Buff", "ATK SPD", "ATK%", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist", "HP%" });
            statType3.Location = new System.Drawing.Point(0, 0);
            statType3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            statType3.Name = "statType3";
            statType3.Size = new System.Drawing.Size(132, 29);
            statType3.TabIndex = 6;
            // 
            // tbxStat3
            // 
            tbxStat3.Controls.Add(stat3);
            tbxStat3.Controls.Add(statType3);
            tbxStat3.Dock = System.Windows.Forms.DockStyle.Fill;
            tbxStat3.Location = new System.Drawing.Point(4, 558);
            tbxStat3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbxStat3.Name = "tbxStat3";
            tbxStat3.Size = new System.Drawing.Size(252, 34);
            tbxStat3.TabIndex = 9;
            // 
            // statType2
            // 
            statType2.Dock = System.Windows.Forms.DockStyle.Left;
            statType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            statType2.FormattingEnabled = true;
            statType2.Items.AddRange(new object[] { "Amplify Buff", "ATK SPD", "ATK%", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist", "HP%" });
            statType2.Location = new System.Drawing.Point(0, 0);
            statType2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            statType2.Name = "statType2";
            statType2.Size = new System.Drawing.Size(132, 29);
            statType2.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Controls.Add(stat2);
            panel4.Controls.Add(statType2);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(4, 409);
            panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(252, 34);
            panel4.TabIndex = 8;
            // 
            // stat2
            // 
            stat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            stat2.DecimalPlaces = 1;
            stat2.Dock = System.Windows.Forms.DockStyle.Right;
            stat2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            stat2.Location = new System.Drawing.Point(137, 0);
            stat2.Margin = new System.Windows.Forms.Padding(0);
            stat2.Name = "stat2";
            stat2.Size = new System.Drawing.Size(115, 29);
            stat2.TabIndex = 7;
            // 
            // toppingType
            // 
            toppingType.Dock = System.Windows.Forms.DockStyle.Right;
            toppingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toppingType.FormattingEnabled = true;
            toppingType.Items.AddRange(new object[] { "Caramel", "Almond", "Raspberry", "Chocolate", "Apple Jelly", "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi" });
            toppingType.Location = new System.Drawing.Point(157, 0);
            toppingType.Margin = new System.Windows.Forms.Padding(0);
            toppingType.Name = "toppingType";
            toppingType.Size = new System.Drawing.Size(95, 29);
            toppingType.TabIndex = 7;
            // 
            // resonantType
            // 
            resonantType.Dock = System.Windows.Forms.DockStyle.Left;
            resonantType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resonantType.FormattingEnabled = true;
            resonantType.Items.AddRange(new object[] { "", "Moonkissed", "Triple Cone Cup Trio", "Dragonic", "Tropical Rock", "Sea Salt", "Radiant Cheese", "Frosted Crystal", "Life-sprouting", "Destructive", "Fragrant", "Iris Gem", "Deceitful", "Truthful", "Sacred Vow", "Flaming", "Indolent", "Passionate", "Fuzzy Wuzzy", "Seafarer", "Destined", "Silent", "Blooming" });
            resonantType.Location = new System.Drawing.Point(0, 0);
            resonantType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            resonantType.Name = "resonantType";
            resonantType.Size = new System.Drawing.Size(154, 29);
            resonantType.TabIndex = 7;
            resonantType.SelectedIndexChanged += drpResonantType_SelectedIndexChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(toppingType);
            panel6.Controls.Add(resonantType);
            panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(4, 111);
            panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(252, 34);
            panel6.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label7.Location = new System.Drawing.Point(4, 448);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(252, 105);
            label7.TabIndex = 6;
            label7.Text = "Stat 3";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label5.Location = new System.Drawing.Point(4, 299);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(252, 105);
            label5.TabIndex = 4;
            label5.Text = "Stat 2";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label3.Location = new System.Drawing.Point(4, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(252, 105);
            label3.TabIndex = 2;
            label3.Text = "Stat 1";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label1.Location = new System.Drawing.Point(4, 1);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(252, 105);
            label1.TabIndex = 0;
            label1.Text = "Topping Type";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(addToppingButton, 0, 8);
            tableLayoutPanel2.Controls.Add(panel3, 0, 3);
            tableLayoutPanel2.Controls.Add(tbxStat3, 0, 7);
            tableLayoutPanel2.Controls.Add(panel4, 0, 5);
            tableLayoutPanel2.Controls.Add(panel6, 0, 1);
            tableLayoutPanel2.Controls.Add(label7, 0, 6);
            tableLayoutPanel2.Controls.Add(label5, 0, 4);
            tableLayoutPanel2.Controls.Add(label3, 0, 2);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(461, 0);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 9;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            tableLayoutPanel2.Size = new System.Drawing.Size(260, 659);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // readButton
            // 
            readButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            readButton.Dock = System.Windows.Forms.DockStyle.Fill;
            readButton.Location = new System.Drawing.Point(156, 5);
            readButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            readButton.Name = "readButton";
            readButton.Size = new System.Drawing.Size(145, 53);
            readButton.TabIndex = 5;
            readButton.Text = "Read";
            readButton.UseVisualStyleBackColor = true;
            // 
            // screenshotButton
            // 
            screenshotButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            screenshotButton.Dock = System.Windows.Forms.DockStyle.Fill;
            screenshotButton.Location = new System.Drawing.Point(4, 5);
            screenshotButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            screenshotButton.Name = "screenshotButton";
            screenshotButton.Size = new System.Drawing.Size(145, 53);
            screenshotButton.TabIndex = 6;
            screenshotButton.Text = "Screenshot";
            screenshotButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Controls.Add(readButton, 1, 0);
            tableLayoutPanel1.Controls.Add(exportButton, 2, 0);
            tableLayoutPanel1.Controls.Add(screenshotButton, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 596);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            tableLayoutPanel1.Size = new System.Drawing.Size(458, 63);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // exportButton
            // 
            exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            exportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            exportButton.Location = new System.Drawing.Point(308, 5);
            exportButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            exportButton.Name = "exportButton";
            exportButton.Size = new System.Drawing.Size(146, 53);
            exportButton.TabIndex = 4;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(458, 659);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Top;
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(233, 21);
            label2.TabIndex = 6;
            label2.Text = "Scanned Toppings";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoScroll = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(scannedList, 0, 1);
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            tableLayoutPanel3.Location = new System.Drawing.Point(724, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.91805744F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.08194F));
            tableLayoutPanel3.Size = new System.Drawing.Size(239, 659);
            tableLayoutPanel3.TabIndex = 8;
            tableLayoutPanel3.Paint += tableLayoutPanel3_Paint;
            // 
            // scannedList
            // 
            scannedList.AcceptsReturn = true;
            scannedList.AcceptsTab = true;
            scannedList.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            scannedList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            scannedList.Dock = System.Windows.Forms.DockStyle.Top;
            scannedList.Location = new System.Drawing.Point(3, 41);
            scannedList.MaxLength = int.MaxValue;
            scannedList.Multiline = true;
            scannedList.Name = "scannedList";
            scannedList.ReadOnly = true;
            scannedList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            scannedList.Size = new System.Drawing.Size(233, 615);
            scannedList.TabIndex = 8;
            scannedList.Text = "None";
            scannedList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Scanner
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(963, 659);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Scanner";
            Text = "Topping Scanner";
            Load += Scanner_Load;
            ((System.ComponentModel.ISupportInitialize)stat3).EndInit();
            ((System.ComponentModel.ISupportInitialize)stat1).EndInit();
            panel3.ResumeLayout(false);
            tbxStat3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stat2).EndInit();
            panel6.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);

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
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button screenshotButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox scannedList;
    }
}

