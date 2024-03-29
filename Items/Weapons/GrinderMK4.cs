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

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class GrinderMK4 : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.useStyle = 5;
			Item.useAnimation = 24;
			Item.useTime = 30;
			Item.shootSpeed = 3.7f;
			Item.knockBack = 6;
			Item.width = 32;
			Item.height = 32;
			Item.scale = 1f;
			Item.rare = 6;
			Item.value = Item.sellPrice(gold: 50);

			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = Mod.Find<ModProjectile>("GrinderMK4").Type;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.SoulofSight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 10);
			recipe.AddIngredient(ItemID.SoulofFright, 10);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 200;
					}
					else
					{
					Item.damage = 35;
					}
			return player.ownedProjectileCounts[Item.shoot] < 1; 
		}
	}
}
