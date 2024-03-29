using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCRebornAgain;

namespace AlchemistNPCRebornAgain.Items.Misc
{
	public class GlobalTeleporter : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.value = 333333;
			Item.rare = 6;
		}
		
		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<AlchemistNPCRebornPlayer>().GlobalTeleporter = true;
		}
	}
}
