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
        private List<string> PossibleSubstats;
        private List<ComboBox> comboBoxes;
        private List<NumericUpDown> numericUpDowns;
        private Dictionary<string, (double, double)> possibleToppingSubs = new Dictionary<string, (double, double)>();
        private List<Topping> toppingsExportList = new List<Topping>();
        private Bitmap bmpScreenshot = new Bitmap(1,1);
        private (int, int)? scanRoot;
        
        public Scanner()
        {
            InitializeComponent();
            
            TenToppingResonants = new List<string> { "Destined", "Silent", "Blooming", "" };
            comboBoxes = new List<ComboBox> { statType1, statType2, statType3 };
            numericUpDowns = new List<NumericUpDown> { stat1, stat2, stat3 };
            PossibleSubstats = new List<string> { "", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist" };
            scannedImage.SizeMode = PictureBoxSizeMode.Zoom;

            possibleToppingSubs.Add("Amplify Buff", (1.0, 2.0));
            possibleToppingSubs.Add("ATK", (1.0, 3.0));
            possibleToppingSubs.Add("ATK SPD", (1.0, 3.0));
            possibleToppingSubs.Add("Cooldown", (1.0, 2.0));
            possibleToppingSubs.Add("CRIT Resist", (3.0, 4.0));
            possibleToppingSubs.Add("Debuff Resist", (1.0, 2.0));
            possibleToppingSubs.Add("DEF%", (1.0, 3.0));
            possibleToppingSubs.Add("DMG Resist", (1.0, 6.0));
            possibleToppingSubs.Add("HP%", (1.0, 3.0));
            possibleToppingSubs.Add("CRIT%", (1.0, 3.0));
            possibleToppingSubs.Add("", (0, 0));
            foreach (var combo in comboBoxes)
            {
                combo.DataSource = new List<string>(PossibleSubstats); // Give each a fresh copy initially
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Scanner_Load(object sender, EventArgs e)
        {

        }

        private void btnAddTopping_Click(object sender, EventArgs e)
        {
            Topping newTopping = new Topping()
            {
                ResonantType = resonantType.Text,
                ToppingType = toppingType.Text,
                Stat1Value = statType1.Text,
                Stat2Value = statType2.Text,
                Stat3Value = statType3.Text,
                Stat1 = stat1.Text,
                Stat2 = stat2.Text,
                Stat3 = stat3.Text
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

        private void drpResonantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox resBox = (ComboBox)sender;
            if (resBox.Text != "")
            {
                PossibleSubstats = new List<string> { "", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "DMG Resist" };
                possibleToppingSubs["ATK SPD"] = (2.0, 3.0);
                possibleToppingSubs["ATK"] = (2.0, 3.0);
                possibleToppingSubs["Cooldown"] = (1.5, 2.0);
                possibleToppingSubs["CRIT Resist"] = (3.5, 4.0);
                possibleToppingSubs["DMG Resist"] = (4.5, 6.0);
                possibleToppingSubs["CRIT%"] = (2.0, 3.0);
                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    var combo = comboBoxes[i];
                    var numUpDown = numericUpDowns[i];
                    var selectedItem = combo.SelectedItem?.ToString();
                    var numVal = numUpDown.Value;
                    combo.DataSource = new List<string>(PossibleSubstats);
                    if (PossibleSubstats.Contains(selectedItem))
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
                PossibleSubstats = new List<string> { "", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist" };
                possibleToppingSubs["ATK SPD"] = (1.0, 3.0);
                possibleToppingSubs["ATK"] = (1.0, 3.0);
                possibleToppingSubs["Cooldown"] = (1.0, 2.0);
                possibleToppingSubs["CRIT Resist"] = (3.0, 4.0);
                possibleToppingSubs["DMG Resist"] = (1.0, 6.0);
                possibleToppingSubs["CRIT%"] = (1.0, 3.0);
                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    var combo = comboBoxes[i];
                    var numUpDown = numericUpDowns[i];
                    var selectedItem = combo.SelectedItem?.ToString();
                    var numVal = numUpDown.Value;
                    combo.DataSource = new List<string>(PossibleSubstats);
                    if (PossibleSubstats.Contains(selectedItem))
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
                    toppingType.Items.AddRange(new List<string> { "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi" }.ToArray());
                }



            }
            else
            {
                if (toppingType.Items.Count != 5)
                {
                    toppingType.Items.Remove("Walnut");
                    toppingType.Items.Remove("Peanut");
                    toppingType.Items.Remove("Hazelnut");
                    toppingType.Items.Remove("Candy");
                    toppingType.Items.Remove("Kiwi");
                }

            }

        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            scannedList.Text = "";
            string json = JsonSerializer.Serialize(toppingsExportList);
            string filePath = Path.Combine(Application.StartupPath, "\"Crk Exports\"\\" + "crkExport" + DateTime.Now.ToString("yyyyMMddhmmss") + ".json");
            File.WriteAllText(filePath, json);

        }

        private void statType1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                var availableItems = PossibleSubstats.Except(selectedItems).ToList();
                var currentSelection = combo.SelectedItem?.ToString();
                combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                combo.DataSource = new List<string>(availableItems);
                combo.SelectedItem = currentSelection;
                if (availableItems.Contains(currentSelection))
                {
                    combo.SelectedItem = currentSelection;
                }
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

                var numVal = numUpDown.Value;

                numUpDown.Minimum = ((decimal)possibleToppingSubs[currentSelection].Item1);
                numUpDown.Maximum = ((decimal)possibleToppingSubs[currentSelection].Item2);

                if (numVal > numUpDown.Minimum && numVal <= numUpDown.Maximum)
                {
                    numUpDown.Value = numVal;
                }
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void screenshotButton_Click(object sender, EventArgs e)
        {
            scanRoot = (Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            // Force 16:9 aspect ratio
            scanRoot = ((int)Math.Min(scanRoot.Value.Item1, scanRoot.Value.Item2 * (9.0 / 16.0)),
                        (int)Math.Min(scanRoot.Value.Item1 * (16.0 / 9.0), scanRoot.Value.Item2));
            scanRoot = ((int)(Screen.PrimaryScreen.Bounds.Width),
                        (int)(Screen.PrimaryScreen.Bounds.Height));
            Rectangle cropRect = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width - (int)(0.604 * scanRoot.Value.Item1), Screen.PrimaryScreen.Bounds.Height - (int)(0.513 * scanRoot.Value.Item2));

            int x1 = (int)(0.063 * scanRoot.Value.Item1);
            int y1 = (int)(0.262 * scanRoot.Value.Item2);
            int x2 = (int)(0.459 * scanRoot.Value.Item1);
            int y2 = (int)(0.749 * scanRoot.Value.Item2);

            int width = x2 - x1;
            int height = y2 - y1;

            bmpScreenshot = new Bitmap(width, height);
            Graphics.FromImage(bmpScreenshot).CopyFromScreen(x1, y1, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            
            scannedImage.Image = bmpScreenshot;

        }

        private void readButton_Click(object sender, EventArgs e)
        {
            var engine = new TesseractEngine(Application.StartupPath + @"/tessdata", "eng", EngineMode.TesseractAndLstm);
            using (var pix = PixConverter.ToPix(MakeGrayscale3(new Bitmap(bmpScreenshot, bmpScreenshot.Width * 5, bmpScreenshot.Height * 5))))
            {
                // Define your rectangle
                Rect rectSubs = new Rect(0, (int)(0.671 * pix.Height), pix.Width, (int)(0.329 * pix.Height));
                Rect rectHead = new Rect(0, 0, pix.Width, pix.Height);
                // Process the image region
                using (var page = engine.Process(pix, rectHead, PageSegMode.Auto))
                {
                    var text = page.GetText();
                    
                    foreach(var resonant in resonantType.Items)
                    {
                        if (text.Contains(resonant.ToString()))
                        {
                            resonantType.SelectedItem = resonant.ToString();
                        }
                    }
                    foreach(var topType in toppingType.Items)
                    {
                        if (text.Contains(topType.ToString()))
                        {
                            toppingType.SelectedItem = topType.ToString();
                        }
                    }

                }
                using (var page = engine.Process(pix, rectSubs, PageSegMode.Auto))
                {
                    var count = 0;
                    var text = page.GetText();
                    for(var i = 0; i < comboBoxes.Count; i++)
                    {
                        comboBoxes[i].SelectedItem = "";
                        numericUpDowns[i].Value = 0;
                    }
                    foreach (var line in text.Split(new[] { '\n', '\r' }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
                    {
                        int lastSpace = line.LastIndexOf(' ');
                        string statName = line.Substring(0, lastSpace);
                        comboBoxes[count].SelectedItem = statName;
                        double statValue = double.Parse(line.Substring(lastSpace + 1).Replace("%", ""));
                        numericUpDowns[count].Value = (decimal)statValue;
                        count++;
                    }
                    
                }
                
            }
        }

        private void scannedList_TextChanged(object sender, EventArgs e)
        {

        }

        //code from switchonthecode
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            using (Graphics g = Graphics.FromImage(newBitmap))
            {

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
                using (ImageAttributes attributes = new ImageAttributes())
                {

                    //set the color matrix attribute
                    attributes.SetColorMatrix(colorMatrix);

                    //draw the original image on the new image
                    //using the grayscale color matrix
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                                0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return newBitmap;
        }

        private void scannedImage_Click(object sender, EventArgs e)
        {
            
        }
    }
}
