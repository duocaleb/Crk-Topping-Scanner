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
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Application = System.Windows.Forms.Application;
using Boolean = System.Boolean;
using Button = System.Windows.Forms.Button;
using ComboBox = System.Windows.Forms.ComboBox;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;


namespace Crk_Topping_Scanner
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]


    public partial class Scanner : Form
    {
        private readonly List<ComboBox> comboBoxes;
        private readonly List<NumericUpDown> numericUpDowns;
        private Dictionary<string, (double, double)> subStatLimits = [];
        private List<Iitem> itemList = [];
        private Bitmap bmpScreenshot = new(1, 1);
        private (int, int)? scanRoot;
        private readonly TesseractEngine engine = new(@Path.Combine(Application.StartupPath, "tessdata"), "eng", EngineMode.LstmOnly);
        private readonly Bitmap[] bmpCollection = new Bitmap[5];
        private readonly JsonSerializerOptions jsonSerializer = new() { WriteIndented = true };
        private readonly JsonSerializerOptions jsonDeserializeOptions = new() { WriteIndented = true };
        private int currentPage = 1;
        private int maxPage = 1;
        private Iitem invType = new Topping();
        public Scanner()
        {

            InitializeComponent();
            comboBoxes = [statType1, statType2, statType3, statType4];
            numericUpDowns = [stat1, stat2, stat3, stat4];

            for (int i = 0; i < bmpCollection.Length; i++)
            {
                bmpCollection[i] = new Bitmap(1, 1);
            }
            invViewerSelector.SelectedItem = "Toppings";
            itemSelector.SelectedItem = "Toppings";
            foreach (ComboBox combo in comboBoxes)
            {
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged1;
            }
        }

        private void ScreenshotButton_Click(object sender, EventArgs e)
        {
            TakeScreenshot();
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            ReadScreenshot(2, false);
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void AutoScanButton_Click(object sender, EventArgs e)
        {
            TakeScreenshot();
            ReadScreenshot(2, false);
            AddItem();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            string json = JsonSerializer.Serialize(itemList, jsonSerializer);
            string filePath = Path.Combine(Application.StartupPath, "Crk-Exports\\" + "crkExport" + DateTime.Now.ToString("yyyyMMddhmmss") + ".json");
            File.WriteAllText(filePath, json);
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            String filePath = "";
            Thread t = new((ThreadStart)(() =>
            {
                OpenFileDialog openFileDialog = new()
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*",
                    Title = "Select Inventory File"
                };

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

        private void ResonantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemSelector.Text == "Toppings")
            {
                ComboBox resBox = (ComboBox)sender;
                if (resBox.Text != "")
                {
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
                        RefreshComboBoxManually(combo, AppData.ToppingSubstatsRes);
                        if (AppData.ToppingSubstatsRes.Contains(selectedItem))
                        {
                            combo.SelectedItem = selectedItem;
                        }
                        else
                        {
                            combo.SelectedItem = "";
                        }
                        if (numVal > numUpDown.Minimum && numVal <= numUpDown.Maximum)
                        {
                            numUpDown.Value = numVal;
                        }
                    }
                }
                else
                {
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
                        RefreshComboBoxManually(combo, AppData.ToppingSubstats);
                        if (AppData.ToppingSubstats.Contains(selectedItem))
                        {
                            combo.SelectedItem = selectedItem;
                        }
                        else
                        {
                            combo.SelectedItem = "";
                        }
                        if (numVal > numUpDown.Minimum && numVal <= numUpDown.Maximum)
                        {
                            numUpDown.Value = numVal;
                        }
                    }
                }
                if (AppData.TenToppingResonants.Contains(resBox.Text))
                {
                    string currentType = toppingType.Text;
                    RefreshComboBoxManually(toppingType, AppData.ToppingTypes);
                    if (AppData.ToppingTypes.Contains(currentType))
                    {
                        toppingType.SelectedItem = currentType;
                    }
                }
                else
                {
                    string currentType = toppingType.Text;
                    RefreshComboBoxManually(toppingType, AppData.ToppingTypesRes);
                    if (AppData.ToppingTypesRes.Contains(currentType))
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
                        RefreshComboBoxManually(statType1, [AppData.BeascuitResToMain[resonantType.Text]]);
                        statType1.SelectedItem = AppData.BeascuitResToMain[resonantType.Text];
                        stat1.Minimum = 20;
                        stat1.Maximum = 20;
                        statType1.Enabled = false;
                        stat1.Enabled = false;
                        for (int i = 1; i < comboBoxes.Count; i++)
                        {
                            List<string> beascuitSubsNew = [.. AppData.BeascuitsSubstats];
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
                            List<string> beascuitSubsNew = [.. AppData.BeascuitsSubstats, AppData.BeascuitResToMain[resonantType.Text]];
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
                        List<string> beascuitSubsNew = [.. AppData.BeascuitsSubstats];
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

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < comboBoxes.Count; i++)
            {
                ComboBox combo = comboBoxes[i];
                NumericUpDown numUpDown = numericUpDowns[i];
                var selectedItems = comboBoxes
                    .Except([combo])
                    .Select(c => c.SelectedItem?.ToString())
                    .Where(item => !string.IsNullOrEmpty(item))
                    .ToList();
                List<String> availableItems;
                if (resonantType.Text == "")
                {
                    availableItems = [.. AppData.ToppingSubstats.Except(selectedItems)];
                }
                else
                {
                    availableItems = [.. AppData.ToppingSubstatsRes.Except(selectedItems)];
                }
                var currentSelection = combo.SelectedItem?.ToString();
                combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                RefreshComboBoxManually(combo, [.. availableItems]);
                combo.SelectedItem = currentSelection;
                if (availableItems.Contains(currentSelection))
                {
                    combo.SelectedItem = currentSelection;
                }
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }

        private void ComboBox_SelectedIndexChanged1(object sender, EventArgs e)
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

        private void ItemSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            statType1.Enabled = true;
            stat1.Enabled = true;
            if (itemSelector.Text == "Toppings")
            {
                resonantType.Enabled = true;
                statType1.Enabled = true;
                RefreshComboBoxManually(resonantType, [.. AppData.ToppingRes]);
                RefreshComboBoxManually(toppingType, [.. AppData.ToppingTypes]);
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
                    RefreshComboBoxManually(combo, [.. AppData.ToppingSubstats]);
                    combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
            else if (itemSelector.Text == "Beascuits")
            {
                resonantType.Enabled = true;
                statType1.Enabled = true;
                RefreshComboBoxManually(resonantType, [.. AppData.BeascuitRes]);
                RefreshComboBoxManually(toppingType, [.. AppData.BeascuitTypes]);
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
                foreach (string stat in AppData.BeascuitResToMain.Values)
                {
                    subStatLimits.Add(stat, (8.0, 15.0));
                }
                foreach (var combo in comboBoxes)
                {
                    combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                    RefreshComboBoxManually(combo, [.. AppData.BeascuitsSubstats]);
                }

            }
            else if (itemSelector.Text == "Tarts")
            {
                resonantType.SelectedItem = "";
                resonantType.Enabled = false;
                statType1.Enabled = false;
                RefreshComboBoxManually(toppingType, [.. AppData.ToppingTypes]);
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
                    RefreshComboBoxManually(combo, [.. AppData.ToppingSubstats]);
                }
            }
        }

        private void ToppingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemSelector.Text == "Tarts")
            {
                statType1.SelectedItem = AppData.TypeToMain[toppingType.Text];
            }
        }

        private void IsTainted_CheckedChanged(object sender, EventArgs e)
        {
            if (resonantType.Text != "")
            {
                if (isTainted.Checked)
                {

                    RefreshComboBoxManually(statType1, [AppData.BeascuitResToMain[resonantType.Text]]);
                    statType1.SelectedItem = AppData.BeascuitResToMain[resonantType.Text];
                    stat1.Minimum = 20;
                    stat1.Maximum = 20;
                    statType1.Enabled = false;
                    stat1.Enabled = false;
                    for (int i = 1; i < comboBoxes.Count; i++)
                    {
                        List<string> beascuitSubsNew = [.. AppData.BeascuitsSubstats];
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
                        List<string> beascuitSubsNew = [.. AppData.BeascuitsSubstats, AppData.BeascuitResToMain[resonantType.Text]];
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
                    Topping newTopping = new()
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
                    itemList.Add(newTopping);
                    recentScanImg.Image?.Dispose();
                    recentScanImg.Image = BitmapTools.CreateGraphic(newTopping);
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
                    Beascuit newBeascuit = new()
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
                    recentScanImg.Image = BitmapTools.CreateGraphic(newBeascuit);
                    itemList.Add(newBeascuit);
                }
            }
            else if (itemSelector.Text == "Tarts")
            {
                if (toppingType.Text == "")
                {
                    MessageBox.Show(
                        "Missing tart type.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                Tart newTart = new()
                {
                    TartType = toppingType.Text,
                    StatValue = double.Parse(stat1.Text),
                    Stat = statType1.Text,
                };
                itemList.Add(newTart);
                recentScanImg.Image?.Dispose();
                recentScanImg.Image = BitmapTools.CreateGraphic(newTart);

            }
        }

        private void ReadScreenshot(int upScale, Boolean overrideCatch)
        {
            try
            {
                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    comboBoxes[i].SelectedItem = "";
                }
                if (itemSelector.Text == "Toppings")
                {
                    double[] statValues = [0, 0, 0];
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
                        using (var scaledBitmap = new Bitmap(bmpCollection[i], bmpCollection[i].Width * upScale, bmpCollection[i].Height * upScale))
                        using (var pix = PixConverter.ToPix(scaledBitmap))
                        using (var page = engine.Process(pix, PageSegMode.SingleLine))
                        {

                            var text = page.GetText();
                            int lastSpace = text.LastIndexOf(' ');
                            string statName = text[..lastSpace];
                            comboBoxes[i - 1].SelectedItem = statName;
                            double statValue = double.Parse(text[(lastSpace + 1)..].Replace("%", ""));
                            statValues[i - 1] = statValue;
                        }
                        for (int a = 0; a < 3; a++)
                        {
                            numericUpDowns[a].Value = (decimal)statValues[a];

                        }
                    }
                }
                else if (itemSelector.Text == "Beascuits")
                {
                    // Future Implementation
                }
                else if (itemSelector.Text == "Tarts")
                {
                    double statValues = 0;
                    using (var pix = PixConverter.ToPix(bmpCollection[0]))
                    using (var page = engine.Process(pix, PageSegMode.SingleLine))
                    {
                        var text = page.GetText();
                        foreach (var topType in toppingType.Items)
                        {
                            if (topType.ToString() != "" && text.Contains(topType.ToString()))
                            {
                                toppingType.SelectedItem = topType.ToString();    
                            }
                            
                        }
                    }
                    statType1.SelectedItem = AppData.TypeToMain[toppingType.Text];
                    using (var scaledBitmap = new Bitmap(bmpCollection[1], bmpCollection[1].Width * upScale, bmpCollection[1].Height * upScale))
                    using (var pix = PixConverter.ToPix(scaledBitmap))
                    using (var page = engine.Process(pix, PageSegMode.SingleLine))
                    {

                        var text = page.GetText();
                        int lastSpace = text.LastIndexOf(' ');
                        double statValue = double.Parse(text[(lastSpace + 1)..].Replace("%", ""));
                        statValues = statValue;
                    }
                    numericUpDowns[0].Value = (decimal)statValues;

                }
            }
            catch (Exception error)
            {
                if (upScale < 10)
                {
                    ReadScreenshot(upScale + 2, overrideCatch); // "are you sureeeeee you cant read it?"
                }
                else if (!overrideCatch)
                {
                    MessageBox.Show(
                        "Scanner Error. Please ensure that CookieRun: Kingdom is full screen and the scanner does not cover the item. \n Error code: " + error.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

            }
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

        private void LoadInventory(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                List<Iitem> itemsImport = JsonSerializer.Deserialize<List<Iitem>>(json, jsonDeserializeOptions);

                JsonElement root = JsonSerializer.Deserialize<JsonElement>(json);
                itemList.Clear();

                foreach (JsonElement element in root.EnumerateArray())
                {
                    string type = element.GetProperty("ItemType").GetString()!;

                    Iitem item;

                    if (type == "Topping")
                    {
                        item = element.Deserialize<Topping>(jsonDeserializeOptions)!;
                        itemList.Add((Topping)item);
                    }
                    else if (type == "Beascuit")
                    {
                        item = element.Deserialize<Beascuit>(jsonDeserializeOptions)!;
                        itemList.Add((Beascuit)item);
                    }
                    else if (type == "Tart")
                    {
                        item = element.Deserialize<Tart>(jsonDeserializeOptions)!;
                        itemList.Add((Tart)item);
                    }
                }
                SetInventoryPage(itemList, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MakePictureBoxDeletable(PictureBox pb, Bitmap bitmap, Iitem item)
        {
            pb.Image = bitmap;
            Label deleteLabel = new()
            {
                Text = "X",
                ForeColor = Color.Red,
                BackColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Top = 0,
                Left = 147
            };
            deleteLabel.Click += (s, e) =>
            {
                itemList.Remove(item);
                SetInventoryPage(itemList, currentPage);
                bitmap.Dispose();
            };

            pb.Controls.Add(deleteLabel);
            deleteLabel.BringToFront();
        }

        private void TakeScreenshot()
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
                double[] startCollection = [0.26, 0.589, 0.646, 0.704];

                for (int i = 0; i < startCollection.Length; i++)
                {
                    bmpCollection[i]?.Dispose();
                    Bitmap bmpDisposable = new(width, hieght);
                    using Graphics g1 = Graphics.FromImage(bmpDisposable);
                    g1.CopyFromScreen((int)(0.063 * scanRoot.Value.Item1), (int)(startCollection[i] * scanRoot.Value.Item2), 0, 0, new Size(width, hieght), CopyPixelOperation.SourceCopy);
                    
                    using Bitmap preProcImage = BitmapTools.PreprocImage(bmpDisposable);
                    using Bitmap tempImage = BitmapTools.AddPadding(preProcImage, 30, Color.White);
                    bmpDisposable?.Dispose();
                    bmpCollection[i] = (Bitmap)tempImage.Clone();
                }

                bmpScreenshot = new Bitmap(width, disHieght);
                using Graphics g2 = Graphics.FromImage(bmpScreenshot);
                g2.CopyFromScreen((int)(0.063 * scanRoot.Value.Item1), (int)(0.262 * scanRoot.Value.Item2), 0, 0, new Size(width, disHieght), CopyPixelOperation.SourceCopy);

            }
            else if (itemSelector.Text == "Beascuits")
            {
                // For future
            }
            else if (itemSelector.Text == "Tarts")
            {
                int width = (int)(0.392 * scanRoot.Value.Item1);
                int disHieght = (int)(0.414 * scanRoot.Value.Item2);
                int hieght = (int)(0.05 * scanRoot.Value.Item2);
                double[] startCollection = [0.54, 0.615];

                for (int i = 0; i < startCollection.Length; i++)
                {
                    bmpCollection[i]?.Dispose();
                    Bitmap bmpDisposable = new(width, hieght);
                    using Graphics g1 = Graphics.FromImage(bmpDisposable);
                    g1.CopyFromScreen((int)(0.063 * scanRoot.Value.Item1), (int)(startCollection[i] * scanRoot.Value.Item2), 0, 0, new Size(width, hieght), CopyPixelOperation.SourceCopy);

                    using Bitmap preProcImage = BitmapTools.PreprocImage(bmpDisposable);
                    using Bitmap tempImage = BitmapTools.AddPadding(preProcImage, 30, Color.White);
                    bmpDisposable?.Dispose();
                    bmpCollection[i] = (Bitmap)tempImage.Clone();
                }

                bmpScreenshot = new Bitmap(width, disHieght);
                using Graphics g2 = Graphics.FromImage(bmpScreenshot);
                g2.CopyFromScreen((int)(0.063 * scanRoot.Value.Item1), (int)(0.265 * scanRoot.Value.Item2), 0, 0, new Size(width, disHieght), CopyPixelOperation.SourceCopy);
            
                
            }

            scannedImage.Image?.Dispose();
            scannedImage.Image = (Bitmap)bmpScreenshot.Clone();
            bmpScreenshot?.Dispose();
        }


        private void SetInventoryPage(List<Iitem> itemList, int pagenum)
        {
            // Someone please tell me if theres a better way of doing this cause I couldnt find one
            List<Iitem> filteredItemList = new();
            if (invType.GetType() == typeof(Topping)) {
                filteredItemList = itemList
                    .Where(item => item.GetType() == typeof(Topping))
                    .ToList();
            }
            else if (invType.GetType() == typeof(Beascuit)) {
                filteredItemList = itemList
                    .Where(item => item.GetType() == typeof(Beascuit))
                    .ToList();
            }
            else if (invType.GetType() == typeof(Tart)) {
                filteredItemList = itemList
                    .Where(item => item.GetType() == typeof(Tart))
                    .ToList();
            }

            maxPage = Math.Max((int)Math.Ceiling(filteredItemList.Count / 20.0), 1);
            goToNum.Maximum = maxPage;
            goToNum.Minimum = 1;
            int initialIndex = (pagenum - 1) * 20;
            for (int i = 0; i < 20; i++)
            {
                PictureBox pb = (PictureBox)invPanel.GetControlFromPosition(i % 5, (int)Math.Floor(i / 5.0));
                pb.Image?.Dispose();
                pb.Image = null;
                pb.Controls.Clear();
            }

            for (int i = initialIndex; i < Math.Min(initialIndex + 20, filteredItemList.Count); i++)
            {
                Bitmap bitmap = new(1, 1);
                Iitem item = filteredItemList[i];
                if (item.GetType() == typeof(Topping))
                {
                    bitmap = BitmapTools.CreateGraphicCompact((Topping)item);
                }
                else if (item.GetType() == typeof(Beascuit))
                {
                    bitmap = BitmapTools.CreateGraphicCompact((Beascuit)item);
                }
                else if (item.GetType() == typeof(Tart))
                {
                    bitmap = BitmapTools.CreateGraphicCompact((Tart)item);
                }
                MakePictureBoxDeletable((PictureBox)invPanel.GetControlFromPosition((i - initialIndex) % 5, (int)Math.Floor((i - initialIndex) / 5.0)), bitmap, item);
            }
            pageIndicator.Text = $"Page {currentPage}/{maxPage}";
        }

        private void PrevButton_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                SetInventoryPage(itemList, currentPage);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (currentPage < maxPage)
            {
                currentPage++;
                SetInventoryPage(itemList, currentPage);
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedIndex == 1)
            {
                SetInventoryPage(itemList, 1);
            }
        }

        private void GoToPageButton_Click(object sender, EventArgs e)
        {
            currentPage = (int)goToNum.Value;
            SetInventoryPage(itemList, currentPage);
        }

        private void InvViewerSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (invViewerSelector.Text == "Toppings")
            {
                invType = new Topping();
            }
            else if (invViewerSelector.Text == "Beascuits")
            {
                invType = new Beascuit();
            }
            else if (invViewerSelector.Text == "Tarts")
            {
                invType = new Tart();
            }
            SetInventoryPage(itemList, 1);
        }
    }
}
