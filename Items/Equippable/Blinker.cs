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
	public class Blinker : ModItem
	{
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 10;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).Blinker = true;
			player.blackBelt = true;
            player.spikedBoots = 2;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MasterNinjaGear);
			recipe.AddIngredient(ItemID.RodofDiscord);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 100);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
