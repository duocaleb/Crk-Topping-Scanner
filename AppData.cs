using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crk_Topping_Scanner
{
    internal static class AppData
    {
        public static readonly List<string> TenToppingResonants = ["Destined", "Silent", "Blooming", ""];
        public static readonly List<string> ToppingSubstats = ["", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "HP"];
        public static readonly List<string> ToppingSubstatsRes = ["", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "DMG Resist"];
        public static readonly List<string> BeascuitsSubstats = ["", "Unattuned", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "HP", "DMG Resist Bypass"];

        public static readonly List<string> ToppingTypes = ["", "Raspberry", "Caramel", "Apple Jelly", "Chocolate", "Almond", "Walnut", "Peanut", "Hazelnut", "Candy", "Kiwi"];
        public static readonly List<string> ToppingTypesRes = ["", "Raspberry", "Caramel", "Apple Jelly", "Chocolate", "Almond"];
        public static readonly List<string> ToppingRes = ["", "Blooming", "Silent", "Destined", "Seafarer", "Fuzzy Wuzzy", "Passionate", "Indolent", "Flaming", "Sacred Vow", "Truthful", "Deceitful", "Iris Gem", "Fragrant", "Destructive", "Life-sprouting", "Frosted Crystal", "Radiant Cheese", "Sea Salt", "Tropical Rock", "Triple Cone Cup", "Moonkissed"];
        public static readonly List<string> BeascuitRes = ["", "Dark", "Thunderous", "Burning", "Earthen", "Poisonous", "Gleaming", "Surging", "Frozen", "Steelen", "Verdant", "Wuthering"];
        public static readonly List<string> BeascuitTypes = ["", "Sweet", "Hearty", "Zesty", "Spicy", "Light", "Chewy", "Hard", "Crispy"];

        public static readonly Dictionary<string, string> TypeToMain = new()
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
            {"Kiwi", "Debuff Resist"},
            {"", ""}
        };

        public static readonly Dictionary<string, string> BeascuitResToMain = new()
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



        public static int LevenshteinDistance(string s, string t)
        {
            // Levenshtein Distance determines how many character changes it takes to form a known result
            // For more info see: https://en.wikipedia.org/wiki/Levenshtein_distance
            s = s.ToLower();
            t = t.ToLower();
            s = Regex.Replace(s, @"[+,.: ]", "");
            t = Regex.Replace(t, @"[+,.: ]", "");
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0 || m == 0)
                return n + m;

            d[0, 0] = 0;

            int count = 0;
            for (int i = 1; i <= n; i++)
                d[i, 0] = (s[i - 1] == ' ' ? count : ++count);

            count = 0;
            for (int j = 1; j <= m; j++)
                d[0, j] = (t[j - 1] == ' ' ? count : ++count);

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                {
                    // deletion of s
                    int opt1 = d[i - 1, j];
                    if (s[i - 1] != ' ')
                        opt1++;

                    // deletion of t
                    int opt2 = d[i, j - 1];
                    if (t[j - 1] != ' ')
                        opt2++;

                    // swapping s to t
                    int opt3 = d[i - 1, j - 1];
                    if (t[j - 1] != s[i - 1])
                        opt3++;
                    d[i, j] = Math.Min(Math.Min(opt1, opt2), opt3);
                }
            return d[n, m];
        }

        public static string FindClosestMatch(string rawText, List<string> validText)
        {
            string lowest = "ERROR";
            int dist = int.MaxValue;

            for (int i = 0; i < validText.Count; i++)
            {
                string validWord = validText[i];
                int val = LevenshteinDistance(validWord, rawText);
                if (val < dist)
                {
                    dist = val;
                    lowest = validWord;
                }
            }
            return lowest;
        }
    }
}
