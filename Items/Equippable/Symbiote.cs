using System.Collections.Generic;
using System.Linq;
using AlchemistNPCRebornAgain.Extensions;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;
using Microsoft.Xna.Framework;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
    public class Symbiote : ModItem
    {
        public static int p = 5;
        public static int r = 2;
        public static int d = 2;
        public static int e = 2;
        public static int s = 10;
        public static bool show = false;
        public static bool SS = false;

        public override void SetDefaults()
        {
            Item.stack = 1;
            Item.width = 26;
            Item.height = 26;
            Item.value = 1000000;
            Item.rare = 11;
            Item.accessory = true;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return Mod.FindPrefixId("Xenomorphic");
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item.potionDelay = 2100;
            show = true;

            if (!Main.hardMode)
            {
                p = 5;
                r = 2;
                d = 2;
                e = 5;
                s = 10;
                player.GetDamage(DamageClass.Generic) += 0.05f;
                player.lifeRegen += 2;
                player.statDefense += 2;
                player.endurance += 0.05f;
            }
            if (Main.hardMode && !NPC.downedMoonlord)
            {
                p = 7;
                r = 4;
                d = 4;
                e = 7;
                s = 15;
                player.GetDamage(DamageClass.Generic) += 0.07f;
                player.lifeRegen += 4;
                player.statDefense += 4;
                player.endurance += 0.07f;
            }
            if (NPC.downedMoonlord)
            {
                p = 10;
                r = 6;
                d = 6;
                e = 10;
                s = 20;
                player.GetDamage(DamageClass.Generic) += 0.1f;
                player.lifeRegen += 6;
                player.statDefense += 6;
                player.endurance += 0.1f;
            }
            player.GetCritChance(DamageClass.Generic) += p;
            player.GetCritChance(DamageClass.Ranged) += p;
            player.GetCritChance(DamageClass.Magic) += p;
            player.GetCritChance(DamageClass.Throwing) += p;

            if (player.statLife > player.statLifeMax2 / 2)
            {
                (player.GetModPlayer<AlchemistNPCRebornPlayer>()).Symbiote = true;
                player.AddBuff(Mod.Find<ModBuff>("SymbOff").Type, 2, true);
                SS = true;
            }
            if (player.statLife < player.statLifeMax2 / 2)
            {
                player.AddBuff(Mod.Find<ModBuff>("SymbDef").Type, 2, true);
                SS = false;
                if (!Main.hardMode)
                {
                    player.lifeRegen += 3;
                    player.statDefense += 8;
                    player.endurance += 0.05f;
                    r += 3;
                    d += 8;
                    e += 5;
                }
                if (Main.hardMode && !NPC.downedMoonlord)
                {
                    player.lifeRegen += 6;
                    player.statDefense += 11;
                    player.endurance += 0.08f;
                    r += 6;
                    d += 11;
                    e += 8;
                }
                if (NPC.downedMoonlord)
                {
                    player.lifeRegen += 9;
                    player.statDefense += 14;
                    player.endurance += 0.1f;
                    r += 9;
                    d += 14;
                    e += 10;
                }
            }
            player.longInvince = true;

            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, p);
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (!Item.social && show)
            {
                string text1 = "+" + p + "% damage";
                string text2 = "+" + p + "% critical strike chance";
                string text3 = "+" + r + " life regeneration";
                string text4 = "+" + d + " defense";
                string text5 = "+" + e + "% damage reduction";
                string text6 = "+" + s + "% attack speed";
                TooltipLine line = new TooltipLine(Mod, "text1", text1);
                TooltipLine line2 = new TooltipLine(Mod, "text2", text2);
                TooltipLine line3 = new TooltipLine(Mod, "text3", text3);
                TooltipLine line4 = new TooltipLine(Mod, "text4", text4);
                TooltipLine line5 = new TooltipLine(Mod, "text5", text5);
                TooltipLine line6 = new TooltipLine(Mod, "text6", text6);
                line.OverrideColor = Color.LimeGreen;
                line2.OverrideColor = Color.LimeGreen;
                line3.OverrideColor = Color.LimeGreen;
                line4.OverrideColor = Color.LimeGreen;
                line5.OverrideColor = Color.LimeGreen;
                line6.OverrideColor = Color.LimeGreen;
                tooltips.Insert(8, line);
                tooltips.Insert(9, line2);
                tooltips.Insert(10, line3);
                tooltips.Insert(11, line4);
                tooltips.Insert(12, line5);
                if (SS) tooltips.Insert(13, line6);
            }
        }

    }
}
