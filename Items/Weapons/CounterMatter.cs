using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class CounterMatter : ModItem
	{
		
		public override void SetDefaults()
		{
			Item.mana = 100;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.buffType = Mod.Find<ModBuff>("ProjCounter").Type;
			Item.scale = 0.5f;
		}
		
		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 2, true);
			}
		}
	}
}
