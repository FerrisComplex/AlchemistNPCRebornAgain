using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class ShroomiteBullet : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 19;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 11;
			Item.shoot = Mod.Find<ModProjectile>("ShroomiteBullet").Type;
			Item.shootSpeed = 24f; 
			Item.ammo = AmmoID.Bullet; //
		}	
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(333);
			recipe.AddIngredient(ItemID.ShroomiteBar, 3);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 3);
			recipe.AddIngredient(ItemID.MoonlordBullet, 333);
			recipe.AddIngredient(null, "ChromaticCrystal", 1);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
