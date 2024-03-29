using System;
using AlchemistNPCRebornAgain.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using AlchemistNPCRebornAgain.Tiles;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class Spore : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.useStyle = 5;
			Item.useAnimation = 20;
			Item.useTime = 25;
			Item.shootSpeed = 3.7f;
			Item.knockBack = 6;
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1f;
			Item.rare = 6;
			Item.value = Item.sellPrice(gold: 50);

			Item.DamageType = DamageClass.Magic;
			Item.mana = 4;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("Spore").Type;
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 250;
					}
					else
					{
					Item.damage = 55;
					}
			return player.ownedProjectileCounts[Item.shoot] < 1; 
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 25);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 25);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
	}
}
