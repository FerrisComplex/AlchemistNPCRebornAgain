using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;

namespace AlchemistNPCRebornAgain.Items.Misc
{
    public class StatsChecker : ModItem
    {
        public override void SetStaticDefaults()
        {
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text1"), () => "Melee damage/critical strike chance boosts are ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text2"), () => "Ranged damage/critical strike chance boosts are ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text3"), () => "Magic damage/critical strike chance boosts are ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text4"), () => "Thrown damage/critical strike chance boosts are ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text5"), () => "Summoner damage boost is ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text6"), () => "Damage Reduction boost is ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text7"), () => "Movement speed boost is ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text8"), () => "Max life boost is ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text9"), () => "Life regeneration is ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text10"), () => "Mana usage reduction is ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text11"), () => "Max amounts of minions/sentries are ");
            Language.GetOrRegister(Mod.GetLocalizationKey("Pip-Boy3000text12"), () => "Melee swing time is ");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 5000000;
            Item.rare = 8;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player player = Main.player[Main.myPlayer];
            string text1 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text1")) + ((player.GetDamage(DamageClass.Melee) * 100) - 100) + "%" + " / " + (player.GetCritChance(DamageClass.Generic) - 4) + "%";
            string text2 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text2")) + ((player.GetDamage(DamageClass.Ranged) * 100) - 100) + "%" + " / " + (player.GetCritChance(DamageClass.Ranged) - 4) + "%";
            string text3 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text3")) + ((player.GetDamage(DamageClass.Magic) * 100) - 100) + "%" + " / " + (player.GetCritChance(DamageClass.Magic) - 4) + "%";
            string text4 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text4")) + ((player.GetDamage(DamageClass.Throwing) * 100) - 100) + "%" + " / " + (player.GetCritChance(DamageClass.Throwing) - 4) + "%";
            string text5 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text5")) + ((player.GetDamage(DamageClass.Summon) * 100) - 100) + "%";
            string text6 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text6")) + (int)(player.endurance * 100) + "%";
            string text7 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text7")) + (int)((player.moveSpeed * 100) - 100) + "%";
            string text8 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text8")) + (player.statLifeMax2 - player.statLifeMax);
            string text9 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text9")) + (player.lifeRegen);
            string text10 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text10")) + (int)((player.manaCost * 100) - 100) + "%";
            string text11 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text11")) + player.maxMinions + " / " + player.maxTurrets;
            string text12 = Language.GetTextValue(Mod.GetLocalizationKey("Pip-Boy3000text12")) + (int)(player.GetAttackSpeed(DamageClass.Melee) * 100) + "%";


            var line1 = new TooltipLine(Mod, "text1", text1);
            var line2 = new TooltipLine(Mod, "text2", text2);
            var line3 = new TooltipLine(Mod, "text3", text3);
            var line4 = new TooltipLine(Mod, "text4", text4);
            var line5 = new TooltipLine(Mod, "text5", text5);
            var line6 = new TooltipLine(Mod, "text6", text6);
            var line7 = new TooltipLine(Mod, "text7", text7);
            var line8 = new TooltipLine(Mod, "text8", text8);
            var line9 = new TooltipLine(Mod, "text9", text9);
            var line10 = new TooltipLine(Mod, "text10", text10);
            var line11 = new TooltipLine(Mod, "text11", text11);
            var line12 = new TooltipLine(Mod, "text12", text12);
            line1.OverrideColor = Color.Red;
            line2.OverrideColor = Color.LimeGreen;
            line3.OverrideColor = Color.SkyBlue;
            line4.OverrideColor = Color.Orange;
            line5.OverrideColor = Color.MediumVioletRed;
            line6.OverrideColor = Color.Gray;
            line7.OverrideColor = Color.Green;
            line8.OverrideColor = Color.Yellow;
            line9.OverrideColor = Color.Brown;
            line10.OverrideColor = Color.SkyBlue;
            line11.OverrideColor = Color.Magenta;
            line12.OverrideColor = Color.Red;

            tooltips.Add(line1);
            tooltips.Add(line2);
            tooltips.Add(line3);
            tooltips.Add(line4);
            tooltips.Add(line5);
            tooltips.Add(line6);
            tooltips.Add(line7);
            tooltips.Add(line8);
            tooltips.Add(line9);
            tooltips.Add(line10);
            tooltips.Add(line11);
            tooltips.Add(line12);
        }
    }
}
