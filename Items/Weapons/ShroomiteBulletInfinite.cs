using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class ShroomiteBulletInfinite : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = 11;
			Item.shoot = Mod.Find<ModProjectile>("ShroomiteBullet").Type;
			Item.shootSpeed = 24f; 
			Item.ammo = AmmoID.Bullet; //
		}	
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "ShroomiteBullet", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
