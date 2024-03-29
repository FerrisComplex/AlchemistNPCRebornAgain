﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class CrackedCrown : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Carrot);
			Item.width = 34;
			Item.height = 34;
			Item.value = 15000000;
			Item.shoot = Mod.Find<ModProjectile>("Snatcher").Type;
			Item.buffType = Mod.Find<ModBuff>("Snatcher").Type;
			Item.expert = true;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}
