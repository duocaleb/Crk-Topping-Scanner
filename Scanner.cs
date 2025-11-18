using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tesseract;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Application = System.Windows.Forms.Application;
using ComboBox = System.Windows.Forms.ComboBox;


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
        private TesseractEngine engine = new TesseractEngine(@Path.Combine(Application.StartupPath, "tessdata"), "eng", EngineMode.TesseractAndLstm);


        public Scanner()
        {
            InitializeComponent();

            TenToppingResonants = new List<string> { "Destined", "Silent", "Blooming", "" };
            comboBoxes = new List<ComboBox> { statType1, statType2, statType3, statType4 };
            numericUpDowns = new List<NumericUpDown> { stat1, stat2, stat3, stat4 };
            ToppingSubstats = new List<string> { "", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist" };
            BeascuitsSubstats = new List<string> { "", "Unattuned", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "DMG Resist Bypass" };
            toppingTypes = new List<string> { "", "Raspberry", "Caramel", "Apple Jelly", "Chocolate", "Almond", "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi" };
            toppingRes = new List<string> { "", "Blooming", "Silent", "Destined", "Seafarer", "Fuzzy Wuzzy", "Passionate", "Indolent", "Flaming", "Sacred Vow", "Truthful", "Deceitful", "Iris", "Fragrant", "Destructive", "Life-sprouting", "Frosted Crystal", "Radiant Cheese", "Sea Salt", "Tropical Rock", "Destructive", "Triple Cone Cup", "Moonkissed" };
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
            scannedImage.SizeMode = PictureBoxSizeMode.Zoom;


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
                        combo.DataSource = new List<string>(ToppingSubstats);
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
                    ToppingSubstats = new List<string> { "", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist" };
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
                        combo.DataSource = new List<string>(ToppingSubstats);
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
                    if (toppingType.Items.Count != 10)
                    {
                        string currentType = toppingType.Text;
                        toppingTypes.AddRange(new List<string> { "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi" }.ToArray());
                        toppingType.DataSource = new List<string>(toppingTypes);
                        if (toppingTypes.Contains(currentType))
                        {
                            toppingType.SelectedItem = currentType;
                        }
                    }



                }
                else
                {
                    if (toppingTypes.Count != 5)
                    {
                        string currentType = toppingType.Text;
                        toppingTypes.Remove("Walnut");
                        toppingTypes.Remove("Peanut");
                        toppingTypes.Remove("Hazelnut");
                        toppingTypes.Remove("Candy");
                        toppingTypes.Remove("Kiwi");
                        toppingType.DataSource = new List<string>(toppingTypes);
                        if (toppingTypes.Contains(currentType))
                        {
                            toppingType.SelectedItem = currentType;
                        }
                    }

                }
            }
            else if (itemSelector.Text == "Beascuits")
            {
                if (resonantType.Text != "")
                {

                    if (isTainted.Checked)
                    {

                        statType1.DataSource = new List<string> { beascuitResToMain[resonantType.Text] };
                        stat1.Minimum = 20;
                        stat1.Maximum = 20;
                        statType1.Enabled = false;
                        stat1.Enabled = false;
                        for (int i = 1; i < comboBoxes.Count(); i++)
                        {
                            List<string> beascuitSubsNew = new List<string>(BeascuitsSubstats).ToList();
                            string comboText = comboBoxes[i].Text;
                            comboBoxes[i].DataSource = beascuitSubsNew;
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
                            combo.DataSource = beascuitSubsNew;
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
                        combo.DataSource = beascuitSubsNew;
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
            scannedList.Text = "None";
            string json = JsonSerializer.Serialize(toppingsExportList);
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
                combo.DataSource = new List<string>(availableItems);
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
            scanRoot = (Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            // Force 16:9 aspect ratio
            scanRoot = ((int)(Screen.PrimaryScreen.Bounds.Width),
            (int)(Screen.PrimaryScreen.Bounds.Height));
            scanRoot = ((int)Math.Min(scanRoot.Value.Item1, scanRoot.Value.Item2 * (16.0 / 9.0)),
                        (int)Math.Min(scanRoot.Value.Item1 * (9.0 / 16.0), scanRoot.Value.Item2));

            int x1 = (int)(0.063 * scanRoot.Value.Item1);
            int y1 = (int)(0.262 * scanRoot.Value.Item2);
            int x2 = (int)(0.459 * scanRoot.Value.Item1);
            int y2 = (int)(0.749 * scanRoot.Value.Item2);

            int width = x2 - x1;
            int height = y2 - y1;

            bmpScreenshot = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmpScreenshot))
            {
                g.CopyFromScreen(x1, y1, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            }
            
            using (Bitmap grayScreenshot = MakeGrayscale3(bmpScreenshot))
            using (Bitmap tempImage = boundWords(grayScreenshot))
            {
                if (scannedImage.Image != null)
                {
                    scannedImage.Image.Dispose();
                }
                scannedImage.Image = (Bitmap)tempImage.Clone();
            }
            if (bmpScreenshot != null)
            {
                bmpScreenshot.Dispose();
            }

        }

        private void readButton_Click(object sender, EventArgs e)
        {

            if (itemSelector.Text == "Toppings")
            {
                foreach(var combo in comboBoxes)
                {
                    combo.SelectedItem = "";
                }
                double[] statValues = { 0, 0, 0 };
                using (var scaledBitmap = new Bitmap(bmpScreenshot, bmpScreenshot.Width * 5, bmpScreenshot.Height * 5))
                using (var pix = PixConverter.ToPix(scaledBitmap))
                {

                    Rect rectSubs = new Rect(0, (int)(0.671 * pix.Height), pix.Width, (int)(0.329 * pix.Height));
                    Rect rectHead = new Rect(0, 0, pix.Width, pix.Height);

                    using (var page = engine.Process(pix, rectHead, PageSegMode.Auto))
                    {
                        var text = page.GetText();
                        scannedList.Text = text;
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

                    using (var page = engine.Process(pix, rectSubs, PageSegMode.Auto))
                    {
                        var text = page.GetText();
                        var textSplit = text.Split(new[] { '\n' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < textSplit.Count(); i++)
                        {
                            try
                            {
                                int lastSpace = textSplit[i].LastIndexOf(' ');
                                string statName = textSplit[i].Substring(0, lastSpace);
                                comboBoxes[i].SelectedItem = statName;
                                double statValue = double.Parse(textSplit[i].Substring(lastSpace + 1).Replace("%", ""));
                                statValues[i] = statValue;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show(
                                    "Scanner Error. Please ensure that CookieRun: Kingdom is full screen and the scanner does not cover the topping.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    numericUpDowns[i].Value = (decimal)statValues[i];
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


        //code from switchonthecode
        public static Bitmap boundWords(Bitmap original)
        {
            //make an empty bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = original.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    int bw;
                    if (originalColor.R > 200)
                    {
                        bw = 255;
                    }
                    else
                    {
                        bw = 0;
                    }

                    //create the color object
                    Color newColor = Color.FromArgb(bw, bw, bw);

                    //set the new image's pixel to the grayscale version
                    newBitmap.SetPixel(i, j, newColor);
                }
            }
            return newBitmap;
        }
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        private void itemSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemSelector.Text == "Toppings")
            {
                resonantType.Enabled = true;
                statType1.Enabled = true;
                resonantType.DataSource = new List<string>(toppingRes);
                toppingType.DataSource = new List<string>(toppingTypes);
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
                    combo.DataSource = new List<string>(ToppingSubstats);
                    combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
                }
            }
            else if (itemSelector.Text == "Beascuits")
            {
                resonantType.Enabled = true;
                statType1.Enabled = true;
                resonantType.DataSource = new List<string>(beascuitRes);
                toppingType.DataSource = new List<string>(beascuitTypes);
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
                    combo.DataSource = new List<string>(BeascuitsSubstats);
                }

            }
            else if (itemSelector.Text == "Tarts")
            {
                resonantType.SelectedItem = "";
                resonantType.Enabled = false;
                statType1.Enabled = false;
                toppingType.DataSource = new List<string>(toppingTypes);
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
                    combo.DataSource = new List<string>(ToppingSubstats);
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

                    statType1.DataSource = new List<string> { beascuitResToMain[resonantType.Text] };
                    stat1.Minimum = 20;
                    stat1.Maximum = 20;
                    statType1.Enabled = false;
                    stat1.Enabled = false;
                    for (int i = 1; i < comboBoxes.Count(); i++)
                    {
                        List<string> beascuitSubsNew = new List<string>(BeascuitsSubstats).ToList();
                        string comboText = comboBoxes[i].Text;
                        comboBoxes[i].DataSource = beascuitSubsNew;
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
                        combo.DataSource = beascuitSubsNew;
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
                    if (scannedList.Text != "None")
                    {
                        scannedList.Text = scannedList.Text + newTopping.ToString().Replace("\n", Environment.NewLine) + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        scannedList.Text = newTopping.ToString().Replace("\n", Environment.NewLine) + Environment.NewLine + Environment.NewLine;
                    }
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
                    if (scannedList.Text != "None")
                    {
                        scannedList.Text = scannedList.Text + newBeascuit.ToString().Replace("\n", Environment.NewLine) + Environment.NewLine + Environment.NewLine;
                    }
                    else
                    {
                        scannedList.Text = newBeascuit.ToString().Replace("\n", Environment.NewLine) + Environment.NewLine + Environment.NewLine;
                    }
                    toppingsExportList.Add(newBeascuit);
                }
            }
        }
    }
}
