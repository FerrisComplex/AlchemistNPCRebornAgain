using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Materials
{
	public class HateVial : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.HealingPotion);
            Item.maxStack = 99;
            Item.consumable = true;
			Item.healLife = 150;
			Item.potion = true;
			Item.value = 5000000;
			Item.rare = 10;
		}
		
		public override bool? UseItem(Player player)
		{
			player.AddBuff(21, 7200);
			player.AddBuff(ModContent.BuffType<Buffs.Hate>(), 7200);
			return true;
		}
	}
}
