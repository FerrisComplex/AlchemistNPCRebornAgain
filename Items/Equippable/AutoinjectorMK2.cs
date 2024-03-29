using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
    public class AutoinjectorMK2 : ModItem
    {

        public override void SetDefaults()
        {
            Item.stack = 1;
            Item.width = 26;
            Item.height = 26;
            Item.value = 1000000;
            Item.rare = 11;
            Item.accessory = true;
            Item.defense = 4;
            Item.lifeRegen = 2;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            (player.GetModPlayer<AlchemistNPCRebornPlayer>()).AutoinjectorMK2 = true;
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 10;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetCritChance(DamageClass.Throwing) += 10;
            player.pStone = true;
            player.longInvince = true;
            player.AddBuff(Mod.Find<ModBuff>("UniversalComb").Type, 2);
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            if (Calamity != null)
            {
                player.AddBuff(Mod.Find<ModBuff>("CalamityComb").Type, 2);
                if (Calamity != null)
                {
                    Calamity.Call("AddRogueCrit", player, 10);
                }
            }
        }

    }
}
