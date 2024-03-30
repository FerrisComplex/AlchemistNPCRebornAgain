using System.Linq;
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
    public class BloodMoonCirclet : ModItem
    {
        public override void SetStaticDefaults()
        {
            
            Language.GetOrRegister(Mod.GetLocalizationKey("BloodMoonSetBonus"), () => "Increases all damage by 25% and adds 20% to critical strike chance"
                                                                 + "\n+36 defense"
                                                                 + "\nIncreases movement speed by 25%"
                                                                 + "\nYou have a chance to dodge attacks"
                                                                 + "\nPlayer is under permanent effect of Mage Combination");
            

            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;

        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1650000;
            Item.rare = -11;
            Item.vanity = true;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.FindItem("BloodMoonDress").Type && legs.type == Mod.FindItem("BloodMoonStockings").Type;
        }

        public override void UpdateVanity(Player player)
        {
            player.hair = 83;
            player.hairColor = new Color(240, 210, 135);
        }

        public override void UpdateArmorSet(Player player)
        {
            string BloodMoonSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("BloodMoonSetBonus"));
            player.setBonus = BloodMoonSetBonus;
            player.statDefense += 36;
            player.moveSpeed += 0.25f;
            player.AddBuff(Mod.Find<ModBuff>("MageComb").Type, 2);
            player.blackBelt = true;
            player.GetDamage(DamageClass.Generic) += 0.25f;
            player.GetCritChance(DamageClass.Generic) += 20;
            player.GetCritChance(DamageClass.Magic) += 20;
            player.GetCritChance(DamageClass.Ranged) += 20;
            player.GetCritChance(DamageClass.Throwing) += 20;
            Mod Calamity = ModLoader.GetMod("CalamityMod");
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 20);
            }
        }
    }
}
