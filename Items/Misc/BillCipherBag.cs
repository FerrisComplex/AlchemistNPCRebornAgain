using Terraria;
using Microsoft.Xna.Framework;
using System.Linq;
using AlchemistNPCRebornAgain.Extensions;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace AlchemistNPCRebornAgain.Items.Misc
{
    public class BillCipherBag : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = 9;
            Item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(Mod.FindItem("GoldenKnuckles").Type));
            itemLoot.Add(ItemDropRule.Common(Mod.FindItem("WrathOfTheCelestial").Type));
            itemLoot.Add(ItemDropRule.Common(Mod.FindItem("LaserCannon").Type));
            itemLoot.Add(ItemDropRule.Common(Mod.FindItem("GrapplingHookGunItem").Type));
            itemLoot.Add(ItemDropRule.Common(Mod.FindItem("IlluminatiGift").Type));
            itemLoot.Add(ItemDropRule.Common(Mod.FindItem("BillSoul").Type));
            if (Main.rand.NextBool(5))
                itemLoot.Add(ItemDropRule.Common(Mod.FindItem("MysticAmulet").Type));
            itemLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 10));
        }
    }
}
