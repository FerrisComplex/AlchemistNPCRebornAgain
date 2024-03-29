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
	[AutoloadEquip(EquipType.Body)]
	public class BlackCatBody : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}
