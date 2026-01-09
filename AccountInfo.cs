using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crk_Topping_Scanner
{
    internal class AccountInfo
    {
        public int[] CookieBondLevels { get; set; } = new int[30];
        public int[] CostumeBondLevels { get; set; } = new int[23];
        public double[] LABATK { get; set; } = new double[8];
        public double[] LABHP { get; set; } = new double[8];
        public double[] LABDEF { get; set; } = new double[8];
        public double LABCritDMG { get; set; } = 0;
        public double StatueLevel { get; set; } = 1;

        public AccountInfo()
        {

        }

        public Dictionary<String, double> CalculateBonusStats(AccountInfo accountInfo, string cookieType, Boolean ancientCookie = false)
        {
            Dictionary<String, int> cookieTypeToIndex = new()
            {
                { "Charge", 0 },
                { "Defense", 1 },
                { "Magic", 2 },
                { "Support", 3 },
                { "Bomber", 4 },
                { "Ranged", 5 },
                { "Healing", 6 },
                { "Ambush", 7 },
            };

            // Assume maxed landmarks
            Dictionary<String, double> bonusStats = new()
            {
                {"Flat ATK", 0},
                {"Flat DEF", 0},
                {"Flat HP", 0},
                {"ATK%", 10},
                {"DEF%", 10},
                {"HP%", 60},
                {"Amp Buff", 0},
                {"CRIT%", 8},
                {"CRIT DMG", 20},
                {"CRIT Resist", 0},
                {"DMG Resist", 15},
                {"DMG Resist Bypass", 0},
                {"ATK SPD", 0},
                {"Cooldown%", 0},
                {"Debuff Resist", 0}
            };

            // Add stats

            // Landmarks, assuming all maxed for now
            bonusStats["ATK%"] += 10;
            bonusStats["DEF%"] += 10;
            bonusStats["HP%"] += 10 + 50;
            bonusStats["CRIT%"] += 8;
            bonusStats["CRIT DMG"] += 20;
            bonusStats["DMG Resist"] += 15;

            // Ancient landmark
            if (ancientCookie)
            {
                bonusStats["HP%"] += 20;
            }

            // Labs
            bonusStats["CRIT DMG"] += this.LABCritDMG;
            bonusStats["ATK%"] += this.LABATK[cookieTypeToIndex[cookieType]];
            bonusStats["HP%"] += this.LABHP[cookieTypeToIndex[cookieType]];
            bonusStats["DEF%"] += this.LABDEF[cookieTypeToIndex[cookieType]];

            // Statue level
            bonusStats["ATK%"] += 1 + Math.Min(this.StatueLevel - 1, 79) * (8 / 79) + Math.Min(this.StatueLevel - 80, 0) * 0.05;
            bonusStats["DEF%"] += 2.5 + Math.Min(this.StatueLevel - 1, 79) * (5 / 79) + Math.Min(this.StatueLevel - 80, 0) * 0.125;
            bonusStats["HP%"] += 2 + Math.Min(this.StatueLevel - 1, 79) * (6 / 79) + Math.Min(this.StatueLevel - 80, 0) * 0.35;

            // Cookie Bond
            int[] regularBonds = this.CookieBondLevels[0..28];
            int peaceBond = this.CookieBondLevels[28];
            int citrusBond = this.CookieBondLevels[29];
            int[] levelCounts = new int[6];
            for (int i = 0; i < 6; i++)
            {
                levelCounts[i] = regularBonds.Where(n => n >= i + 1).ToArray().Count();
            }
            bonusStats["Flat HP"] += levelCounts[0] * 50
                                    + levelCounts[1] * 250
                                    + levelCounts[2] * 300
                                    + levelCounts[4] * 500
                                    + (peaceBond >= 1 ? 200 : 0)
                                    + (peaceBond >= 2 ? 300 : 0)
                                    + (peaceBond >= 3 ? 300 : 0)
                                    + (peaceBond >= 5 ? 500 : 0)
                                    + (citrusBond >= 2 ? 1000 : 0)
                                    + (citrusBond >= 4 ? 250 : 0)
                                    + (citrusBond >= 5 ? 250 : 0)
                                    + (citrusBond >= 6 ? 250 : 0);
            bonusStats["Flat DEF"] += levelCounts[2] * 30
                                    + levelCounts[3] * 35
                                    + levelCounts[5] * 50
                                    + (peaceBond >= 2 ? 100 : 0)
                                    + (peaceBond >= 5 ? 100 : 0)
                                    + (peaceBond >= 6 ? 100 : 0);
            bonusStats["Flat ATK"] += levelCounts[1] * 30
                                    + levelCounts[3] * 60
                                    + levelCounts[4] * 90
                                    + levelCounts[5] * 120
                                    + (peaceBond >= 3 ? 100 : 0)
                                    + (peaceBond >= 4 ? 100 : 0)
                                    + (peaceBond >= 6 ? 100 : 0)
                                    + (citrusBond >= 4 ? 25 : 0)
                                    + (citrusBond >= 5 ? 25 : 0)
                                    + (citrusBond >= 6 ? 50 : 0);
            bonusStats["CRIT DMG"] += (citrusBond >= 1 ? 2 : 0);

            // Costume Bond
            int[] regularCostumes = this.CostumeBondLevels[0..11];
            int[] ampBuffCostumes = this.CostumeBondLevels.Select(i => new int[] { 11, 12, 14, 15 }[i]).ToArray();
            int[] critCostumes = this.CostumeBondLevels.Select(i => new int[] { 20 }[i]).ToArray();
            int[] critResCostumes = this.CostumeBondLevels.Select(i => new int[] { 16, 17 }[i]).ToArray();
            int[] hpCostumes = this.CostumeBondLevels.Select(i => new int[] { 18, 19, 22 }[i]).ToArray();
            int[] flat15 = this.CostumeBondLevels.Select(i => new int[] { 11, 12, 14, 15, 16, 17, 18, 19, 20 }[i]).ToArray();
            int eternalCostume = this.CostumeBondLevels[13];
            int[] regCount = new int[5];
            for (int i = 0; i < 5; i++)
            {
                regCount[i] = regularCostumes.Where(n => n >= i + 1).ToArray().Count();
            }

            bonusStats["Amp Buff"] += ampBuffCostumes.Sum();
            bonusStats["CRIT%"] += critCostumes.Sum() * 1.5;
            bonusStats["HP%"] += hpCostumes.Sum() + this.CostumeBondLevels[21] * 0.5;
            bonusStats["Flat ATK"] += regCount[0] * 15
                                    + regCount[1] * 15
                                    + regCount[3] * 50
                                    + regCount[4] * 100
                                    + (eternalCostume >= 1 ? 30 : 0)
                                    + (eternalCostume >= 2 ? 30 : 0)
                                    + (eternalCostume >= 4 ? 100 : 0)
                                    + flat15.Sum() * 15
                                    + this.CostumeBondLevels[21] * 10
                                    + this.CostumeBondLevels[22] * 25;
            bonusStats["Flat DEF"] += regCount[0] * 15
                                    + regCount[3] * 250
                                    + (eternalCostume >= 1 ? 30 : 0)
                                    + (eternalCostume >= 3 ? 300 : 0)
                                    + (eternalCostume >= 4 ? 550 : 0);
            bonusStats["Flat HP"] += regCount[1] * 200
                                    + regCount[2] * 300
                                    + regCount[4] * 500
                                    + (eternalCostume >= 2 ? 400 : 0)
                                    + (eternalCostume >= 3 ? 600 : 0);
            bonusStats["CRIT Resist"] += critResCostumes.Sum() * 2.5;

            return bonusStats;
        }
    }
}
