using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class ShroomiteArrow : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 14;
			Item.height = 38;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = 11;
			Item.shoot = Mod.Find<ModProjectile>("ShroomiteArrow").Type;   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 12f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(333);
			recipe.AddIngredient(ItemID.ShroomiteBar, 3);
			recipe.AddIngredient(ItemID.MartianConduitPlating, 3);
			recipe.AddIngredient(ItemID.MoonlordArrow, 333);
			recipe.AddIngredient(null, "ChromaticCrystal", 1);
			recipe.AddIngredient(null, "NyctosythiaCrystal", 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
