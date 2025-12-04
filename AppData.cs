using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk_Topping_Scanner
{
    internal static class AppData
    {
        public static readonly List<string> TenToppingResonants = ["Destined", "Silent", "Blooming", ""];
        public static readonly List<string> ToppingSubstats = ["", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "HP"];
        public static readonly List<string> ToppingSubstatsRes = ["", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "DMG Resist"];
        public static readonly List<string> BeascuitsSubstats = ["", "Unattuned", "Amplify Buff", "ATK SPD", "ATK", "Cooldown", "CRIT Resist", "CRIT%", "Debuff Resist", "DEF", "DMG Resist", "DMG Resist Bypass"];

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
    }
}
