using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Materials
{
	public class CrystalDust : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = 100;
			Item.rare = 1;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(1);
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}
