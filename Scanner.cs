using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tesseract;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Application = System.Windows.Forms.Application;
using ComboBox = System.Windows.Forms.ComboBox;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;


namespace Crk_Topping_Scanner
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]


    public partial class Scanner : Form
    {
        private List<string> TenToppingResonants;
        private List<string> ToppingSubstats;
        private List<string> BeascuitsSubstats;
        private List<string> TartSubstats;
        private List<string> toppingRes;
        private List<string> toppingTypes;
        private List<string> resToppingTypes;
        private List<string> beascuitRes;
        private List<string> beascuitTypes;
        private List<ComboBox> comboBoxes;
        private List<NumericUpDown> numericUpDowns;
        private Dictionary<string, (double, double)> subStatLimits = new Dictionary<string, (double, double)>();
        private List<Iitem> toppingsExportList = new List<Iitem>();
        private Bitmap bmpScreenshot = new Bitmap(1, 1);
        private (int, int)? scanRoot;
        private Dictionary<string, string> typeToMain = new Dictionary<string, string>();
        private Dictionary<string, string> beascuitResToMain = new Dictionary<string, string>();
        private TesseractEngine engine = new TesseractEngine(@Path.Combine(Application.StartupPath, "tessdata"), "eng", EngineMode.LstmOnly);
        private Bitmap[] bmpCollection = new Bitmap[5];
        private PrivateFontCollection privateFonts = new PrivateFontCollection();
        private FontFamily cookieRunFont;
        private List<Bitmap> BitmapGraphics = new List<Bitmap>();

        public Scanner()
        {
            InitializeComponent();

            privateFonts.AddFontFile(Path.Combine(Application.StartupPath, "CookieRun Black.ttf"));
            cookieRunFont = (FontFamily)privateFonts.Families[0];
            TenToppingResonants = new List<string> { "Destined", "Silent", "Blooming", "" };
            comboBoxes = new List<ComboBox> { statType1, statType2, statType3, statType4 };
            numericUpDowns = new List<NumericUpDown> { stat1, stat2, stat3, stat4 };
            ToppingSubstats = new List<string> { "", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "HP" };
            BeascuitsSubstats = new List<string> { "", "Unattuned", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "DMG Resist Bypass" };
            toppingTypes = new List<string> { "", "Raspberry", "Caramel", "Apple Jelly", "Chocolate", "Almond", "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi" };
            resToppingTypes = new List<string> { "", "Raspberry", "Caramel", "Apple Jelly", "Chocolate", "Almond" };
            toppingRes = new List<string> { "", "Blooming", "Silent", "Destined", "Seafarer", "Fuzzy Wuzzy", "Passionate", "Indolent", "Flaming", "Sacred Vow", "Truthful", "Deceitful", "Iris Gem", "Fragrant", "Destructive", "Life-sprouting", "Frosted Crystal", "Radiant Cheese", "Sea Salt", "Tropical Rock", "Triple Cone Cup", "Moonkissed" };
            beascuitRes = new List<string> { "", "Dark", "Thunderous", "Burning", "Earthen", "Poisonous", "Gleaming", "Surging", "Frozen", "Steelen", "Verdant", "Wuthering" };
            beascuitTypes = new List<string> { "", "Sweet", "Hearty", "Zesty", "Spicy", "Light", "Chewy", "Hard", "Crispy" };
            typeToMain = new Dictionary<string, string>()
            {
                {"Raspberry", "ATK"},
                {"Caramel", "ATK SPD"},
                {"Apple Jelly", "CRIT%"},
                {"Chocolate", "Cooldown"},
                {"Almond", "DMG Resist"},
                {"Walnut", "DEF"},
                {"Peanut", "HP"},
                {"Hazelnut", "CRIT Resist"},
                {"Candy", "Amplify Buff"},
                {"Kiwi", "Debuff Resist"}
            };
            beascuitResToMain = new Dictionary<string, string>()
            {
                { "Dark", "Dark. DMG"},
                { "Thunderous", "Elec. DMG"},
                { "Burning", "Fire DMG" },
                { "Earthen", "Earth DMG" },
                { "Poisonous", "Poison DMG" },
                { "Gleaming", "Light DMG" },
                { "Surging", "Water DMG" },
                { "Frozen", "Ice DMG" },
                { "Steelen", "Steel DMG" },
                { "Verdant", "Grass DMG" },
                { "Wuthering", "Wind DMG" }
            };

            for (int i = 0; i < bmpCollection.Length; i++)
            {
                // Create a new, non-null bitmap for each array slot
                bmpCollection[i] = new Bitmap(1, 1);
            }

            itemSelector.SelectedItem = "Toppings";
            foreach (ComboBox combo in comboBoxes)
            {
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged_1;
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void resonantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemSelector.Text == "Toppings")
            {
                ComboBox resBox = (ComboBox)sender;
                if (resBox.Text != "")
                {
                    ToppingSubstats = new List<string> { "", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "DMG Resist" };
                    subStatLimits["ATK SPD"] = (2.0, 3.0);
                    subStatLimits["ATK"] = (2.0, 3.0);
                    subStatLimits["Cooldown"] = (1.5, 2.0);
                    subStatLimits["CRIT Resist"] = (3.5, 4.0);
                    subStatLimits["DMG Resist"] = (4.5, 6.0);
                    subStatLimits["CRIT%"] = (2.0, 3.0);
                    for (int i = 0; i < comboBoxes.Count; i++)
                    {
                        var combo = comboBoxes[i];
                        var numUpDown = numericUpDowns[i];
                        var selectedItem = combo.SelectedItem?.ToString();
                        var numVal = numUpDown.Value;
                        //combo.Refresh();
                        RefreshComboBoxManually(combo, ToppingSubstats);
                        if (ToppingSubstats.Contains(selectedItem))
                        {
                            combo.SelectedItem = selectedItem;
                        }
                        if (numVal > numUpDown.Minimum && numVal <= numUpDown.Maximum)
                        {
                            numUpDown.Value = numVal;
                        }
                    }
                }
                else
                {
                    ToppingSubstats = new List<string> { "", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "HP" };
                    subStatLimits["ATK SPD"] = (1.0, 3.0);
                    subStatLimits["ATK"] = (1.0, 3.0);
                    subStatLimits["Cooldown"] = (1.0, 2.0);
                    subStatLimits["CRIT Resist"] = (3.0, 4.0);
                    subStatLimits["DMG Resist"] = (1.0, 6.0);
                    subStatLimits["CRIT%"] = (1.0, 3.0);
                    for (int i = 0; i < comboBoxes.Count; i++)
                    {
                        var combo = comboBoxes[i];
                        var numUpDown = numericUpDowns[i];
                        var selectedItem = combo.SelectedItem?.ToString();
                        var numVal = numUpDown.Value;
                        RefreshComboBoxManually(combo, ToppingSubstats);
                        if (ToppingSubstats.Contains(selectedItem))
                        {
                            combo.SelectedItem = selectedItem;
                        }
                        if (numVal > numUpDown.Minimum && numVal <= numUpDown.Maximum)
                        {
                            numUpDown.Value = numVal;
                        }
                    }
                }
                if (TenToppingResonants.Contains(resBox.Text))
                {
                    string currentType = toppingType.Text;
                    RefreshComboBoxManually(toppingType, toppingTypes);
                    if (toppingTypes.Contains(currentType))
                    {
                        toppingType.SelectedItem = currentType;
                    }
                }
                else
                {
                    string currentType = toppingType.Text;
                    RefreshComboBoxManually(toppingType, resToppingTypes);
                    if (toppingTypes.Contains(currentType))
                    {
                        toppingType.SelectedItem = currentType;
                    }
                }
            }
            else if (itemSelector.Text == "Beascuits")
            {
                if (resonantType.Text != "")
                {

                    if (isTainted.Checked)
                    {
                        RefreshComboBoxManually(statType1, new List<string> { beascuitResToMain[resonantType.Text] });
                        statType1.SelectedItem = beascuitResToMain[resonantType.Text];
                        stat1.Minimum = 20;
                        stat1.Maximum = 20;
                        statType1.Enabled = false;
                        stat1.Enabled = false;
                        for (int i = 1; i < comboBoxes.Count(); i++)
                        {
                            List<string> beascuitSubsNew = new List<string>(BeascuitsSubstats).ToList();
                            string comboText = comboBoxes[i].Text;
                            RefreshComboBoxManually(comboBoxes[i], beascuitSubsNew);
                            if (comboBoxes[i].Items.Contains(comboText))
                            {
                                comboBoxes[i].SelectedItem = comboText;
                            }
                        }
                    }
                    else
                    {
                        statType1.Enabled = true;
                        stat1.Enabled = true;
                        foreach (ComboBox combo in comboBoxes)
                        {
                            List<string> beascuitSubsNew = new List<string>(BeascuitsSubstats).Append(beascuitResToMain[resonantType.Text]).ToList();
                            string comboText = combo.Text;
                            RefreshComboBoxManually(combo, beascuitSubsNew);
                            if (combo.Items.Contains(comboText))
                            {
                                combo.SelectedItem = comboText;
                            }
                        }
                    }
                }
                else
                {
                    foreach (ComboBox combo in comboBoxes)
                    {
                        List<string> beascuitSubsNew = new List<string>(BeascuitsSubstats);
                        string comboText = combo.Text;
                        RefreshComboBoxManually(combo, beascuitSubsNew);
                        if (combo.Items.Contains(comboText))
                        {
                            combo.SelectedItem = comboText;
                        }
                    }
                    statType1.Enabled = true;
                    stat1.Enabled = true;
                }

            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {

            string json = JsonSerializer.Serialize(toppingsExportList, new JsonSerializerOptions { WriteIndented = true });
            string filePath = Path.Combine(Application.StartupPath, "Crk-Exports\\" + "crkExport" + DateTime.Now.ToString("yyyyMMddhmmss") + ".json");
            File.WriteAllText(filePath, json);

        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBoxes.Count; i++)
            {
                ComboBox combo = comboBoxes[i];
                NumericUpDown numUpDown = numericUpDowns[i];
                var selectedItems = comboBoxes
                    .Except(new List<ComboBox> { combo })
                    .Select(c => c.SelectedItem?.ToString())
                    .Where(item => !string.IsNullOrEmpty(item))
                    .ToList();
                var availableItems = ToppingSubstats.Except(selectedItems).ToList();
                var currentSelection = combo.SelectedItem?.ToString();
                combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                RefreshComboBoxManually(combo, new List<string>(availableItems));
                combo.SelectedItem = currentSelection;
                if (availableItems.Contains(currentSelection))
                {
                    combo.SelectedItem = currentSelection;
                }
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }

        private void ComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int index = int.Parse(char.ToString(((ComboBox)sender).Name.Last())) - 1;
            NumericUpDown numUpDown = numericUpDowns[index];
            var numVal = numUpDown.Value;

            var currentSelection = comboBoxes[index].SelectedItem?.ToString();

            numUpDown.Minimum = ((decimal)subStatLimits[currentSelection].Item1);
            numUpDown.Maximum = ((decimal)subStatLimits[currentSelection].Item2);

            if (numVal > numUpDown.Minimum && numVal <= numUpDown.Maximum)
            {
                numUpDown.Value = numVal;
            }
        }


        private void screenshotButton_Click(object sender, EventArgs e)
        {
            takeScreenshot();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            readScreenshot(1, false);
        }



        //code from switchonthecode, edits pixel's byte to be fast.
        public static Bitmap preprocImage(Bitmap original)
        {
            unsafe
            {
                //create an empty bitmap the same size as original
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);

                //lock the original bitmap in memory
                BitmapData originalData = original.LockBits(
                   new Rectangle(0, 0, original.Width, original.Height),
                   ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                //lock the new bitmap in memory
                BitmapData newData = newBitmap.LockBits(
                   new Rectangle(0, 0, original.Width, original.Height),
                   ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                //set the number of bytes per pixel
                int pixelSize = 3;

                for (int y = 0; y < original.Height; y++)
                {
                    //get the data from the original image
                    byte* oRow = (byte*)originalData.Scan0 + (y * originalData.Stride);

                    //get the data from the new image
                    byte* nRow = (byte*)newData.Scan0 + (y * newData.Stride);

                    for (int x = 0; x < original.Width; x++)
                    {
                        byte pixCol;
                        if ((oRow[x * pixelSize] * .11) +
                           (oRow[x * pixelSize + 1] * .59) +
                           (oRow[x * pixelSize + 2] * .3) >= 200) // Combining grayscale and bounding into one step
                        {
                            pixCol = 255;
                        }
                        else
                        {
                            pixCol = 0;
                        }


                        //set the new image's pixel to the grayscale version
                        nRow[x * pixelSize] = pixCol; //B
                        nRow[x * pixelSize + 1] = pixCol; //G
                        nRow[x * pixelSize + 2] = pixCol; //R
                    }
                }

                //unlock the bitmaps
                newBitmap.UnlockBits(newData);
                original.UnlockBits(originalData);

                return newBitmap;
            }
        }


        private void itemSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            statType1.Enabled = true;
            stat1.Enabled = true;
            if (itemSelector.Text == "Toppings")
            {
                resonantType.Enabled = true;
                RefreshComboBoxManually(resonantType, new List<string>(toppingRes));
                RefreshComboBoxManually(toppingType, new List<string>(toppingTypes));
                label1.Text = "Topping Type";
                tableLayoutPanel4.ColumnStyles[0].Width = 25;
                tableLayoutPanel4.ColumnStyles[1].Width = 0;
                tableLayoutPanel4.ColumnStyles[2].Width = 25;
                tableLayoutPanel4.ColumnStyles[3].Width = 25;
                tableLayoutPanel4.ColumnStyles[4].Width = 25;
                tableLayoutPanel4.ColumnStyles[5].Width = 0;
                isTainted.Width = 0;
                subStatLimits = new Dictionary<string, (double, double)>()
                {
                    {"Amplify Buff", (1.0, 2.0)},
                    {"ATK", (1.0, 3.0)},
                    {"ATK SPD", (1.0, 3.0)},
                    {"Cooldown", (1.0, 2.0)},
                    {"CRIT Resist", (3.0, 4.0)},
                    {"Debuff Resist", (1.0, 2.0)},
                    {"DEF", (1.0, 3.0)},
                    {"DMG Resist", (1.0, 6.0)},
                    {"HP", (1.0, 3.0)},
                    {"CRIT%", (1.0, 3.0)},
                    {"DMG Resist Bypass", (5.0, 15.0)},
                    {"", (0, 0)}
                };
                foreach (var combo in comboBoxes)
                {
                    RefreshComboBoxManually(combo, new List<string>(ToppingSubstats));
                    combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
            else if (itemSelector.Text == "Beascuits")
            {
                resonantType.Enabled = true;
                RefreshComboBoxManually(resonantType, new List<string>(beascuitRes));
                RefreshComboBoxManually(toppingType, new List<string>(beascuitTypes));
                label1.Text = "Beascuit Type";
                tableLayoutPanel4.ColumnStyles[1].SizeType = SizeType.Percent;
                tableLayoutPanel4.ColumnStyles[0].Width = 20;
                tableLayoutPanel4.ColumnStyles[1].Width = 20;
                tableLayoutPanel4.ColumnStyles[2].Width = 20;
                tableLayoutPanel4.ColumnStyles[3].Width = 20;
                tableLayoutPanel4.ColumnStyles[4].Width = 20;
                tableLayoutPanel4.ColumnStyles[5].Width = 20;
                isTainted.Width = (int)(tableLayoutPanel4.ClientSize.Width * 0.2);
                subStatLimits = new Dictionary<string, (double, double)>()
                {
                    {"Amplify Buff", (2.0, 5.0)},
                    {"ATK", (3.0, 7.5)},
                    {"ATK SPD", (3.0, 10.0)},
                    {"Cooldown", (2.0, 6.0)},
                    {"CRIT Resist", (4.0, 10.0)},
                    {"Debuff Resist", (2.0, 5.0)},
                    {"DEF", (5.0, 7.5)},
                    {"DMG Resist", (5.0, 10.0)},
                    {"HP", (3.0, 15.0)},
                    {"CRIT%", (3.0, 7.0)},
                    {"DMG Resist Bypass", (5.0, 15.0)},
                    {"", (0, 0)},
                    {"Unattuned", (0, 0)}
                };
                foreach (string stat in beascuitResToMain.Values)
                {
                    subStatLimits.Add(stat, (8.0, 15.0));
                }
                foreach (var combo in comboBoxes)
                {
                    combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    RefreshComboBoxManually(combo, new List<string>(BeascuitsSubstats));
                }

            }
            else if (itemSelector.Text == "Tarts")
            {
                resonantType.SelectedItem = "";
                resonantType.Enabled = false;
                RefreshComboBoxManually(toppingType, new List<string>(toppingTypes));
                label1.Text = "Tart Type";
                subStatLimits = new Dictionary<string, (double, double)>()
                {
                    {"Amplify Buff", (6.0, 10.0)},
                    {"ATK", (7.2, 12.0)},
                    {"ATK SPD", (5.4, 9.0)},
                    {"Cooldown", (3.0, 5.0)},
                    {"CRIT Resist", (9.0, 15.0)},
                    {"Debuff Resist", (6.0, 10.0)},
                    {"DEF", (12.0, 20.0)},
                    {"DMG Resist", (6.0, 10.0)},
                    {"HP", (7.8, 13.0)},
                    {"CRIT%", (6.6, 11.0)},
                    {"", (0, 0)}
                };
                tableLayoutPanel4.ColumnStyles[0].Width = 50;
                tableLayoutPanel4.ColumnStyles[1].Width = 0;
                tableLayoutPanel4.ColumnStyles[2].Width = 50;
                tableLayoutPanel4.ColumnStyles[3].Width = 0;
                tableLayoutPanel4.ColumnStyles[4].Width = 0;
                tableLayoutPanel4.ColumnStyles[5].Width = 0;
                isTainted.Width = 0;

                foreach (var combo in comboBoxes)
                {
                    combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    RefreshComboBoxManually(combo, new List<string>(ToppingSubstats));
                }
            }
        }

        private void toppingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemSelector.Text == "Tarts" && toppingType.Text != "")
            {
                statType1.SelectedItem = typeToMain[toppingType.Text];
            }
        }

        private void isTainted_CheckedChanged(object sender, EventArgs e)
        {
            if (resonantType.Text != "")
            {
                if (isTainted.Checked)
                {

                    RefreshComboBoxManually(statType1, new List<string> { beascuitResToMain[resonantType.Text] });
                    statType1.SelectedItem = beascuitResToMain[resonantType.Text];
                    stat1.Minimum = 20;
                    stat1.Maximum = 20;
                    statType1.Enabled = false;
                    stat1.Enabled = false;
                    for (int i = 1; i < comboBoxes.Count(); i++)
                    {
                        List<string> beascuitSubsNew = new List<string>(BeascuitsSubstats).ToList();
                        string comboText = comboBoxes[i].Text;
                        RefreshComboBoxManually(comboBoxes[i], beascuitSubsNew);
                        if (comboBoxes[i].Items.Contains(comboText))
                        {
                            comboBoxes[i].SelectedItem = comboText;
                        }
                    }
                }
                else
                {
                    statType1.Enabled = true;
                    stat1.Enabled = true;
                    foreach (ComboBox combo in comboBoxes)
                    {
                        List<string> beascuitSubsNew = new List<string>(BeascuitsSubstats).Append(beascuitResToMain[resonantType.Text]).ToList();
                        string comboText = combo.Text;
                        RefreshComboBoxManually(combo, beascuitSubsNew);
                        if (combo.Items.Contains(comboText))
                        {
                            combo.SelectedItem = comboText;
                        }
                    }
                }
            }
        }

        private void scannedImage_Click(object sender, EventArgs e)
        {

        }
        private void AddItem()
        {
            if (itemSelector.Text == "Toppings")
            {
                if (toppingType.Text == "")
                {
                    MessageBox.Show(
                        "Missing topping type.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else if (new List<string> { statType1.Text, statType2.Text, statType3.Text }.Any(n => n == ""))
                {
                    MessageBox.Show(
                        "Missing topping substat. Please ensure your topping is epic and is fully upgraded.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    Topping newTopping = new Topping()
                    {
                        ResonantType = resonantType.Text,
                        ToppingType = toppingType.Text,
                        Stat1Value = double.Parse(stat1.Text),
                        Stat2Value = double.Parse(stat2.Text),
                        Stat3Value = double.Parse(stat3.Text),
                        Stat1 = statType1.Text,
                        Stat2 = statType2.Text,
                        Stat3 = statType3.Text
                    };
                    toppingsExportList.Add(newTopping);
                    BitmapGraphics.Add(createCompactGraphic(newTopping));
                    if (recentScanImg.Image != null)
                    {
                        recentScanImg.Image.Dispose();
                    }
                    recentScanImg.Image = createGraphic(newTopping);
                }
            }
            else if (itemSelector.Text == "Beascuits")
            {
                if (toppingType.Text == "")
                {
                    MessageBox.Show(
                        "Missing topping type.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else if (new List<string> { statType1.Text, statType2.Text, statType3.Text, statType4.Text }.Any(n => n == ""))
                {
                    MessageBox.Show(
                        "Missing Beascuit substat. Please ensure you select \"unattuned\" for all unattuned slots.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    Beascuit newBeascuit = new Beascuit()
                    {
                        Tainted = isTainted.Checked,
                        ResonantType = resonantType.Text,
                        BeascuitType = toppingType.Text,
                        Stat1Value = double.Parse(stat1.Text),
                        Stat2Value = double.Parse(stat2.Text),
                        Stat3Value = double.Parse(stat3.Text),
                        Stat4Value = double.Parse(stat4.Text),
                        Stat1 = statType1.Text,
                        Stat2 = statType2.Text,
                        Stat3 = statType3.Text,
                        Stat4 = statType4.Text
                    };
                    recentScanImg.Image = createGraphic(newBeascuit);
                    toppingsExportList.Add(newBeascuit);
                    BitmapGraphics.Add(createCompactGraphic(newBeascuit));
                }
            }
        }

        private Bitmap AddPadding(Bitmap bmp, int padding, Color color)
        {
            Bitmap image = new Bitmap(bmp.Width + padding * 2, bmp.Height + padding * 2, bmp.PixelFormat);
            Graphics g = Graphics.FromImage(image);
            g.Clear(color);
            g.DrawImageUnscaled(bmp, padding, padding, bmp.Width, bmp.Height);
            g.Dispose();
            return image;
        }

        private void readScreenshot(int upScale, Boolean overrideCatch)
        {
            for (int i = 0; i < comboBoxes.Count; i++)
            {
                comboBoxes[i].SelectedItem = "";
            }
            if (itemSelector.Text == "Toppings")
            {
                double[] statValues = { 0, 0, 0 };


                try
                {
                    using (var pix = PixConverter.ToPix(bmpCollection[0]))
                    using (var page = engine.Process(pix, PageSegMode.SingleLine))
                    {
                        var text = page.GetText();
                        foreach (var resonant in resonantType.Items)
                        {
                            if (text.Contains(resonant.ToString()))
                            {
                                resonantType.SelectedItem = resonant.ToString();
                            }
                        }
                        foreach (var topType in toppingType.Items)
                        {
                            if (text.Contains(topType.ToString()))
                            {
                                toppingType.SelectedItem = topType.ToString();
                            }
                        }
                    }
                    for (int i = 1; i < 4; i++)
                    {
                        // scannedImage.Image = bmpCollection[i];
                        using (var scaledBitmap = new Bitmap(bmpCollection[i], bmpCollection[i].Width * upScale, bmpCollection[i].Height * upScale))
                        using (var pix = PixConverter.ToPix(scaledBitmap))
                        using (var page = engine.Process(pix, PageSegMode.SingleLine))
                        {

                            var text = page.GetText();
                            int lastSpace = text.LastIndexOf(' ');
                            string statName = text.Substring(0, lastSpace);
                            comboBoxes[i - 1].SelectedItem = statName;
                            double statValue = double.Parse(text.Substring(lastSpace + 1).Replace("%", ""));
                            statValues[i - 1] = statValue;
                        }
                        for (int a = 0; a < 3; a++)
                        {
                            numericUpDowns[a].Value = (decimal)statValues[a];

                        }
                    }
                }
                catch (Exception error)
                {
                    if (upScale < 10)
                    {
                        readScreenshot(upScale + 1, overrideCatch); // "are you sureeeeee you cant read it?"
                    }
                    else if (!overrideCatch)
                    {
                        MessageBox.Show(
                            "Scanner Error. Please ensure that CookieRun: Kingdom is full screen and the scanner does not cover the topping. \n Error code: " + error.ToString(),
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }

                }
            }
            else if (itemSelector.Text == "Beascuits")
            {
                // Future Implementation
            }
            else if (itemSelector.Text == "Tarts")
            {
                // Future Implementation
            }
        }
        private Bitmap AddTextToImage(Image image, string textToAdd, Font font, Brush brush, PointF location)
        {
            Bitmap originalImage = (Bitmap)image;
            using (Graphics graphics = Graphics.FromImage(originalImage))
            {
                graphics.DrawString(textToAdd, font, brush, location);
            }
            return originalImage;
        }

        private Bitmap createGraphic(Topping topping)
        {
            Bitmap image = new Bitmap(768, 432);
            Bitmap toppingGraphic = (Bitmap)Image.FromFile(Path.Combine(Application.StartupPath, "graphics/" + topping.ToppingType.Replace(" ", "").ToLower() + topping.ResonantType.Replace(" ", "").ToLower() + "_topping.png"));

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawImageUnscaled(toppingGraphic, 45, 70, toppingGraphic.Width, toppingGraphic.Height);
            g.Dispose();

            image = AddTextToImage(image, topping.ResonantType, new Font(cookieRunFont, 55, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(272, 47));
            image = AddTextToImage(image, topping.ToppingType, new Font(cookieRunFont, 70, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(272, 104));
            image = AddTextToImage(image, topping.Stat1 + ": " + topping.Stat1Value + "%", new Font(cookieRunFont, 42, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(272, 210));
            image = AddTextToImage(image, topping.Stat2 + ": " + topping.Stat2Value + "%", new Font(cookieRunFont, 42, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(272, 260));
            image = AddTextToImage(image, topping.Stat3 + ": " + topping.Stat3Value + "%", new Font(cookieRunFont, 42, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(272, 310));
            toppingGraphic.Dispose();

            return image;

        }
        private Bitmap createGraphic(Beascuit beascuit)
        {
            Bitmap image = new Bitmap(768, 432);
            Bitmap toppingGraphic = (Bitmap)Image.FromFile(Path.Combine(Application.StartupPath, "graphics/" + beascuit.BeascuitType.ToLower() + "_beascuit.png"));

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawImage(toppingGraphic, 10, 70, (int)(toppingGraphic.Width*1.7), (int)(toppingGraphic.Height*1.7));
            g.Dispose();

            image = AddTextToImage(image, (beascuit.Tainted?"Tainted ":"") + beascuit.ResonantType, new Font(cookieRunFont, 45, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(267, 60));
            image = AddTextToImage(image, beascuit.BeascuitType + " Beascuit", new Font(cookieRunFont, 60, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(267, 104));
            image = AddTextToImage(image, beascuit.Stat1 + ": " + beascuit.Stat1Value + "%", new Font(cookieRunFont, 37, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(267, 180));
            image = AddTextToImage(image, beascuit.Stat2 + ": " + beascuit.Stat2Value + "%", new Font(cookieRunFont, 37, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(267, 220));
            image = AddTextToImage(image, beascuit.Stat3 + ": " + beascuit.Stat3Value + "%", new Font(cookieRunFont, 37, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(267, 260));
            image = AddTextToImage(image, beascuit.Stat4 + ": " + beascuit.Stat4Value + "%", new Font(cookieRunFont, 37, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(267, 300));
            toppingGraphic.Dispose();

            return image;

        }

        private Bitmap createCompactGraphic(Topping topping)
        {
            Bitmap image = new Bitmap(400, 400, PixelFormat.Format32bppArgb);
            Bitmap toppingGraphic = (Bitmap)Image.FromFile(Path.Combine(Application.StartupPath, "graphics/" + topping.ToppingType.Replace(" ", "").ToLower() + topping.ResonantType.Replace(" ", "").ToLower() + "_topping.png"));

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawImage(toppingGraphic, image.Width / 2 - (int)(toppingGraphic.Width * 0.55), 25, (int)(toppingGraphic.Width * 1.1), (int)(toppingGraphic.Height * 1.1));
            g.Dispose();

            image = AddTextToImage(image, topping.Stat1 + ": " + topping.Stat1Value + "%", new Font(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(image.Width / 2 - (topping.Stat1 + ": " + topping.Stat1Value + "%").Length * 9, 265));
            image = AddTextToImage(image, topping.Stat2 + ": " + topping.Stat2Value + "%", new Font(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(image.Width / 2 - (topping.Stat2 + ": " + topping.Stat2Value + "%").Length * 9, 305));
            image = AddTextToImage(image, topping.Stat3 + ": " + topping.Stat3Value + "%", new Font(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(image.Width / 2 - (topping.Stat3 + ": " + topping.Stat3Value + "%").Length * 9, 345));

            toppingGraphic.Dispose();

            return image;
        }
        private Bitmap createCompactGraphic(Beascuit beascuit)
        {
            Bitmap image = new Bitmap(400, 400, PixelFormat.Format32bppArgb);
            Bitmap toppingGraphic = (Bitmap)Image.FromFile(Path.Combine(Application.StartupPath, "graphics/" + beascuit.BeascuitType.ToLower() + "_beascuit.png"));

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            g.DrawImage(toppingGraphic, image.Width/2  - (int)(toppingGraphic.Width * 1.4)/2, 15, (int)(toppingGraphic.Width * 1.4), (int)(toppingGraphic.Height * 1.4));
            g.Dispose();

            image = AddTextToImage(image, beascuit.Stat1 + ": " + beascuit.Stat1Value + "%", new Font(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(image.Width / 2 - (beascuit.Stat1 + ": " + beascuit.Stat1Value + "%").Length * 9, 225));
            image = AddTextToImage(image, beascuit.Stat2 + ": " + beascuit.Stat2Value + "%", new Font(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(image.Width / 2 - (beascuit.Stat2 + ": " + beascuit.Stat2Value + "%").Length * 9, 265));
            image = AddTextToImage(image, beascuit.Stat3 + ": " + beascuit.Stat3Value + "%", new Font(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(image.Width / 2 - (beascuit.Stat3 + ": " + beascuit.Stat3Value + "%").Length * 9, 305));
            image = AddTextToImage(image, beascuit.Stat4 + ": " + beascuit.Stat4Value + "%", new Font(cookieRunFont, 34, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), new PointF(image.Width / 2 - (beascuit.Stat4 + ": " + beascuit.Stat4Value + "%").Length * 9, 345));

            toppingGraphic.Dispose();

            return image;
        }

        private void RefreshComboBoxManually(ComboBox combo, List<string> newItems)
        {
            combo.BeginUpdate();
            try
            {
                combo.Items.Clear();
                foreach (string item in newItems)
                {
                    combo.Items.Add(item);
                }
            }
            finally
            {
                combo.EndUpdate();
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedIndex == 1)
            {
                updateInventory();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            String filePath = "";
            Thread t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.Title = "Select Inventory File";

                // Show the dialog
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
            if (filePath != "")
            {
                LoadInventory(filePath);
            }
        }
        private void LoadInventory(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);

                toppingsExportList = JsonSerializer.Deserialize<List<Iitem>>(json, new JsonSerializerOptions { WriteIndented = true });
                BitmapGraphics.Clear();
                foreach (Iitem item in toppingsExportList)
                {
                    BitmapGraphics.Add(createCompactGraphic((Topping)item));
                }
                updateInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateInventory()
        {
            inventoryDisplay.Controls.Clear();
            for (int i = 0; i < BitmapGraphics.Count; i++)
            {
                Panel itemPanel = new Panel();
                itemPanel.Width = 158;
                itemPanel.Height = 158;
                itemPanel.BackColor = Color.Black;

                PictureBox pb = new PictureBox();

                pb.BackColor = Color.White;
                pb.Image = BitmapGraphics[i];
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Width = 148;
                pb.Height = 148;
                pb.Left = (itemPanel.Width - pb.Width) / 2;
                pb.Top = (itemPanel.Height - pb.Height) / 2;
                pb.Tag = (BitmapGraphics[i], toppingsExportList[i]);

                Label deleteLabel = new Label();
                deleteLabel.Text = "X";
                deleteLabel.ForeColor = Color.Red;
                deleteLabel.BackColor = Color.White;
                deleteLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                deleteLabel.AutoSize = true;
                deleteLabel.Top = 0;
                deleteLabel.Left = 123;
                deleteLabel.Click += (s, e) =>
                {
                    ValueTuple<Bitmap, Iitem> i = (ValueTuple<Bitmap, Iitem>)pb.Tag;
                    BitmapGraphics.Remove(i.Item1);
                    i.Item1.Dispose();
                    toppingsExportList.Remove(i.Item2);
                    inventoryDisplay.Controls.Remove(itemPanel);
                    itemPanel.Dispose();
                };

                pb.Controls.Add(deleteLabel);
                deleteLabel.BringToFront();
                itemPanel.Controls.Add(pb);
                inventoryDisplay.Controls.Add(itemPanel);
            }
        }

        private void takeScreenshot()
        {
            // The magic numbers come from measurements of screenshots to determine where the topping is, where the substats are, ect
            scanRoot = ((int)(Screen.PrimaryScreen.Bounds.Width),
            (int)(Screen.PrimaryScreen.Bounds.Height));

            // Force 16:9 aspect ratio
            scanRoot = ((int)Math.Min(scanRoot.Value.Item1, scanRoot.Value.Item2 * (16.0 / 9.0)),
                        (int)Math.Min(scanRoot.Value.Item1 * (9.0 / 16.0), scanRoot.Value.Item2));

            if (itemSelector.Text == "Toppings")
            {
                int width = (int)(0.392 * scanRoot.Value.Item1);
                int disHieght = (int)(0.494 * scanRoot.Value.Item2);
                int hieght = (int)(0.05 * scanRoot.Value.Item2);
                double[] startCollection = { 0.26, 0.589, 0.646, 0.704 };

                for (int i = 0; i < startCollection.Length; i++)
                {
                    bmpCollection[i]?.Dispose();
                    Bitmap bmpDisposable = new Bitmap(width, hieght);
                    using (Graphics g = Graphics.FromImage(bmpDisposable))
                    {
                        g.CopyFromScreen((int)(0.063 * scanRoot.Value.Item1), (int)(startCollection[i] * scanRoot.Value.Item2), 0, 0, new Size(width, hieght), CopyPixelOperation.SourceCopy);

                    }
                    using (Bitmap preProcImage = preprocImage(bmpDisposable))
                    using (Bitmap tempImage = AddPadding(preProcImage, 30, Color.White))
                    {
                        if (bmpDisposable != null)
                        {
                            bmpDisposable.Dispose();
                        }
                        bmpCollection[i] = (Bitmap)tempImage.Clone();
                    }
                }

                bmpScreenshot = new Bitmap(width, disHieght);
                using (Graphics g = Graphics.FromImage(bmpScreenshot))
                {
                    g.CopyFromScreen((int)(0.063 * scanRoot.Value.Item1), (int)(0.262 * scanRoot.Value.Item2), 0, 0, new Size(width, disHieght), CopyPixelOperation.SourceCopy);
                }

            }
            else if (itemSelector.Text == "Beascuits")
            {
                // For future
            }
            else if (itemSelector.Text == "Tarts")
            {
                // For future
            }

            if (scannedImage.Image != null)
            {
                scannedImage.Image.Dispose();
            }
            scannedImage.Image = (Bitmap)bmpScreenshot.Clone();
            if (bmpScreenshot != null)
            {
                bmpScreenshot.Dispose();
            }
        }
        private void autoScanButton_Click(object sender, EventArgs e)
        {
            takeScreenshot();
            readScreenshot(1, false);
            AddItem();
        }
    }
}
