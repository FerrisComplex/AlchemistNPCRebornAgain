﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class NyctosythiaBulletInfinite : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 16;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 0, 20, 0);
			Item.rare = 10;
			Item.shoot = Mod.Find<ModProjectile>("NyctosythiaBullet").Type;
			Item.shootSpeed = 16f; 
			Item.ammo = AmmoID.Bullet; //
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "NyctosythiaBullet", 3996);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}
