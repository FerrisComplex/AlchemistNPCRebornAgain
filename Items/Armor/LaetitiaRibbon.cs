using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class LaetitiaRibbon : ModItem
    {
        public int ad = 3;

        public override void SetStaticDefaults()
        {
            Language.GetOrRegister(Mod.GetLocalizationKey("LaetitiaSetBonus"), () => "Allows to summon Little Witch Monster from the Gift"
                                                                                     + "\nMinion damage grows stronger by additional 25% in Hardmode"
                                                                                     + "\nDoubles speed of Laetitia Rifle");

            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 100000;
            Item.rare = 7;
            Item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.FindItem("LaetitiaCoat").Type && legs.type == Mod.FindItem("LaetitiaLeggings").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            string LaetitiaSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("LaetitiaSetBonus"));
            player.setBonus = LaetitiaSetBonus;
            if (Main.hardMode)
            {
                player.GetDamage(DamageClass.Summon) += 0.25f;
            }

            if (NPC.downedPlantBoss)
            {
                //player.SporeSac();
                player.sporeSac = true;
            }

            player.GetModPlayer<AlchemistNPCRebornPlayer>().LaetitiaSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.05f;
            Item.defense = ad;
            ad = 3;
            if (NPC.downedQueenBee)
            {
                ad = 4;
            }

            if (NPC.downedBoss3)
            {
                ad = 5;
            }

            if (Main.hardMode)
            {
                ad = 8;
            }

            if (NPC.downedMechBossAny)
            {
                ad = 10;
            }

            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                ad = 12;
            }

            if (NPC.downedPlantBoss)
            {
                ad = 14;
            }

            if (NPC.downedGolemBoss)
            {
                ad = 16;
            }

            if (NPC.downedFishron)
            {
                ad = 18;
            }

            if (NPC.downedAncientCultist)
            {
                ad = 19;
            }

            if (NPC.downedMoonlord)
            {
                ad = 22;
            }
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            Player player = Main.player[Main.myPlayer];
            Item.defense = ad;
            ad = 3;
            if (NPC.downedQueenBee)
            {
                ad = 4;
            }

            if (NPC.downedBoss3)
            {
                ad = 5;
            }

            if (Main.hardMode)
            {
                ad = 8;
            }

            if (NPC.downedMechBossAny)
            {
                ad = 10;
            }

            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                ad = 12;
            }

            if (NPC.downedPlantBoss)
            {
                ad = 14;
            }

            if (NPC.downedGolemBoss)
            {
                ad = 16;
            }

            if (NPC.downedFishron)
            {
                ad = 18;
            }

            if (NPC.downedAncientCultist)
            {
                ad = 19;
            }

            if (NPC.downedMoonlord)
            {
                ad = 22;
            }

            string text1 = ad + " defense";
            TooltipLine line = new TooltipLine(Mod, "text1", text1);
            line.OverrideColor = Color.White;
            tooltips.RemoveAt(2);
            tooltips.Insert(2, line);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddIngredient(ItemID.Cobweb, 30);
            recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 10);
            recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilMush", 5);
            recipe.AddTile(null, "WingoftheWorld");
            recipe.Register();
        }
    }
}
