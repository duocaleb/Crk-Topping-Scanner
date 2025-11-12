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
            panel1 = new System.Windows.Forms.Panel();
            panel7 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            itemSelector = new System.Windows.Forms.ComboBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            readButton = new System.Windows.Forms.Button();
            exportButton = new System.Windows.Forms.Button();
            screenshotButton = new System.Windows.Forms.Button();
            tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            tbxStat3 = new System.Windows.Forms.Panel();
            stat3 = new System.Windows.Forms.NumericUpDown();
            statType3 = new System.Windows.Forms.ComboBox();
            panel4 = new System.Windows.Forms.Panel();
            stat2 = new System.Windows.Forms.NumericUpDown();
            statType2 = new System.Windows.Forms.ComboBox();
            panel3 = new System.Windows.Forms.Panel();
            statType1 = new System.Windows.Forms.ComboBox();
            stat1 = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            panel6 = new System.Windows.Forms.Panel();
            toppingType = new System.Windows.Forms.ComboBox();
            resonantType = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            scannedImage = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            scannedList = new System.Windows.Forms.TextBox();
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            btnAddTopping = new System.Windows.Forms.Button();
            panel8 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tbxStat3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stat3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stat2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stat1).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scannedImage).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(scannedImage);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(514, 649);
            panel1.TabIndex = 12;
            // 
            // panel7
            // 
            panel7.Controls.Add(panel2);
            panel7.Controls.Add(tableLayoutPanel4);
            panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel7.Location = new System.Drawing.Point(0, 469);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(514, 180);
            panel7.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel2.Location = new System.Drawing.Point(0, 89);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(514, 91);
            panel2.TabIndex = 8;
            // 
            // panel5
            // 
            panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel5.Controls.Add(label4);
            panel5.Controls.Add(itemSelector);
            panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            panel5.Location = new System.Drawing.Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(514, 34);
            panel5.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = System.Windows.Forms.DockStyle.Left;
            label4.Location = new System.Drawing.Point(0, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(150, 21);
            label4.TabIndex = 9;
            label4.Text = "Currently Scanning: ";
            // 
            // itemSelector
            // 
            itemSelector.Dock = System.Windows.Forms.DockStyle.Right;
            itemSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            itemSelector.FormattingEnabled = true;
            itemSelector.Items.AddRange(new object[] { "Toppings", "Beascuits", "Tarts" });
            itemSelector.Location = new System.Drawing.Point(153, 0);
            itemSelector.Margin = new System.Windows.Forms.Padding(0);
            itemSelector.Name = "itemSelector";
            itemSelector.Size = new System.Drawing.Size(359, 29);
            itemSelector.TabIndex = 7;
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
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            tableLayoutPanel1.Size = new System.Drawing.Size(514, 57);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // readButton
            // 
            readButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            readButton.Dock = System.Windows.Forms.DockStyle.Fill;
            readButton.Location = new System.Drawing.Point(172, 1);
            readButton.Margin = new System.Windows.Forms.Padding(0);
            readButton.Name = "readButton";
            readButton.Size = new System.Drawing.Size(170, 55);
            readButton.TabIndex = 5;
            readButton.Text = "Read";
            readButton.UseVisualStyleBackColor = true;
            readButton.Click += readButton_Click;
            // 
            // exportButton
            // 
            exportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            exportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            exportButton.Location = new System.Drawing.Point(343, 1);
            exportButton.Margin = new System.Windows.Forms.Padding(0);
            exportButton.Name = "exportButton";
            exportButton.Size = new System.Drawing.Size(170, 55);
            exportButton.TabIndex = 4;
            exportButton.Text = "Export";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // screenshotButton
            // 
            screenshotButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            screenshotButton.Dock = System.Windows.Forms.DockStyle.Fill;
            screenshotButton.Location = new System.Drawing.Point(1, 1);
            screenshotButton.Margin = new System.Windows.Forms.Padding(0);
            screenshotButton.Name = "screenshotButton";
            screenshotButton.Size = new System.Drawing.Size(170, 55);
            screenshotButton.TabIndex = 6;
            screenshotButton.Text = "Screenshot";
            screenshotButton.UseVisualStyleBackColor = true;
            screenshotButton.Click += screenshotButton_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel4.ColumnCount = 4;
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel4.Controls.Add(tbxStat3, 3, 1);
            tableLayoutPanel4.Controls.Add(panel4, 2, 1);
            tableLayoutPanel4.Controls.Add(panel3, 1, 1);
            tableLayoutPanel4.Controls.Add(label7, 3, 0);
            tableLayoutPanel4.Controls.Add(panel6, 0, 1);
            tableLayoutPanel4.Controls.Add(label5, 2, 0);
            tableLayoutPanel4.Controls.Add(label3, 1, 0);
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            tableLayoutPanel4.Size = new System.Drawing.Size(514, 91);
            tableLayoutPanel4.TabIndex = 9;
            // 
            // tbxStat3
            // 
            tbxStat3.Controls.Add(stat3);
            tbxStat3.Controls.Add(statType3);
            tbxStat3.Dock = System.Windows.Forms.DockStyle.Fill;
            tbxStat3.Location = new System.Drawing.Point(388, 28);
            tbxStat3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbxStat3.Name = "tbxStat3";
            tbxStat3.Size = new System.Drawing.Size(122, 58);
            tbxStat3.TabIndex = 9;
            // 
            // stat3
            // 
            stat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            stat3.DecimalPlaces = 1;
            stat3.Dock = System.Windows.Forms.DockStyle.Bottom;
            stat3.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            stat3.Location = new System.Drawing.Point(0, 29);
            stat3.Margin = new System.Windows.Forms.Padding(0);
            stat3.Name = "stat3";
            stat3.Size = new System.Drawing.Size(122, 29);
            stat3.TabIndex = 7;
            // 
            // statType3
            // 
            statType3.Dock = System.Windows.Forms.DockStyle.Top;
            statType3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            statType3.FormattingEnabled = true;
            statType3.Items.AddRange(new object[] { "Amplify Buff", "ATK SPD", "ATK%", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist", "HP%" });
            statType3.Location = new System.Drawing.Point(0, 0);
            statType3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            statType3.Name = "statType3";
            statType3.Size = new System.Drawing.Size(122, 29);
            statType3.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Controls.Add(stat2);
            panel4.Controls.Add(statType2);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(260, 28);
            panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(121, 58);
            panel4.TabIndex = 8;
            // 
            // stat2
            // 
            stat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            stat2.DecimalPlaces = 1;
            stat2.Dock = System.Windows.Forms.DockStyle.Bottom;
            stat2.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            stat2.Location = new System.Drawing.Point(0, 29);
            stat2.Margin = new System.Windows.Forms.Padding(0);
            stat2.Name = "stat2";
            stat2.Size = new System.Drawing.Size(121, 29);
            stat2.TabIndex = 7;
            // 
            // statType2
            // 
            statType2.Dock = System.Windows.Forms.DockStyle.Top;
            statType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            statType2.FormattingEnabled = true;
            statType2.Items.AddRange(new object[] { "Amplify Buff", "ATK SPD", "ATK%", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist", "HP%" });
            statType2.Location = new System.Drawing.Point(0, 0);
            statType2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            statType2.Name = "statType2";
            statType2.Size = new System.Drawing.Size(121, 29);
            statType2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(statType1);
            panel3.Controls.Add(stat1);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(132, 28);
            panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(121, 58);
            panel3.TabIndex = 10;
            // 
            // statType1
            // 
            statType1.BackColor = System.Drawing.SystemColors.Window;
            statType1.Dock = System.Windows.Forms.DockStyle.Top;
            statType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            statType1.FormattingEnabled = true;
            statType1.Items.AddRange(new object[] { "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist", "HP%" });
            statType1.Location = new System.Drawing.Point(0, 0);
            statType1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            statType1.Name = "statType1";
            statType1.Size = new System.Drawing.Size(121, 29);
            statType1.TabIndex = 6;
            // 
            // stat1
            // 
            stat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            stat1.DecimalPlaces = 1;
            stat1.Dock = System.Windows.Forms.DockStyle.Bottom;
            stat1.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            stat1.Location = new System.Drawing.Point(0, 29);
            stat1.Margin = new System.Windows.Forms.Padding(0);
            stat1.Name = "stat1";
            stat1.Size = new System.Drawing.Size(121, 29);
            stat1.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = System.Windows.Forms.DockStyle.Fill;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label7.Location = new System.Drawing.Point(388, 1);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(122, 22);
            label7.TabIndex = 6;
            label7.Text = "Stat 3";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.Controls.Add(toppingType);
            panel6.Controls.Add(resonantType);
            panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            panel6.Location = new System.Drawing.Point(4, 28);
            panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(121, 58);
            panel6.TabIndex = 6;
            // 
            // toppingType
            // 
            toppingType.Dock = System.Windows.Forms.DockStyle.Bottom;
            toppingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toppingType.FormattingEnabled = true;
            toppingType.Items.AddRange(new object[] { "Caramel", "Almond", "Raspberry", "Chocolate", "Apple Jelly", "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi" });
            toppingType.Location = new System.Drawing.Point(0, 29);
            toppingType.Margin = new System.Windows.Forms.Padding(0);
            toppingType.Name = "toppingType";
            toppingType.Size = new System.Drawing.Size(121, 29);
            toppingType.TabIndex = 7;
            // 
            // resonantType
            // 
            resonantType.Dock = System.Windows.Forms.DockStyle.Top;
            resonantType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resonantType.FormattingEnabled = true;
            resonantType.Items.AddRange(new object[] { "", "Moonkissed", "Triple Cone Cup Trio", "Dragonic", "Tropical Rock", "Sea Salt", "Radiant Cheese", "Frosted Crystal", "Life-sprouting", "Destructive", "Fragrant", "Iris Gem", "Deceitful", "Truthful", "Sacred Vow", "Flaming", "Indolent", "Passionate", "Fuzzy Wuzzy", "Seafarer", "Destined", "Silent", "Blooming" });
            resonantType.Location = new System.Drawing.Point(0, 0);
            resonantType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            resonantType.Name = "resonantType";
            resonantType.Size = new System.Drawing.Size(121, 29);
            resonantType.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = System.Windows.Forms.DockStyle.Fill;
            label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F);
            label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            label5.Location = new System.Drawing.Point(260, 1);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(121, 22);
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
            label3.Location = new System.Drawing.Point(132, 1);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(121, 22);
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
            label1.Size = new System.Drawing.Size(121, 22);
            label1.TabIndex = 0;
            label1.Text = "Topping Type";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scannedImage
            // 
            scannedImage.Dock = System.Windows.Forms.DockStyle.Top;
            scannedImage.Location = new System.Drawing.Point(0, 0);
            scannedImage.Name = "scannedImage";
            scannedImage.Size = new System.Drawing.Size(514, 467);
            scannedImage.TabIndex = 6;
            scannedImage.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(5, 2);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(224, 34);
            label2.TabIndex = 6;
            label2.Text = "Scanned Pieces";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scannedList
            // 
            scannedList.AcceptsReturn = true;
            scannedList.AcceptsTab = true;
            scannedList.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            scannedList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            scannedList.Dock = System.Windows.Forms.DockStyle.Fill;
            scannedList.Location = new System.Drawing.Point(5, 41);
            scannedList.MaxLength = int.MaxValue;
            scannedList.Multiline = true;
            scannedList.Name = "scannedList";
            scannedList.ReadOnly = true;
            scannedList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            scannedList.Size = new System.Drawing.Size(224, 545);
            scannedList.TabIndex = 8;
            scannedList.TabStop = false;
            scannedList.Text = "None";
            scannedList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(scannedList, 0, 1);
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.91805744F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.08194F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new System.Drawing.Size(234, 591);
            tableLayoutPanel3.TabIndex = 11;
            // 
            // btnAddTopping
            // 
            btnAddTopping.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btnAddTopping.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnAddTopping.Location = new System.Drawing.Point(0, 591);
            btnAddTopping.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnAddTopping.Name = "btnAddTopping";
            btnAddTopping.Size = new System.Drawing.Size(234, 58);
            btnAddTopping.TabIndex = 11;
            btnAddTopping.Text = "Add Item";
            btnAddTopping.UseVisualStyleBackColor = true;
            btnAddTopping.Click += btnAddTopping_Click;
            // 
            // panel8
            // 
            panel8.Controls.Add(tableLayoutPanel3);
            panel8.Controls.Add(btnAddTopping);
            panel8.Dock = System.Windows.Forms.DockStyle.Right;
            panel8.Location = new System.Drawing.Point(516, 0);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(234, 649);
            panel8.TabIndex = 11;
            // 
            // Scanner
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 649);
            Controls.Add(panel8);
            Controls.Add(panel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Scanner";
            Text = "Topping Scanner";
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tbxStat3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stat3).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stat2).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stat1).EndInit();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scannedImage).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel8.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox scannedImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox scannedList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button screenshotButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox itemSelector;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnAddTopping;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox statType1;
        private System.Windows.Forms.NumericUpDown stat1;
        private System.Windows.Forms.Panel tbxStat3;
        private System.Windows.Forms.NumericUpDown stat3;
        private System.Windows.Forms.ComboBox statType3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown stat2;
        private System.Windows.Forms.ComboBox statType2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox toppingType;
        private System.Windows.Forms.ComboBox resonantType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
    }
}

