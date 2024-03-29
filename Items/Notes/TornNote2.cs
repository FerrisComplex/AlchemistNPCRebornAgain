using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Notes
{
	public class TornNote2 : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 36;
			Item.maxStack = 99;
			Item.value = 150000;
			Item.rare = 5;
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TornNote2Piece>(),35);
            recipe.AddIngredient(ItemID.ShadowScale, 15);
            recipe.AddTile(TileID.Loom);
            recipe.Register();

			Recipe recipe_alt = CreateRecipe();
            recipe_alt.AddIngredient(ModContent.ItemType<TornNote2Piece>(),35);
            recipe_alt.AddIngredient(ItemID.TissueSample, 15);
            recipe_alt.AddTile(TileID.Loom);
            recipe_alt.Register();  
        }	
	}
}
