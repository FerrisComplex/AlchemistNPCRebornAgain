﻿using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class Skyline222Legs : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 16;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}
