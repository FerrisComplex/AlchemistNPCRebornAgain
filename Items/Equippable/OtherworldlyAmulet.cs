using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	public class OtherworldlyAmulet : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.BlessedApple);
			Item.width = 32;
			Item.height = 30;
			Item.value = 5000000;
			Item.rare = 11;
			Item.noUseGraphic = true;
			Item.mountType = ModContent.MountType<Mounts.Poro>();
		}
	}
}
