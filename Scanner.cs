using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private Dictionary<string, double> maxToppingSubs = new Dictionary<string, double>();
        
        public Scanner()
        {
            InitializeComponent();
            TenToppingResonants = new List<string> { "Destined", "Silent", "Blooming", "Not Resonant" };
            comboBoxes = new List<ComboBox> { statType1, statType2, statType3 };
            numericUpDowns = new List<NumericUpDown> { stat1, stat2, stat3 };
            PossibleSubstats = new List<string> {"Amplify Buff", "ATK SPD", "ATK%", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF%", "DMG Resist" };
            maxToppingSubs.Add("Amplify Buff", 2.0);
            maxToppingSubs.Add("ATK%", 3.0);
            maxToppingSubs.Add("ATK SPD", 3.0);
            maxToppingSubs.Add("Cooldown", 2.0);
            maxToppingSubs.Add("CRIT Resist", 4.0);
            maxToppingSubs.Add("Debuff Resist", 2.0);
            maxToppingSubs.Add("DEF%", 3.0);
            maxToppingSubs.Add("DMG Resist", 6.0);
            maxToppingSubs.Add("HP%", 3.0);
            maxToppingSubs.Add("CRIT%", 3.0);
            maxToppingSubs.Add("", 0);
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
            Topping newTopping = new Topping(resonantType.Text, toppingType.Text, statType1.Text, statType2.Text, statType3.Text, stat1.Text, stat2.Text, stat3.Text);
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

                numUpDown.Maximum = ((decimal)maxToppingSubs[currentSelection]);
            }
        }

    }
}
