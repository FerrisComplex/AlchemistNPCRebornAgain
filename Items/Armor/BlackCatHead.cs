using System.Collections.Generic;
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
    public class BlackCatHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            Language.GetOrRegister(Mod.GetLocalizationKey("BlackCatSetBonus"), () => "Increases current melee damage by 25% and adds 15% to melee critical strike chance"
                                                                                     + "\n+48 defense"
                                                                                     + "\nIncreases movement speed by 33%"
                                                                                     + "\nPlayer is under permanent effect of Battle Combination"
                                                                                     + "\nGrants the abilities of a Master Ninja");


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
            return body.type == Mod.Find<ModItem>("BlackCatBody").Type && legs.type == Mod.Find<ModItem>("BlackCatLegs").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            string BlackCatSetBonus = Language.GetTextValue(Mod.GetLocalizationKey("BlackCatSetBonus"));
            player.setBonus = BlackCatSetBonus;
            player.statDefense += 48;
            player.GetDamage(DamageClass.Melee) += 0.25f;
            player.GetCritChance(DamageClass.Generic) += 15;
            player.moveSpeed += 0.33f;
            player.AddBuff(Mod.Find<ModBuff>("BattleComb").Type, 2);
            player.dash = 1;
            player.blackBelt = true;
            player.spikedBoots = 2;
        }
    }
}
