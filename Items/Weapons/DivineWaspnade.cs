﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using AlchemistNPCRebornAgain;
using Terraria.WorldBuilding;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class DivineWaspnade : ModItem
	{

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Beenade);
			Item.DamageType = DamageClass.Throwing;
			Item.damage = 25;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.value = 10000;
			Item.rare = 8;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("DivineWaspnade").Type;
			Item.shootSpeed = 8f;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(25);
			recipe.AddIngredient(null, "Waspnade", 25);
			recipe.AddIngredient(null, "DivineLava");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
