using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCRebornAgain.Items.Weapons
{
	public class SpearofJustice : ModItem
	{
		public override void SetDefaults()
		{

			Item.damage = 175;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 26;
			Item.noUseGraphic = true;
			Item.maxStack = 1;
			Item.consumable = false;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = Mod.Find<ModProjectile>("SpearofJustice").Type;
			Item.shootSpeed = 32f;
			Item.useStyle = 1;
			Item.knockBack = 8;
			Item.value = 1000000;
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2 && player.statMana < 200)
			{
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.damage = 175;
				Item.shootSpeed = 32f;
				Item.shoot = Mod.Find<ModProjectile>("SpearofJustice").Type;
			}
			if (player.altFunctionUse == 2 && player.statMana > 200)
			{
				Item.useTime = 90;
				Item.useAnimation = 90;
				Item.damage = 200;
				Item.shootSpeed = 64f;
				Item.shoot = Mod.Find<ModProjectile>("SpearofJusticeG").Type;
			}
			if (player.altFunctionUse != 2)
			{
				Item.useTime = 20;
				Item.useAnimation = 20;
				Item.damage = 175;
				Item.shootSpeed = 32f;
				Item.shoot = Mod.Find<ModProjectile>("SpearofJustice").Type;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				if (player.statMana > 390)
					{
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-20, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-40, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-60, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-80, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-100, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-120, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+20, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+40, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+60, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+80, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+100, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+120, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y-15, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y-30, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y-45, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y-60, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y-75, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y-90, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y+15, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y+30, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y+45, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y+60, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y+75, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X-50, position.Y+90, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					player.statMana -= 390;
					}
				if (player.statMana > 200)
					{
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-15, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-30, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-45, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-60, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-75, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y-90, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+15, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+30, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+45, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+60, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+75, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					Projectile.NewProjectile(((Entity) player).GetSource_FromThis((string) null),position.X, position.Y+90, velocity.X, velocity.Y, Mod.Find<ModProjectile>("SpearofJusticeG").Type, damage, Item.knockBack, player.whoAmI);
					player.statMana -= 200;
					}
			}
			return true;
		}
        

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(null, "SoulEssence", 7);
			recipe.AddIngredient(null, "HateVial");
			recipe.AddIngredient(3543);
			recipe.AddIngredient(null, "EmagledFragmentation", 300);
			recipe.AddTile(null, "MateriaTransmutator");
			recipe.Register();
		}
	}
}
