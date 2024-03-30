using System.Collections.Generic;
using AlchemistNPCRebornAgain.Extensions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class ChaingunMeatGrinder : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ChainGun);
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.knockBack = 3;
			Item.width = 50;
			Item.height = 30;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.noMelee = true;
			Item.value = 1000000;
			Item.rare = -12;
			Item.autoReuse = true;
			Item.shoot = 638;
			Item.useAmmo = Mod.FindItem("MGB").Type;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).MeatGrinderOnUse = true;
			Item.useTime = 10;
			Item.useAnimation = 10;
			(player.GetModPlayer<AlchemistNPCRebornPlayer>()).MeatGrinderUsetime++;
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).MeatGrinderUsetime >= 240)
			{
				Item.useTime = 3;
				Item.useAnimation = 3;
			}
			else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).MeatGrinderUsetime >= 180)
			{
				Item.useTime = 5;
				Item.useAnimation = 5;
			}
			else if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).MeatGrinderUsetime >= 90)
			{
				Item.useTime = 8;
				Item.useAnimation = 8;
			}
		}

		public override void HoldItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).MeatGrinderOnUse == false)
			{
				(player.GetModPlayer<AlchemistNPCRebornPlayer>()).MeatGrinderUsetime = 0;
			}
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
		return Main.rand.NextFloat() >= .66;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(3));
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float speedX = perturbedSpeed.X;
			float speedY = perturbedSpeed.Y;
			Vector2 perturbedSpeed2 = velocity.RotatedByRandom(MathHelper.ToRadians(3));
			Vector2 perturbedSpeed3 = velocity.RotatedByRandom(MathHelper.ToRadians(3));
			float speedX2 = perturbedSpeed2.X;
			float speedY2 = perturbedSpeed2.Y;
			float speedX3 = perturbedSpeed3.X;
			float speedY3 = perturbedSpeed3.Y;
			Projectile.NewProjectile(source, vector.X, vector.Y+4, speedX2, speedY2, 638, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y, speedX, speedY, 638, damage, Item.knockBack, player.whoAmI);
			Projectile.NewProjectile(source, vector.X, vector.Y-4, speedX3, speedY3, 638, damage, Item.knockBack, player.whoAmI);
			return false;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChainGun);
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddRecipeGroup("AlchemistNPCRebornAgain:Tier3Bar", 20);
			recipe.AddIngredient(null, "AlchemicalBundle");
			recipe.AddIngredient(null, "EmagledFragmentation", 150);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
