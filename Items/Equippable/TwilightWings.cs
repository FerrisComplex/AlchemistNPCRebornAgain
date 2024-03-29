using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPCRebornAgain.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class TwilightWings : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(Mod.Find<ModBuff>("BigBirdLamp").Type, 60);
			player.wingTimeMax = 240;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.135f;
		}
		
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 16f;
			acceleration *= 3.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "BigBirdLamp");
			recipe.AddIngredient(null, "EmagledFragmentation", 50);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:AnyCelestialWings");
			recipe.AddTile(null, "WingoftheWorld");
			recipe.Register();
		}
	}
}
