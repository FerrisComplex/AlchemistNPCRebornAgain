using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class CorrosiveFlaskThrown : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 175;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 10;
			Item.value = 100000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item106;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("CorrosiveFlask").Type;
			Item.shootSpeed = 16f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ToxicFlask, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
