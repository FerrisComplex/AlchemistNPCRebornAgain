using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPCRebornAgain.Items
{
    public class SapphireBlueberrySoda : ModItem
    {
		public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SuperManaPotion);
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = 0;
            Item.rare = 6;
			Item.healMana = 200;
            return;
        }
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.SapphireSoda>(),900);
			return true;
		}
    }
}
