using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
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
	public class Reverberation : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 8;
			Item.value = 10000;
			Item.rare = 8;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DynastyWood, 200);
			recipe.AddIngredient(ItemID.SoulofLight, 20);
			recipe.AddIngredient(ItemID.SoulofNight, 20);
			recipe.AddIngredient(ItemID.HallowedRepeater);
			recipe.AddTile<Tiles.WingoftheWorld>();
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).RevSet == true || ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true))
				{
					if (player.statMana >= 30)
					{
					int numberProjectiles = 2 + Main.rand.Next(3);
					for (int i = 0; i < numberProjectiles; i++)
						{
						Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
						Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CrystalLeafShot, damage/2, Item.knockBack, player.whoAmI);
						player.statMana -= 4;
						}
					}
				}
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).RevSet == false)
				{
					if (Main.rand.Next(2) == 0 && player.statMana >= 30)
						{
						Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y, velocity.X, velocity.Y, ProjectileID.CrystalLeafShot, damage, Item.knockBack, player.whoAmI);
						player.statMana -= 15;
						}
				}
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if ((player.GetModPlayer<AlchemistNPCRebornPlayer>()).ParadiseLost == true)
					{
					Item.damage = 120;
					Item.useTime = 10;
					Item.useAnimation = 10;
					}
					else
					{
					Item.damage = 40;
					Item.useTime = 15;
					Item.useAnimation = 15;
					}
			return base.CanUseItem(player);
		}
	}
}
