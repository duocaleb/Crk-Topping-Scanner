using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Crk_Topping_Scanner
{
    public partial class Scanner : Form
    {
        private List<string> TenToppingResonants;
        private List<string> PossibleSubstats; 
        private List<ComboBox> comboBoxes;
        private List<NumericUpDown> numericUpDowns;
        private Dictionary<string,( double, double )> possibleToppingSubs = new Dictionary<string, (double, double)>();
        private List<Topping> toppingsExportList = new List<Topping>();
        public Scanner()
        {
            InitializeComponent();
            TenToppingResonants = new List<string> { "Destined", "Silent", "Blooming", "Not Resonant" };
            comboBoxes = new List<ComboBox> { statType1, statType2, statType3 };
            numericUpDowns = new List<NumericUpDown> { stat1, stat2, stat3 };
            PossibleSubstats = new List<string> {"Amplify Buff", "ATK SPD", "ATK%", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist" };
            
            possibleToppingSubs.Add("Amplify Buff", (1.0,2.0));
            possibleToppingSubs.Add("ATK%", (1.0, 3.0));
            possibleToppingSubs.Add("ATK SPD", (1.0, 3.0));
            possibleToppingSubs.Add("Cooldown", (1.0, 2.0));
            possibleToppingSubs.Add("CRIT Resist", (1.0, 4.0));
            possibleToppingSubs.Add("Debuff Resist", (1.0, 2.0));
            possibleToppingSubs.Add("DEF%", (1.0, 3.0));
            possibleToppingSubs.Add("DMG Resist", (1.0, 6.0));
            possibleToppingSubs.Add("HP%", (1.0, 3.0));
            possibleToppingSubs.Add("CRIT%", (1.0, 3.0));
            possibleToppingSubs.Add("", (0,0));
            foreach (var combo in comboBoxes)
            {
                List<string> PosSubBlank = PossibleSubstats;
                PosSubBlank.Insert(0, "");
                combo.DataSource = new List<string>(PosSubBlank); // Give each a fresh copy initially
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
            Topping newTopping = new Topping() { 
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
            if (scannedList.Text != "None") {
                scannedList.Text = scannedList.Text + newTopping.ToString() + "\n";
            }
            else
            {
                scannedList.Text = newTopping.ToString() + "\n";
            }
        }

        private void drpResonantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox resBox = (ComboBox)sender;
            if (TenToppingResonants.Contains(resBox.Text))
            {
                if (toppingType.Items.Count != 10) {
                    toppingType.Items.AddRange(new List<string> { "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi" }.ToArray());
                }
                
            }
            else {
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
            string filePath = Path.Combine(Application.StartupPath, "crkExport" + DateTime.Now.ToString("yyyyMMddhmmss") + ".json");
            File.WriteAllText(filePath, json);

        }

        private void statType1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            for(int i = 0; i < comboBoxes.Count; i++)
            {
                ComboBox combo = comboBoxes[i];
                NumericUpDown numUpDown = numericUpDowns[i];
                var selectedItems = comboBoxes
                    .Except(new List<ComboBox> {combo})
                    .Select(c => c.SelectedItem?.ToString())
                    .Where(item => !string.IsNullOrEmpty(item))
                    .ToList();
                var availableItems = PossibleSubstats.Except(selectedItems).ToList();
                var currentSelection = combo.SelectedItem?.ToString();
                combo.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                combo.DataSource = new List<string>(availableItems);
                combo.SelectedItem = currentSelection;
                combo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

                numUpDown.Minimum = ((decimal)possibleToppingSubs[(currentSelection)].Item1);
                numUpDown.Maximum = ((decimal)possibleToppingSubs[currentSelection].Item2);
            }
        }

    }
}
