using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Placeable
{
	public class WingoftheWorld : ModItem
	{

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 60;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 100000;
			Item.createTile = Mod.Find<ModTile>("WingoftheWorld").Type;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 25);
			recipe.AddIngredient(ItemID.Book, 1);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:EvilComponent", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
